using Microsoft.Extensions.DependencyInjection;
using unlockfps_nc.Properties;
using unlockfps_nc.Service;

namespace unlockfps_nc;

internal static class Program
{
	public const string RegistryPath = @"Software\Stella Mod Launcher";
	public static IServiceProvider? ServiceProvider { get; private set; }

	[STAThread]
	private static void Main()
	{
		if (File.Exists("YuanShen.exe") || File.Exists("GenshinImpact.exe"))
		{
			MessageBox.Show(@"Do not place the unlocker in the game folder!", Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Warning);
			return;
		}

		using Mutex mutex = new(true, "StellaFPSUnlocker", out bool createdNew);
		if (!createdNew)
		{
			MessageBox.Show(Resources.Program_AnotherUnlockerIsAlreadyRunning, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Warning);
			return;
		}

		ServiceCollection services = [];
		services.AddTransient<MainForm>();
		services.AddTransient<SettingsForm>();
		services.AddTransient<SetupForm>();
		services.AddSingleton<ConfigService>();
		services.AddSingleton<ProcessService>();
		services.AddSingleton<IpcService>();

		ServiceProvider = services.BuildServiceProvider();

		ApplicationConfiguration.Initialize();
		Application.Run(ServiceProvider.GetRequiredService<MainForm>());
	}
}
