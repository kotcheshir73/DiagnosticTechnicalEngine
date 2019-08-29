using DiagnosticTechnicalEngine.Controls;
using DiagnosticTechnicalEngine.StandartClasses;
using DTE_Implement_Level.Implementations;
using DTE_Interface_Level.BindingModels;
using DTE_Interface_Level.Interfaces;
using DTE_Interface_Level.ViewModels;
using System.Windows.Forms;

namespace DiagnosticTechnicalEngine.Forms
{
    public class FormDiagnosticTest : StandartForm<DiagnosticTestViewModel, DiagnosticTestBindingModel>
	{
		#region Контролы для работы
		private UserControlAnalysisSeries userControlAnalysisSeries;
		private UserControlDiagnosticTestRecord userControlDiagnosticTestRecord;
		private UserControlGranuleUX userControlGranuleUX;
		private UserControlGranuleFT userControlGranuleFT;
		private UserControlGranuleEntropy userControlGranuleEntropy;
		private UserControlGranuleFuzzy userControlGranuleFuzzy;
		private SplitContainer splitContainerUXFT;
		private SplitContainer splitContainerEF;
		private TabPage tabPageGranuleFTUXs;
		private TabPage tabPageLoadSeries;
		private TabPage tabPageGranuleEF;
		private TabPage tabPageRecords;
		private TabControl tabControl;
		#endregion

		protected override void InitializeComponent()
		{
			base.InitializeComponent();
			SuspendLayout();
			userControlAnalysisSeries = new UserControlAnalysisSeries
			{
				Dock = DockStyle.Fill,
				Location = new System.Drawing.Point(3, 3),
				Name = "userControlAnalysisSeries",
				Size = new System.Drawing.Size(1301, 809),
				TabIndex = 0
			};
			userControlDiagnosticTestRecord = new UserControlDiagnosticTestRecord
			{
				Dock = DockStyle.Fill,
				BackColor = System.Drawing.Color.Transparent,
				Location = new System.Drawing.Point(3, 3),
				MinimumSize = new System.Drawing.Size(530, 200),
				Name = "userControlDiagnosticTestRecord",
				Size = new System.Drawing.Size(1301, 809),
				TabIndex = 0
			};
			userControlDiagnosticTestRecord.Initialize(new DiagnosticTestRecordService());
			userControlGranuleUX = new UserControlGranuleUX
			{
				BackColor = System.Drawing.Color.Transparent,
				Dock = DockStyle.Fill,
				Location = new System.Drawing.Point(0, 0),
				Name = "userControlGranuleUX",
				Size = new System.Drawing.Size(659, 809),
				TabIndex = 0
			};
			userControlGranuleUX.Initialize(new GranuleUXService());
			userControlGranuleFT = new UserControlGranuleFT
			{
				BackColor = System.Drawing.Color.Transparent,
				Dock = DockStyle.Fill,
				Location = new System.Drawing.Point(0, 0),
				Name = "userControlGranuleFT",
				Size = new System.Drawing.Size(638, 809),
				TabIndex = 0
			};
			userControlGranuleFT.Initialize(new GranuleFTService());
			userControlGranuleEntropy = new UserControlGranuleEntropy
			{
				BackColor = System.Drawing.Color.Transparent,
				Dock = DockStyle.Fill,
				Location = new System.Drawing.Point(0, 0),
				Name = "userControlGranuleEntropy",
				Size = new System.Drawing.Size(614, 815),
				TabIndex = 0
			};
			userControlGranuleEntropy.Initialize(new GranuleEntropyService());
			userControlGranuleFuzzy = new UserControlGranuleFuzzy
			{
				BackColor = System.Drawing.Color.Transparent,
				Dock = DockStyle.Fill,
				Location = new System.Drawing.Point(0, 0),
				Name = "userControlGranuleFuzzy",
				Size = new System.Drawing.Size(689, 815),
				TabIndex = 0
			};
			userControlGranuleFuzzy.Initialize(new GranuleFuzzyService());
			splitContainerUXFT = new SplitContainer
			{
				Dock = DockStyle.Fill,
				Location = new System.Drawing.Point(3, 3),
				Name = "splitContainerUXFT",
				Size = new System.Drawing.Size(1301, 809),
				SplitterDistance = 659,
				TabIndex = 0
			};
			((System.ComponentModel.ISupportInitialize)(splitContainerUXFT)).BeginInit();
			splitContainerUXFT.Panel1.SuspendLayout();
			splitContainerUXFT.Panel2.SuspendLayout();
			splitContainerUXFT.SuspendLayout();
			splitContainerUXFT.Panel1.Controls.Add(userControlGranuleUX);
			splitContainerUXFT.Panel2.Controls.Add(userControlGranuleFT);
			splitContainerEF = new SplitContainer
			{
				Dock = DockStyle.Fill,
				Location = new System.Drawing.Point(0, 0),
				Name = "splitContainerEF",
				Size = new System.Drawing.Size(1307, 815),
				SplitterDistance = 614,
				TabIndex = 0
			};
			((System.ComponentModel.ISupportInitialize)(splitContainerEF)).BeginInit();
			splitContainerEF.Panel1.SuspendLayout();
			splitContainerEF.Panel2.SuspendLayout();
			splitContainerEF.SuspendLayout();
			splitContainerEF.Panel1.Controls.Add(userControlGranuleEntropy);
			splitContainerEF.Panel2.Controls.Add(userControlGranuleFuzzy);
			tabPageLoadSeries = new TabPage
			{
				Location = new System.Drawing.Point(4, 22),
				Name = "tabPageLoadSeries",
				Padding = new Padding(3),
				Size = new System.Drawing.Size(1307, 815),
				TabIndex = 4,
				Text = "Обработка ряда",
				UseVisualStyleBackColor = true
			};
			tabPageLoadSeries.SuspendLayout();
			tabPageLoadSeries.Controls.Add(userControlAnalysisSeries);
			tabPageRecords = new TabPage
			{
				Location = new System.Drawing.Point(4, 22),
				Name = "tabPageRecords",
				Padding = new Padding(3),
				Size = new System.Drawing.Size(1307, 815),
				TabIndex = 7,
				Text = "Записи",
				UseVisualStyleBackColor = true
			};
			tabPageRecords.SuspendLayout();
			tabPageRecords.Controls.Add(userControlDiagnosticTestRecord);
			tabPageGranuleFTUXs = new TabPage
			{
				Location = new System.Drawing.Point(4, 22),
				Name = "tabPageGranuleFTUXs",
				Padding = new Padding(3),
				Size = new System.Drawing.Size(1307, 815),
				TabIndex = 5,
				Text = "Гранулы UX/FT",
				UseVisualStyleBackColor = true
			};
			tabPageGranuleFTUXs.SuspendLayout();
			tabPageGranuleFTUXs.Controls.Add(splitContainerUXFT);
			tabPageGranuleEF = new TabPage
			{
				Location = new System.Drawing.Point(4, 22),
				Name = "tabPageGranuleEF",
				Size = new System.Drawing.Size(1307, 815),
				TabIndex = 6,
				Text = "Гранулы E/F",
				UseVisualStyleBackColor = true
			};
			tabPageGranuleEF.SuspendLayout();
			tabPageGranuleEF.Controls.Add(splitContainerEF);
			tabControl = new TabControl
			{
				Dock = DockStyle.Fill,
				Location = new System.Drawing.Point(0, 0),
				Name = "tabControl",
				SelectedIndex = 0,
				Size = new System.Drawing.Size(1315, 841),
				TabIndex = 0
			};
			tabControl.SuspendLayout();
			tabControl.Controls.Add(tabPageLoadSeries);
			tabControl.Controls.Add(tabPageRecords);
			tabControl.Controls.Add(tabPageGranuleFTUXs);
			tabControl.Controls.Add(tabPageGranuleEF);

			buttonSave.Visible = false;
			buttonClose.Visible = false;			

			ClientSize = new System.Drawing.Size(1315, 841);
			Controls.Add(tabControl);
			Name = "FormDiagnosticTest";
			Text = "Диагностический тест";
			tabControl.ResumeLayout(false);
			tabPageLoadSeries.ResumeLayout(false);
			tabPageRecords.ResumeLayout(false);
			tabPageGranuleFTUXs.ResumeLayout(false);
			splitContainerUXFT.Panel1.ResumeLayout(false);
			splitContainerUXFT.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(splitContainerUXFT)).EndInit();
			splitContainerUXFT.ResumeLayout(false);
			tabPageGranuleEF.ResumeLayout(false);
			splitContainerEF.Panel1.ResumeLayout(false);
			splitContainerEF.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(splitContainerEF)).EndInit();
			splitContainerEF.ResumeLayout(false);
			ResumeLayout(false);
		}

		protected override void LoadElement()
		{
			userControlDiagnosticTestRecord.ParentId = _id.Value;
			userControlGranuleUX.ParentId = _id.Value;
			userControlGranuleFT.ParentId = _id.Value;
			userControlGranuleEntropy.ParentId = _id.Value;
			userControlGranuleFuzzy.ParentId = _id.Value;
			tabControl.TabPages.Remove(tabPageLoadSeries);
		}

		public override void Initialize(ISeriesDescriptionModel<DiagnosticTestViewModel, DiagnosticTestBindingModel> logicClass, int parentId, int? id = null)
		{
			base.Initialize(logicClass, parentId, id);
			userControlAnalysisSeries.SeriesId = _parentId;
		}
	}
}
