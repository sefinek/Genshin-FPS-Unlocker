namespace unlockfps_nc
{
    partial class AboutForm
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
				LabelTitle = new Label();
				LabelDescription = new Label();
				LinkLabelSource = new LinkLabel();
				LinkLabelIssues = new LinkLabel();
				SuspendLayout();
				// 
				// LabelTitle
				// 
				LabelTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
				LabelTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
				LabelTitle.ForeColor = Color.White;
				LabelTitle.Location = new Point(12, 20);
				LabelTitle.Name = "LabelTitle";
				LabelTitle.Size = new Size(473, 44);
				LabelTitle.TabIndex = 0;
				LabelTitle.Text = "Genshin FPS Unlocker\r\nv{0}";
				LabelTitle.TextAlign = ContentAlignment.TopCenter;
				// 
				// LabelDescription
				// 
				LabelDescription.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
				LabelDescription.ForeColor = Color.White;
				LabelDescription.Location = new Point(12, 71);
				LabelDescription.Name = "LabelDescription";
				LabelDescription.Size = new Size(473, 36);
				LabelDescription.TabIndex = 1;
				LabelDescription.Text = "This program is only a fork of 34736384/genshin-fps-unlock that has been prepared for compatibility with Stella Mod.";
				LabelDescription.TextAlign = ContentAlignment.MiddleCenter;
				// 
				// LinkLabelSource
				// 
				LinkLabelSource.ActiveLinkColor = Color.LightSkyBlue;
				LinkLabelSource.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
				LinkLabelSource.ForeColor = Color.White;
				LinkLabelSource.LinkArea = new LinkArea(5, 49);
				LinkLabelSource.LinkBehavior = LinkBehavior.HoverUnderline;
				LinkLabelSource.LinkColor = Color.DodgerBlue;
				LinkLabelSource.Location = new Point(12, 108);
				LinkLabelSource.Name = "LinkLabelSource";
				LinkLabelSource.Size = new Size(473, 16);
				LinkLabelSource.TabIndex = 2;
				LinkLabelSource.TabStop = true;
				LinkLabelSource.Text = "See: https://github.com/sefinek/Genshin-FPS-Unlocker";
				LinkLabelSource.TextAlign = ContentAlignment.MiddleCenter;
				LinkLabelSource.UseCompatibleTextRendering = true;
				LinkLabelSource.LinkClicked += GitHub_LinkClicked;
				// 
				// LinkLabelIssues
				// 
				LinkLabelIssues.ActiveLinkColor = Color.LightSkyBlue;
				LinkLabelIssues.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
				LinkLabelIssues.ForeColor = Color.White;
				LinkLabelIssues.LinkArea = new LinkArea(77, 26);
				LinkLabelIssues.LinkBehavior = LinkBehavior.HoverUnderline;
				LinkLabelIssues.LinkColor = Color.DodgerBlue;
				LinkLabelIssues.Location = new Point(12, 131);
				LinkLabelIssues.Name = "LinkLabelIssues";
				LinkLabelIssues.Size = new Size(473, 41);
				LinkLabelIssues.TabIndex = 3;
				LinkLabelIssues.TabStop = true;
				LinkLabelIssues.Text = "If you need help or have any suggestions, please visit the official website:\r\nhttps://stella.sefinek.net";
				LinkLabelIssues.TextAlign = ContentAlignment.MiddleCenter;
				LinkLabelIssues.UseCompatibleTextRendering = true;
				LinkLabelIssues.LinkClicked += OfficialWebsite_LinkClicked;
				// 
				// AboutForm
				// 
				AutoScaleDimensions = new SizeF(96F, 96F);
				AutoScaleMode = AutoScaleMode.Dpi;
				BackColor = Color.FromArgb(19, 19, 19);
				ClientSize = new Size(497, 192);
				Controls.Add(LinkLabelIssues);
				Controls.Add(LinkLabelSource);
				Controls.Add(LabelDescription);
				Controls.Add(LabelTitle);
				DoubleBuffered = true;
				ForeColor = Color.White;
				FormBorderStyle = FormBorderStyle.FixedDialog;
				MaximizeBox = false;
				MinimizeBox = false;
				Name = "AboutForm";
				StartPosition = FormStartPosition.CenterParent;
				Text = "About";
				Load += AboutForm_Load;
				ResumeLayout(false);
		  }

		  #endregion

		  private Label LabelTitle;
        private Label LabelDescription;
        private LinkLabel LinkLabelSource;
        private LinkLabel LinkLabelIssues;
    }
}
