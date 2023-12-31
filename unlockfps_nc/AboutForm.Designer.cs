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
            LabelTitle.Anchor = AnchorStyles.None;
            LabelTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelTitle.ForeColor = Color.White;
            LabelTitle.Location = new Point(12, 17);
            LabelTitle.Name = "LabelTitle";
            LabelTitle.Size = new Size(366, 44);
            LabelTitle.TabIndex = 0;
            LabelTitle.Text = "Genshin FPS Unlocker\r\nv{0}";
            LabelTitle.TextAlign = ContentAlignment.TopCenter;
            // 
            // LabelDescription
            // 
            LabelDescription.Anchor = AnchorStyles.None;
            LabelDescription.ForeColor = Color.White;
            LabelDescription.Location = new Point(12, 67);
            LabelDescription.Name = "LabelDescription";
            LabelDescription.Size = new Size(366, 20);
            LabelDescription.TabIndex = 1;
            LabelDescription.Text = "This program is free and open source.";
            LabelDescription.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LinkLabelSource
            // 
            LinkLabelSource.Anchor = AnchorStyles.None;
            LinkLabelSource.ForeColor = Color.White;
            LinkLabelSource.LinkArea = new LinkArea(5, 47);
            LinkLabelSource.Location = new Point(12, 87);
            LinkLabelSource.Name = "LinkLabelSource";
            LinkLabelSource.Size = new Size(366, 20);
            LinkLabelSource.TabIndex = 2;
            LinkLabelSource.TabStop = true;
            LinkLabelSource.Text = "See: https://github.com/sefinek24/genshin-fps-unlock";
            LinkLabelSource.TextAlign = ContentAlignment.MiddleCenter;
            LinkLabelSource.UseCompatibleTextRendering = true;
            LinkLabelSource.LinkClicked += LinkLabelSource_LinkClicked;
            // 
            // LinkLabelIssues
            // 
            LinkLabelIssues.Anchor = AnchorStyles.None;
            LinkLabelIssues.ForeColor = Color.White;
            LinkLabelIssues.LinkArea = new LinkArea(84, 54);
            LinkLabelIssues.Location = new Point(12, 117);
            LinkLabelIssues.Name = "LinkLabelIssues";
            LinkLabelIssues.Size = new Size(366, 67);
            LinkLabelIssues.TabIndex = 3;
            LinkLabelIssues.TabStop = true;
            LinkLabelIssues.Text = "If you encounter any problems or have a suggestion\r\nGo ahead and submit an issue at\r\n\r\nhttps://github.com/sefinek24/genshin-fps-unlock/issues\r\n\r\n";
            LinkLabelIssues.TextAlign = ContentAlignment.MiddleCenter;
            LinkLabelIssues.UseCompatibleTextRendering = true;
            LinkLabelIssues.LinkClicked += LinkLabelIssues_LinkClicked;
            // 
            // AboutForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(22, 22, 22);
            ClientSize = new Size(390, 204);
            Controls.Add(LinkLabelIssues);
            Controls.Add(LinkLabelSource);
            Controls.Add(LabelDescription);
            Controls.Add(LabelTitle);
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
