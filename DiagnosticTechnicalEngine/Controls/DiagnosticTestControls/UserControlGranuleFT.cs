using DiagnosticTechnicalEngine.StandartClasses;
using ServicesModule.BindingModels;
using ServicesModule.ViewModels;
using System.Windows.Forms;

namespace DiagnosticTechnicalEngine.Controls
{
	public class UserControlGranuleFT : StandartDiagnosticTestControl<GranuleFTViewModel, GranuleFTBindingModel>
	{
		protected override void InitializeComponent()
		{
			base.InitializeComponent();

			var ColumnPosition = new DataGridViewTextBoxColumn
			{
				HeaderText = "Позиция",
				Name = "ColumnPosition",
				ReadOnly = true
			};
			var ColumnName = new DataGridViewTextBoxColumn
			{
				AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
				HeaderText = "Значение",
				Name = "ColumnName",
				ReadOnly = true
			};
			var ColumnCount = new DataGridViewTextBoxColumn
			{
				HeaderText = "Количество",
				Name = "ColumnCount",
				ReadOnly = true
			};

			dataGridView.Columns.AddRange(new DataGridViewColumn[] {
			ColumnPosition,
			ColumnName,
			ColumnCount});

			groupBox.Text = "Гранулы по мерам энтропий по нечеткой тенденции";
		}

		protected override void LoadData()
		{
			int i = 0;
			foreach (var granule in _list)
			{
				dataGridView.Rows.Add();
				dataGridView.Rows[i].Cells[0].Value = granule.GranulePosition;
				dataGridView.Rows[i].Cells[1].Value = granule.LingvistFT;
				dataGridView.Rows[i].Cells[2].Value = granule.Count;
				i++;
			}
		}
	}
}
