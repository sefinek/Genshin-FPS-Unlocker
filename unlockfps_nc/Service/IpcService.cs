using System.IO.MemoryMappedFiles;
using System.Reflection;
using System.Runtime.InteropServices;
using unlockfps_nc.Properties;
using unlockfps_nc.Utility;

namespace unlockfps_nc.Service;

public enum IpcStatus
{
	None = 0,
	Error,
	Ready
}

[StructLayout(LayoutKind.Sequential, Pack = 8)]
public struct IpcData
{
	public IpcStatus Status;
	public int FrameRate;
	public bool PowerSave;
}

public class IpcService(ConfigService configService) : IDisposable
{
	private MemoryMappedFile? _sharedMemory;
	private MemoryMappedViewAccessor? _sharedMemoryAccessor;
	private ModuleGuard _stubModule = IntPtr.Zero;
	private string _stubPath = string.Empty;
	private IntPtr _wndHook = IntPtr.Zero;

	public void Dispose()
	{
		_sharedMemoryAccessor?.Dispose();
		_sharedMemory?.Dispose();
		_stubModule.Dispose();
	}

	public bool Start(int processId)
	{
		Program.Logger.Info($"Starting IPC service for process ID: {processId}");
		
		_sharedMemory ??= MemoryMappedFile.CreateOrOpen(@"Global\2DE95FDC-6AB7-4593-BFE6-760DD4AB422B", 4096, MemoryMappedFileAccess.ReadWrite);
		_sharedMemoryAccessor ??= _sharedMemory.CreateViewAccessor();
		if (_sharedMemoryAccessor == null)
		{
			Program.Logger.Error("Failed to create shared memory accessor");
			MessageBox.Show(@"Failed to create shared memory.", Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
			return false;
		}

		Update();

		_sharedMemoryAccessor.Read(0, out IpcData ipcData);
		switch (ipcData.Status)
		{
			case IpcStatus.Ready:
				Program.Logger.Info("IPC service already running and ready");
				return true;
			case IpcStatus.Error:
				Program.Logger.Error("IPC service reported error status");
				return false;
		}

		_stubPath = GetUnlockerStubPath();
		Program.Logger.Info($"Loading stub module from: {_stubPath}");
		_stubModule = Native.LoadLibrary(_stubPath);
		if (_stubModule == IntPtr.Zero)
		{
			var error = Marshal.GetLastWin32Error();
			var errorMessage = $@"Failed to load stub module: {error}{Environment.NewLine}{Marshal.GetLastPInvokeErrorMessage()}";
			Program.Logger.Error($"LoadLibrary failed with error code {error}: {Marshal.GetLastPInvokeErrorMessage()}");
			MessageBox.Show(errorMessage, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
			return false;
		}

		var stubWndProc = Native.GetProcAddress(_stubModule, "WndProc");
		var targetWindow = ProcessUtils.GetWindowFromProcessId(processId);
		var threadId = Native.GetWindowThreadProcessId(targetWindow, out _);

		_wndHook = Native.SetWindowsHookEx(3, stubWndProc, _stubModule, threadId);
		if (_wndHook == IntPtr.Zero)
		{
			var error = Marshal.GetLastWin32Error();
			var errorMessage = $@"Failed to set window hook: {error}{Environment.NewLine}{Marshal.GetLastPInvokeErrorMessage()}";
			Program.Logger.Error($"SetWindowsHookEx failed with error code {error}: {Marshal.GetLastPInvokeErrorMessage()}");
			MessageBox.Show(errorMessage, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
			return false;
		}

		if (!Native.PostThreadMessage(threadId, 0, IntPtr.Zero, IntPtr.Zero))
		{
			var error = Marshal.GetLastWin32Error();
			var errorMessage = $@"Failed to post thread message: {error}{Environment.NewLine}{Marshal.GetLastPInvokeErrorMessage()}";
			Program.Logger.Error($"PostThreadMessage failed with error code {error}: {Marshal.GetLastPInvokeErrorMessage()}");
			MessageBox.Show(errorMessage, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
			return false;
		}

		var retryCount = 0;
		while (true)
		{
			_sharedMemoryAccessor.Read(0, out ipcData);

			if (ipcData.Status == IpcStatus.Ready)
			{
				Program.Logger.Info("IPC service initialization completed successfully");
				break;
			}

			if (ipcData.Status == IpcStatus.Error)
			{
				Program.Logger.Error("IPC service initialization failed with error status");
				return false;
			}

			if (retryCount >= 10)
			{
				Program.Logger.Error($"IPC initialization timeout after {retryCount} retries");
				MessageBox.Show(@"Failed to start the unlocker.", Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}

			retryCount++;
			Task.Delay(1000).Wait();
		}

		return true;
	}

	public void OnGameExit()
	{
		Program.Logger.Info("Game exit detected, cleaning up IPC service");
		var ipcData = new IpcData
		{
			Status = IpcStatus.None
		};

		_sharedMemoryAccessor?.Write(0, ref ipcData);
	}

	public void Update()
	{
		var ipcData = new IpcData
		{
			FrameRate = configService.Config.FPSTarget,
			PowerSave = configService.Config.UsePowerSave
		};

		_sharedMemoryAccessor?.Write(0, ref ipcData);
	}

	private static string GetUnlockerStubPath()
	{
		var assembly = Assembly.GetExecutingAssembly();
		using Stream stream = assembly.GetManifestResourceStream("unlockfps_nc.Resources.UnlockerStub.dll")!;

		var filePath = Path.Combine(AppContext.BaseDirectory, "UnlockerStub.dll");

		try
		{
			using var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write);
			stream.CopyTo(fileStream);
		}
		catch (Exception)
		{
			// . . .
		}

		return filePath;
	}
}
