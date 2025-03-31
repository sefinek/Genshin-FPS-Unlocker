using unlockfps_nc.Model;
using unlockfps_nc.Service;

namespace unlockfps_nc;

public partial class SettingsForm : Form
{
	private readonly Config _config;
	private readonly ConfigService _configService;

	public SettingsForm(ConfigService configService)
	{
		InitializeComponent();
		_configService = configService;
		_config = _configService.Config;

		SetupBindings();

#if RELEASEMIN
	TabCtrlSettings.Controls.Remove(TabDlls);
#endif
	}

	private void SetupBindings()
	{
		// General
		CBStartMinimized.DataBindings.Add("Checked", _config, "StartMinimized", true, DataSourceUpdateMode.OnPropertyChanged);
		CBAutoClose.DataBindings.Add("Checked", _config, "AutoClose", true, DataSourceUpdateMode.OnPropertyChanged);
		CBPowerSave.DataBindings.Add("Checked", _config, "UsePowerSave", true, DataSourceUpdateMode.OnPropertyChanged);
		ComboPriority.DataBindings.Add("SelectedIndex", _config, "Priority", true, DataSourceUpdateMode.OnPropertyChanged);

		// Launch Options
		CBPopup.DataBindings.Add("Checked", _config, "PopupWindow", true, DataSourceUpdateMode.OnPropertyChanged);
		CBFullscreen.DataBindings.Add("Checked", _config, "Fullscreen", true, DataSourceUpdateMode.OnPropertyChanged);
		CBCustomRes.DataBindings.Add("Checked", _config, "UseCustomRes", true, DataSourceUpdateMode.OnPropertyChanged);
		CBUseMobileUI.DataBindings.Add("Checked", _config, "UseMobileUI", true, DataSourceUpdateMode.OnPropertyChanged);
		InputResX.DataBindings.Add("Value", _config, "CustomResX", true, DataSourceUpdateMode.OnPropertyChanged);
		InputResY.DataBindings.Add("Value", _config, "CustomResY", true, DataSourceUpdateMode.OnPropertyChanged);
		ComboFullscreenMode.DataBindings.Add("SelectedIndex", _config, "IsExclusiveFullscreen", true, DataSourceUpdateMode.OnPropertyChanged);
		InputMonitorNum.DataBindings.Add("Value", _config, "MonitorNum", true, DataSourceUpdateMode.OnPropertyChanged);
	}

	private void UpdateControlState()
	{
		if (_config.PopupWindow) _config.Fullscreen = false; // They can't coexist (?) so disable the other

		CBPopup.Enabled = !_config.Fullscreen;
		CBFullscreen.Enabled = !_config.PopupWindow;
		InputResX.Enabled = _config.UseCustomRes;
		InputResY.Enabled = _config.UseCustomRes;
		ComboFullscreenMode.Enabled = _config is { Fullscreen: true, PopupWindow: false };
	}

	private void LaunchOptionsChanged(object sender, EventArgs e)
	{
		UpdateControlState();
	}

	private void SettingsForm_Load(object sender, EventArgs e)
	{
		UpdateControlState();
	}

	private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
	{
		_configService.Save();
	}
}
