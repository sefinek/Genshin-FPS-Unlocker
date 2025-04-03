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
				System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
				LabelTitle = new Label();
				LabelDescription = new Label();
				LinkLabelSource = new LinkLabel();
				LinkLabelIssues = new LinkLabel();
				SuspendLayout();
				// 
				// LabelTitle
				// 
				resources.ApplyResources(LabelTitle, "LabelTitle");
				LabelTitle.ForeColor = Color.White;
				LabelTitle.Name = "LabelTitle";
				// 
				// LabelDescription
				// 
				resources.ApplyResources(LabelDescription, "LabelDescription");
				LabelDescription.ForeColor = Color.White;
				LabelDescription.Name = "LabelDescription";
				// 
				// LinkLabelSource
				// 
				LinkLabelSource.ActiveLinkColor = Color.LightSkyBlue;
				resources.ApplyResources(LinkLabelSource, "LinkLabelSource");
				LinkLabelSource.ForeColor = Color.White;
				LinkLabelSource.LinkBehavior = LinkBehavior.HoverUnderline;
				LinkLabelSource.LinkColor = Color.DodgerBlue;
				LinkLabelSource.Name = "LinkLabelSource";
				LinkLabelSource.TabStop = true;
				LinkLabelSource.UseCompatibleTextRendering = true;
				LinkLabelSource.LinkClicked += GitHub_LinkClicked;
				// 
				// LinkLabelIssues
				// 
				LinkLabelIssues.ActiveLinkColor = Color.LightSkyBlue;
				resources.ApplyResources(LinkLabelIssues, "LinkLabelIssues");
				LinkLabelIssues.ForeColor = Color.White;
				LinkLabelIssues.LinkBehavior = LinkBehavior.HoverUnderline;
				LinkLabelIssues.LinkColor = Color.DodgerBlue;
				LinkLabelIssues.Name = "LinkLabelIssues";
				LinkLabelIssues.TabStop = true;
				LinkLabelIssues.UseCompatibleTextRendering = true;
				LinkLabelIssues.LinkClicked += OfficialWebsite_LinkClicked;
				// 
				// AboutForm
				// 
				resources.ApplyResources(this, "$this");
				AutoScaleMode = AutoScaleMode.Dpi;
				BackColor = Color.FromArgb(19, 19, 19);
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
