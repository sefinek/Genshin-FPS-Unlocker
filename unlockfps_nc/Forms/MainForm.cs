using System.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Win32;
using unlockfps_nc.Model;
using unlockfps_nc.Properties;
using unlockfps_nc.Service;

namespace unlockfps_nc.Forms;

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
		Program.ServiceProvider.GetRequiredService<SettingsForm>().ShowDialog();
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

		if (_processService.StartGame())
			WindowState = FormWindowState.Minimized;
	}

	private static void ShowSetupForm()
	{
		Program.ServiceProvider.GetRequiredService<SetupForm>().ShowDialog();
	}

	private void ExitMenuItem_Click(object sender, EventArgs e)
	{
		Application.Exit();
	}

	private void MainForm_Resize(object sender, EventArgs e)
	{
		if (WindowState == FormWindowState.Minimized && _processService.IsGameRunning()) NotifyAndHide();
	}

	private void NotifyAndHide()
	{
		var showNotify = Program.Settings.ReadInt("FPSUnlocker", "ShowNotify", 1);

		NotifyIconMain.Icon = ImageResources.cat;
		NotifyIconMain.Visible = true;
		NotifyIconMain.Text = string.Format(Resources.MainForm_NotifyAndHide_GenshinFPSUnlockerCurrentLimit_, _config.FPSTarget);
		if (showNotify == 1)
		{
			NotifyIconMain.ShowBalloonTip(500);
			Program.Settings.WriteInt("FPSUnlocker", "ShowNotify", 0);
		}

		ShowInTaskbar = false;
		Hide();
	}

	private void NotifyIconMain_DoubleClick(object sender, EventArgs e)
	{
		RestoreFromTray();
	}

	public void RestoreFromTray()
	{
		if (InvokeRequired)
		{
			Invoke(RestoreFromTray);
			return;
		}

		WindowState = FormWindowState.Normal;
		ShowInTaskbar = true;
		TopMost = true;
		Show();
		Activate();
		TopMost = false;

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
		using RegistryKey? key = Registry.CurrentUser.OpenSubKey(Program.REGISTRY_PATH);
		if (key != null)
		{
			var o = key.GetValue("StellaPath");
			if (o != null)
			{
				var stellaPath = o.ToString();
				var exePath = Path.Combine(stellaPath!, "Stella Mod Launcher.exe");

				ProcessStartInfo startInfo = new()
				{
					FileName = exePath,
					WorkingDirectory = stellaPath
				};
				Process.Start(startInfo);
			}
			else
			{
				MessageBox.Show(Resources.MainForm_OpenStella_Click_TheRegistryKeyStellaPathWasNotFoundAreYouSureGenshinStellaModIsInstalled, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		else
		{
			MessageBox.Show(Resources.MainForm_OpenStella_Click_TheRegistryKeyStellaPathWasNotFoundAreYouSureGenshinStellaModIsInstalled, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
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


	private void ViewConfig_Click(object sender, EventArgs e)
	{
		var cfgPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "unlocker.config.json");
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
