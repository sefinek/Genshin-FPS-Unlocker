using System.Text;
using System.Text.Json;
using unlockfps_nc.Model;
using unlockfps_nc.Utility;

namespace unlockfps_nc.Service;

public class ConfigService
{
	private const string ConfigName = "unlocker.config.json";
	private readonly Lock _lock = new();

	public ConfigService()
	{
		var configPath = GetFullPath();
		var isFirstRun = !File.Exists(configPath);
		
		if (isFirstRun)
			Program.Logger.Info($"First run detected, creating new config at: {configPath}");
		else
			Program.Logger.Info($"Loading existing config from: {configPath}");
		
		Load();
		Sanitize();
		if (isFirstRun) InitializePrimaryMonitor();
	}

	public Config Config { get; private set; } = new();

	private void Load()
	{
		var configPath = GetFullPath();
		if (!File.Exists(configPath)) return;

		try
		{
			var json = File.ReadAllText(configPath);
			var config = JsonSerializer.Deserialize<Config>(json);
			if (config != null) 
			{
				Config = config;
				Program.Logger.Info("Configuration loaded successfully");
			}
		}
		catch (Exception e)
		{
			Program.Logger.Error(e, "Failed to load configuration file, using defaults");
		}
	}

	private void Sanitize()
	{
		Config.FPSTarget = Math.Clamp(Config.FPSTarget, 1, 420);
		Config.Priority = Math.Clamp(Config.Priority, 0, 5);
		Config.CustomResX = Math.Clamp(Config.CustomResX, 200, 7680);
		Config.CustomResY = Math.Clamp(Config.CustomResY, 200, 4320);
		Config.MonitorNum = Math.Clamp(Config.MonitorNum, 1, 100);
	}

	private void InitializePrimaryMonitor()
	{
		var primaryMonitorIndex = FindPrimaryMonitorIndex();

		if (primaryMonitorIndex != -1)
		{
			Config.MonitorNum = primaryMonitorIndex + 1;
			UpdateMonitorSettings(primaryMonitorIndex);
			Program.Logger.Info($"Initialized primary monitor settings: {Config.CustomResX}x{Config.CustomResY} @{Config.FPSTarget}Hz");
		}
		else
		{
			Program.Logger.Warn("Could not detect primary monitor, using default settings");
		}
	}

	private int FindPrimaryMonitorIndex()
	{
		for (var i = 0; i < 10; i++)
			try
			{
				var (_, _, _, _, isPrimary) = MonitorUtils.GetMonitorInfo(i);
				if (isPrimary) return i;
			}
			catch
			{
				break;
			}

		return -1;
	}

	public void UpdateMonitorSettings(int monitorIndex)
	{
		var (_, width, height, refreshRate, _) = MonitorUtils.GetMonitorInfo(monitorIndex);
		Config.FPSTarget = refreshRate > 0 ? refreshRate : 60;
		Config.CustomResX = width > 0 ? width : 1920;
		Config.CustomResY = height > 0 ? height : 1080;
	}

	private static string GetFullPath()
	{
		var currentPath = AppContext.BaseDirectory;
		return Path.Combine(currentPath, ConfigName);
	}

	public void Save()
	{
		lock (_lock)
		{
			try
			{
				var configPath = GetFullPath();
				var json = JsonSerializer.Serialize(Config, new JsonSerializerOptions { WriteIndented = true });

                bool wasHidden = false;
                if (File.Exists(configPath)) {
                    var attributes = File.GetAttributes(configPath);
                    if ((attributes & FileAttributes.Hidden) != 0) {
                        wasHidden = true;
                        File.SetAttributes(configPath, attributes & ~FileAttributes.Hidden);
                    }
                }

                try {
                    using var fs = new FileStream(configPath, FileMode.Create, FileAccess.Write, FileShare.None, 4096, FileOptions.WriteThrough);
                    using var sw = new StreamWriter(fs, Encoding.UTF8);
                    sw.Write(json);
                }
                finally {
                    if (wasHidden && File.Exists(configPath)) {
                        var attributes = File.GetAttributes(configPath);
                        File.SetAttributes(configPath, attributes | FileAttributes.Hidden);
                    }
                }
				
				Program.Logger.Info("Configuration saved successfully");
			}
			catch (Exception e)
			{
				Program.Logger.Error(e, "Failed to save configuration file");
			}
		}
	}
}
