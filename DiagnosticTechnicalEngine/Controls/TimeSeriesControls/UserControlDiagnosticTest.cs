using DiagnosticTechnicalEngine.Forms;
using DiagnosticTechnicalEngine.StandartClasses;
using ServicesModule.BindingModels;
using ServicesModule.ViewModels;
using System.Windows.Forms;

namespace DiagnosticTechnicalEngine.Controls
{
	public class UserControlDiagnosticTest : StandartSeriesControl<DiagnosticTestViewModel, DiagnosticTestBindingModel, FormDiagnosticTest>
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
			var ColumnNumber = new DataGridViewTextBoxColumn
			{
				HeaderText = "Номер",
				Name = "ColumnNumber",
				ReadOnly = true
			};
			var ColumnFileName = new DataGridViewTextBoxColumn
			{
				AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
				HeaderText = "Путь до файла",
				Name = "ColumnFileName",
				ReadOnly = true
			};
			var ColumnDate = new DataGridViewTextBoxColumn
			{
				HeaderText = "Дата",
				Name = "ColumnDate",
				ReadOnly = true,
				Width = 140
			};
			var ColumnNeedForecast = new DataGridViewCheckBoxColumn
			{
				HeaderText = "С прогнозом",
				Name = "ColumnNeedForecast",
				ReadOnly = true
			};

			dataGridView.Columns.AddRange(new DataGridViewColumn[] {
			ColumnId,
			ColumnNumber,
			ColumnFileName,
			ColumnDate,
			ColumnNeedForecast});

			groupBox.Text = "Диагностические тесты";
		}
	}
}
