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

		if (hProcess == IntPtr.Zero) return string.Empty;

		StringBuilder sb = new(1024);
		uint bufferSize = (uint)sb.Capacity;
		return !Native.QueryFullProcessImageName(hProcess, 0, sb, ref bufferSize) ? string.Empty : sb.ToString();
	}

	public static bool InjectDlls(IntPtr processHandle, List<string> dllPaths)
	{
		if (dllPaths.Count == 0) return true;

		Native.RtlAdjustPrivilege(20, true, false, out bool _);

		IntPtr kernel32 = Native.LoadLibrary("kernel32.dll");
		IntPtr loadLibrary = Native.GetProcAddress(kernel32, "LoadLibraryW");

		IntPtr remoteVa = Native.VirtualAllocEx(processHandle, IntPtr.Zero, 0x1000, AllocationType.COMMIT | AllocationType.RESERVE, MemoryProtection.READWRITE);
		if (remoteVa == IntPtr.Zero) return false;

		foreach (string dllPath in dllPaths)
		{
			IntPtr nativeString = Marshal.StringToHGlobalUni(dllPath);
			byte[] bytes = Encoding.Unicode.GetBytes(dllPath);
			Marshal.FreeHGlobal(nativeString);

			if (!Native.WriteProcessMemory(processHandle, remoteVa, bytes, bytes.Length, out int bytesWritten)) return false;

			IntPtr thread = Native.CreateRemoteThread(processHandle, IntPtr.Zero, 0, loadLibrary, remoteVa, 0, out uint threadId);
			if (thread == IntPtr.Zero) return false;

			Native.WaitForSingleObject(thread, uint.MaxValue);
			Native.CloseHandle(thread);
			Native.WriteProcessMemory(processHandle, remoteVa, new byte[bytes.Length], bytes.Length, out _);
		}

		Native.VirtualFreeEx(processHandle, remoteVa, 0, FreeType.RELEASE);

		return true;
	}

	public static unsafe IntPtr PatternScan(IntPtr module, string signature)
	{
		string[] tokens = signature.Split(' ');
		byte[] patternBytes = tokens
			.ToList()
			.Select(x => x == "?" ? (byte)0xFF : Convert.ToByte(x, 16))
			.ToArray();

		IMAGE_DOS_HEADER dosHeader = Marshal.PtrToStructure<IMAGE_DOS_HEADER>(module);
		IMAGE_NT_HEADERS ntHeader = Marshal.PtrToStructure<IMAGE_NT_HEADERS>((IntPtr)(module.ToInt64() + dosHeader.e_lfanew));

		uint sizeOfImage = ntHeader.OptionalHeader.SizeOfImage;
		byte* scanBytes = (byte*)module;

		int s = patternBytes.Length;
		for (uint i = 0U; i < sizeOfImage - s; i++)
		{
			bool found = true;
			for (int j = 0; j < s; j++)
				if (patternBytes[j] != scanBytes[i + j] && patternBytes[j] != 0xFF)
				{
					found = false;
					break;
				}

			if (found)
				return (IntPtr)(module.ToInt64() + i);
		}

		return IntPtr.Zero;
	}

	public static IntPtr GetModuleBase(IntPtr hProcess, string moduleName)
	{
		IntPtr[] modules = new IntPtr[1024];

		if (!Native.EnumProcessModules(hProcess, modules, (uint)(modules.Length * IntPtr.Size), out uint bytesNeeded))
			if (Marshal.GetLastWin32Error() != 299)
				return IntPtr.Zero;

		foreach (IntPtr module in modules.Where(x => x != IntPtr.Zero))
		{
			StringBuilder sb = new(1024);
			if (Native.GetModuleBaseName(hProcess, module, sb, (uint)sb.Capacity) == 0)
				continue;

			if (sb.ToString() != moduleName)
				continue;

			if (!Native.GetModuleInformation(hProcess, module, out MODULEINFO moduleInfo, (uint)Marshal.SizeOf<MODULEINFO>()))
				continue;

			return moduleInfo.lpBaseOfDll;
		}

		return IntPtr.Zero;
	}
}
