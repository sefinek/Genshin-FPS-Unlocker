using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace unlockfps_nc.Utility;

public static class MonitorUtils
{
	[DllImport("user32.dll")]
	private static extern bool EnumDisplayDevices(string? lpDevice, uint iDevNum, ref DisplayDevice lpDisplayDevice, uint dwFlags);

	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	private struct DisplayDevice
	{
		[MarshalAs(UnmanagedType.U4)]
		public int cb;
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
		public string DeviceName;
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
		public string DeviceString;
		[MarshalAs(UnmanagedType.U4)]
		public uint StateFlags;
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
		public string DeviceID;
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
		public string DeviceKey;
	}

	public static (string Name, int Width, int Height, int RefreshRate, bool IsPrimary) GetMonitorInfo(int monitorIndex)
	{
		var device = new DisplayDevice { cb = Marshal.SizeOf<DisplayDevice>() };
		
		if (EnumDisplayDevices(null, (uint)monitorIndex, ref device, 0))
		{
			var monitorDevice = new DisplayDevice { cb = Marshal.SizeOf<DisplayDevice>() };
			
			if (EnumDisplayDevices(device.DeviceName, 0, ref monitorDevice, 0))
			{
				var realName = GetMonitorNameFromRegistry(monitorDevice.DeviceID);
				var name = !string.IsNullOrEmpty(realName) && !realName.Contains("Generic") 
					? realName 
					: monitorDevice.DeviceString;
				
				DevMode devMode = GetDeviceMode(device.DeviceName);
				var width = devMode.dmPelsWidth;
				var height = devMode.dmPelsHeight;
				var refreshRate = devMode.dmDisplayFrequency;
				var isPrimary = (device.StateFlags & 4) != 0;
				
				return (name, width, height, refreshRate, isPrimary);
			}
		}
		
		return ($"Monitor {monitorIndex + 1}", 0, 0, 60, false);
	}

	public static string GetMonitorFriendlyName(int monitorIndex)
	{
		return GetMonitorInfo(monitorIndex).Name;
	}

	[DllImport("user32.dll")]
	private static extern bool EnumDisplaySettings(string? deviceName, int modeNum, ref DevMode devMode);

	[StructLayout(LayoutKind.Sequential)]
	private struct DevMode
	{
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
		public string dmDeviceName;
		public short dmSpecVersion;
		public short dmDriverVersion;
		public short dmSize;
		public short dmDriverExtra;
		public int dmFields;
		public int dmPositionX;
		public int dmPositionY;
		public int dmDisplayOrientation;
		public int dmDisplayFixedOutput;
		public short dmColor;
		public short dmDuplex;
		public short dmYResolution;
		public short dmTTOption;
		public short dmCollate;
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
		public string dmFormName;
		public short dmLogPixels;
		public int dmBitsPerPel;
		public int dmPelsWidth;
		public int dmPelsHeight;
		public int dmDisplayFlags;
		public int dmDisplayFrequency;
	}

	private static DevMode GetDeviceMode(string deviceName)
	{
		var devMode = new DevMode { dmSize = (short)Marshal.SizeOf<DevMode>() };
		return EnumDisplaySettings(deviceName, -1, ref devMode) ? devMode : default;
	}

	private static string? GetMonitorNameFromRegistry(string deviceId)
	{
		try
		{
			var parts = deviceId.Split('\\');
			if (parts.Length < 2) return null;
			
			var keyPath = $@"SYSTEM\CurrentControlSet\Enum\DISPLAY\{parts[1]}";
			
			using RegistryKey? key = Registry.LocalMachine.OpenSubKey(keyPath);
			if (key == null) return null;
			
			foreach (var subKeyName in key.GetSubKeyNames())
			{
				using RegistryKey? subKey = key.OpenSubKey(subKeyName);
				var friendlyName = subKey?.GetValue("FriendlyName")?.ToString();
				if (!string.IsNullOrEmpty(friendlyName))
				{
					var cleanName = CleanMonitorName(friendlyName);
					if (!string.IsNullOrEmpty(cleanName) && !cleanName.Contains("Generic"))
						return cleanName;
				}
			}
		}
		catch { }
		
		return null;
	}

	private static string CleanMonitorName(string rawName)
	{
		if (rawName.Contains(';'))
		{
			var parts = rawName.Split(';');
			var lastPart = parts[^1];
			if (lastPart.StartsWith('(') && lastPart.EndsWith(')'))
				return lastPart.Trim('(', ')');
		}
		
		if (rawName.StartsWith('@'))
		{
			var index = rawName.IndexOf(';');
			if (index > 0 && index < rawName.Length - 1)
				return rawName.Substring(index + 1);
		}
		
		return rawName;
	}
}