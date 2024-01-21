using Newtonsoft.Json;
using unlockfps_nc.Model;

namespace unlockfps_nc.Service;

public class ConfigService
{
	private const string CONFIG_NAME = "unlocker.config.json";

	public ConfigService()
	{
		Load();
		Sanitize();
	}

	public Config? Config { get; private set; } = new();

	private void Load()
	{
		if (!File.Exists(CONFIG_NAME) || string.IsNullOrWhiteSpace(File.ReadAllText(CONFIG_NAME)))
		{
			InitializeDefaultConfig();
			return;
		}

		string json = File.ReadAllText(CONFIG_NAME);
		try
		{
			Config = JsonConvert.DeserializeObject<Config>(json) ?? InitializeDefaultConfig();
		}
		catch (Exception ex)
		{
			MessageBox.Show(
				$"We have detected errors in the FPS Unlocker's configuration file. We will attempt its repair. If the program launches normally, this will indicate that the repair was successful. If this message keeps appearing, please delete the configuration file (unlocker.config.json) or contact the developer.\n\n{ex.Message}",
				@"Fatal error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
	}

	private Config InitializeDefaultConfig()
	{
		Config = new Config();
		Save();
		return Config;
	}

	private void Sanitize()
	{
		Config!.FpsTarget = Math.Clamp(Config.FpsTarget, 1, 420);
		Config.Priority = Math.Clamp(Config.Priority, 0, 5);
		Config.CustomResX = Math.Clamp(Config.CustomResX, 200, 7680);
		Config.CustomResY = Math.Clamp(Config.CustomResY, 200, 4320);
		Config.MonitorNum = Math.Clamp(Config.MonitorNum, 1, 100);
	}

	public void Save()
	{
		string json = JsonConvert.SerializeObject(Config, Formatting.Indented);
		File.WriteAllText(CONFIG_NAME, json);
	}
}
