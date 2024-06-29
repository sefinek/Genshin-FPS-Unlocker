using Newtonsoft.Json;
using unlockfps_nc.Model;
using unlockfps_nc.Properties;

namespace unlockfps_nc.Service;

public class ConfigService
{
	private const string CONFIG_NAME = "unlocker.config.json";

	public ConfigService()
	{
		Load();
		Sanitize();
	}

	public Config Config { get; private set; } = new();

	private void Load()
	{
		if (!File.Exists(CONFIG_NAME))
			return;

		try
		{
			string json = File.ReadAllText(CONFIG_NAME);
			Config = JsonConvert.DeserializeObject<Config>(json)!;
		}
		catch (Exception ex)
		{
			MessageBox.Show(string.Format(Resources.ConfigService_WeHaveDetectedErrorsInTheConfigFile, ex.Message), Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);

			Config = new Config();
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

	public void Save()
	{
		string json = JsonConvert.SerializeObject(Config, Formatting.Indented);
		File.WriteAllText(CONFIG_NAME, json);
	}
}
