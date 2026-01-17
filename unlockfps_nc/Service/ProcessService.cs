using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using unlockfps_nc.Model;
using unlockfps_nc.Properties;
using unlockfps_nc.Utility;

namespace unlockfps_nc.Service;

public class ProcessService
{
	private readonly Config _config;
	private readonly CancellationTokenSource _cts = new();

	private readonly IpcService _ipcService;
	private IntPtr _gameHandle = IntPtr.Zero;

	public ProcessService(ConfigService configService, IpcService ipcService)
	{
		_config = configService.Config;
		_ipcService = ipcService;

		_ = Task.Run(UnlockerPoll, _cts.Token);
	}

	public bool StartGame()
	{
		Program.Logger.Info($"Starting game from path: {_config.GamePath}");

		if (!File.Exists(_config.GamePath))
		{
			Program.Logger.Error($"Game executable not found at path: {_config.GamePath}");
			MessageBox.Show("Game path is invalid.", Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
			return false;
		}

		if (IsGameRunning())
		{
			Program.Logger.Warn("Attempted to start game while another instance is already running");
			MessageBox.Show("An instance of the game is already running.", Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
			return false;
		}

		if (_gameHandle != IntPtr.Zero)
		{
			Native.CloseHandle(_gameHandle);
			_gameHandle = IntPtr.Zero;
		}

		if (_config.UseHDR)
		{
			var subKeyName = Path.GetFileName(_config.GamePath) == "YuanShen.exe" ? "原神" : "Genshin Impact";
			Program.Logger.Info($"Enabling HDR mode for {subKeyName}");
			try
			{
				using RegistryKey key = Registry.CurrentUser.CreateSubKey($@"Software\miHoYo\{subKeyName}");
				key.SetValue("WINDOWS_HDR_ON_h3132281285", 1);
				Program.Logger.Info("HDR registry setting applied successfully");
			}
			catch (Exception e)
			{
				Program.Logger.Error(e, "Failed to enable HDR registry setting");
				MessageBox.Show($@"Failed to enable HDR: {e.Message}", Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		STARTUPINFO si = new();
		var creationFlag = _config.SuspendLoad ? 4u : 0u;
		var gameFolder = Path.GetDirectoryName(_config.GamePath);

		var commandLine = BuildCommandLine();
		Program.Logger.Info($"Launching game with command line: {commandLine}");

		if (!Native.CreateProcess(_config.GamePath, commandLine, IntPtr.Zero, IntPtr.Zero, false, creationFlag, IntPtr.Zero, gameFolder, ref si, out PROCESS_INFORMATION pi))
		{
			var error = Marshal.GetLastWin32Error();
			Program.Logger.Error($"CreateProcess failed with error code {error}: {Marshal.GetLastPInvokeErrorMessage()}");
			MessageBox.Show($@"CreateProcess failed ({error}){Environment.NewLine} {Marshal.GetLastPInvokeErrorMessage()}", Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
			return false;
		}

		if (_config.SuspendLoad)
		{
			Program.Logger.Info("Resuming suspended game thread");
			Native.ResumeThread(pi.hThread);
		}

		_gameHandle = pi.hProcess;
		Program.Logger.Info($"Game process started successfully with PID: {pi.dwProcessId}");

		Native.CloseHandle(pi.hThread);
		return true;
	}

	public void OnFormClosing()
	{
		Program.Logger.Info("ProcessService shutting down");
		_cts.Cancel();
		Native.CloseHandle(_gameHandle);
	}

	internal bool IsGameRunning()
	{
		if (_gameHandle == IntPtr.Zero)
			return false;

		if (!Native.GetExitCodeProcess(_gameHandle, out var exitCode))
			return false;

		return exitCode == 259; // STILL_ACTIVE
	}

	private async Task UnlockerPoll()
	{
		while (!_cts.IsCancellationRequested)
		{
			await Task.Delay(1000, _cts.Token);
			using Process? process = Process.GetProcessesByName("GenshinImpact").FirstOrDefault()
				?? Process.GetProcessesByName("YuanShen").FirstOrDefault();
			if (process == null)
				continue;

			Program.Logger.Info($"Game process detected: {process.ProcessName} (PID: {process.Id})");

			while (!ProcessUtils.IsWindowDrawing(process.MainWindowHandle) && !_cts.IsCancellationRequested)
				await Task.Delay(1000, _cts.Token);

			if (!_ipcService.Start(process.Id))
			{
				Program.Logger.Error("Failed to start IPC service, terminating unlocker poll");
				return;
			}

			Program.Logger.Info("FPS unlocker successfully attached to game process");

			while (!process.HasExited && !_cts.IsCancellationRequested)
			{
				_ipcService.Update();
				await Task.Delay(62, _cts.Token);
			}

			if (_gameHandle != IntPtr.Zero && _config.AutoClose)
			{
				Program.Logger.Info("Game exited, auto-closing application");
				Application.Exit();
			}

			_ipcService.OnGameExit();
			Program.Logger.Info("Game process terminated, waiting for restart");
			await Task.Delay(5000, _cts.Token);
		}
	}

	private string BuildCommandLine()
	{
		var commandLine = $"{_config.GamePath} ";
		if (_config.PopupWindow)
			commandLine += "-popupwindow ";

		if (_config.UseCustomRes)
			commandLine += $"-screen-width {_config.CustomResX} -screen-height {_config.CustomResY} ";

		commandLine += $"-screen-fullscreen {(_config.Fullscreen ? 1 : 0)} ";
		if (_config.Fullscreen)
			commandLine += $"-window-mode {(_config.IsExclusiveFullscreen ? "exclusive" : "borderless")} ";

		commandLine += $"-monitor {_config.MonitorNum} ";
		commandLine += $"{_config.AdditionalCommandLine} ";
		return commandLine;
	}
}
