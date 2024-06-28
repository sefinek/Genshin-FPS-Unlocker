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
	}

	public void Start(int processId, IntPtr pFpsValue)
	{
		if (_started)
			return;

		_pFpsValue = pFpsValue;

		_sharedMemory = MemoryMappedFile.CreateOrOpen("2DE95FDC-6AB7-4593-BFE6-760DD4AB422B", 4096, MemoryMappedFileAccess.ReadWrite);
		_sharedMemoryAccessor = _sharedMemory.CreateViewAccessor();

		WriteToSharedMemory(_pFpsValue, 60, IpcStatus.HostAwaiting);

		_stubPath = GetUnlockerStubPath();
		_stubModule = Native.LoadLibrary(_stubPath);
		if (_stubModule == IntPtr.Zero)
		{
			string errorMessage = $@"Failed to load stub module: {Marshal.GetLastWin32Error()}{Environment.NewLine}{Marshal.GetLastPInvokeErrorMessage()}";
			MessageBox.Show(errorMessage, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			return;
		}

		IntPtr stubWndProc = Native.GetProcAddress(_stubModule, "WndProc");
		IntPtr targetWindow = GetWindowFromProcessId(processId);
		uint threadId = Native.GetWindowThreadProcessId(targetWindow, out uint _);

		_wndHook = Native.SetWindowsHookEx(3, stubWndProc, _stubModule, threadId);
		if (_wndHook == IntPtr.Zero)
		{
			string errorMessage = $@"Failed to set window hook: {Marshal.GetLastWin32Error()}{Environment.NewLine}{Marshal.GetLastPInvokeErrorMessage()}";
			MessageBox.Show(errorMessage, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			return;
		}

		if (!Native.PostThreadMessage(threadId, 0, IntPtr.Zero, IntPtr.Zero))
		{
			string errorMessage = $@"Failed to post thread message: {Marshal.GetLastWin32Error()}{Environment.NewLine}{Marshal.GetLastPInvokeErrorMessage()}";
			MessageBox.Show(errorMessage, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			return;
		}

		int retryCount = 0;
		while (true)
		{
			IpcData ipcData = new();
			_sharedMemoryAccessor.Read(0, out ipcData);

			if (ipcData.Status == IpcStatus.ClientReady)
				break;

			if (retryCount >= 10)
			{
				MessageBox.Show(@"Failed to start the unlocker.", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			retryCount++;
			Task.Delay(1000).Wait();
		}

		_started = true;
	}

	public void ApplyFpsLimit(int fps)
	{
		if (_pFpsValue == IntPtr.Zero)
			return;

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

	private string GetUnlockerStubPath()
	{
		Assembly assembly = Assembly.GetExecutingAssembly();
		using Stream? stream = assembly.GetManifestResourceStream("unlockfps_nc.Resources.UnlockerStub.dll");

		string processPath = Path.GetDirectoryName(assembly.Location) ?? "";
		string filePath = Path.Combine(processPath, "UnlockerStub.dll");
		using FileStream fileStream = new(filePath, FileMode.Create, FileAccess.Write);
		stream.CopyTo(fileStream);

		return filePath;
	}

	private IntPtr GetWindowFromProcessId(int processId)
	{
		IntPtr windowHandle = IntPtr.Zero;

		Native.EnumWindows((hWnd, lParam) =>
		{
			Native.GetWindowThreadProcessId(hWnd, out uint pid);
			if (pid == processId)
			{
				windowHandle = hWnd;
				return false;
			}

			return true;
		}, IntPtr.Zero);

		return windowHandle;
	}
}
