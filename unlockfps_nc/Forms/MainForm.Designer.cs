using unlockfps_nc.Properties;

namespace unlockfps_nc
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			OptionsMenuStrip = new MenuStrip();
			openToolStripMenuItem = new ToolStripMenuItem();
			stellaModLauncherToolStripMenuItem = new ToolStripMenuItem();
			checkHzOfYourMonitorToolStripMenuItem = new ToolStripMenuItem();
			systemInformationToolStripMenuItem = new ToolStripMenuItem();
			dxDiaxToolStripMenuItem = new ToolStripMenuItem();
			configToolStripMenuItem = new ToolStripMenuItem();
			viewConfigToolStripMenuItem = new ToolStripMenuItem();
			linksToolStripMenuItem = new ToolStripMenuItem();
			officialWebsiteToolStripMenuItem = new ToolStripMenuItem();
			youTubeToolStripMenuItem = new ToolStripMenuItem();
			gitHubToolStripMenuItem = new ToolStripMenuItem();
			repositoresToolStripMenuItem = new ToolStripMenuItem();
			genshinImpactReShadeToolStripMenuItem = new ToolStripMenuItem();
			fPSUnlockerToolStripMenuItem = new ToolStripMenuItem();
			sefineksProfileToolStripMenuItem = new ToolStripMenuItem();
			optionsToolStripMenuItem = new ToolStripMenuItem();
			SettingsMenuItem = new ToolStripMenuItem();
			SetupMenuItem = new ToolStripMenuItem();
			AboutMenuItem = new ToolStripMenuItem();
			LabelFPS = new Label();
			InputFPS = new NumericUpDown();
			SliderFPS = new TrackBar();
			CBAutoStart = new CheckBox();
			BtnStartGame = new Button();
			ToolTipMain = new ToolTip(components);
			NotifyIconMain = new NotifyIcon(components);
			ContextNotify = new ContextMenuStrip(components);
			ExitMenuItem = new ToolStripMenuItem();
			pictureBox1 = new PictureBox();
			OptionsMenuStrip.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)InputFPS).BeginInit();
			((System.ComponentModel.ISupportInitialize)SliderFPS).BeginInit();
			ContextNotify.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			SuspendLayout();
			// 
			// OptionsMenuStrip
			// 
			OptionsMenuStrip.BackColor = Color.FromArgb(32, 34, 37);
			OptionsMenuStrip.Items.AddRange(new ToolStripItem[] { openToolStripMenuItem, configToolStripMenuItem, linksToolStripMenuItem, optionsToolStripMenuItem });
			resources.ApplyResources(OptionsMenuStrip, "OptionsMenuStrip");
			OptionsMenuStrip.Name = "OptionsMenuStrip";
			// 
			// openToolStripMenuItem
			// 
			openToolStripMenuItem.BackColor = Color.Transparent;
			openToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { stellaModLauncherToolStripMenuItem, checkHzOfYourMonitorToolStripMenuItem });
			openToolStripMenuItem.ForeColor = Color.DarkGray;
			openToolStripMenuItem.Name = "openToolStripMenuItem";
			resources.ApplyResources(openToolStripMenuItem, "openToolStripMenuItem");
			// 
			// stellaModLauncherToolStripMenuItem
			// 
			stellaModLauncherToolStripMenuItem.Name = "stellaModLauncherToolStripMenuItem";
			resources.ApplyResources(stellaModLauncherToolStripMenuItem, "stellaModLauncherToolStripMenuItem");
			stellaModLauncherToolStripMenuItem.Click += OpenStella_Click;
			// 
			// checkHzOfYourMonitorToolStripMenuItem
			// 
			checkHzOfYourMonitorToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { systemInformationToolStripMenuItem, dxDiaxToolStripMenuItem });
			checkHzOfYourMonitorToolStripMenuItem.Name = "checkHzOfYourMonitorToolStripMenuItem";
			resources.ApplyResources(checkHzOfYourMonitorToolStripMenuItem, "checkHzOfYourMonitorToolStripMenuItem");
			// 
			// systemInformationToolStripMenuItem
			// 
			systemInformationToolStripMenuItem.Name = "systemInformationToolStripMenuItem";
			resources.ApplyResources(systemInformationToolStripMenuItem, "systemInformationToolStripMenuItem");
			systemInformationToolStripMenuItem.Click += SysInf_Click;
			// 
			// dxDiaxToolStripMenuItem
			// 
			dxDiaxToolStripMenuItem.Name = "dxDiaxToolStripMenuItem";
			resources.ApplyResources(dxDiaxToolStripMenuItem, "dxDiaxToolStripMenuItem");
			dxDiaxToolStripMenuItem.Click += DxDiag_Click;
			// 
			// configToolStripMenuItem
			// 
			configToolStripMenuItem.BackColor = Color.Transparent;
			configToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { viewConfigToolStripMenuItem });
			configToolStripMenuItem.ForeColor = Color.DarkGray;
			configToolStripMenuItem.Name = "configToolStripMenuItem";
			resources.ApplyResources(configToolStripMenuItem, "configToolStripMenuItem");
			// 
			// viewConfigToolStripMenuItem
			// 
			viewConfigToolStripMenuItem.Name = "viewConfigToolStripMenuItem";
			resources.ApplyResources(viewConfigToolStripMenuItem, "viewConfigToolStripMenuItem");
			viewConfigToolStripMenuItem.Click += ViewCfg_Click;
			// 
			// linksToolStripMenuItem
			// 
			linksToolStripMenuItem.BackColor = Color.Transparent;
			linksToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { officialWebsiteToolStripMenuItem, youTubeToolStripMenuItem, gitHubToolStripMenuItem });
			linksToolStripMenuItem.ForeColor = Color.DarkGray;
			linksToolStripMenuItem.Name = "linksToolStripMenuItem";
			resources.ApplyResources(linksToolStripMenuItem, "linksToolStripMenuItem");
			// 
			// officialWebsiteToolStripMenuItem
			// 
			officialWebsiteToolStripMenuItem.Name = "officialWebsiteToolStripMenuItem";
			resources.ApplyResources(officialWebsiteToolStripMenuItem, "officialWebsiteToolStripMenuItem");
			officialWebsiteToolStripMenuItem.Click += OfficialWebsite_Click;
			// 
			// youTubeToolStripMenuItem
			// 
			youTubeToolStripMenuItem.Name = "youTubeToolStripMenuItem";
			resources.ApplyResources(youTubeToolStripMenuItem, "youTubeToolStripMenuItem");
			youTubeToolStripMenuItem.Click += YouTube_Click;
			// 
			// gitHubToolStripMenuItem
			// 
			gitHubToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { repositoresToolStripMenuItem, sefineksProfileToolStripMenuItem });
			gitHubToolStripMenuItem.Name = "gitHubToolStripMenuItem";
			resources.ApplyResources(gitHubToolStripMenuItem, "gitHubToolStripMenuItem");
			// 
			// repositoresToolStripMenuItem
			// 
			repositoresToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { genshinImpactReShadeToolStripMenuItem, fPSUnlockerToolStripMenuItem });
			repositoresToolStripMenuItem.Name = "repositoresToolStripMenuItem";
			resources.ApplyResources(repositoresToolStripMenuItem, "repositoresToolStripMenuItem");
			// 
			// genshinImpactReShadeToolStripMenuItem
			// 
			genshinImpactReShadeToolStripMenuItem.Name = "genshinImpactReShadeToolStripMenuItem";
			resources.ApplyResources(genshinImpactReShadeToolStripMenuItem, "genshinImpactReShadeToolStripMenuItem");
			genshinImpactReShadeToolStripMenuItem.Click += GIReShade_Click;
			// 
			// fPSUnlockerToolStripMenuItem
			// 
			fPSUnlockerToolStripMenuItem.Name = "fPSUnlockerToolStripMenuItem";
			resources.ApplyResources(fPSUnlockerToolStripMenuItem, "fPSUnlockerToolStripMenuItem");
			fPSUnlockerToolStripMenuItem.Click += FpsUnlocker_Click;
			// 
			// sefineksProfileToolStripMenuItem
			// 
			sefineksProfileToolStripMenuItem.Name = "sefineksProfileToolStripMenuItem";
			resources.ApplyResources(sefineksProfileToolStripMenuItem, "sefineksProfileToolStripMenuItem");
			sefineksProfileToolStripMenuItem.Click += SefinGitHub_Click;
			// 
			// optionsToolStripMenuItem
			// 
			optionsToolStripMenuItem.BackColor = Color.Transparent;
			optionsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { SettingsMenuItem, SetupMenuItem, AboutMenuItem });
			optionsToolStripMenuItem.ForeColor = Color.DarkGray;
			optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
			resources.ApplyResources(optionsToolStripMenuItem, "optionsToolStripMenuItem");
			// 
			// SettingsMenuItem
			// 
			SettingsMenuItem.Name = "SettingsMenuItem";
			resources.ApplyResources(SettingsMenuItem, "SettingsMenuItem");
			SettingsMenuItem.Click += SettingsMenuItem_Click;
			// 
			// SetupMenuItem
			// 
			SetupMenuItem.Name = "SetupMenuItem";
			resources.ApplyResources(SetupMenuItem, "SetupMenuItem");
			SetupMenuItem.Click += SetupMenuItem_Click;
			// 
			// AboutMenuItem
			// 
			AboutMenuItem.Name = "AboutMenuItem";
			resources.ApplyResources(AboutMenuItem, "AboutMenuItem");
			AboutMenuItem.Click += AboutMenuItem_Click;
			// 
			// LabelFPS
			// 
			resources.ApplyResources(LabelFPS, "LabelFPS");
			LabelFPS.ForeColor = Color.White;
			LabelFPS.Name = "LabelFPS";
			// 
			// InputFPS
			// 
			resources.ApplyResources(InputFPS, "InputFPS");
			InputFPS.BackColor = Color.FromArgb(47, 49, 54);
			InputFPS.ForeColor = Color.White;
			InputFPS.Maximum = new decimal(new int[] { 420, 0, 0, 0 });
			InputFPS.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
			InputFPS.Name = "InputFPS";
			InputFPS.Value = new decimal(new int[] { 144, 0, 0, 0 });
			// 
			// SliderFPS
			// 
			resources.ApplyResources(SliderFPS, "SliderFPS");
			SliderFPS.Maximum = 420;
			SliderFPS.Minimum = 1;
			SliderFPS.Name = "SliderFPS";
			SliderFPS.TickStyle = TickStyle.None;
			SliderFPS.Value = 120;
			// 
			// CBAutoStart
			// 
			resources.ApplyResources(CBAutoStart, "CBAutoStart");
			CBAutoStart.ForeColor = Color.White;
			CBAutoStart.Name = "CBAutoStart";
			ToolTipMain.SetToolTip(CBAutoStart, resources.GetString("CBAutoStart.ToolTip"));
			CBAutoStart.UseVisualStyleBackColor = true;
			// 
			// BtnStartGame
			// 
			resources.ApplyResources(BtnStartGame, "BtnStartGame");
			BtnStartGame.Name = "BtnStartGame";
			BtnStartGame.UseVisualStyleBackColor = true;
			BtnStartGame.Click += BtnStartGame_Click;
			// 
			// NotifyIconMain
			// 
			NotifyIconMain.BalloonTipIcon = ToolTipIcon.Info;
			resources.ApplyResources(NotifyIconMain, "NotifyIconMain");
			NotifyIconMain.ContextMenuStrip = ContextNotify;
			NotifyIconMain.DoubleClick += NotifyIconMain_DoubleClick;
			// 
			// ContextNotify
			// 
			ContextNotify.Items.AddRange(new ToolStripItem[] { ExitMenuItem });
			ContextNotify.Name = "ContextNotify";
			resources.ApplyResources(ContextNotify, "ContextNotify");
			// 
			// ExitMenuItem
			// 
			ExitMenuItem.Name = "ExitMenuItem";
			resources.ApplyResources(ExitMenuItem, "ExitMenuItem");
			ExitMenuItem.Click += ExitMenuItem_Click;
			// 
			// pictureBox1
			// 
			resources.ApplyResources(pictureBox1, "pictureBox1");
			pictureBox1.Image = Resources.fps_unlocker;
			pictureBox1.Name = "pictureBox1";
			pictureBox1.TabStop = false;
			// 
			// MainForm
			// 
			resources.ApplyResources(this, "$this");
			AutoScaleMode = AutoScaleMode.Dpi;
			BackColor = Color.FromArgb(46, 48, 51);
			Controls.Add(pictureBox1);
			Controls.Add(BtnStartGame);
			Controls.Add(CBAutoStart);
			Controls.Add(SliderFPS);
			Controls.Add(InputFPS);
			Controls.Add(LabelFPS);
			Controls.Add(OptionsMenuStrip);
			FormBorderStyle = FormBorderStyle.FixedSingle;
			MainMenuStrip = OptionsMenuStrip;
			MaximizeBox = false;
			Name = "MainForm";
			FormClosing += MainForm_FormClosing;
			Load += MainForm_Load;
			Resize += MainForm_Resize;
			OptionsMenuStrip.ResumeLayout(false);
			OptionsMenuStrip.PerformLayout();
			((System.ComponentModel.ISupportInitialize)InputFPS).EndInit();
			((System.ComponentModel.ISupportInitialize)SliderFPS).EndInit();
			ContextNotify.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private MenuStrip OptionsMenuStrip;
        private ToolStripMenuItem optionsToolStripMenuItem;
        private ToolStripMenuItem SettingsMenuItem;
        private ToolStripMenuItem SetupMenuItem;
        private ToolStripMenuItem AboutMenuItem;
        private Label LabelFPS;
        private NumericUpDown InputFPS;
        private TrackBar SliderFPS;
        private CheckBox CBAutoStart;
        private Button BtnStartGame;
        private ToolTip ToolTipMain;
        private NotifyIcon NotifyIconMain;
        private ContextMenuStrip ContextNotify;
        private ToolStripMenuItem ExitMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem configToolStripMenuItem;
        private ToolStripMenuItem linksToolStripMenuItem;
        private ToolStripMenuItem officialWebsiteToolStripMenuItem;
        private ToolStripMenuItem youTubeToolStripMenuItem;
        private ToolStripMenuItem gitHubToolStripMenuItem;
        private ToolStripMenuItem repositoresToolStripMenuItem;
        private ToolStripMenuItem genshinImpactReShadeToolStripMenuItem;
        private ToolStripMenuItem fPSUnlockerToolStripMenuItem;
        private ToolStripMenuItem sefineksProfileToolStripMenuItem;
        private ToolStripMenuItem stellaModLauncherToolStripMenuItem;
        private ToolStripMenuItem checkHzOfYourMonitorToolStripMenuItem;
        private ToolStripMenuItem systemInformationToolStripMenuItem;
        private ToolStripMenuItem dxDiaxToolStripMenuItem;
        private ToolStripMenuItem viewConfigToolStripMenuItem;
		  private PictureBox pictureBox1;
	 }
}
