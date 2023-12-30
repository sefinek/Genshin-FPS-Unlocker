using System.Diagnostics;

namespace unlockfps_nc;

public partial class AboutForm : Form
{
    public AboutForm()
    {
        InitializeComponent();
    }

    private void LinkLabelSource_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        OpenLink("https://github.com/34736384/genshin-fps-unlock");
    }

    private void LinkLabelIssues_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        OpenLink("https://github.com/34736384/genshin-fps-unlock/issues");
    }

    private void OpenLink(string url)
    {
        ProcessStartInfo psi = new ProcessStartInfo
        {
            FileName = url,
            UseShellExecute = true
        };

        Process.Start(psi);
    }
}
