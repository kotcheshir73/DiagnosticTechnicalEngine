namespace DiagnosticTechnicalEngine.Forms
{
	partial class FormDiagnosticTest
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
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tabPageStaticticsEntropy = new System.Windows.Forms.TabPage();
			this.userControlStatisticEntropy = new DiagnosticTechnicalEngine.Controls.UserControlStatisticEntropy();
			this.tabPageStaticticsFuzzy = new System.Windows.Forms.TabPage();
			this.userControlStatisticFuzzy = new DiagnosticTechnicalEngine.Controls.UserControlStatisticFuzzy();
			this.tabPageAnomalyInfo = new System.Windows.Forms.TabPage();
			this.userControlAnomalyInfo = new DiagnosticTechnicalEngine.Controls.UserControlAnomalyInfo();
			this.tabPageLoadSeries = new System.Windows.Forms.TabPage();
			this.userControlAnalysisSeries = new DiagnosticTechnicalEngine.Controls.UserControlAnalysisSeries();
			this.tabPageGranuleFTUXs = new System.Windows.Forms.TabPage();
			this.splitContainerUXFT = new System.Windows.Forms.SplitContainer();
			this.userControlGranuleUX = new DiagnosticTechnicalEngine.Controls.UserControlGranuleUX();
			this.userControlGranuleFT = new DiagnosticTechnicalEngine.Controls.UserControlGranuleFT();
			this.tabPageGranuleEF = new System.Windows.Forms.TabPage();
			this.splitContainerEF = new System.Windows.Forms.SplitContainer();
			this.userControlGranuleEntropy = new DiagnosticTechnicalEngine.Controls.UserControlGranuleEntropy();
			this.userControlGranuleFuzzy = new DiagnosticTechnicalEngine.Controls.UserControlGranuleFuzzy();
			this.tabControl.SuspendLayout();
			this.tabPageStaticticsEntropy.SuspendLayout();
			this.tabPageStaticticsFuzzy.SuspendLayout();
			this.tabPageAnomalyInfo.SuspendLayout();
			this.tabPageLoadSeries.SuspendLayout();
			this.tabPageGranuleFTUXs.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerUXFT)).BeginInit();
			this.splitContainerUXFT.Panel1.SuspendLayout();
			this.splitContainerUXFT.Panel2.SuspendLayout();
			this.splitContainerUXFT.SuspendLayout();
			this.tabPageGranuleEF.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerEF)).BeginInit();
			this.splitContainerEF.Panel1.SuspendLayout();
			this.splitContainerEF.Panel2.SuspendLayout();
			this.splitContainerEF.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl
			// 
			this.tabControl.Controls.Add(this.tabPageLoadSeries);
			this.tabControl.Controls.Add(this.tabPageStaticticsEntropy);
			this.tabControl.Controls.Add(this.tabPageStaticticsFuzzy);
			this.tabControl.Controls.Add(this.tabPageAnomalyInfo);
			this.tabControl.Controls.Add(this.tabPageGranuleFTUXs);
			this.tabControl.Controls.Add(this.tabPageGranuleEF);
			this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl.Location = new System.Drawing.Point(0, 0);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(1315, 841);
			this.tabControl.TabIndex = 1;
			// 
			// tabPageStaticticsEntropy
			// 
			this.tabPageStaticticsEntropy.Controls.Add(this.userControlStatisticEntropy);
			this.tabPageStaticticsEntropy.Location = new System.Drawing.Point(4, 22);
			this.tabPageStaticticsEntropy.Name = "tabPageStaticticsEntropy";
			this.tabPageStaticticsEntropy.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageStaticticsEntropy.Size = new System.Drawing.Size(1307, 815);
			this.tabPageStaticticsEntropy.TabIndex = 1;
			this.tabPageStaticticsEntropy.Text = "Статистика энтропий по ряду";
			this.tabPageStaticticsEntropy.UseVisualStyleBackColor = true;
			// 
			// userControlStatisticEntropy
			// 
			this.userControlStatisticEntropy.BackColor = System.Drawing.Color.Transparent;
			this.userControlStatisticEntropy.Dock = System.Windows.Forms.DockStyle.Fill;
			this.userControlStatisticEntropy.Location = new System.Drawing.Point(3, 3);
			this.userControlStatisticEntropy.MinimumSize = new System.Drawing.Size(600, 400);
			this.userControlStatisticEntropy.Name = "userControlStatisticEntropy";
			this.userControlStatisticEntropy.Size = new System.Drawing.Size(1301, 809);
			this.userControlStatisticEntropy.TabIndex = 0;
			// 
			// tabPageStaticticsFuzzy
			// 
			this.tabPageStaticticsFuzzy.Controls.Add(this.userControlStatisticFuzzy);
			this.tabPageStaticticsFuzzy.Location = new System.Drawing.Point(4, 22);
			this.tabPageStaticticsFuzzy.Name = "tabPageStaticticsFuzzy";
			this.tabPageStaticticsFuzzy.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageStaticticsFuzzy.Size = new System.Drawing.Size(1307, 815);
			this.tabPageStaticticsFuzzy.TabIndex = 2;
			this.tabPageStaticticsFuzzy.Text = "Статистика нечеткости по ряду";
			this.tabPageStaticticsFuzzy.UseVisualStyleBackColor = true;
			// 
			// userControlStatisticFuzzy
			// 
			this.userControlStatisticFuzzy.BackColor = System.Drawing.Color.Transparent;
			this.userControlStatisticFuzzy.Dock = System.Windows.Forms.DockStyle.Fill;
			this.userControlStatisticFuzzy.Location = new System.Drawing.Point(3, 3);
			this.userControlStatisticFuzzy.MinimumSize = new System.Drawing.Size(600, 400);
			this.userControlStatisticFuzzy.Name = "userControlStatisticFuzzy";
			this.userControlStatisticFuzzy.Size = new System.Drawing.Size(1301, 809);
			this.userControlStatisticFuzzy.TabIndex = 0;
			// 
			// tabPageAnomalyInfo
			// 
			this.tabPageAnomalyInfo.Controls.Add(this.userControlAnomalyInfo);
			this.tabPageAnomalyInfo.Location = new System.Drawing.Point(4, 22);
			this.tabPageAnomalyInfo.Name = "tabPageAnomalyInfo";
			this.tabPageAnomalyInfo.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageAnomalyInfo.Size = new System.Drawing.Size(1307, 815);
			this.tabPageAnomalyInfo.TabIndex = 3;
			this.tabPageAnomalyInfo.Text = "Информация по аномалиям";
			this.tabPageAnomalyInfo.UseVisualStyleBackColor = true;
			// 
			// userControlAnomalyInfo
			// 
			this.userControlAnomalyInfo.BackColor = System.Drawing.Color.Transparent;
			this.userControlAnomalyInfo.Dock = System.Windows.Forms.DockStyle.Fill;
			this.userControlAnomalyInfo.Location = new System.Drawing.Point(3, 3);
			this.userControlAnomalyInfo.Name = "userControlAnomalyInfo";
			this.userControlAnomalyInfo.Size = new System.Drawing.Size(1301, 809);
			this.userControlAnomalyInfo.TabIndex = 0;
			// 
			// tabPageLoadSeries
			// 
			this.tabPageLoadSeries.Controls.Add(this.userControlAnalysisSeries);
			this.tabPageLoadSeries.Location = new System.Drawing.Point(4, 22);
			this.tabPageLoadSeries.Name = "tabPageLoadSeries";
			this.tabPageLoadSeries.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageLoadSeries.Size = new System.Drawing.Size(1307, 815);
			this.tabPageLoadSeries.TabIndex = 4;
			this.tabPageLoadSeries.Text = "Обработка ряда";
			this.tabPageLoadSeries.UseVisualStyleBackColor = true;
			// 
			// userControlAnalysisSeries
			// 
			this.userControlAnalysisSeries.Dock = System.Windows.Forms.DockStyle.Fill;
			this.userControlAnalysisSeries.Location = new System.Drawing.Point(3, 3);
			this.userControlAnalysisSeries.Name = "userControlAnalysisSeries";
			this.userControlAnalysisSeries.Size = new System.Drawing.Size(1301, 809);
			this.userControlAnalysisSeries.TabIndex = 0;
			// 
			// tabPageGranuleFTUXs
			// 
			this.tabPageGranuleFTUXs.Controls.Add(this.splitContainerUXFT);
			this.tabPageGranuleFTUXs.Location = new System.Drawing.Point(4, 22);
			this.tabPageGranuleFTUXs.Name = "tabPageGranuleFTUXs";
			this.tabPageGranuleFTUXs.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageGranuleFTUXs.Size = new System.Drawing.Size(1307, 815);
			this.tabPageGranuleFTUXs.TabIndex = 5;
			this.tabPageGranuleFTUXs.Text = "Гранулы UX/FT";
			this.tabPageGranuleFTUXs.UseVisualStyleBackColor = true;
			// 
			// splitContainerUXFT
			// 
			this.splitContainerUXFT.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerUXFT.Location = new System.Drawing.Point(3, 3);
			this.splitContainerUXFT.Name = "splitContainerUXFT";
			// 
			// splitContainerUXFT.Panel1
			// 
			this.splitContainerUXFT.Panel1.Controls.Add(this.userControlGranuleUX);
			// 
			// splitContainerUXFT.Panel2
			// 
			this.splitContainerUXFT.Panel2.Controls.Add(this.userControlGranuleFT);
			this.splitContainerUXFT.Size = new System.Drawing.Size(1301, 809);
			this.splitContainerUXFT.SplitterDistance = 659;
			this.splitContainerUXFT.TabIndex = 0;
			// 
			// userControlGranuleUX
			// 
			this.userControlGranuleUX.BackColor = System.Drawing.Color.Transparent;
			this.userControlGranuleUX.Dock = System.Windows.Forms.DockStyle.Fill;
			this.userControlGranuleUX.Location = new System.Drawing.Point(0, 0);
			this.userControlGranuleUX.Name = "userControlGranuleUX";
			this.userControlGranuleUX.Size = new System.Drawing.Size(659, 809);
			this.userControlGranuleUX.TabIndex = 0;
			// 
			// userControlGranuleFT
			// 
			this.userControlGranuleFT.BackColor = System.Drawing.Color.Transparent;
			this.userControlGranuleFT.Dock = System.Windows.Forms.DockStyle.Fill;
			this.userControlGranuleFT.Location = new System.Drawing.Point(0, 0);
			this.userControlGranuleFT.Name = "userControlGranuleFT";
			this.userControlGranuleFT.Size = new System.Drawing.Size(638, 809);
			this.userControlGranuleFT.TabIndex = 0;
			// 
			// tabPageGranuleEF
			// 
			this.tabPageGranuleEF.Controls.Add(this.splitContainerEF);
			this.tabPageGranuleEF.Location = new System.Drawing.Point(4, 22);
			this.tabPageGranuleEF.Name = "tabPageGranuleEF";
			this.tabPageGranuleEF.Size = new System.Drawing.Size(1307, 815);
			this.tabPageGranuleEF.TabIndex = 6;
			this.tabPageGranuleEF.Text = "Гранулы E/F";
			this.tabPageGranuleEF.UseVisualStyleBackColor = true;
			// 
			// splitContainerEF
			// 
			this.splitContainerEF.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerEF.Location = new System.Drawing.Point(0, 0);
			this.splitContainerEF.Name = "splitContainerEF";
			// 
			// splitContainerEF.Panel1
			// 
			this.splitContainerEF.Panel1.Controls.Add(this.userControlGranuleEntropy);
			// 
			// splitContainerEF.Panel2
			// 
			this.splitContainerEF.Panel2.Controls.Add(this.userControlGranuleFuzzy);
			this.splitContainerEF.Size = new System.Drawing.Size(1307, 815);
			this.splitContainerEF.SplitterDistance = 614;
			this.splitContainerEF.TabIndex = 0;
			// 
			// userControlGranuleEntropy
			// 
			this.userControlGranuleEntropy.BackColor = System.Drawing.Color.Transparent;
			this.userControlGranuleEntropy.Dock = System.Windows.Forms.DockStyle.Fill;
			this.userControlGranuleEntropy.Location = new System.Drawing.Point(0, 0);
			this.userControlGranuleEntropy.Name = "userControlGranuleEntropy";
			this.userControlGranuleEntropy.Size = new System.Drawing.Size(614, 815);
			this.userControlGranuleEntropy.TabIndex = 0;
			// 
			// userControlGranuleFuzzy
			// 
			this.userControlGranuleFuzzy.BackColor = System.Drawing.Color.Transparent;
			this.userControlGranuleFuzzy.Dock = System.Windows.Forms.DockStyle.Fill;
			this.userControlGranuleFuzzy.Location = new System.Drawing.Point(0, 0);
			this.userControlGranuleFuzzy.Name = "userControlGranuleFuzzy";
			this.userControlGranuleFuzzy.Size = new System.Drawing.Size(689, 815);
			this.userControlGranuleFuzzy.TabIndex = 0;
			// 
			// FormDiagnosticTest
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1315, 841);
			this.Controls.Add(this.tabControl);
			this.Name = "FormDiagnosticTest";
			this.Text = "Диагностический тест";
			this.tabControl.ResumeLayout(false);
			this.tabPageStaticticsEntropy.ResumeLayout(false);
			this.tabPageStaticticsFuzzy.ResumeLayout(false);
			this.tabPageAnomalyInfo.ResumeLayout(false);
			this.tabPageLoadSeries.ResumeLayout(false);
			this.tabPageGranuleFTUXs.ResumeLayout(false);
			this.splitContainerUXFT.Panel1.ResumeLayout(false);
			this.splitContainerUXFT.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainerUXFT)).EndInit();
			this.splitContainerUXFT.ResumeLayout(false);
			this.tabPageGranuleEF.ResumeLayout(false);
			this.splitContainerEF.Panel1.ResumeLayout(false);
			this.splitContainerEF.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainerEF)).EndInit();
			this.splitContainerEF.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage tabPageLoadSeries;
		private Controls.UserControlAnalysisSeries userControlAnalysisSeries;
		private System.Windows.Forms.TabPage tabPageStaticticsEntropy;
		private Controls.UserControlStatisticEntropy userControlStatisticEntropy;
		private System.Windows.Forms.TabPage tabPageStaticticsFuzzy;
		private Controls.UserControlStatisticFuzzy userControlStatisticFuzzy;
		private System.Windows.Forms.TabPage tabPageAnomalyInfo;
		private Controls.UserControlAnomalyInfo userControlAnomalyInfo;
		private System.Windows.Forms.TabPage tabPageGranuleFTUXs;
		private System.Windows.Forms.SplitContainer splitContainerUXFT;
		private Controls.UserControlGranuleUX userControlGranuleUX;
		private Controls.UserControlGranuleFT userControlGranuleFT;
		private System.Windows.Forms.TabPage tabPageGranuleEF;
		private System.Windows.Forms.SplitContainer splitContainerEF;
		private Controls.UserControlGranuleEntropy userControlGranuleEntropy;
		private Controls.UserControlGranuleFuzzy userControlGranuleFuzzy;
	}
}