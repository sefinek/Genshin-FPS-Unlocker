using System.Runtime.InteropServices;
using System.Text;

namespace unlockfps_nc.Utility;

internal static class ProcessUtils
{
	public static string GetProcessPathFromPid(uint pid, out IntPtr processHandle)
	{
		var hProcess = Native.OpenProcess(
			ProcessAccess.QUERY_LIMITED_INFORMATION |
			ProcessAccess.TERMINATE |
			StandardAccess.SYNCHRONIZE, false, pid);

		processHandle = hProcess;

		if (hProcess == IntPtr.Zero)
			return string.Empty;

		StringBuilder sb = new(1024);
		var bufferSize = (uint)sb.Capacity;
		return !Native.QueryFullProcessImageName(hProcess, 0, sb, ref bufferSize) ? string.Empty : sb.ToString();
	}

	public static IntPtr GetWindowFromProcessId(int processId)
	{
		var windowHandle = IntPtr.Zero;

		Native.EnumWindows((hWnd, lParam) =>
		{
			Native.GetWindowThreadProcessId(hWnd, out var pid);
			if (pid != processId) return true;
			windowHandle = hWnd;
			return false;
		}, IntPtr.Zero);

		return windowHandle;
	}

	public static unsafe IntPtr PatternScan(IntPtr module, string signature)
	{
		var (patternBytes, maskBytes) = ParseSignature(signature);

		var sizeOfImage = Native.GetModuleImageSize(module);
		var scanBytes = (byte*)module;

		if (Native.IsWine())
			/*
			 *  Fixes a problem with LoadLibraryEx not working properly on Wine.
			 *  When the flag 'LOAD_LIBRARY_AS_IMAGE_RESOURCE' is used, it is supposed to map the entire file as READONLY.
			 *  But Wine maps each section with the respective protection, and if there is a section with no read permission, it will trigger Access Violation.
			 */
			Native.VirtualProtect(module, sizeOfImage, MemoryProtection.EXECUTE_READWRITE, out _);

		ReadOnlySpan<byte> span = new(scanBytes, (int)sizeOfImage);
		var offset = PatternScan(span, patternBytes, maskBytes);

		if (offset != -1)
			return (IntPtr)(module.ToInt64() + offset);

		return IntPtr.Zero;
	}

	public static unsafe List<IntPtr> PatternScanAllOccurrences(IntPtr module, string signature)
	{
		var (patternBytes, maskBytes) = ParseSignature(signature);

		var sizeOfImage = Native.GetModuleImageSize(module);
		var scanBytes = (byte*)module;

		if (Native.IsWine())
			Native.VirtualProtect(module, sizeOfImage, MemoryProtection.EXECUTE_READWRITE, out _);

		ReadOnlySpan<byte> span = new(scanBytes, (int)sizeOfImage);
		List<IntPtr> offsets = [];

		var totalProcessed = 0L;
		while (true)
		{
			var offset = PatternScan(span, patternBytes, maskBytes);
			if (offset == -1)
				break;

			offsets.Add((IntPtr)(module.ToInt64() + offset + totalProcessed));

			var processedOffset = offset + patternBytes.Length;
			totalProcessed += processedOffset;

			span = span[(int)processedOffset..];
		}

		return offsets;
	}

	private static long PatternScan(ReadOnlySpan<byte> data, byte[] patternBytes, bool[] maskBytes)
	{
		var s = patternBytes.Length;

		for (var i = 0; i < data.Length - s; i++)
		{
			var found = true;
			for (var j = 0; j < s; j++)
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
		var tokens = signature.Split(' ');
		var patternBytes = tokens
			.Select(x => x == "?" ? (byte)0xFF : Convert.ToByte(x, 16))
			.ToArray();
		var maskBytes = tokens
			.Select(x => x == "?")
			.ToArray();

		return (patternBytes, maskBytes);
	}

	public static IntPtr GetModuleBase(IntPtr hProcess, string moduleName)
	{
		var moduleNameLower = moduleName.ToLowerInvariant();
		var modules = new IntPtr[1024];

		if (!Native.EnumProcessModulesEx(hProcess, modules, (uint)(modules.Length * IntPtr.Size), out _, 2))
		{
			var errorCode = Marshal.GetLastWin32Error();
			if (errorCode != 299)
			{
				MessageBox.Show($"EnumProcessModulesEx failed ({errorCode}){Environment.NewLine}{Marshal.GetLastPInvokeErrorMessage()}", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return IntPtr.Zero;
			}
		}

		foreach (var module in modules.Where(x => x != IntPtr.Zero))
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
