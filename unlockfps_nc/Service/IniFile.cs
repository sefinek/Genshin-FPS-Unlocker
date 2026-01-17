using System.Runtime.InteropServices;
using System.Text;

namespace unlockfps_nc.Service;

internal class IniFile(string path)
{
	private const int BufferSize = 256;

	[DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
	private static extern int WritePrivateProfileString(string? section, string? key, string? val, string filePath);

	[DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
	private static extern int GetPrivateProfileString(string? section, string? key, string? def, StringBuilder retVal, int size, string filePath);

	internal bool WriteString(string section, string key, string value)
	{
		return WritePrivateProfileString(section, key, value, path) != 0;
	}

	internal string ReadString(string section, string key, string defaultValue = "")
	{
		StringBuilder sb = new(BufferSize);
		GetPrivateProfileString(section, key, defaultValue, sb, sb.Capacity, path);
		return sb.ToString();
	}
}
