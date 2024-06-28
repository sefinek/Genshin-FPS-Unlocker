using System.Runtime.InteropServices;
using Microsoft.Extensions.DependencyInjection;
using unlockfps_nc.Service;
using unlockfps_nc.Utility;

namespace unlockfps_nc;

internal static class Program
{
	private static IntPtr MutexHandle = IntPtr.Zero;
	public static readonly string RegistryPath = @"Software\Stella Mod Launcher";
	public static IServiceProvider ServiceProvider { get; private set; }

	[STAThread]
	private static void Main()
	{
		if (File.Exists("YuanShen.exe") || File.Exists("GenshinImpact.exe"))
		{
			MessageBox.Show(@"Do not place the unlocker in the game folder.", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			return;
		}

		MutexHandle = Native.CreateMutex(IntPtr.Zero, true, @"GenshinFPSUnlocker");
		if (Marshal.GetLastWin32Error() == 183)
		{
			MessageBox.Show(@"Another unlocker is already running.", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			return;
		}

		ServiceCollection services = new();
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
