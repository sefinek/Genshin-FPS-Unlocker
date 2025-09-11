namespace unlockfps_nc.Forms
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
			var resources = new System.ComponentModel.ComponentResourceManager(typeof(SetupForm));
			BrowseDialog = new OpenFileDialog();
			LabelHeader = new Label();
			BtnConfirm = new Button();
			BtnBrowse = new Button();
			LabelHint = new Label();
			ComboResult = new ComboBox();
			LabelResult = new Label();
			SuspendLayout();
			// 
			// BrowseDialog
			// 
			resources.ApplyResources(BrowseDialog, "BrowseDialog");
			BrowseDialog.RestoreDirectory = true;
			// 
			// LabelHeader
			// 
			resources.ApplyResources(LabelHeader, "LabelHeader");
			LabelHeader.ForeColor = Color.White;
			LabelHeader.Name = "LabelHeader";
			// 
			// BtnConfirm
			// 
			resources.ApplyResources(BtnConfirm, "BtnConfirm");
			BtnConfirm.Name = "BtnConfirm";
			BtnConfirm.UseVisualStyleBackColor = true;
			BtnConfirm.Click += BtnConfirm_Click;
			// 
			// BtnBrowse
			// 
			resources.ApplyResources(BtnBrowse, "BtnBrowse");
			BtnBrowse.Name = "BtnBrowse";
			BtnBrowse.UseVisualStyleBackColor = true;
			BtnBrowse.Click += BtnBrowse_Click;
			// 
			// LabelHint
			// 
			resources.ApplyResources(LabelHint, "LabelHint");
			LabelHint.ForeColor = Color.White;
			LabelHint.Name = "LabelHint";
			// 
			// ComboResult
			// 
			ComboResult.FormattingEnabled = true;
			resources.ApplyResources(ComboResult, "ComboResult");
			ComboResult.Name = "ComboResult";
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
			Controls.Add(LabelHeader);
			Controls.Add(BtnConfirm);
			Controls.Add(BtnBrowse);
			Controls.Add(LabelHint);
			Controls.Add(ComboResult);
			Controls.Add(LabelResult);
			DoubleBuffered = true;
			FormBorderStyle = FormBorderStyle.FixedDialog;
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "SetupForm";
			FormClosing += SetupForm_FormClosing;
			Load += SetupForm_Load;
			ResumeLayout(false);
		}

		#endregion

		private OpenFileDialog BrowseDialog;
		private Label LabelHeader;
		private Button BtnConfirm;
		private Button BtnBrowse;
		private Label LabelHint;
		private ComboBox ComboResult;
		private Label LabelResult;
	}
}
