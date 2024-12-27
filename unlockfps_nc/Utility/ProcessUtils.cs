using System.Runtime.InteropServices;
using System.Text;

namespace unlockfps_nc.Utility;

internal static class ProcessUtils
{
	public static string GetProcessPathFromPid(uint pid, out IntPtr processHandle)
	{
		IntPtr hProcess = Native.OpenProcess(
			ProcessAccess.QUERY_LIMITED_INFORMATION |
			ProcessAccess.TERMINATE |
			StandardAccess.SYNCHRONIZE, false, pid);

		processHandle = hProcess;

		if (hProcess == IntPtr.Zero)
			return string.Empty;

		StringBuilder sb = new(1024);
		uint bufferSize = (uint)sb.Capacity;
		return !Native.QueryFullProcessImageName(hProcess, 0, sb, ref bufferSize) ? string.Empty : sb.ToString();
	}

	public static IntPtr GetWindowFromProcessId(int processId)
	{
		IntPtr windowHandle = IntPtr.Zero;

		Native.EnumWindows((hWnd, lParam) =>
		{
			Native.GetWindowThreadProcessId(hWnd, out uint pid);
			if (pid != processId) return true;
			windowHandle = hWnd;
			return false;
		}, IntPtr.Zero);

		return windowHandle;
	}

	public static unsafe IntPtr PatternScan(IntPtr module, string signature)
	{
		(byte[] patternBytes, bool[] maskBytes) = ParseSignature(signature);

		uint sizeOfImage = Native.GetModuleImageSize(module);
		byte* scanBytes = (byte*)module;

		if (Native.IsWine())
			/*
			 *  Fixes a problem with LoadLibraryEx not working properly on Wine.
			 *  When the flag 'LOAD_LIBRARY_AS_IMAGE_RESOURCE' is used, it is supposed to map the entire file as READONLY.
			 *  But Wine maps each section with the respective protection, and if there is a section with no read permission, it will trigger Access Violation.
			 */
			Native.VirtualProtect(module, sizeOfImage, MemoryProtection.EXECUTE_READWRITE, out _);

		ReadOnlySpan<byte> span = new(scanBytes, (int)sizeOfImage);
		long offset = PatternScan(span, patternBytes, maskBytes);

		if (offset != -1)
			return (IntPtr)(module.ToInt64() + offset);

		return IntPtr.Zero;
	}

	public static unsafe List<IntPtr> PatternScanAllOccurrences(IntPtr module, string signature)
	{
		(byte[] patternBytes, bool[] maskBytes) = ParseSignature(signature);

		uint sizeOfImage = Native.GetModuleImageSize(module);
		byte* scanBytes = (byte*)module;

		if (Native.IsWine())
			Native.VirtualProtect(module, sizeOfImage, MemoryProtection.EXECUTE_READWRITE, out _);

		ReadOnlySpan<byte> span = new(scanBytes, (int)sizeOfImage);
		List<IntPtr> offsets = [];

		long totalProcessed = 0L;
		while (true)
		{
			long offset = PatternScan(span, patternBytes, maskBytes);
			if (offset == -1)
				break;

			offsets.Add((IntPtr)(module.ToInt64() + offset + totalProcessed));

			long processedOffset = offset + patternBytes.Length;
			totalProcessed += processedOffset;

			span = span[(int)processedOffset..];
		}

		return offsets;
	}

	private static long PatternScan(ReadOnlySpan<byte> data, byte[] patternBytes, bool[] maskBytes)
	{
		int s = patternBytes.Length;

		for (int i = 0; i < data.Length - s; i++)
		{
			bool found = true;
			for (int j = 0; j < s; j++)
				if (patternBytes[j] != data[i + j] && !maskBytes[j])
				{
					found = false;
					break;
				}

			if (found)
				return i;
		}

		return -1;
	}

	private static (byte[], bool[]) ParseSignature(string signature)
	{
		string[] tokens = signature.Split(' ');
		byte[] patternBytes = tokens
			.Select(x => x == "?" ? (byte)0xFF : Convert.ToByte(x, 16))
			.ToArray();
		bool[] maskBytes = tokens
			.Select(x => x == "?")
			.ToArray();

		return (patternBytes, maskBytes);
	}

	public static IntPtr GetModuleBase(IntPtr hProcess, string moduleName)
	{
		string moduleNameLower = moduleName.ToLowerInvariant();
		IntPtr[] modules = new IntPtr[1024];

		if (!Native.EnumProcessModulesEx(hProcess, modules, (uint)(modules.Length * IntPtr.Size), out uint _, 2))
		{
			int errorCode = Marshal.GetLastWin32Error();
			if (errorCode != 299)
			{
				MessageBox.Show($@"EnumProcessModulesEx failed ({errorCode}){Environment.NewLine}{Marshal.GetLastPInvokeErrorMessage()}", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return IntPtr.Zero;
			}
		}

		foreach (IntPtr module in modules.Where(x => x != IntPtr.Zero))
		{
			StringBuilder sb = new(1024);
			if (Native.GetModuleBaseName(hProcess, module, sb, (uint)sb.Capacity) == 0)
				continue;

			if (sb.ToString().ToLowerInvariant() != moduleNameLower)
				continue;

			if (!Native.GetModuleInformation(hProcess, module, out MODULEINFO moduleInfo, (uint)Marshal.SizeOf<MODULEINFO>()))
				continue;

			return moduleInfo.lpBaseOfDll;
		}

		return IntPtr.Zero;
	}
}
