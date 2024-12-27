namespace unlockfps_nc
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
		  /// Required method for Designer support - do not modify
		  /// the contents of this method with the code editor.
		  /// </summary>
		  private void InitializeComponent()
		  {
				components = new System.ComponentModel.Container();
				LabelAutoSave = new Label();
				TabCtrlSettings = new TabControl();
				TabGeneral = new TabPage();
				ComboPriority = new ComboBox();
				LabelPriority = new Label();
				CBPowerSave = new CheckBox();
				CBAutoClose = new CheckBox();
				CBStartMinimized = new CheckBox();
				TabLaunchOptions = new TabPage();
				CBUseMobileUI = new CheckBox();
				InputMonitorNum = new NumericUpDown();
				LabelMonitor = new Label();
				ComboFullscreenMode = new ComboBox();
				LabelWindowMode = new Label();
				InputResY = new NumericUpDown();
				LabelX = new Label();
				InputResX = new NumericUpDown();
				LabelCustomRes = new Label();
				CBCustomRes = new CheckBox();
				CBFullscreen = new CheckBox();
				CBPopup = new CheckBox();
				ToolTipSettings = new ToolTip(components);
				DllAddDialog = new OpenFileDialog();
				TabCtrlSettings.SuspendLayout();
				TabGeneral.SuspendLayout();
				TabLaunchOptions.SuspendLayout();
				((System.ComponentModel.ISupportInitialize)InputMonitorNum).BeginInit();
				((System.ComponentModel.ISupportInitialize)InputResY).BeginInit();
				((System.ComponentModel.ISupportInitialize)InputResX).BeginInit();
				SuspendLayout();
				// 
				// LabelAutoSave
				// 
				LabelAutoSave.Anchor = AnchorStyles.None;
				LabelAutoSave.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
				LabelAutoSave.ForeColor = Color.MediumSpringGreen;
				LabelAutoSave.Location = new Point(12, 255);
				LabelAutoSave.Name = "LabelAutoSave";
				LabelAutoSave.Size = new Size(288, 15);
				LabelAutoSave.TabIndex = 0;
				LabelAutoSave.Text = "All settings will be saved automatically.";
				LabelAutoSave.TextAlign = ContentAlignment.MiddleCenter;
				// 
				// TabCtrlSettings
				// 
				TabCtrlSettings.Anchor = AnchorStyles.None;
				TabCtrlSettings.Controls.Add(TabGeneral);
				TabCtrlSettings.Controls.Add(TabLaunchOptions);
				TabCtrlSettings.Location = new Point(12, 12);
				TabCtrlSettings.Name = "TabCtrlSettings";
				TabCtrlSettings.SelectedIndex = 0;
				TabCtrlSettings.Size = new Size(288, 238);
				TabCtrlSettings.TabIndex = 1;
				// 
				// TabGeneral
				// 
				TabGeneral.BackColor = Color.FromArgb(54, 57, 60);
				TabGeneral.Controls.Add(ComboPriority);
				TabGeneral.Controls.Add(LabelPriority);
				TabGeneral.Controls.Add(CBPowerSave);
				TabGeneral.Controls.Add(CBAutoClose);
				TabGeneral.Controls.Add(CBStartMinimized);
				TabGeneral.Location = new Point(4, 24);
				TabGeneral.Name = "TabGeneral";
				TabGeneral.Padding = new Padding(3);
				TabGeneral.Size = new Size(280, 210);
				TabGeneral.TabIndex = 0;
				TabGeneral.Text = "General";
				// 
				// ComboPriority
				// 
				ComboPriority.Anchor = AnchorStyles.None;
				ComboPriority.ForeColor = Color.Black;
				ComboPriority.FormattingEnabled = true;
				ComboPriority.Items.AddRange(new object[] { "Realtime", "High", "Above Normal", "Normal", "Below Normal", "Low" });
				ComboPriority.Location = new Point(153, 79);
				ComboPriority.Name = "ComboPriority";
				ComboPriority.Size = new Size(121, 23);
				ComboPriority.TabIndex = 5;
				ComboPriority.Text = "Normal";
				// 
				// LabelPriority
				// 
				LabelPriority.Anchor = AnchorStyles.None;
				LabelPriority.AutoSize = true;
				LabelPriority.ForeColor = Color.White;
				LabelPriority.Location = new Point(6, 82);
				LabelPriority.Name = "LabelPriority";
				LabelPriority.Size = new Size(122, 15);
				LabelPriority.TabIndex = 4;
				LabelPriority.Text = "Game process priority";
				// 
				// CBPowerSave
				// 
				CBPowerSave.Anchor = AnchorStyles.None;
				CBPowerSave.AutoSize = true;
				CBPowerSave.ForeColor = Color.White;
				CBPowerSave.Location = new Point(6, 56);
				CBPowerSave.Name = "CBPowerSave";
				CBPowerSave.Size = new Size(97, 19);
				CBPowerSave.TabIndex = 3;
				CBPowerSave.Text = "Power Saving";
				ToolTipSettings.SetToolTip(CBPowerSave, "Sets fps to 10 and low process priority upon losing focus (e.g. tabbing out of game)");
				CBPowerSave.UseVisualStyleBackColor = true;
				// 
				// CBAutoClose
				// 
				CBAutoClose.Anchor = AnchorStyles.None;
				CBAutoClose.AutoSize = true;
				CBAutoClose.ForeColor = Color.White;
				CBAutoClose.Location = new Point(6, 31);
				CBAutoClose.Name = "CBAutoClose";
				CBAutoClose.Size = new Size(84, 19);
				CBAutoClose.TabIndex = 2;
				CBAutoClose.Text = "Auto Close";
				ToolTipSettings.SetToolTip(CBAutoClose, "Unlocker will exit upon game closing");
				CBAutoClose.UseVisualStyleBackColor = true;
				// 
				// CBStartMinimized
				// 
				CBStartMinimized.Anchor = AnchorStyles.None;
				CBStartMinimized.AutoSize = true;
				CBStartMinimized.ForeColor = Color.White;
				CBStartMinimized.Location = new Point(6, 6);
				CBStartMinimized.Name = "CBStartMinimized";
				CBStartMinimized.Size = new Size(167, 19);
				CBStartMinimized.TabIndex = 1;
				CBStartMinimized.Text = "Start Minimized (Unlocker)";
				ToolTipSettings.SetToolTip(CBStartMinimized, "Unlocker will minimized to tray on starup");
				CBStartMinimized.UseVisualStyleBackColor = true;
				// 
				// TabLaunchOptions
				// 
				TabLaunchOptions.BackColor = Color.FromArgb(54, 57, 60);
				TabLaunchOptions.Controls.Add(CBUseMobileUI);
				TabLaunchOptions.Controls.Add(InputMonitorNum);
				TabLaunchOptions.Controls.Add(LabelMonitor);
				TabLaunchOptions.Controls.Add(ComboFullscreenMode);
				TabLaunchOptions.Controls.Add(LabelWindowMode);
				TabLaunchOptions.Controls.Add(InputResY);
				TabLaunchOptions.Controls.Add(LabelX);
				TabLaunchOptions.Controls.Add(InputResX);
				TabLaunchOptions.Controls.Add(LabelCustomRes);
				TabLaunchOptions.Controls.Add(CBCustomRes);
				TabLaunchOptions.Controls.Add(CBFullscreen);
				TabLaunchOptions.Controls.Add(CBPopup);
				TabLaunchOptions.Location = new Point(4, 24);
				TabLaunchOptions.Name = "TabLaunchOptions";
				TabLaunchOptions.Padding = new Padding(3);
				TabLaunchOptions.Size = new Size(280, 210);
				TabLaunchOptions.TabIndex = 1;
				TabLaunchOptions.Text = "Launch options";
				// 
				// CBUseMobileUI
				// 
				CBUseMobileUI.Anchor = AnchorStyles.None;
				CBUseMobileUI.AutoSize = true;
				CBUseMobileUI.ForeColor = Color.White;
				CBUseMobileUI.Location = new Point(6, 81);
				CBUseMobileUI.Name = "CBUseMobileUI";
				CBUseMobileUI.Size = new Size(99, 19);
				CBUseMobileUI.TabIndex = 11;
				CBUseMobileUI.Text = "Use Mobile UI";
				CBUseMobileUI.UseVisualStyleBackColor = true;
				// 
				// InputMonitorNum
				// 
				InputMonitorNum.Anchor = AnchorStyles.None;
				InputMonitorNum.Location = new Point(139, 168);
				InputMonitorNum.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
				InputMonitorNum.Name = "InputMonitorNum";
				InputMonitorNum.Size = new Size(135, 23);
				InputMonitorNum.TabIndex = 10;
				InputMonitorNum.Value = new decimal(new int[] { 1, 0, 0, 0 });
				// 
				// LabelMonitor
				// 
				LabelMonitor.Anchor = AnchorStyles.None;
				LabelMonitor.AutoSize = true;
				LabelMonitor.ForeColor = Color.White;
				LabelMonitor.Location = new Point(6, 170);
				LabelMonitor.Name = "LabelMonitor";
				LabelMonitor.Size = new Size(56, 15);
				LabelMonitor.TabIndex = 9;
				LabelMonitor.Text = "Monitor: ";
				// 
				// ComboFullscreenMode
				// 
				ComboFullscreenMode.Anchor = AnchorStyles.None;
				ComboFullscreenMode.FormattingEnabled = true;
				ComboFullscreenMode.Items.AddRange(new object[] { "Borderless", "Exclusive" });
				ComboFullscreenMode.Location = new Point(139, 139);
				ComboFullscreenMode.Name = "ComboFullscreenMode";
				ComboFullscreenMode.Size = new Size(135, 23);
				ComboFullscreenMode.TabIndex = 8;
				ComboFullscreenMode.Text = "Borderless";
				// 
				// LabelWindowMode
				// 
				LabelWindowMode.Anchor = AnchorStyles.None;
				LabelWindowMode.AutoSize = true;
				LabelWindowMode.ForeColor = Color.White;
				LabelWindowMode.Location = new Point(6, 142);
				LabelWindowMode.Name = "LabelWindowMode";
				LabelWindowMode.Size = new Size(97, 15);
				LabelWindowMode.TabIndex = 7;
				LabelWindowMode.Text = "Fullscreen mode:";
				// 
				// InputResY
				// 
				InputResY.Anchor = AnchorStyles.None;
				InputResY.Location = new Point(219, 110);
				InputResY.Maximum = new decimal(new int[] { 4320, 0, 0, 0 });
				InputResY.Minimum = new decimal(new int[] { 200, 0, 0, 0 });
				InputResY.Name = "InputResY";
				InputResY.Size = new Size(55, 23);
				InputResY.TabIndex = 6;
				InputResY.TextAlign = HorizontalAlignment.Center;
				InputResY.Value = new decimal(new int[] { 1080, 0, 0, 0 });
				// 
				// LabelX
				// 
				LabelX.Anchor = AnchorStyles.None;
				LabelX.AutoSize = true;
				LabelX.ForeColor = Color.White;
				LabelX.Location = new Point(200, 113);
				LabelX.Name = "LabelX";
				LabelX.Size = new Size(12, 15);
				LabelX.TabIndex = 5;
				LabelX.Text = "x";
				// 
				// InputResX
				// 
				InputResX.Anchor = AnchorStyles.None;
				InputResX.Location = new Point(139, 110);
				InputResX.Maximum = new decimal(new int[] { 7680, 0, 0, 0 });
				InputResX.Minimum = new decimal(new int[] { 200, 0, 0, 0 });
				InputResX.Name = "InputResX";
				InputResX.Size = new Size(55, 23);
				InputResX.TabIndex = 4;
				InputResX.TextAlign = HorizontalAlignment.Center;
				InputResX.Value = new decimal(new int[] { 1920, 0, 0, 0 });
				// 
				// LabelCustomRes
				// 
				LabelCustomRes.Anchor = AnchorStyles.None;
				LabelCustomRes.AutoSize = true;
				LabelCustomRes.ForeColor = Color.White;
				LabelCustomRes.Location = new Point(6, 113);
				LabelCustomRes.Name = "LabelCustomRes";
				LabelCustomRes.Size = new Size(69, 15);
				LabelCustomRes.TabIndex = 3;
				LabelCustomRes.Text = "Resolution: ";
				// 
				// CBCustomRes
				// 
				CBCustomRes.Anchor = AnchorStyles.None;
				CBCustomRes.AutoSize = true;
				CBCustomRes.ForeColor = Color.White;
				CBCustomRes.Location = new Point(6, 56);
				CBCustomRes.Name = "CBCustomRes";
				CBCustomRes.Size = new Size(127, 19);
				CBCustomRes.TabIndex = 2;
				CBCustomRes.Text = "Custom Resolution";
				CBCustomRes.UseVisualStyleBackColor = true;
				CBCustomRes.CheckStateChanged += LaunchOptionsChanged;
				// 
				// CBFullscreen
				// 
				CBFullscreen.Anchor = AnchorStyles.None;
				CBFullscreen.AutoSize = true;
				CBFullscreen.ForeColor = Color.White;
				CBFullscreen.Location = new Point(6, 31);
				CBFullscreen.Name = "CBFullscreen";
				CBFullscreen.Size = new Size(79, 19);
				CBFullscreen.TabIndex = 1;
				CBFullscreen.Text = "Fullscreen";
				CBFullscreen.UseVisualStyleBackColor = true;
				CBFullscreen.CheckStateChanged += LaunchOptionsChanged;
				// 
				// CBPopup
				// 
				CBPopup.Anchor = AnchorStyles.None;
				CBPopup.AutoSize = true;
				CBPopup.ForeColor = Color.White;
				CBPopup.Location = new Point(6, 6);
				CBPopup.Name = "CBPopup";
				CBPopup.Size = new Size(127, 19);
				CBPopup.TabIndex = 0;
				CBPopup.Text = "Borderless Window";
				CBPopup.UseVisualStyleBackColor = true;
				CBPopup.CheckStateChanged += LaunchOptionsChanged;
				// 
				// ToolTipSettings
				// 
				ToolTipSettings.AutoPopDelay = 5000;
				ToolTipSettings.InitialDelay = 500;
				ToolTipSettings.ReshowDelay = 500;
				// 
				// DllAddDialog
				// 
				DllAddDialog.Filter = "DLL (*.dll)|*.dll|All files (*.*)|*.*";
				DllAddDialog.Multiselect = true;
				DllAddDialog.RestoreDirectory = true;
				// 
				// SettingsForm
				// 
				AutoScaleDimensions = new SizeF(96F, 96F);
				AutoScaleMode = AutoScaleMode.Dpi;
				BackColor = Color.FromArgb(32, 34, 40);
				ClientSize = new Size(312, 277);
				Controls.Add(TabCtrlSettings);
				Controls.Add(LabelAutoSave);
				DoubleBuffered = true;
				FormBorderStyle = FormBorderStyle.FixedDialog;
				MaximizeBox = false;
				MinimizeBox = false;
				Name = "SettingsForm";
				StartPosition = FormStartPosition.CenterParent;
				Text = "Settings";
				FormClosing += SettingsForm_FormClosing;
				Load += SettingsForm_Load;
				TabCtrlSettings.ResumeLayout(false);
				TabGeneral.ResumeLayout(false);
				TabGeneral.PerformLayout();
				TabLaunchOptions.ResumeLayout(false);
				TabLaunchOptions.PerformLayout();
				((System.ComponentModel.ISupportInitialize)InputMonitorNum).EndInit();
				((System.ComponentModel.ISupportInitialize)InputResY).EndInit();
				((System.ComponentModel.ISupportInitialize)InputResX).EndInit();
				ResumeLayout(false);
		  }

		  #endregion

		  private Label LabelAutoSave;
        private TabControl TabCtrlSettings;
        private TabPage TabGeneral;
        private TabPage TabLaunchOptions;
        private ComboBox ComboPriority;
        private Label LabelPriority;
        private CheckBox CBPowerSave;
        private CheckBox CBAutoClose;
        private CheckBox CBStartMinimized;
        private NumericUpDown InputResY;
        private Label LabelX;
        private NumericUpDown InputResX;
        private Label LabelCustomRes;
        private CheckBox CBCustomRes;
        private CheckBox CBFullscreen;
        private CheckBox CBPopup;
        private NumericUpDown InputMonitorNum;
        private Label LabelMonitor;
        private ComboBox ComboFullscreenMode;
        private Label LabelWindowMode;
        private ToolTip ToolTipSettings;
        private CheckBox CBUseMobileUI;
        private OpenFileDialog DllAddDialog;
    }
}
