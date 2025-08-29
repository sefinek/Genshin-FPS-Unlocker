namespace unlockfps_nc.Forms
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
			var resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
			DllAddDialog = new OpenFileDialog();
			ToolTipSettings = new ToolTip(components);
			CBAutoClose = new CheckBox();
			CBStartMinimized = new CheckBox();
			CBPowerSave = new CheckBox();
			CBUseMobileUI = new CheckBox();
			TabLaunchOptions = new TabPage();
			ComboMonitor = new ComboBox();
			LabelMonitor = new Label();
			ComboFullscreenMode = new ComboBox();
			InputResY = new NumericUpDown();
			LabelX = new Label();
			InputResX = new NumericUpDown();
			CBCustomRes = new CheckBox();
			CBFullscreen = new CheckBox();
			CBPopup = new CheckBox();
			TabGeneral = new TabPage();
			CBHdr = new CheckBox();
			ComboPriority = new ComboBox();
			LabelPriority = new Label();
			TabCtrlSettings = new TabControl();
			LabelAutoSave = new Label();
			TabLaunchOptions.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)InputResY).BeginInit();
			((System.ComponentModel.ISupportInitialize)InputResX).BeginInit();
			TabGeneral.SuspendLayout();
			TabCtrlSettings.SuspendLayout();
			SuspendLayout();
			// 
			// DllAddDialog
			// 
			resources.ApplyResources(DllAddDialog, "DllAddDialog");
			DllAddDialog.Multiselect = true;
			DllAddDialog.RestoreDirectory = true;
			// 
			// ToolTipSettings
			// 
			ToolTipSettings.AutoPopDelay = 5000;
			ToolTipSettings.InitialDelay = 500;
			ToolTipSettings.ReshowDelay = 500;
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
			// CBPowerSave
			// 
			resources.ApplyResources(CBPowerSave, "CBPowerSave");
			CBPowerSave.ForeColor = Color.White;
			CBPowerSave.Name = "CBPowerSave";
			ToolTipSettings.SetToolTip(CBPowerSave, resources.GetString("CBPowerSave.ToolTip"));
			CBPowerSave.UseVisualStyleBackColor = true;
			// 
			// CBUseMobileUI
			// 
			resources.ApplyResources(CBUseMobileUI, "CBUseMobileUI");
			CBUseMobileUI.ForeColor = Color.White;
			CBUseMobileUI.Name = "CBUseMobileUI";
			CBUseMobileUI.UseVisualStyleBackColor = true;
			// 
			// TabLaunchOptions
			// 
			TabLaunchOptions.BackColor = Color.FromArgb(46, 48, 51);
			TabLaunchOptions.Controls.Add(CBUseMobileUI);
			TabLaunchOptions.Controls.Add(ComboMonitor);
			TabLaunchOptions.Controls.Add(LabelMonitor);
			TabLaunchOptions.Controls.Add(ComboFullscreenMode);
			TabLaunchOptions.Controls.Add(InputResY);
			TabLaunchOptions.Controls.Add(LabelX);
			TabLaunchOptions.Controls.Add(InputResX);
			TabLaunchOptions.Controls.Add(CBCustomRes);
			TabLaunchOptions.Controls.Add(CBFullscreen);
			TabLaunchOptions.Controls.Add(CBPopup);
			resources.ApplyResources(TabLaunchOptions, "TabLaunchOptions");
			TabLaunchOptions.Name = "TabLaunchOptions";
			// 
			// ComboMonitor
			// 
			ComboMonitor.DropDownStyle = ComboBoxStyle.DropDownList;
			resources.ApplyResources(ComboMonitor, "ComboMonitor");
			ComboMonitor.FormattingEnabled = true;
			ComboMonitor.Name = "ComboMonitor";
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
			// CBCustomRes
			// 
			resources.ApplyResources(CBCustomRes, "CBCustomRes");
			CBCustomRes.ForeColor = Color.White;
			CBCustomRes.Name = "CBCustomRes";
			CBCustomRes.UseVisualStyleBackColor = true;
			CBCustomRes.CheckedChanged += CBCustomRes_CheckedChanged;
			// 
			// CBFullscreen
			// 
			resources.ApplyResources(CBFullscreen, "CBFullscreen");
			CBFullscreen.ForeColor = Color.White;
			CBFullscreen.Name = "CBFullscreen";
			CBFullscreen.UseVisualStyleBackColor = true;
			CBFullscreen.CheckedChanged += CBFullscreen_CheckedChanged;
			// 
			// CBPopup
			// 
			resources.ApplyResources(CBPopup, "CBPopup");
			CBPopup.ForeColor = Color.White;
			CBPopup.Name = "CBPopup";
			CBPopup.UseVisualStyleBackColor = true;
			CBPopup.CheckedChanged += CBPopup_CheckedChanged;
			// 
			// TabGeneral
			// 
			TabGeneral.BackColor = Color.FromArgb(46, 48, 51);
			TabGeneral.Controls.Add(CBHdr);
			TabGeneral.Controls.Add(ComboPriority);
			TabGeneral.Controls.Add(LabelPriority);
			TabGeneral.Controls.Add(CBPowerSave);
			TabGeneral.Controls.Add(CBAutoClose);
			TabGeneral.Controls.Add(CBStartMinimized);
			resources.ApplyResources(TabGeneral, "TabGeneral");
			TabGeneral.Name = "TabGeneral";
			// 
			// CBHdr
			// 
			resources.ApplyResources(CBHdr, "CBHdr");
			CBHdr.ForeColor = Color.White;
			CBHdr.Name = "CBHdr";
			CBHdr.UseVisualStyleBackColor = true;
			// 
			// ComboPriority
			// 
			ComboPriority.DropDownStyle = ComboBoxStyle.DropDownList;
			ComboPriority.ForeColor = Color.Black;
			ComboPriority.FormattingEnabled = true;
			ComboPriority.Items.AddRange(new object[] { resources.GetString("ComboPriority.Items"), resources.GetString("ComboPriority.Items1"), resources.GetString("ComboPriority.Items2"), resources.GetString("ComboPriority.Items3"), resources.GetString("ComboPriority.Items4"), resources.GetString("ComboPriority.Items5") });
			resources.ApplyResources(ComboPriority, "ComboPriority");
			ComboPriority.Name = "ComboPriority";
			// 
			// LabelPriority
			// 
			resources.ApplyResources(LabelPriority, "LabelPriority");
			LabelPriority.ForeColor = Color.White;
			LabelPriority.Name = "LabelPriority";
			// 
			// TabCtrlSettings
			// 
			TabCtrlSettings.Controls.Add(TabGeneral);
			TabCtrlSettings.Controls.Add(TabLaunchOptions);
			resources.ApplyResources(TabCtrlSettings, "TabCtrlSettings");
			TabCtrlSettings.Name = "TabCtrlSettings";
			TabCtrlSettings.SelectedIndex = 0;
			// 
			// LabelAutoSave
			// 
			resources.ApplyResources(LabelAutoSave, "LabelAutoSave");
			LabelAutoSave.ForeColor = Color.MediumTurquoise;
			LabelAutoSave.Name = "LabelAutoSave";
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
			TabLaunchOptions.ResumeLayout(false);
			TabLaunchOptions.PerformLayout();
			((System.ComponentModel.ISupportInitialize)InputResY).EndInit();
			((System.ComponentModel.ISupportInitialize)InputResX).EndInit();
			TabGeneral.ResumeLayout(false);
			TabGeneral.PerformLayout();
			TabCtrlSettings.ResumeLayout(false);
			ResumeLayout(false);
		}

		#endregion

		private OpenFileDialog DllAddDialog;
		private ToolTip ToolTipSettings;
		private CheckBox CBUseMobileUI;
		private TabPage TabLaunchOptions;
		private ComboBox ComboMonitor;
		private Label LabelMonitor;
		private ComboBox ComboFullscreenMode;
		private NumericUpDown InputResY;
		private Label LabelX;
		private NumericUpDown InputResX;
		private CheckBox CBCustomRes;
		private CheckBox CBFullscreen;
		private CheckBox CBPopup;
		private CheckBox CBAutoClose;
		private CheckBox CBStartMinimized;
		private TabPage TabGeneral;
		private CheckBox CBHdr;
		private ComboBox ComboPriority;
		private Label LabelPriority;
		private CheckBox CBPowerSave;
		private TabControl TabCtrlSettings;
		private Label LabelAutoSave;
	}
}
