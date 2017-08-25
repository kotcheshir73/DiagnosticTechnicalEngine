namespace DiagnosticTechnicalEngine.Controls
{
    partial class UserControlSeriesInfo
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
            this.groupBoxSeries = new System.Windows.Forms.GroupBox();
            this.labelDescription = new System.Windows.Forms.Label();
            this.userControlDiagnosticTest = new DiagnosticTechnicalEngine.Controls.UserControlDiagnosticTest();
            this.userControlPountTrend = new DiagnosticTechnicalEngine.Controls.UserControlPountTrend();
            this.userControlFuzzyTrend = new DiagnosticTechnicalEngine.Controls.UserControlFuzzyTrend();
            this.userControlRuleTrend = new DiagnosticTechnicalEngine.Controls.UserControlRuleTrend();
            this.userControlFuzzyLabel = new DiagnosticTechnicalEngine.Controls.UserControlFuzzyLabel();
            this.groupBoxSeries.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxSeries
            // 
            this.groupBoxSeries.Controls.Add(this.userControlDiagnosticTest);
            this.groupBoxSeries.Controls.Add(this.userControlPountTrend);
            this.groupBoxSeries.Controls.Add(this.userControlFuzzyTrend);
            this.groupBoxSeries.Controls.Add(this.userControlRuleTrend);
            this.groupBoxSeries.Controls.Add(this.userControlFuzzyLabel);
            this.groupBoxSeries.Controls.Add(this.labelDescription);
            this.groupBoxSeries.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxSeries.Location = new System.Drawing.Point(0, 0);
            this.groupBoxSeries.Name = "groupBoxSeries";
            this.groupBoxSeries.Size = new System.Drawing.Size(1078, 699);
            this.groupBoxSeries.TabIndex = 0;
            this.groupBoxSeries.TabStop = false;
            this.groupBoxSeries.Text = "ряд";
            // 
            // labelDescription
            // 
            this.labelDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelDescription.Location = new System.Drawing.Point(17, 27);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(1038, 40);
            this.labelDescription.TabIndex = 0;
            this.labelDescription.Text = "описание ряда";
            // 
            // userControlDiagnosticTest
            // 
            this.userControlDiagnosticTest.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userControlDiagnosticTest.BackColor = System.Drawing.Color.Transparent;
            this.userControlDiagnosticTest.Location = new System.Drawing.Point(0, 482);
            this.userControlDiagnosticTest.Name = "userControlDiagnosticTest";
            this.userControlDiagnosticTest.Size = new System.Drawing.Size(1072, 211);
            this.userControlDiagnosticTest.TabIndex = 7;
            // 
            // userControlPountTrend
            // 
            this.userControlPountTrend.BackColor = System.Drawing.Color.Transparent;
            this.userControlPountTrend.Location = new System.Drawing.Point(542, 276);
            this.userControlPountTrend.Name = "userControlPountTrend";
            this.userControlPountTrend.Size = new System.Drawing.Size(530, 200);
            this.userControlPountTrend.TabIndex = 6;
            // 
            // userControlFuzzyTrend
            // 
            this.userControlFuzzyTrend.BackColor = System.Drawing.Color.Transparent;
            this.userControlFuzzyTrend.Location = new System.Drawing.Point(0, 276);
            this.userControlFuzzyTrend.Name = "userControlFuzzyTrend";
            this.userControlFuzzyTrend.Size = new System.Drawing.Size(536, 200);
            this.userControlFuzzyTrend.TabIndex = 2;
            // 
            // userControlRuleTrend
            // 
            this.userControlRuleTrend.BackColor = System.Drawing.Color.Transparent;
            this.userControlRuleTrend.Location = new System.Drawing.Point(542, 70);
            this.userControlRuleTrend.MinimumSize = new System.Drawing.Size(530, 200);
            this.userControlRuleTrend.Name = "userControlRuleTrend";
            this.userControlRuleTrend.Size = new System.Drawing.Size(530, 200);
            this.userControlRuleTrend.TabIndex = 3;
            // 
            // userControlFuzzyLabel
            // 
            this.userControlFuzzyLabel.BackColor = System.Drawing.Color.Transparent;
            this.userControlFuzzyLabel.Location = new System.Drawing.Point(6, 70);
            this.userControlFuzzyLabel.MinimumSize = new System.Drawing.Size(530, 200);
            this.userControlFuzzyLabel.Name = "userControlFuzzyLabel";
            this.userControlFuzzyLabel.Size = new System.Drawing.Size(530, 200);
            this.userControlFuzzyLabel.TabIndex = 1;
            // 
            // UserControlSeriesInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.groupBoxSeries);
            this.MinimumSize = new System.Drawing.Size(540, 500);
            this.Name = "UserControlSeriesInfo";
            this.Size = new System.Drawing.Size(1078, 699);
            this.groupBoxSeries.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxSeries;
        private System.Windows.Forms.Label labelDescription;
        private UserControlFuzzyLabel userControlFuzzyLabel;
        private UserControlRuleTrend userControlRuleTrend;
		private UserControlFuzzyTrend userControlFuzzyTrend;
		private UserControlPountTrend userControlPountTrend;
        private UserControlDiagnosticTest userControlDiagnosticTest;
    }
}
