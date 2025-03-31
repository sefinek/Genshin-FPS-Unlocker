using System.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Win32;
using unlockfps_nc.Model;
using unlockfps_nc.Properties;
using unlockfps_nc.Service;

namespace unlockfps_nc;

public partial class MainForm : Form
{
	private readonly Config _config;

	private readonly ConfigService _configService;
	private readonly ProcessService _processService;
	private Point _windowLocation;
	private Size _windowSize;

	public MainForm(ConfigService configService, ProcessService processService)
	{
		InitializeComponent();
		_configService = configService;
		_config = _configService.Config;
		_processService = processService;
		SetupBindings();
	}

	private void SettingsMenuItem_Click(object sender, EventArgs e)
	{
		SettingsForm settingsForm = Program.ServiceProvider!.GetRequiredService<SettingsForm>();
		settingsForm.ShowDialog();
	}

	private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
	{
		_configService.Save();
		_processService.OnFormClosing();
		NotifyIconMain.Visible = false;
	}

	private void MainForm_Load(object sender, EventArgs e)
	{
		_windowLocation = Location;
		_windowSize = Size;
		if (_config.AutoStart) BtnStartGame_Click(null, null);

		Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
	}

	private void SetupBindings()
	{
		InputFPS.DataBindings.Add("Value", _config, "FPSTarget", true, DataSourceUpdateMode.OnPropertyChanged);
		SliderFPS.DataBindings.Add("Value", _config, "FPSTarget", true, DataSourceUpdateMode.OnPropertyChanged);
		CBAutoStart.DataBindings.Add("Checked", _config, "AutoStart", true, DataSourceUpdateMode.OnPropertyChanged);
	}

	private void SetupMenuItem_Click(object sender, EventArgs e)
	{
		ShowSetupForm();
	}

	private void BtnStartGame_Click(object? sender, EventArgs? e)
	{
		if (!File.Exists(_config.GamePath))
			ShowSetupForm();

		if (File.Exists(_config.GamePath) && _processService.Start())
			WindowState = FormWindowState.Minimized;
	}

	private static void ShowSetupForm()
	{
		SetupForm setupForm = Program.ServiceProvider!.GetRequiredService<SetupForm>();
		setupForm.ShowDialog();
	}

	private void ExitMenuItem_Click(object sender, EventArgs e)
	{
		Application.Exit();
	}

	private void MainForm_Resize(object sender, EventArgs e)
	{
		if (WindowState == FormWindowState.Minimized) NotifyAndHide();
	}

	private void NotifyAndHide()
	{
		NotifyIconMain.Visible = true;
		NotifyIconMain.Text = string.Format(Resources.MainForm_GenshinFPSUnlocker_CurrentLimit, _config.FPSTarget);
		NotifyIconMain.ShowBalloonTip(500);

		ShowInTaskbar = false;
		Hide();
	}

	private void NotifyIconMain_DoubleClick(object sender, EventArgs e)
	{
		WindowState = FormWindowState.Normal;
		ShowInTaskbar = true;
		Show();
		Activate();

		Location = _windowLocation;
		Size = _windowSize;
	}

	private void AboutMenuItem_Click(object sender, EventArgs e)
	{
		AboutForm aboutForm = new();
		aboutForm.ShowDialog();
	}


	private void OpenStella_Click(object sender, EventArgs e)
	{
		try
		{
			using RegistryKey? key = Registry.CurrentUser.OpenSubKey(Program.RegistryPath);

			if (key != null)
			{
				object? o = key.GetValue("StellaPath");
				if (o != null)
				{
					string? stellaPath = o.ToString();
					string exePath = Path.Combine(stellaPath!, "Stella Mod Launcher.exe");

					ProcessStartInfo startInfo = new()
					{
						FileName = exePath,
						WorkingDirectory = stellaPath
					};

					Process.Start(startInfo);
				}
				else
				{
					MessageBox.Show(Resources.MainForm_KeyStellaPathNotFound, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			else
			{
				MessageBox.Show(string.Format(Resources.MainForm_RegistryKeySOFTWAREStellaModLauncherNotFound, Program.RegistryPath), Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(string.Format(Resources.MainForm_AnErrorOccurred, ex.Message), Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
	}

	private void SysInf_Click(object sender, EventArgs e)
	{
		Process.Start("msinfo32.exe");
	}

	private void DxDiag_Click(object sender, EventArgs e)
	{
		Process.Start("dxdiag.exe");
	}


	private void ViewCfg_Click(object sender, EventArgs e)
	{
		string cfgPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "unlocker.config.json");
		if (!File.Exists(cfgPath)) MessageBox.Show(Resources.MainForm_ViewCfg_TheUnlockerConfigJsonFileWasNotFound, Resources.MainForm_ViewCfg_FileNotFound, MessageBoxButtons.OK, MessageBoxIcon.Warning);

		Process.Start(new ProcessStartInfo
		{
			FileName = cfgPath,
			UseShellExecute = true
		});
	}


	private void OfficialWebsite_Click(object sender, EventArgs e)
	{
		AboutForm.OpenLink("https://sefinek.net/genshin-stella-mod?referrer=OfficialWebsite_Click");
	}

	private void YouTube_Click(object sender, EventArgs e)
	{
		AboutForm.OpenLink("https://www.youtube.com/channel/UCfPJwxVkrfcJtTDRT7peNyg?referrer=YouTube_Click");
	}

	private void GIReShade_Click(object sender, EventArgs e)
	{
		AboutForm.OpenLink("https://github.com/sefinek/Genshin-Impact-ReShade?referrer=GIReShade_Click");
	}

	private void FpsUnlocker_Click(object sender, EventArgs e)
	{
		AboutForm.OpenLink("https://github.com/sefinek/Genshin-FPS-Unlocker?referrer=FpsUnlocker_Click");
	}

	private void SefinGitHub_Click(object sender, EventArgs e)
	{
		AboutForm.OpenLink("https://github.com/sefinek?referrer=SefinGitHub_Click");
	}
}
