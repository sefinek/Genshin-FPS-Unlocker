using Microsoft.Extensions.DependencyInjection;
using NLog;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Security.Principal;
using unlockfps_nc.Forms;
using unlockfps_nc.Properties;
using unlockfps_nc.Service;

namespace unlockfps_nc;

internal static class Program
{
	// App
	private static readonly string AppName = Assembly.GetExecutingAssembly().GetName().Name!;
	private static readonly string AppVersion = Assembly.GetExecutingAssembly().GetName().Version?.ToString()!;
	private static readonly string AppFullVersion = Application.ProductVersion;

	// Files and folders
	private static readonly string AppPath = AppDomain.CurrentDomain.BaseDirectory;
	private static readonly string AppData = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Genshin Stella Mod");

	internal const string REGISTRY_PATH = @"Software\Stella Mod Launcher";
	private static readonly string[] SupportedLangs = ["en", "pl-PL", "fr-FR", "tr-TR", "ru-RU", "sv-SE", "es-ES", "pt-BR", "it-IT"];

	private static readonly string MutexName = "286B345F-A2EB-4FF3-83E9-2DD83B87694A";
	private static readonly string EventName = "B2ABB8F2-E6B2-4E31-8A11-15F969ADF755";

	// Misc
	internal static readonly IniFile Settings = new(Path.Combine(AppData, "settings.ini"));
	public static IServiceProvider ServiceProvider { get; private set; } = null!;

	// Logger
	internal static Logger Logger = null!;

	[STAThread]
	private static void Main()
	{
		// Prepare NLog
		LogManagerHelper.Initialize(Path.Combine(AppPath, "NLog.config"), AppName, AppVersion);
		Logger = LogManagerHelper.GetLogger();

		// First log
		var currentLang = Settings.ReadString("Language", "UI");
		Logger.Info(
			$"================= v{AppFullVersion} {(Debugger.IsAttached ? "(DEBUG MODE)" : "")} =================\n" +
			$"* AppVersion: {AppVersion}\n" +
			$"* AppPath: {AppPath}\n" +
			$"* AppData: {AppData}");

		// Set the correct language
		Logger.Info($"Loaded language from settings: {currentLang}");
		if (!SupportedLangs.Contains(currentLang))
		{
			var sysLang = CultureInfo.InstalledUICulture.TwoLetterISOLanguageName;
			currentLang = Array.Find(SupportedLangs, lang => lang == sysLang) ?? "en";
			Logger.Info($"System language detected: {sysLang}. Using: {currentLang}");
			Settings.WriteString("Language", "UI", currentLang);
		}
		else
		{
			Logger.Info($"Using supported language: {currentLang}");
		}

		try
		{
			CultureInfo culture = new(currentLang);
			CultureInfo.DefaultThreadCurrentCulture = CultureInfo.DefaultThreadCurrentUICulture = culture;
			Logger.Info($"Application culture set to: {culture.Name}");
		}
		catch (CultureNotFoundException)
		{
			Logger.Error($"CultureNotFoundException! Invalid language detected: {currentLang}; Falling back to English...");
			CultureInfo fallback = new("en");
			CultureInfo.DefaultThreadCurrentCulture = CultureInfo.DefaultThreadCurrentUICulture = fallback;
		}

		if (File.Exists("GenshinImpact.exe") || File.Exists("YuanShen.exe"))
		{
			MessageBox.Show(Resources.Program_Main_DoNotPlaceThisToolInTheGameFolder, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Warning);
			return;
		}

		using var mutex = new Mutex(true, MutexName, out var isFirst);
		if (!isFirst)
		{
			try
			{
				using EventWaitHandle evt = EventWaitHandle.OpenExisting(EventName);
				evt.Set();
			}
			catch (Exception ex)
			{
				Logger.Error(ex);
			}

			return;
		}

		using var showEvent = new EventWaitHandle(false, EventResetMode.AutoReset, EventName);
		_ = Task.Run(() =>
		{
			while (showEvent.WaitOne())
			{
				MainForm? form = Application.OpenForms
					.OfType<MainForm>()
					.FirstOrDefault();

				if (form is { IsHandleCreated: true }) form.RestoreFromTray();
			}
		});

		if (!IsAdministrator())
		{
			try
			{
				var processInfo = new ProcessStartInfo
				{
					FileName = Application.ExecutablePath,
					UseShellExecute = true,
					Verb = "runas"
				};
				Process.Start(processInfo);
			}
			catch
			{
				// . . .
			}

			return;
		}

		var services = new ServiceCollection();
		services.AddTransient<MainForm>();
		services.AddTransient<SettingsForm>();
		services.AddTransient<SetupForm>();
		services.AddSingleton<ConfigService>();
		services.AddSingleton<ProcessService>();
		services.AddSingleton<IpcService>();

		ServiceProvider = services.BuildServiceProvider();

		ApplicationConfiguration.Initialize();

		try
		{
			Application.Run(ServiceProvider.GetRequiredService<MainForm>());
		}
		catch (Exception ex)
		{

			MessageBox.Show(ex.ToString(), Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
			Environment.Exit(1);
		}
	}

	private static bool IsAdministrator()
	{
		using WindowsIdentity identity = WindowsIdentity.GetCurrent();
		var principal = new WindowsPrincipal(identity);
		return principal.IsInRole(WindowsBuiltInRole.Administrator);
	}
}
