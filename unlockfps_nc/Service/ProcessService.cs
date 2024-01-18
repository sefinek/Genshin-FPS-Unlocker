using System.Diagnostics;
using System.Runtime.InteropServices;
using unlockfps_nc.Model;
using unlockfps_nc.Utility;

namespace unlockfps_nc.Service;

public class ProcessService
{
	private static readonly uint[] PriorityClass =
	[
		0x00000100,
		0x00000080,
		0x00008000,
		0x00000020,
		0x00004000,
		0x00000040
	];

	private readonly Config? _config;
	private readonly ConfigService _configService;

	private readonly IntPtr _winEventHook;

	private CancellationTokenSource _cts = new();
	private IntPtr _gameHandle = IntPtr.Zero;
	private bool _gameInForeground = true;
	private int _gamePid;

	private IntPtr _pFpsValue = IntPtr.Zero;
	private GCHandle _pinnedCallback;
	private IntPtr _remoteUnityPlayer = IntPtr.Zero;
	private IntPtr _remoteUserAssembly = IntPtr.Zero;

	public ProcessService(ConfigService configService)
	{
		_configService = configService;
		_config = _configService.Config;

		Native.WinEventProc eventCallback = WinEventProc;
		_pinnedCallback = GCHandle.Alloc(eventCallback, GCHandleType.Normal);
		_winEventHook = Native.SetWinEventHook(
			3, // EVENT_SYSTEM_FOREGROUND
			3, // EVENT_SYSTEM_FOREGROUND
			IntPtr.Zero,
			eventCallback,
			0,
			0,
			0 // WINEVENT_OUTOFCONTEXT
		);
	}

	public bool Start()
	{
		if (IsGameRunning())
		{
			MessageBox.Show(@"An instance of the game is already running.", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			return false;
		}

		_cts = new CancellationTokenSource();
		Process.GetProcesses()
			.ToList()
			.Where(x => x.ProcessName is "GenshinImpact" or "YuanShen")
			.ToList()
			.ForEach(x => x.Kill());

		Task.Run(Worker, _cts.Token);
		return true;
	}

	public void OnFormClosing()
	{
		_cts.Cancel();
		_pinnedCallback.Free();
		Native.UnhookWinEvent(_winEventHook);
		Native.CloseHandle(_gameHandle);
	}

	private void WinEventProc(IntPtr hWinEventHook, uint eventType, IntPtr hWnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime)
	{
		if (eventType != 3) return;

		Native.GetWindowThreadProcessId(hWnd, out uint pid);
		_gameInForeground = pid == _gamePid;

		ApplyFpsLimit();

		if (_config!.UsePowerSave) return;

		uint targetPriority = _gameInForeground ? PriorityClass[_config.Priority] : 0x00000040;
		Native.SetPriorityClass(_gameHandle, targetPriority);
	}

	private bool IsGameRunning()
	{
		if (_gameHandle == IntPtr.Zero) return false;

		Native.GetExitCodeProcess(_gameHandle, out uint exitCode);
		return exitCode == 259;
	}

	private async Task Worker()
	{
		STARTUPINFO si = new();
		uint creationFlag = _config!.SuspendLoad ? 4u : 0u;
		string? gameFolder = Path.GetDirectoryName(_config.GamePath);

		if (!Native.CreateProcess(_config.GamePath, BuildCommandLine(), IntPtr.Zero, IntPtr.Zero, false, creationFlag, IntPtr.Zero, gameFolder, ref si, out PROCESS_INFORMATION pi))
		{
			MessageBox.Show($@"CreateProcess failed ({Marshal.GetLastWin32Error()}){Environment.NewLine} {Marshal.GetLastPInvokeErrorMessage()}", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			return;
		}

		if (!ProcessUtils.InjectDlls(pi.hProcess, _config.DllList))
			MessageBox.Show($@"Dll Injection failed ({Marshal.GetLastWin32Error()}){Environment.NewLine} {Marshal.GetLastPInvokeErrorMessage()}", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

		if (_config.SuspendLoad) Native.ResumeThread(pi.hThread);

		_gamePid = pi.dwProcessId;
		_gameHandle = pi.hProcess;

		Native.CloseHandle(pi.hThread);

		if (!await UpdateRemoteModules().ConfigureAwait(false))
			return;

		if (!SetupData())
			return;

		while (IsGameRunning() && !_cts.Token.IsCancellationRequested)
		{
			ApplyFpsLimit();
			await Task.Delay(1000, _cts.Token).ConfigureAwait(false);
		}

		if (!IsGameRunning() && _config.AutoClose)
			_ = Task.Run(async () =>
			{
				await Task.Delay(2000).ConfigureAwait(false);
				Application.Exit();
			});
	}

	private void ApplyFpsLimit()
	{
		int fpsTarget = _gameInForeground ? _config!.FpsTarget : _config!.UsePowerSave ? 10 : _config.FpsTarget;
		byte[] toWrite = BitConverter.GetBytes(fpsTarget);
		Native.WriteProcessMemory(_gameHandle, _pFpsValue, toWrite, 4, out _);
	}

	private string BuildCommandLine()
	{
		string commandLine = $"{_config!.GamePath} ";
		if (_config.PopupWindow) commandLine += "-popupwindow ";
		if (_config.UseCustomRes) commandLine += $"-screen-width {_config.CustomResX} -screen-height {_config.CustomResY} ";

		commandLine += $"-screen-fullscreen {(_config.Fullscreen ? 1 : 0)} ";
		if (_config.Fullscreen) commandLine += $"-window-mode {(_config.IsExclusiveFullscreen ? "exclusive" : "borderless")} ";
		if (_config.UseMobileUi) commandLine += "use_mobile_platform -is_cloud 1 -platform_type CLOUD_THIRD_PARTY_MOBILE ";

		commandLine += $"-monitor {_config.MonitorNum} ";
		return commandLine;
	}

	private unsafe bool SetupData()
	{
		string? gameDir = Path.GetDirectoryName(_config!.GamePath);
		string gameName = Path.GetFileNameWithoutExtension(_config.GamePath);
		string dataDir = Path.Combine(gameDir!, $"{gameName}_Data");

		string unityPlayerPath = Path.Combine(gameDir!, "UnityPlayer.dll");
		string userAssemblyPath = Path.Combine(dataDir, "Native", "UserAssembly.dll");

		using ModuleGuard pUnityPlayer = Native.LoadLibraryEx(unityPlayerPath, IntPtr.Zero, 32);
		using ModuleGuard pUserAssembly = Native.LoadLibraryEx(userAssemblyPath, IntPtr.Zero, 32);

		if (!pUnityPlayer || !pUserAssembly)
		{
			MessageBox.Show(@"Failed to load UnityPlayer.dll or UserAssembly.dll", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			return false;
		}

		IMAGE_DOS_HEADER dosHeader = Marshal.PtrToStructure<IMAGE_DOS_HEADER>(pUnityPlayer);
		IMAGE_NT_HEADERS ntHeader = Marshal.PtrToStructure<IMAGE_NT_HEADERS>((IntPtr)(pUnityPlayer.BaseAddress.ToInt64() + dosHeader.e_lfanew));

		if (ntHeader.FileHeader.TimeDateStamp < 0x656FFAF7U) // < 3.7
		{
			byte* address = (byte*)ProcessUtils.PatternScan(pUnityPlayer, "7F 0F 8B 05 ? ? ? ?");
			if (address == null) goto BAD_PATTERN;

			byte* rip = address + 2;
			int rel = *(int*)(rip + 2);
			byte* localVa = rip + rel + 6;
			byte* rva = localVa - pUnityPlayer.BaseAddress.ToInt64();
			_pFpsValue = (IntPtr)(pUnityPlayer.BaseAddress.ToInt64() + rva);
		}
		else
		{
			byte* rip = null;
			if (ntHeader.FileHeader.TimeDateStamp < 0x656FFAF7U) // < 4.3
			{
				byte* address = (byte*)ProcessUtils.PatternScan(pUserAssembly, "E8 ? ? ? ? 85 C0 7E 07 E8 ? ? ? ? EB 05");
				if (address == null) goto BAD_PATTERN;

				rip = address;
				rip += *(int*)(rip + 1) + 5;
				rip += *(int*)(rip + 3) + 7;
			}
			else
			{
				byte* address = (byte*)ProcessUtils.PatternScan(pUserAssembly, "B9 3C 00 00 00 FF 15");
				if (address == null) goto BAD_PATTERN;

				rip = address;
				rip += 5;
				rip += *(int*)(rip + 2) + 6;
			}

			byte* remoteVa = rip - pUserAssembly.BaseAddress.ToInt64() + _remoteUserAssembly.ToInt64();
			byte* dataPtr = null;

			while (dataPtr == null)
			{
				byte[] readResult = new byte[8];
				Native.ReadProcessMemory(_gameHandle, (IntPtr)remoteVa, readResult, readResult.Length, out _);

				ulong value = BitConverter.ToUInt64(readResult, 0);
				dataPtr = (byte*)value;
			}

			byte* localVa = dataPtr - _remoteUnityPlayer.ToInt64() + pUnityPlayer.BaseAddress.ToInt64();
			while (localVa[0] == 0xE8 || localVa[0] == 0xE9) localVa += *(int*)(localVa + 1) + 5;

			localVa += *(int*)(localVa + 2) + 6;
			byte* rva = localVa - pUnityPlayer.BaseAddress.ToInt64();
			_pFpsValue = (IntPtr)(_remoteUnityPlayer.ToInt64() + rva);
		}

		return true;

		BAD_PATTERN:
		MessageBox.Show(@"Outdated fps pattern", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		return false;
	}

	private async Task<bool> UpdateRemoteModules()
	{
		int retries = 0;

		while (true)
		{
			_remoteUnityPlayer = ProcessUtils.GetModuleBase(_gameHandle, "UnityPlayer.dll");
			_remoteUserAssembly = ProcessUtils.GetModuleBase(_gameHandle, "UserAssembly.dll");

			if (_remoteUnityPlayer != IntPtr.Zero && _remoteUserAssembly != IntPtr.Zero)
				break;

			if (retries > 10)
				break;

			await Task.Delay(2000, _cts.Token).ConfigureAwait(false);
			retries++;
		}

		if (_remoteUnityPlayer != IntPtr.Zero && _remoteUserAssembly != IntPtr.Zero) return true;

		MessageBox.Show(@"Failed to get remote module base address", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		return false;
	}
}
