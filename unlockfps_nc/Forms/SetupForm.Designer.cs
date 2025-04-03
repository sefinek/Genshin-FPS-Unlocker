namespace unlockfps_nc
{
    partial class SetupForm
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
                _cts?.Dispose();
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
				System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetupForm));
				ComboResult = new ComboBox();
				LabelHint = new Label();
				BtnBrowse = new Button();
				BtnConfirm = new Button();
				LabelCurrentPath = new Label();
				BrowseDialog = new OpenFileDialog();
				LabelResult = new Label();
				SuspendLayout();
				// 
				// ComboResult
				// 
				resources.ApplyResources(ComboResult, "ComboResult");
				ComboResult.FormattingEnabled = true;
				ComboResult.Name = "ComboResult";
				// 
				// LabelHint
				// 
				resources.ApplyResources(LabelHint, "LabelHint");
				LabelHint.ForeColor = Color.White;
				LabelHint.Name = "LabelHint";
				// 
				// BtnBrowse
				// 
				resources.ApplyResources(BtnBrowse, "BtnBrowse");
				BtnBrowse.Name = "BtnBrowse";
				BtnBrowse.UseVisualStyleBackColor = true;
				BtnBrowse.Click += BtnBrowse_Click;
				// 
				// BtnConfirm
				// 
				resources.ApplyResources(BtnConfirm, "BtnConfirm");
				BtnConfirm.Name = "BtnConfirm";
				BtnConfirm.UseVisualStyleBackColor = true;
				BtnConfirm.Click += BtnConfirm_Click;
				// 
				// LabelCurrentPath
				// 
				resources.ApplyResources(LabelCurrentPath, "LabelCurrentPath");
				LabelCurrentPath.ForeColor = Color.White;
				LabelCurrentPath.Name = "LabelCurrentPath";
				// 
				// BrowseDialog
				// 
				resources.ApplyResources(BrowseDialog, "BrowseDialog");
				BrowseDialog.RestoreDirectory = true;
				// 
				// LabelResult
				// 
				resources.ApplyResources(LabelResult, "LabelResult");
				LabelResult.ForeColor = Color.White;
				LabelResult.Name = "LabelResult";
				// 
				// SetupForm
				// 
				resources.ApplyResources(this, "$this");
				AutoScaleMode = AutoScaleMode.Dpi;
				BackColor = Color.FromArgb(35, 36, 38);
				Controls.Add(LabelResult);
				Controls.Add(LabelCurrentPath);
				Controls.Add(BtnConfirm);
				Controls.Add(BtnBrowse);
				Controls.Add(LabelHint);
				Controls.Add(ComboResult);
				DoubleBuffered = true;
				FormBorderStyle = FormBorderStyle.FixedDialog;
				MaximizeBox = false;
				MinimizeBox = false;
				Name = "SetupForm";
				FormClosing += SetupForm_FormClosing;
				Load += SetupForm_Load;
				ResumeLayout(false);
				PerformLayout();
		  }

		  #endregion
		  private ComboBox ComboResult;
        private Label LabelHint;
        private Button BtnBrowse;
        private Button BtnConfirm;
        private Label LabelCurrentPath;
        private OpenFileDialog BrowseDialog;
        private Label LabelResult;
    }
}
