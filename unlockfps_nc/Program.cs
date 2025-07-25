using System.Globalization;
using Microsoft.Extensions.DependencyInjection;
using unlockfps_nc.Forms;
using unlockfps_nc.Properties;
using unlockfps_nc.Service;

namespace unlockfps_nc;

internal static class Program
{
	internal const string RegistryPath = @"Software\Stella Mod Launcher";
	private static readonly string[] SupportedLangs = ["en", "pl", "fr", "tr", "ru", "sv", "es", "pt-BR", "it"];

	// Files and folders
	private static readonly string AppData = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Genshin Stella Mod");
	internal static readonly IniFile Settings = new(Path.Combine(AppData, "settings.ini"));
	internal static IServiceProvider ServiceProvider { get; private set; } = null!;

	[STAThread]
	private static void Main()
	{
		// Set the correct language
		var currentLang = Settings.ReadString("Language", "UI");
		if (!SupportedLangs.Contains(currentLang))
		{
			var sysLang = CultureInfo.InstalledUICulture.TwoLetterISOLanguageName;
			currentLang = Array.Find(SupportedLangs, lang => lang == sysLang) ?? "en";
			Settings.WriteString("Language", "UI", currentLang);
		}

		try
		{
			CultureInfo culture = new(currentLang);
			CultureInfo.DefaultThreadCurrentCulture = CultureInfo.DefaultThreadCurrentUICulture = culture;
		}
		catch (CultureNotFoundException)
		{
			CultureInfo fallback = new("en");
			CultureInfo.DefaultThreadCurrentCulture = CultureInfo.DefaultThreadCurrentUICulture = fallback;
		}


		if (File.Exists("GenshinImpact.exe") || File.Exists("YuanShen.exe"))
		{
			MessageBox.Show(Resources.Program_DoNotPlaceThisToolInTheGameFolder, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Warning);
			return;
		}

		using Mutex mutex = new(true, "StellaFPSUnlocker", out var createdNew);
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
