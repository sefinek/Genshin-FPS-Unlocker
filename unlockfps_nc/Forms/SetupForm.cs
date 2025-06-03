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
		Task.Run(SearchGamePath, _cts.Token);
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
				StringBuilder sb = new(maxCount);

				Native.GetClassName(hWnd, sb, maxCount);
				if (sb.ToString() != "UnityWndClass") return true;

				windowHandle = hWnd;
				Native.GetWindowThreadProcessId(hWnd, out var pid);
				processPath = ProcessUtils.GetProcessPathFromPid(pid, out processHandle);
				return false;
			}, IntPtr.Zero);

			if (windowHandle == IntPtr.Zero)
				continue;

			Native.TerminateProcess(processHandle, 0);
			Native.CloseHandle(processHandle);

			if (string.IsNullOrEmpty(processPath))
			{
				MessageBox.Show(Resources.SetupForm_FailedToFindProcessPath, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			MessageBox.Show(string.Format(Resources.SetupForm_GameFound, processPath), Resources.Success, MessageBoxButtons.OK, MessageBoxIcon.Information);

			_config.GamePath = processPath;
			Invoke(Close);
		}
	}

	private void SearchGamePath()
	{
		List<RegistryKey> openedSubKeys = [];

		try
		{
			using RegistryKey? uninstallKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall");
			if (uninstallKey == null)
				return;

			List<RegistryKey?> subKeys = uninstallKey.GetSubKeyNames()
				.ToList()
				.Where(keyName => keyName is "Genshin Impact" or "原神")
				.Select(uninstallKey.OpenSubKey)
				.Where(key => key != null)
				.ToList();

			subKeys.ForEach(openedSubKeys.Add!);

			List<string> launcherIniPaths = subKeys
				.Select(key => (string)key?.GetValue("InstallPath")!)
				.Where(path => !string.IsNullOrEmpty(path) && Directory.Exists(path))
				.Select(launcherPath => $@"{launcherPath}\config.ini")
				.ToList();

			List<string> gamePaths = [];
			foreach (var configPath in launcherIniPaths)
			{
				IEnumerable<string> configLines = File.ReadLines(configPath);
				Dictionary<string, string> ini = [];
				foreach (var line in configLines)
				{
					var split = line.Split('=', StringSplitOptions.RemoveEmptyEntries);
					if (split.Length < 2)
						continue;

					ini[split[0]] = split[1];
				}

				if (!ini.TryGetValue("game_install_path", out var gamePath))
					continue;

				if (!ini.TryGetValue("game_start_name", out var gameName))
					continue;

				gamePaths.Add($@"{gamePath}\{gameName}".Replace('/', '\\'));
			}

			using RegistryKey? localMachineKeyGlobal = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\HYP_1_0_global");
			var installPath1 = localMachineKeyGlobal?.GetValue("InstallPath") as string ?? string.Empty;
			if (!string.IsNullOrEmpty(installPath1))
			{
				var game = Path.Combine(installPath1, "games", "Genshin Impact game", "GenshinImpact.exe");
				if (File.Exists(game)) gamePaths.Add(game);
			}

			using RegistryKey? localMachineKeyCn = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\HYP_1_1_cn");
			var installPath2 = localMachineKeyCn?.GetValue("InstallPath") as string ?? string.Empty;
			if (!string.IsNullOrEmpty(installPath2))
			{
				var game = Path.Combine(installPath2, "games", "Genshin Impact game", "YuanShen.exe");
				if (File.Exists(game)) gamePaths.Add(game);
			}

			Invoke(() =>
			{
				LabelResult.ForeColor = gamePaths.Count > 0 ? Color.Green : Color.Red;
				LabelResult.Text = string.Format(Resources.SetupForm_Found_InstallationOfTheGame, gamePaths.Count);
				ComboResult.Items.AddRange([..gamePaths]);
				if (gamePaths.Count > 0)
					ComboResult.SelectedIndex = 0;
			});
		}
		finally
		{
			openedSubKeys.ForEach(x => x.Close());
		}
	}

	private void BtnBrowse_Click(object sender, EventArgs e)
	{
		if (BrowseDialog.ShowDialog() != DialogResult.OK) return;

		var selectedFile = BrowseDialog.FileName;
		var fileName = Path.GetFileNameWithoutExtension(selectedFile);
		var directory = Path.GetDirectoryName(selectedFile);
		if (fileName != "GenshinImpact" && fileName != "YuanShen")
		{
			MessageBox.Show(Resources.SetupForm_PleaseSelectTheGameExe, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
			return;
		}

		var dataDir = Path.Combine(directory!, $"{fileName}_Data");
		if (!Directory.Exists(dataDir))
		{
			MessageBox.Show(Resources.SetupForm_ThatsNotTheRightPlace, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
