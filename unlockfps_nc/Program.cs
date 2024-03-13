using System.Runtime.InteropServices;
using Microsoft.Extensions.DependencyInjection;
using unlockfps_nc.Properties;
using unlockfps_nc.Service;
using unlockfps_nc.Utility;

namespace unlockfps_nc;

internal static class Program
{
	public static readonly string RegistryPath = @"Software\Stella Mod Launcher";
	public static IServiceProvider? ServiceProvider { get; private set; }

	[STAThread]
	private static void Main()
	{
		Native.CreateMutex(IntPtr.Zero, true, @"GenshinFPSUnlocker");
		if (Marshal.GetLastWin32Error() == 183)
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

		ServiceProvider = services.BuildServiceProvider();

		ApplicationConfiguration.Initialize();
		Application.Run(ServiceProvider.GetRequiredService<MainForm>());
	}
}
