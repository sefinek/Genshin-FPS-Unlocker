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
				LabelSelect = new Label();
				ComboResult = new ComboBox();
				LabelHint = new Label();
				BtnBrowse = new Button();
				BtnConfirm = new Button();
				LabelCurrentPath = new Label();
				BrowseDialog = new OpenFileDialog();
				LabelResult = new Label();
				SuspendLayout();
				// 
				// LabelSelect
				// 
				LabelSelect.Anchor = AnchorStyles.None;
				LabelSelect.AutoSize = true;
				LabelSelect.Location = new Point(12, 60);
				LabelSelect.Name = "LabelSelect";
				LabelSelect.Size = new Size(38, 15);
				LabelSelect.TabIndex = 1;
				LabelSelect.Text = "Select";
				// 
				// ComboResult
				// 
				ComboResult.Anchor = AnchorStyles.None;
				ComboResult.FormattingEnabled = true;
				ComboResult.Location = new Point(12, 78);
				ComboResult.Name = "ComboResult";
				ComboResult.Size = new Size(435, 23);
				ComboResult.TabIndex = 2;
				// 
				// LabelHint
				// 
				LabelHint.Anchor = AnchorStyles.None;
				LabelHint.AutoSize = true;
				LabelHint.ForeColor = Color.White;
				LabelHint.Location = new Point(12, 114);
				LabelHint.Name = "LabelHint";
				LabelHint.Size = new Size(359, 45);
				LabelHint.TabIndex = 3;
				LabelHint.Text = "If your game is not listed above, you can either:\r\n1. Open the game now and the unlocker will try to find it's location\r\n2. Use the browse button below";
				// 
				// BtnBrowse
				// 
				BtnBrowse.Anchor = AnchorStyles.None;
				BtnBrowse.Location = new Point(12, 176);
				BtnBrowse.Name = "BtnBrowse";
				BtnBrowse.Size = new Size(90, 23);
				BtnBrowse.TabIndex = 4;
				BtnBrowse.Text = "Browse";
				BtnBrowse.UseVisualStyleBackColor = true;
				BtnBrowse.Click += BtnBrowse_Click;
				// 
				// BtnConfirm
				// 
				BtnConfirm.Anchor = AnchorStyles.None;
				BtnConfirm.Location = new Point(357, 176);
				BtnConfirm.Name = "BtnConfirm";
				BtnConfirm.Size = new Size(90, 23);
				BtnConfirm.TabIndex = 5;
				BtnConfirm.Text = "Confirm";
				BtnConfirm.UseVisualStyleBackColor = true;
				BtnConfirm.Click += BtnConfirm_Click;
				// 
				// LabelCurrentPath
				// 
				LabelCurrentPath.Anchor = AnchorStyles.None;
				LabelCurrentPath.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
				LabelCurrentPath.ForeColor = Color.White;
				LabelCurrentPath.Location = new Point(12, 9);
				LabelCurrentPath.Name = "LabelCurrentPath";
				LabelCurrentPath.Size = new Size(435, 39);
				LabelCurrentPath.TabIndex = 6;
				LabelCurrentPath.Text = "LabelCurrentPath";
				LabelCurrentPath.TextAlign = ContentAlignment.MiddleCenter;
				// 
				// BrowseDialog
				// 
				BrowseDialog.Filter = "Executable Files (*.exe)|GenshinImpact.exe;YuanShen.exe";
				BrowseDialog.RestoreDirectory = true;
				BrowseDialog.Title = "Select GenshinImpact.exe or YuanShen.exe";
				// 
				// LabelResult
				// 
				LabelResult.Anchor = AnchorStyles.None;
				LabelResult.AutoSize = true;
				LabelResult.ForeColor = Color.White;
				LabelResult.Location = new Point(9, 60);
				LabelResult.Name = "LabelResult";
				LabelResult.Size = new Size(67, 15);
				LabelResult.TabIndex = 7;
				LabelResult.Text = "LabelResult";
				// 
				// SetupForm
				// 
				AutoScaleDimensions = new SizeF(96F, 96F);
				AutoScaleMode = AutoScaleMode.Dpi;
				BackColor = Color.FromArgb(32, 34, 40);
				ClientSize = new Size(459, 211);
				Controls.Add(LabelResult);
				Controls.Add(LabelCurrentPath);
				Controls.Add(BtnConfirm);
				Controls.Add(BtnBrowse);
				Controls.Add(LabelHint);
				Controls.Add(ComboResult);
				Controls.Add(LabelSelect);
				DoubleBuffered = true;
				FormBorderStyle = FormBorderStyle.FixedDialog;
				MaximizeBox = false;
				MinimizeBox = false;
				Name = "SetupForm";
				StartPosition = FormStartPosition.CenterParent;
				Text = "Setup";
				FormClosing += SetupForm_FormClosing;
				Load += SetupForm_Load;
				ResumeLayout(false);
				PerformLayout();
		  }

		  #endregion
		  private Label LabelSelect;
        private ComboBox ComboResult;
        private Label LabelHint;
        private Button BtnBrowse;
        private Button BtnConfirm;
        private Label LabelCurrentPath;
        private OpenFileDialog BrowseDialog;
        private Label LabelResult;
    }
}
