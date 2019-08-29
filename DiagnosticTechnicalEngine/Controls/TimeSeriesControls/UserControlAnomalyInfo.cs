using DiagnosticTechnicalEngine.Forms;
using DiagnosticTechnicalEngine.StandartClasses;
using DTE_Interface_Level.BindingModels;
using DTE_Interface_Level.ViewModels;
using System.Windows.Forms;

namespace DiagnosticTechnicalEngine.Controls
{
    public class UserControlAnomalyInfo : StandartSeriesControl<AnomalyInfoViewModel, AnomalyInfoBindingModel, FormAnomalyInfo>
	{
		protected override void InitializeComponent()
		{
			base.InitializeComponent();

			var ColumnId = new DataGridViewTextBoxColumn
			{
				HeaderText = "Id",
				Name = "ColumnId",
				ReadOnly = true,
				Visible = false
			};
			var ColumnName = new DataGridViewTextBoxColumn
			{
				AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
				HeaderText = "Название",
				Name = "ColumnName",
				ReadOnly = true,
				Width = 82
			};
			var ColumnSetSituation = new DataGridViewTextBoxColumn
			{
				AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
				HeaderText = "Набор ситуаций",
				Name = "ColumnSetSituation",
				ReadOnly = true,
				Width = 104
			};
			var ColumnCountMeet = new DataGridViewTextBoxColumn
			{
				HeaderText = "Количество",
				Name = "ColumnCountMeet",
				ReadOnly = true
			};
			var ColumnDescription = new DataGridViewTextBoxColumn
			{
				AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
				HeaderText = "Описание",
				Name = "ColumnDescription",
				ReadOnly = true
			};
			var ColumnNotAnomaly = new DataGridViewCheckBoxColumn
			{
				FillWeight = 40F,
				HeaderText = "Аномалия",
				Name = "ColumnNotAnomaly",
				ReadOnly = true
			};
			var ColumnNotDetected = new DataGridViewCheckBoxColumn
			{
				HeaderText = "Не выявляемая",
				Name = "ColumnNotDetected",
				ReadOnly = true
			};

			dataGridView.Columns.AddRange(new DataGridViewColumn[] {
			ColumnId,
			ColumnName,
			ColumnSetSituation,
			ColumnCountMeet,
			ColumnDescription,
			ColumnNotAnomaly,
			ColumnNotDetected});

			groupBox.Text = "Аномалии";

			ChangeVisibiles("buttonAdd", false);
			ChangeVisibiles("buttonDel", false);
			ChangeVisibiles("buttonClear", false);
		}

		protected override void LoadData()
		{
			int i = 0;
			foreach (var anomaly in _list)
			{
				dataGridView.Rows.Add();
				dataGridView.Rows[i].Cells[0].Value = anomaly.Id;
				dataGridView.Rows[i].Cells[1].Value = anomaly.AnomalyName;
				dataGridView.Rows[i].Cells[2].Value = anomaly.SetSituations + " -> " + anomaly.AnomalySituation;
				dataGridView.Rows[i].Cells[3].Value = anomaly.CountMeet;
				dataGridView.Rows[i].Cells[4].Value = anomaly.Description;
				dataGridView.Rows[i].Cells[5].Value = anomaly.NotAnomaly;
				dataGridView.Rows[i].Cells[6].Value = anomaly.NotDetected;
				i++;
			}
		}
	}
}
