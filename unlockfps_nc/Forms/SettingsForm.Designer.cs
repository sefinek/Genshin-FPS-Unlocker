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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
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
			resources.ApplyResources(LabelAutoSave, "LabelAutoSave");
			LabelAutoSave.ForeColor = Color.MediumTurquoise;
			LabelAutoSave.Name = "LabelAutoSave";
			// 
			// TabCtrlSettings
			// 
			resources.ApplyResources(TabCtrlSettings, "TabCtrlSettings");
			TabCtrlSettings.Controls.Add(TabGeneral);
			TabCtrlSettings.Controls.Add(TabLaunchOptions);
			TabCtrlSettings.Name = "TabCtrlSettings";
			TabCtrlSettings.SelectedIndex = 0;
			// 
			// TabGeneral
			// 
			TabGeneral.BackColor = Color.FromArgb(46, 48, 51);
			TabGeneral.Controls.Add(ComboPriority);
			TabGeneral.Controls.Add(LabelPriority);
			TabGeneral.Controls.Add(CBPowerSave);
			TabGeneral.Controls.Add(CBAutoClose);
			TabGeneral.Controls.Add(CBStartMinimized);
			resources.ApplyResources(TabGeneral, "TabGeneral");
			TabGeneral.Name = "TabGeneral";
			// 
			// ComboPriority
			// 
			resources.ApplyResources(ComboPriority, "ComboPriority");
			ComboPriority.ForeColor = Color.Black;
			ComboPriority.FormattingEnabled = true;
			ComboPriority.Items.AddRange(new object[] { resources.GetString("ComboPriority.Items"), resources.GetString("ComboPriority.Items1"), resources.GetString("ComboPriority.Items2"), resources.GetString("ComboPriority.Items3"), resources.GetString("ComboPriority.Items4"), resources.GetString("ComboPriority.Items5") });
			ComboPriority.Name = "ComboPriority";
			// 
			// LabelPriority
			// 
			resources.ApplyResources(LabelPriority, "LabelPriority");
			LabelPriority.ForeColor = Color.White;
			LabelPriority.Name = "LabelPriority";
			// 
			// CBPowerSave
			// 
			resources.ApplyResources(CBPowerSave, "CBPowerSave");
			CBPowerSave.ForeColor = Color.White;
			CBPowerSave.Name = "CBPowerSave";
			ToolTipSettings.SetToolTip(CBPowerSave, resources.GetString("CBPowerSave.ToolTip"));
			CBPowerSave.UseVisualStyleBackColor = true;
			// 
			// CBAutoClose
			// 
			resources.ApplyResources(CBAutoClose, "CBAutoClose");
			CBAutoClose.ForeColor = Color.White;
			CBAutoClose.Name = "CBAutoClose";
			ToolTipSettings.SetToolTip(CBAutoClose, resources.GetString("CBAutoClose.ToolTip"));
			CBAutoClose.UseVisualStyleBackColor = true;
			// 
			// CBStartMinimized
			// 
			resources.ApplyResources(CBStartMinimized, "CBStartMinimized");
			CBStartMinimized.ForeColor = Color.White;
			CBStartMinimized.Name = "CBStartMinimized";
			ToolTipSettings.SetToolTip(CBStartMinimized, resources.GetString("CBStartMinimized.ToolTip"));
			CBStartMinimized.UseVisualStyleBackColor = true;
			// 
			// TabLaunchOptions
			// 
			TabLaunchOptions.BackColor = Color.FromArgb(46, 48, 51);
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
			resources.ApplyResources(TabLaunchOptions, "TabLaunchOptions");
			TabLaunchOptions.Name = "TabLaunchOptions";
			// 
			// CBUseMobileUI
			// 
			resources.ApplyResources(CBUseMobileUI, "CBUseMobileUI");
			CBUseMobileUI.ForeColor = Color.White;
			CBUseMobileUI.Name = "CBUseMobileUI";
			CBUseMobileUI.UseVisualStyleBackColor = true;
			// 
			// InputMonitorNum
			// 
			resources.ApplyResources(InputMonitorNum, "InputMonitorNum");
			InputMonitorNum.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
			InputMonitorNum.Name = "InputMonitorNum";
			InputMonitorNum.Value = new decimal(new int[] { 1, 0, 0, 0 });
			// 
			// LabelMonitor
			// 
			resources.ApplyResources(LabelMonitor, "LabelMonitor");
			LabelMonitor.ForeColor = Color.White;
			LabelMonitor.Name = "LabelMonitor";
			// 
			// ComboFullscreenMode
			// 
			resources.ApplyResources(ComboFullscreenMode, "ComboFullscreenMode");
			ComboFullscreenMode.FormattingEnabled = true;
			ComboFullscreenMode.Items.AddRange(new object[] { resources.GetString("ComboFullscreenMode.Items"), resources.GetString("ComboFullscreenMode.Items1") });
			ComboFullscreenMode.Name = "ComboFullscreenMode";
			// 
			// LabelWindowMode
			// 
			resources.ApplyResources(LabelWindowMode, "LabelWindowMode");
			LabelWindowMode.ForeColor = Color.White;
			LabelWindowMode.Name = "LabelWindowMode";
			// 
			// InputResY
			// 
			resources.ApplyResources(InputResY, "InputResY");
			InputResY.Maximum = new decimal(new int[] { 4320, 0, 0, 0 });
			InputResY.Minimum = new decimal(new int[] { 200, 0, 0, 0 });
			InputResY.Name = "InputResY";
			InputResY.Value = new decimal(new int[] { 1080, 0, 0, 0 });
			// 
			// LabelX
			// 
			resources.ApplyResources(LabelX, "LabelX");
			LabelX.ForeColor = Color.White;
			LabelX.Name = "LabelX";
			// 
			// InputResX
			// 
			resources.ApplyResources(InputResX, "InputResX");
			InputResX.Maximum = new decimal(new int[] { 7680, 0, 0, 0 });
			InputResX.Minimum = new decimal(new int[] { 200, 0, 0, 0 });
			InputResX.Name = "InputResX";
			InputResX.Value = new decimal(new int[] { 1920, 0, 0, 0 });
			// 
			// LabelCustomRes
			// 
			resources.ApplyResources(LabelCustomRes, "LabelCustomRes");
			LabelCustomRes.ForeColor = Color.White;
			LabelCustomRes.Name = "LabelCustomRes";
			// 
			// CBCustomRes
			// 
			resources.ApplyResources(CBCustomRes, "CBCustomRes");
			CBCustomRes.ForeColor = Color.White;
			CBCustomRes.Name = "CBCustomRes";
			CBCustomRes.UseVisualStyleBackColor = true;
			CBCustomRes.CheckStateChanged += LaunchOptionsChanged;
			// 
			// CBFullscreen
			// 
			resources.ApplyResources(CBFullscreen, "CBFullscreen");
			CBFullscreen.ForeColor = Color.White;
			CBFullscreen.Name = "CBFullscreen";
			CBFullscreen.UseVisualStyleBackColor = true;
			CBFullscreen.CheckStateChanged += LaunchOptionsChanged;
			// 
			// CBPopup
			// 
			resources.ApplyResources(CBPopup, "CBPopup");
			CBPopup.ForeColor = Color.White;
			CBPopup.Name = "CBPopup";
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
			resources.ApplyResources(DllAddDialog, "DllAddDialog");
			DllAddDialog.Multiselect = true;
			DllAddDialog.RestoreDirectory = true;
			// 
			// SettingsForm
			// 
			resources.ApplyResources(this, "$this");
			AutoScaleMode = AutoScaleMode.Dpi;
			BackColor = Color.FromArgb(35, 36, 38);
			Controls.Add(TabCtrlSettings);
			Controls.Add(LabelAutoSave);
			DoubleBuffered = true;
			FormBorderStyle = FormBorderStyle.FixedDialog;
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "SettingsForm";
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
