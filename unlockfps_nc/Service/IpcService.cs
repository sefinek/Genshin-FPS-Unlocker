using System.IO.MemoryMappedFiles;
using System.Reflection;
using System.Runtime.InteropServices;
using unlockfps_nc.Utility;

namespace unlockfps_nc.Service;

public enum IpcStatus
{
	Error = -1,
	None = 0,
	HostAwaiting = 1,
	ClientReady = 2,
	ClientExit = 3,
	HostExit = 4
}

[StructLayout(LayoutKind.Sequential, Pack = 8)]
public struct IpcData
{
	public ulong Address;
	public int Value;
	public IpcStatus Status;
}

public class IpcService : IDisposable
{
	private IntPtr _pFpsValue = IntPtr.Zero;
	private MemoryMappedFile? _sharedMemory;
	private MemoryMappedViewAccessor? _sharedMemoryAccessor;
	private bool _started;
	private ModuleGuard _stubModule = IntPtr.Zero;
	private string _stubPath = string.Empty;
	private IntPtr _wndHook = IntPtr.Zero;

	public void Dispose()
	{
		Stop();
		_sharedMemoryAccessor?.Dispose();
		_sharedMemory?.Dispose();
		_stubModule.Dispose();
	}

	public void Start(int processId, IntPtr pFpsValue)
	{
		if (_started) return;

		_pFpsValue = pFpsValue;
		_sharedMemory = MemoryMappedFile.CreateOrOpen("2DE95FDC-6AB7-4593-BFE6-760DD4AB422B", 4096, MemoryMappedFileAccess.ReadWrite);
		_sharedMemoryAccessor = _sharedMemory.CreateViewAccessor();

		WriteToSharedMemory(_pFpsValue, 60, IpcStatus.HostAwaiting);

		_stubPath = GetUnlockerStubPath();
		_stubModule = Native.LoadLibrary(_stubPath);
		if (_stubModule == IntPtr.Zero)
		{
			var errorMessage = $"Failed to load stub module: {Marshal.GetLastWin32Error()}{Environment.NewLine}{Marshal.GetLastPInvokeErrorMessage()}";
			MessageBox.Show(errorMessage, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			return;
		}

		var stubWndProc = Native.GetProcAddress(_stubModule, "WndProc");
		var targetWindow = ProcessUtils.GetWindowFromProcessId(processId);
		var threadId = Native.GetWindowThreadProcessId(targetWindow, out _);

		_wndHook = Native.SetWindowsHookEx(3, stubWndProc, _stubModule, threadId);
		if (_wndHook == IntPtr.Zero)
		{
			var errorMessage = $"Failed to set window hook: {Marshal.GetLastWin32Error()}{Environment.NewLine}{Marshal.GetLastPInvokeErrorMessage()}";
			MessageBox.Show(errorMessage, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			return;
		}

		if (!Native.PostThreadMessage(threadId, 0, IntPtr.Zero, IntPtr.Zero))
		{
			var errorMessage = $"Failed to post thread message: {Marshal.GetLastWin32Error()}{Environment.NewLine}{Marshal.GetLastPInvokeErrorMessage()}";
			MessageBox.Show(errorMessage, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			return;
		}

		var retryCount = 0;
		while (true)
		{
			_sharedMemoryAccessor.Read(0, out IpcData ipcData);

			if (ipcData.Status == IpcStatus.ClientReady) break;

			if (retryCount >= 10)
			{
				MessageBox.Show("Failed to start the unlocker.", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			retryCount++;
			Task.Delay(1000).Wait();
		}

		_started = true;
	}

	public void ApplyFpsLimit(int fps)
	{
		if (_pFpsValue == IntPtr.Zero) return;
		WriteToSharedMemory(_pFpsValue, fps, IpcStatus.None);
	}

	public void Stop()
	{
		_started = false;
		_pFpsValue = IntPtr.Zero;

		WriteToSharedMemory(IntPtr.Zero, 0, IpcStatus.HostExit);
		Task.Delay(200).Wait();
		Native.UnhookWindowsHookEx(_wndHook);
		Native.FreeLibrary(_stubModule);
	}

	private void WriteToSharedMemory(IntPtr address, int fps, IpcStatus status)
	{
		IpcData ipcData = new()
		{
			Address = (ulong)address,
			Value = fps,
			Status = status
		};

		_sharedMemoryAccessor?.Write(0, ref ipcData);
	}

	private static string GetUnlockerStubPath()
	{
		var assembly = Assembly.GetExecutingAssembly();
		using Stream? stream = assembly.GetManifestResourceStream("unlockfps_nc.Resources.UnlockerStub.dll");

		var filePath = Path.Combine(AppContext.BaseDirectory, "UnlockerStub.dll");
		using FileStream fileStream = new(filePath, FileMode.Create, FileAccess.Write);
		stream?.CopyTo(fileStream);

		return filePath;
	}
}
