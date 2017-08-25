namespace DiagnosticTechnicalEngine.Controls
{
    partial class UserControlMain
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.userControlSeriesInfo = new DiagnosticTechnicalEngine.Controls.UserControlSeriesInfo();
            this.userControlSeriesDescription = new DiagnosticTechnicalEngine.Controls.UserControlSeriesDescription();
            this.SuspendLayout();
            // 
            // userControlSeriesInfo
            // 
            this.userControlSeriesInfo.AutoScroll = true;
            this.userControlSeriesInfo.BackColor = System.Drawing.Color.Transparent;
            this.userControlSeriesInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlSeriesInfo.Location = new System.Drawing.Point(300, 0);
            this.userControlSeriesInfo.MinimumSize = new System.Drawing.Size(540, 500);
            this.userControlSeriesInfo.Name = "userControlSeriesInfo";
            this.userControlSeriesInfo.Size = new System.Drawing.Size(1135, 731);
            this.userControlSeriesInfo.TabIndex = 3;
            this.userControlSeriesInfo.Visible = false;
            // 
            // userControlSeriesDescription
            // 
            this.userControlSeriesDescription.BackColor = System.Drawing.Color.Transparent;
            this.userControlSeriesDescription.Dock = System.Windows.Forms.DockStyle.Left;
            this.userControlSeriesDescription.Location = new System.Drawing.Point(0, 0);
            this.userControlSeriesDescription.MinimumSize = new System.Drawing.Size(300, 400);
            this.userControlSeriesDescription.Name = "userControlSeriesDescription";
            this.userControlSeriesDescription.Size = new System.Drawing.Size(300, 731);
            this.userControlSeriesDescription.TabIndex = 2;
            // 
            // UserControlMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.userControlSeriesInfo);
            this.Controls.Add(this.userControlSeriesDescription);
            this.Name = "UserControlMain";
            this.Size = new System.Drawing.Size(1435, 731);
            this.ResumeLayout(false);

        }

        #endregion

        private UserControlSeriesInfo userControlSeriesInfo;
        private UserControlSeriesDescription userControlSeriesDescription;
    }
}
