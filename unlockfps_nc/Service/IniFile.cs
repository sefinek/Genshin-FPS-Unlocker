using System.Runtime.InteropServices;
using System.Text;

namespace unlockfps_nc.Service;

public class IniFile(string path)
{
	private const int BufferSize = 256;

	[DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
	private static extern int WritePrivateProfileString(string? section, string? key, string? val, string filePath);

	[DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
	private static extern int GetPrivateProfileString(string? section, string? key, string? def, StringBuilder retVal, int size, string filePath);

	public void WriteInt(string section, string key, int value)
	{
		WriteString(section, key, value.ToString());
	}

	public int ReadInt(string section, string key, int defaultValue)
	{
		var result = ReadString(section, key, defaultValue.ToString());
		return int.TryParse(result, out var value) ? value : defaultValue;
	}

	public bool WriteString(string section, string key, string value)
	{
		return WritePrivateProfileString(section, key, value, path) != 0;
	}

	public string ReadString(string section, string key, string defaultValue = "")
	{
		StringBuilder sb = new(BufferSize);
		GetPrivateProfileString(section, key, defaultValue, sb, sb.Capacity, path);
		return sb.ToString();
	}
}
