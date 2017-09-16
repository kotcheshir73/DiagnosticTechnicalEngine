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

			dataGridView.Columns.AddRange(new DataGridViewColumn[] {
			ColumnId,
			ColumnNumber,
			ColumnFileName,
			ColumnDate});

			groupBox.Text = "Диагностические тесты";
		}

		protected override void LoadData()
		{
			int i = 0;
			foreach (var diagnostic in _list)
			{
				dataGridView.Rows.Add();
				dataGridView.Rows[i].Cells[0].Value = diagnostic.Id;
				dataGridView.Rows[i].Cells[1].Value = diagnostic.TestNumber;
				dataGridView.Rows[i].Cells[2].Value = diagnostic.FileName;
				dataGridView.Rows[i].Cells[3].Value = diagnostic.DateTest.ToLongDateString();
				i++;
			}
		}
	}
}
