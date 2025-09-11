using unlockfps_nc.Model;
using unlockfps_nc.Service;
using unlockfps_nc.Utility;

namespace unlockfps_nc.Forms;

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
		SetupDataBindings();
		SetupManualBindings();
		SetupMonitorCombo();
	}

	private void SetupDataBindings()
	{
		CBStartMinimized.DataBindings.Add("Checked", _config, nameof(_config.StartMinimized), true, DataSourceUpdateMode.OnPropertyChanged);
		CBAutoClose.DataBindings.Add("Checked", _config, nameof(_config.AutoClose), true, DataSourceUpdateMode.OnPropertyChanged);
		CBPowerSave.DataBindings.Add("Checked", _config, nameof(_config.UsePowerSave), true, DataSourceUpdateMode.OnPropertyChanged);
		CBHdr.DataBindings.Add("Checked", _config, nameof(_config.UseHDR), true, DataSourceUpdateMode.OnPropertyChanged);
		CBUseMobileUI.DataBindings.Add("Checked", _config, nameof(_config.UseMobileUI), true, DataSourceUpdateMode.OnPropertyChanged);

		ComboPriority.DataBindings.Add("SelectedIndex", _config, nameof(_config.Priority), true, DataSourceUpdateMode.OnPropertyChanged);
		ComboFullscreenMode.DataBindings.Add("SelectedIndex", _config, nameof(_config.IsExclusiveFullscreen), true, DataSourceUpdateMode.OnPropertyChanged);

		InputResX.DataBindings.Add("Value", _config, nameof(_config.CustomResX), true, DataSourceUpdateMode.OnPropertyChanged);
		InputResY.DataBindings.Add("Value", _config, nameof(_config.CustomResY), true, DataSourceUpdateMode.OnPropertyChanged);
	}

	private void SetupManualBindings()
	{
		CBPopup.Checked = _config.PopupWindow;
		CBFullscreen.Checked = _config.Fullscreen;
		CBCustomRes.Checked = _config.UseCustomRes;
	}

	private void UpdateControlState()
	{
		CBPopup.Enabled = !_config.Fullscreen;
		CBFullscreen.Enabled = !_config.PopupWindow;
		ComboFullscreenMode.Enabled = _config.Fullscreen && !_config.PopupWindow;

		InputResX.Enabled = _config.UseCustomRes;
		InputResY.Enabled = _config.UseCustomRes;
	}

	private void SettingsForm_Load(object sender, EventArgs e)
	{
		UpdateControlState();
	}

	private void CBCustomRes_CheckedChanged(object? sender, EventArgs e)
	{
		_config.UseCustomRes = CBCustomRes.Checked;
		UpdateControlState();
	}

	private void CBPopup_CheckedChanged(object? sender, EventArgs e)
	{
		_config.PopupWindow = CBPopup.Checked;
		if (_config.PopupWindow && _config.Fullscreen)
		{
			_config.Fullscreen = false;
			CBFullscreen.Checked = false;
		}

		UpdateControlState();
	}

	private void CBFullscreen_CheckedChanged(object? sender, EventArgs e)
	{
		_config.Fullscreen = CBFullscreen.Checked;
		if (_config.Fullscreen && _config.PopupWindow)
		{
			_config.PopupWindow = false;
			CBPopup.Checked = false;
		}

		UpdateControlState();
	}

	private void SetupMonitorCombo()
	{
		ComboMonitor.Items.Clear();
		Screen[] screens = Screen.AllScreens;

		for (var i = 0; i < screens.Length; i++)
		{
			var (name, width, height, refreshRate, isPrimary) = MonitorUtils.GetMonitorInfo(i);
			var displayName = $"{name}{(isPrimary ? " (Primary)" : "")} - {width}x{height}@{refreshRate}Hz";
			ComboMonitor.Items.Add(displayName);
		}

		ComboMonitor.SelectedIndex = Math.Min(_config.MonitorNum - 1, screens.Length - 1);
		ComboMonitor.SelectedIndexChanged += ComboMonitor_SelectedIndexChanged;
	}

	private void ComboMonitor_SelectedIndexChanged(object? sender, EventArgs e)
	{
		var monitorIndex = ComboMonitor.SelectedIndex;
		_config.MonitorNum = monitorIndex + 1;
		_configService.UpdateMonitorSettings(monitorIndex);

		InputResX.Value = _config.CustomResX;
		InputResY.Value = _config.CustomResY;
	}

	private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
	{
		_configService.Save();
	}
}
