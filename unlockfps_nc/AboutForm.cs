using System.Diagnostics;

namespace unlockfps_nc;

public partial class AboutForm : Form
{
	public AboutForm()
	{
		InitializeComponent();
	}

	private void AboutForm_Load(object sender, EventArgs e)
	{
		LabelTitle.Text = string.Format(LabelTitle.Text, Application.ProductVersion);
	}

	private void GitHub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		OpenLink("https://github.com/sefinek/Genshin-FPS-Unlocker");
	}

	private void OfficialWebsite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		OpenLink("https://sefinek.net/genshin-stella-mod?referrer=unlockfps_nc-about");
	}

	public static void OpenLink(string url)
	{
		ProcessStartInfo psi = new()
		{
			FileName = url,
			UseShellExecute = true
		};

		Process.Start(psi);
	}
}
