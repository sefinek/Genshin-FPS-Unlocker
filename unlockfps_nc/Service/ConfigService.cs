using System.Text;
using System.Text.Json;
using unlockfps_nc.Model;

namespace unlockfps_nc.Service;

public class ConfigService
{
	private const string ConfigName = "unlocker.config.json";
	private readonly Lock _lock = new();

	public ConfigService()
	{
		Load();
		Sanitize();
	}

	public Config Config { get; private set; } = new();

	private void Load()
	{
		var configPath = GetFullPath();
		if (!File.Exists(configPath)) return;

		var json = File.ReadAllText(configPath);
		var config = JsonSerializer.Deserialize<Config>(json);
		if (config != null) Config = config;
	}

	private void Sanitize()
	{
		Config.FPSTarget = Math.Clamp(Config.FPSTarget, 1, 420);
		Config.Priority = Math.Clamp(Config.Priority, 0, 5);
		Config.CustomResX = Math.Clamp(Config.CustomResX, 200, 7680);
		Config.CustomResY = Math.Clamp(Config.CustomResY, 200, 4320);
		Config.MonitorNum = Math.Clamp(Config.MonitorNum, 1, 100);
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
			var configPath = GetFullPath();
			var json = JsonSerializer.Serialize(Config, new JsonSerializerOptions { WriteIndented = true });

			using var fs = new FileStream(configPath, FileMode.Create, FileAccess.Write, FileShare.None, 4096, FileOptions.WriteThrough);
			using var sw = new StreamWriter(fs, Encoding.UTF8);
			sw.Write(json);
		}
	}
}
