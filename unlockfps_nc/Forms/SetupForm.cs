using System.Text;
using Microsoft.Win32;
using unlockfps_nc.Model;
using unlockfps_nc.Properties;
using unlockfps_nc.Service;
using unlockfps_nc.Utility;

namespace unlockfps_nc.Forms;

public partial class SetupForm : Form
{
	private readonly Config _config;
	private readonly ConfigService _configService;

	private readonly string[] _executableNames = ["GenshinImpact.exe", "YuanShen.exe"];

	private readonly string[] _registryPaths =
	[
		@"SOFTWARE\Cognosphere\HYP\1_0\hk4e_global",
		@"SOFTWARE\Cognosphere\HYP\1_1\hk4e_global",
		@"SOFTWARE\miHoYo\HYP\1_1\hk4e_cn"
	];

	private CancellationTokenSource? _cts;

	public SetupForm(ConfigService configService)
	{
		InitializeComponent();
		_configService = configService;
		_config = _configService.Config;
	}

	private void SetupForm_Load(object sender, EventArgs e)
	{
		_cts = new CancellationTokenSource();
		Task.Run(PollProcess, _cts.Token);

		LabelResult.Text = Resources.SetupForm_Searching;
		LabelResult.ForeColor = Color.Orange;
		SearchGamePath();
	}

	private void SetupForm_FormClosing(object sender, FormClosingEventArgs e)
	{
		_cts?.Cancel();
		_configService.Save();
	}

	private async Task PollProcess()
	{
		// System.Diagnostics.Process will throw access denied
		// use native win32 api instead

		while (!_cts!.Token.IsCancellationRequested)
		{
			await Task.Delay(1000);
			var windowHandle = IntPtr.Zero;
			var processHandle = IntPtr.Zero;
			var processPath = string.Empty;

			Native.EnumWindows((hWnd, _) =>
			{
				const int maxCount = 256;
				var sb = new StringBuilder(maxCount);

				Native.GetClassName(hWnd, sb, maxCount);
				if (sb.ToString() != "UnityWndClass") return true;

				Native.GetWindowThreadProcessId(hWnd, out var pid);
				processHandle = Native.OpenProcess(
					ProcessAccess.QUERY_LIMITED_INFORMATION |
					ProcessAccess.TERMINATE |
					StandardAccess.SYNCHRONIZE, false, pid);

				var foundPath = ProcessUtils.GetProcessPath(processHandle);
				if (!foundPath.Contains("YuanShen.exe") && !foundPath.Contains("GenshinImpact.exe")) return true;

				windowHandle = hWnd;
				processPath = foundPath;
				return false;
			}, IntPtr.Zero);

			if (windowHandle == IntPtr.Zero)
				continue;

			Native.TerminateProcess(processHandle, 0);
			Native.CloseHandle(processHandle);

			if (string.IsNullOrEmpty(processPath))
			{
				MessageBox.Show(Resources.SetupForm_PollProcess_FailedToFindProcessPathPleaseUseBrowseInstead, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			MessageBox.Show(string.Format(Resources.SetupForm_PollProcess_GameFound_, processPath), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

			_config.GamePath = processPath;
			Invoke(Close);
		}
	}

	private void SearchGamePath()
	{
		try
		{
			List<string> gamePaths = GetGamePathsFromRegistry();
			UpdateGamePathUi(gamePaths);
		}
		catch (Exception ex)
		{
			LabelResult.ForeColor = Color.Red;
			LabelResult.Text = string.Format(Resources.SetupForm_SearchGamePath_SomethingWentWrong_ExMessage, ex.Message);
		}
	}

	private List<string> GetGamePathsFromRegistry()
	{
		var paths = new HashSet<string>();
		foreach (var regPath in _registryPaths)
		{
			using RegistryKey? key = Registry.CurrentUser.OpenSubKey(regPath);
			if (key?.GetValue("GameInstallPath") is not string installPath) continue;

			foreach (var exeName in _executableNames)
			{
				var fullPath = Path.Combine(installPath, exeName).Replace('/', '\\');
				if (File.Exists(fullPath)) paths.Add(fullPath);
			}
		}

		return paths.ToList();
	}

	private void UpdateGamePathUi(IReadOnlyCollection<string> gamePaths)
	{
		var hasGames = gamePaths.Count > 0;

		LabelResult.ForeColor = hasGames ? Color.Green : Color.Orange;
		LabelResult.Text = hasGames
			? string.Format(Resources.SetupForm_UpdateGamePathUi_Found0InstallationOfTheGame, gamePaths.Count)
			: Resources.SetupForm_UpdateGamePathUi_NoGameInstallationsFound;

		ComboResult.Items.Clear();

		if (!hasGames) return;
		ComboResult.Items.AddRange(gamePaths.ToArray<object>());
		ComboResult.SelectedIndex = 0;
	}

	private void BtnBrowse_Click(object sender, EventArgs e)
	{
		if (BrowseDialog.ShowDialog() != DialogResult.OK) return;

		var selectedFile = BrowseDialog.FileName;
		var fileName = Path.GetFileNameWithoutExtension(selectedFile);
		var directory = Path.GetDirectoryName(selectedFile);
		if (fileName != "GenshinImpact" && fileName != "YuanShen")
		{
			MessageBox.Show(Resources.SetupForm_BtnBrowse_Click_PleaseSelectTheGameExe_GenshinImpactExeOrYuanShenExe, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
			return;
		}

		var dataDir = Path.Combine(directory!, $"{fileName}_Data");
		if (!Directory.Exists(dataDir))
		{
			MessageBox.Show(Resources.SetupForm_BtnBrowse_Click_ThatSNotTheRightPlace, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
			return;
		}

		_config.GamePath = selectedFile;
		Close();
	}

	private void BtnConfirm_Click(object sender, EventArgs e)
	{
		var selectedPath = (string)ComboResult.SelectedItem!;
		if (string.IsNullOrEmpty(selectedPath)) return;

		_config.GamePath = selectedPath;
		Close();
	}
}
