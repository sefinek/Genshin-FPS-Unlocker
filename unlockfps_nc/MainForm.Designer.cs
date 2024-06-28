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
				toolStripMenuItem1 = new ToolStripMenuItem();
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
				OptionsMenuStrip.Items.AddRange(new ToolStripItem[] { openToolStripMenuItem, configToolStripMenuItem, linksToolStripMenuItem, optionsToolStripMenuItem, toolStripMenuItem1 });
				OptionsMenuStrip.Location = new Point(0, 0);
				OptionsMenuStrip.Name = "OptionsMenuStrip";
				OptionsMenuStrip.Size = new Size(446, 24);
				OptionsMenuStrip.TabIndex = 0;
				OptionsMenuStrip.Text = "menuStrip1";
				// 
				// openToolStripMenuItem
				// 
				openToolStripMenuItem.BackColor = Color.Transparent;
				openToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { stellaModLauncherToolStripMenuItem, checkHzOfYourMonitorToolStripMenuItem });
				openToolStripMenuItem.ForeColor = Color.DarkGray;
				openToolStripMenuItem.Name = "openToolStripMenuItem";
				openToolStripMenuItem.Size = new Size(48, 20);
				openToolStripMenuItem.Text = "Open";
				// 
				// stellaModLauncherToolStripMenuItem
				// 
				stellaModLauncherToolStripMenuItem.Name = "stellaModLauncherToolStripMenuItem";
				stellaModLauncherToolStripMenuItem.Size = new Size(211, 22);
				stellaModLauncherToolStripMenuItem.Text = "Stella Mod Launcher";
				stellaModLauncherToolStripMenuItem.Click += OpenStella_Click;
				// 
				// checkHzOfYourMonitorToolStripMenuItem
				// 
				checkHzOfYourMonitorToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { systemInformationToolStripMenuItem, dxDiaxToolStripMenuItem });
				checkHzOfYourMonitorToolStripMenuItem.Name = "checkHzOfYourMonitorToolStripMenuItem";
				checkHzOfYourMonitorToolStripMenuItem.Size = new Size(211, 22);
				checkHzOfYourMonitorToolStripMenuItem.Text = "Check Hz of your monitor";
				// 
				// systemInformationToolStripMenuItem
				// 
				systemInformationToolStripMenuItem.Name = "systemInformationToolStripMenuItem";
				systemInformationToolStripMenuItem.Size = new Size(178, 22);
				systemInformationToolStripMenuItem.Text = "System Information";
				systemInformationToolStripMenuItem.Click += SysInf_Click;
				// 
				// dxDiaxToolStripMenuItem
				// 
				dxDiaxToolStripMenuItem.Name = "dxDiaxToolStripMenuItem";
				dxDiaxToolStripMenuItem.Size = new Size(178, 22);
				dxDiaxToolStripMenuItem.Text = "DxDiag";
				dxDiaxToolStripMenuItem.Click += DxDiag_Click;
				// 
				// configToolStripMenuItem
				// 
				configToolStripMenuItem.BackColor = Color.Transparent;
				configToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { viewConfigToolStripMenuItem });
				configToolStripMenuItem.ForeColor = Color.DarkGray;
				configToolStripMenuItem.Name = "configToolStripMenuItem";
				configToolStripMenuItem.Size = new Size(55, 20);
				configToolStripMenuItem.Text = "Config";
				// 
				// viewConfigToolStripMenuItem
				// 
				viewConfigToolStripMenuItem.Name = "viewConfigToolStripMenuItem";
				viewConfigToolStripMenuItem.Size = new Size(136, 22);
				viewConfigToolStripMenuItem.Text = "View config";
				viewConfigToolStripMenuItem.Click += ViewCfg_Click;
				// 
				// linksToolStripMenuItem
				// 
				linksToolStripMenuItem.BackColor = Color.Transparent;
				linksToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { officialWebsiteToolStripMenuItem, youTubeToolStripMenuItem, gitHubToolStripMenuItem });
				linksToolStripMenuItem.ForeColor = Color.DarkGray;
				linksToolStripMenuItem.Name = "linksToolStripMenuItem";
				linksToolStripMenuItem.Size = new Size(46, 20);
				linksToolStripMenuItem.Text = "Links";
				// 
				// officialWebsiteToolStripMenuItem
				// 
				officialWebsiteToolStripMenuItem.Name = "officialWebsiteToolStripMenuItem";
				officialWebsiteToolStripMenuItem.Size = new Size(155, 22);
				officialWebsiteToolStripMenuItem.Text = "Official website";
				officialWebsiteToolStripMenuItem.Click += OfficialWebsite_Click;
				// 
				// youTubeToolStripMenuItem
				// 
				youTubeToolStripMenuItem.Name = "youTubeToolStripMenuItem";
				youTubeToolStripMenuItem.Size = new Size(155, 22);
				youTubeToolStripMenuItem.Text = "YouTube";
				youTubeToolStripMenuItem.Click += YouTube_Click;
				// 
				// gitHubToolStripMenuItem
				// 
				gitHubToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { repositoresToolStripMenuItem, sefineksProfileToolStripMenuItem });
				gitHubToolStripMenuItem.Name = "gitHubToolStripMenuItem";
				gitHubToolStripMenuItem.Size = new Size(155, 22);
				gitHubToolStripMenuItem.Text = "GitHub";
				// 
				// repositoresToolStripMenuItem
				// 
				repositoresToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { genshinImpactReShadeToolStripMenuItem, fPSUnlockerToolStripMenuItem });
				repositoresToolStripMenuItem.Name = "repositoresToolStripMenuItem";
				repositoresToolStripMenuItem.Size = new Size(157, 22);
				repositoresToolStripMenuItem.Text = "Repositories";
				// 
				// genshinImpactReShadeToolStripMenuItem
				// 
				genshinImpactReShadeToolStripMenuItem.Name = "genshinImpactReShadeToolStripMenuItem";
				genshinImpactReShadeToolStripMenuItem.Size = new Size(205, 22);
				genshinImpactReShadeToolStripMenuItem.Text = "Genshin Impact ReShade";
				genshinImpactReShadeToolStripMenuItem.Click += GIReShade_Click;
				// 
				// fPSUnlockerToolStripMenuItem
				// 
				fPSUnlockerToolStripMenuItem.Name = "fPSUnlockerToolStripMenuItem";
				fPSUnlockerToolStripMenuItem.Size = new Size(205, 22);
				fPSUnlockerToolStripMenuItem.Text = "FPS Unlocker";
				fPSUnlockerToolStripMenuItem.Click += FpsUnlocker_Click;
				// 
				// sefineksProfileToolStripMenuItem
				// 
				sefineksProfileToolStripMenuItem.Name = "sefineksProfileToolStripMenuItem";
				sefineksProfileToolStripMenuItem.Size = new Size(157, 22);
				sefineksProfileToolStripMenuItem.Text = "Sefinek's profile";
				sefineksProfileToolStripMenuItem.Click += SefinGitHub_Click;
				// 
				// optionsToolStripMenuItem
				// 
				optionsToolStripMenuItem.BackColor = Color.Transparent;
				optionsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { SettingsMenuItem, SetupMenuItem, AboutMenuItem });
				optionsToolStripMenuItem.ForeColor = Color.DarkGray;
				optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
				optionsToolStripMenuItem.Size = new Size(61, 20);
				optionsToolStripMenuItem.Text = "Options";
				// 
				// SettingsMenuItem
				// 
				SettingsMenuItem.Name = "SettingsMenuItem";
				SettingsMenuItem.Size = new Size(116, 22);
				SettingsMenuItem.Text = "Settings";
				SettingsMenuItem.Click += SettingsMenuItem_Click;
				// 
				// SetupMenuItem
				// 
				SetupMenuItem.Name = "SetupMenuItem";
				SetupMenuItem.Size = new Size(116, 22);
				SetupMenuItem.Text = "Setup";
				SetupMenuItem.Click += SetupMenuItem_Click;
				// 
				// AboutMenuItem
				// 
				AboutMenuItem.Name = "AboutMenuItem";
				AboutMenuItem.Size = new Size(116, 22);
				AboutMenuItem.Text = "About";
				AboutMenuItem.Click += AboutMenuItem_Click;
				// 
				// toolStripMenuItem1
				// 
				toolStripMenuItem1.Name = "toolStripMenuItem1";
				toolStripMenuItem1.Size = new Size(12, 20);
				// 
				// LabelFPS
				// 
				LabelFPS.Anchor = AnchorStyles.None;
				LabelFPS.AutoSize = true;
				LabelFPS.ForeColor = Color.White;
				LabelFPS.Location = new Point(138, 57);
				LabelFPS.Name = "LabelFPS";
				LabelFPS.Size = new Size(29, 15);
				LabelFPS.TabIndex = 1;
				LabelFPS.Text = "FPS:";
				// 
				// InputFPS
				// 
				InputFPS.Anchor = AnchorStyles.None;
				InputFPS.BackColor = Color.FromArgb(47, 49, 54);
				InputFPS.ForeColor = Color.White;
				InputFPS.Location = new Point(188, 53);
				InputFPS.Maximum = new decimal(new int[] { 420, 0, 0, 0 });
				InputFPS.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
				InputFPS.Name = "InputFPS";
				InputFPS.Size = new Size(240, 23);
				InputFPS.TabIndex = 2;
				InputFPS.Value = new decimal(new int[] { 144, 0, 0, 0 });
				// 
				// SliderFPS
				// 
				SliderFPS.Anchor = AnchorStyles.None;
				SliderFPS.Location = new Point(133, 84);
				SliderFPS.Maximum = 420;
				SliderFPS.Minimum = 1;
				SliderFPS.Name = "SliderFPS";
				SliderFPS.Size = new Size(302, 45);
				SliderFPS.TabIndex = 3;
				SliderFPS.TickStyle = TickStyle.None;
				SliderFPS.Value = 120;
				// 
				// CBAutoStart
				// 
				CBAutoStart.Anchor = AnchorStyles.None;
				CBAutoStart.AutoSize = true;
				CBAutoStart.ForeColor = Color.White;
				CBAutoStart.Location = new Point(141, 120);
				CBAutoStart.Name = "CBAutoStart";
				CBAutoStart.Size = new Size(158, 19);
				CBAutoStart.TabIndex = 4;
				CBAutoStart.Text = "Start game automatically";
				ToolTipMain.SetToolTip(CBAutoStart, "This will take effect on subsequent launch");
				CBAutoStart.UseVisualStyleBackColor = true;
				// 
				// BtnStartGame
				// 
				BtnStartGame.Anchor = AnchorStyles.None;
				BtnStartGame.Location = new Point(331, 117);
				BtnStartGame.Name = "BtnStartGame";
				BtnStartGame.Size = new Size(97, 23);
				BtnStartGame.TabIndex = 5;
				BtnStartGame.Text = "Start Game";
				BtnStartGame.UseVisualStyleBackColor = true;
				BtnStartGame.Click += BtnStartGame_Click;
				// 
				// NotifyIconMain
				// 
				NotifyIconMain.BalloonTipIcon = ToolTipIcon.Info;
				NotifyIconMain.BalloonTipText = "The program has been minimized to the system tray. You can change the FPS limit even during the game.";
				NotifyIconMain.BalloonTipTitle = "Genshin FPS Unlocker";
				NotifyIconMain.ContextMenuStrip = ContextNotify;
				NotifyIconMain.Icon = (Icon)resources.GetObject("NotifyIconMain.Icon");
				NotifyIconMain.Text = "FPS Unlocker";
				NotifyIconMain.Visible = true;
				NotifyIconMain.DoubleClick += NotifyIconMain_DoubleClick;
				// 
				// ContextNotify
				// 
				ContextNotify.Items.AddRange(new ToolStripItem[] { ExitMenuItem });
				ContextNotify.Name = "ContextNotify";
				ContextNotify.Size = new Size(94, 26);
				// 
				// ExitMenuItem
				// 
				ExitMenuItem.Name = "ExitMenuItem";
				ExitMenuItem.Size = new Size(93, 22);
				ExitMenuItem.Text = "Exit";
				ExitMenuItem.Click += ExitMenuItem_Click;
				// 
				// pictureBox1
				// 
				pictureBox1.Image = Resources.fps_unlocker;
				pictureBox1.Location = new Point(12, 36);
				pictureBox1.Name = "pictureBox1";
				pictureBox1.Size = new Size(113, 113);
				pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
				pictureBox1.TabIndex = 6;
				pictureBox1.TabStop = false;
				// 
				// MainForm
				// 
				AutoScaleDimensions = new SizeF(96F, 96F);
				AutoScaleMode = AutoScaleMode.Dpi;
				BackColor = Color.FromArgb(54, 57, 63);
				ClientSize = new Size(446, 161);
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
				StartPosition = FormStartPosition.CenterScreen;
				Text = "Genshin FPS Unlocker";
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
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem stellaModLauncherToolStripMenuItem;
        private ToolStripMenuItem checkHzOfYourMonitorToolStripMenuItem;
        private ToolStripMenuItem systemInformationToolStripMenuItem;
        private ToolStripMenuItem dxDiaxToolStripMenuItem;
        private ToolStripMenuItem viewConfigToolStripMenuItem;
		  private PictureBox pictureBox1;
	 }
}
