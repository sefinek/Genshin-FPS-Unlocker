using System.Text;
using Microsoft.Win32;
using unlockfps_nc.Model;
using unlockfps_nc.Service;
using unlockfps_nc.Utility;

namespace unlockfps_nc;

public partial class SetupForm : Form
{
	private readonly Config? _config;

	private readonly ConfigService _configService;
	private CancellationTokenSource _cts;

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

		LabelCurrentPath.Text = $@"Current Path: {_config.GamePath}";
		LabelResult.Text = @"Searching...";
		LabelResult.ForeColor = Color.Orange;
		Task.Run(SearchGamePath, _cts.Token);
	}

	private void SetupForm_FormClosing(object sender, FormClosingEventArgs e)
	{
		_cts.Cancel();
		_configService.Save();
	}

	private async Task PollProcess()
	{
		// System.Diagnostics.Process will throw access denied
		// use native win32 api instead

		while (!_cts.Token.IsCancellationRequested)
		{
			await Task.Delay(1000).ConfigureAwait(false);
			IntPtr windowHandle = IntPtr.Zero;
			IntPtr processHandle = IntPtr.Zero;
			string processPath = string.Empty;

			Native.EnumWindows((hWnd, lParam) =>
			{
				const int maxCount = 256;
				StringBuilder sb = new(maxCount);

				Native.GetClassName(hWnd, sb, maxCount);
				if (sb.ToString() == "UnityWndClass")
				{
					windowHandle = hWnd;
					Native.GetWindowThreadProcessId(hWnd, out uint pid);
					string foundPath = ProcessUtils.GetProcessPathFromPid(pid, out processHandle);
					if (!foundPath.Contains("YuanShen.exe") && !foundPath.Contains("GenshinImpact.exe"))
						return true;

					processPath = foundPath;
					return false;
				}

				return true;
			}, IntPtr.Zero);

			if (windowHandle == IntPtr.Zero)
				continue;

			Native.TerminateProcess(processHandle, 0);
			Native.CloseHandle(processHandle);

			if (string.IsNullOrEmpty(processPath))
			{
				MessageBox.Show("Failed to find process path\nPlease use \"Browse\" instead", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			MessageBox.Show($@"Game Found!{Environment.NewLine}{processPath}", @"Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
			foreach (string configPath in launcherIniPaths)
			{
				IEnumerable<string> configLines = File.ReadLines(configPath);
				Dictionary<string, string> ini = [];
				foreach (string line in configLines)
				{
					string[] split = line.Split('=', StringSplitOptions.RemoveEmptyEntries);
					if (split.Length < 2)
						continue;

					ini[split[0]] = split[1];
				}

				if (!ini.TryGetValue("game_install_path", out string? gamePath))
					continue;

				if (!ini.TryGetValue("game_start_name", out string? gameName))
					continue;

				gamePaths.Add($@"{gamePath}\{gameName}".Replace('/', '\\'));
			}

			using RegistryKey? localMachineKeyGlobal = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\HYP_1_0_global");
			string installPath1 = localMachineKeyGlobal?.GetValue("InstallPath") as string ?? string.Empty;
			if (!string.IsNullOrEmpty(installPath1))
			{
				string game = Path.Combine(installPath1, "games", "Genshin Impact game", "GenshinImpact.exe");
				if (File.Exists(game)) gamePaths.Add(game);
			}

			using RegistryKey? localMachineKeyCn = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\HYP_1_1_cn");
			string installPath2 = localMachineKeyCn?.GetValue("InstallPath") as string ?? string.Empty;
			if (!string.IsNullOrEmpty(installPath2))
			{
				string game = Path.Combine(installPath2, "games", "Genshin Impact game", "YuanShen.exe");
				if (File.Exists(game)) gamePaths.Add(game);
			}

			Invoke(() =>
			{
				LabelResult.ForeColor = gamePaths.Count > 0 ? Color.Green : Color.Red;
				LabelResult.Text = $@"Found {gamePaths.Count} installation of the game";
				ComboResult.Items.AddRange(gamePaths.ToArray());
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
		if (BrowseDialog.ShowDialog() != DialogResult.OK)
			return;

		string selectedFile = BrowseDialog.FileName;
		string fileName = Path.GetFileNameWithoutExtension(selectedFile);
		string? directory = Path.GetDirectoryName(selectedFile);

		if (fileName != "GenshinImpact" && fileName != "YuanShen")
		{
			MessageBox.Show(
				$@"Please select the game exe{Environment.NewLine}GenshinImpact.exe or YuanShen.exe",
				@"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			return;
		}

		string unityPlayer = Path.Combine(directory, "UnityPlayer.dll");
		if (!File.Exists(unityPlayer))
		{
			MessageBox.Show(@"That's not the right place", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			return;
		}

		_config.GamePath = selectedFile;
		Close();
	}

	private void BtnConfirm_Click(object sender, EventArgs e)
	{
		string selectedPath = (string)ComboResult.SelectedItem!;
		if (string.IsNullOrEmpty(selectedPath))
			return;

		_config.GamePath = selectedPath;
		Close();
	}
}
