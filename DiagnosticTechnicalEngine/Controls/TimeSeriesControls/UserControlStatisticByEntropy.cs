using DiagnosticTechnicalEngine.Forms;
using DiagnosticTechnicalEngine.StandartClasses;
using ServicesModule.BindingModels;
using ServicesModule.ViewModels;
using System.Windows.Forms;

namespace DiagnosticTechnicalEngine.Controls
{
	public class UserControlStatisticByEntropy : StandartSeriesControl<StatisticsByEntropyViewModel, StatisticsByEntropyBindingModel, FormStatisticByEntropy>
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
				ReadOnly = true,
				Width = 80
			};
			var ColumnFrom = new DataGridViewTextBoxColumn
			{
				HeaderText = "Предыдущее состояние",
				Name = "ColumnFrom",
				ReadOnly = true,
				Width = 200
			};
			var ColumnTo = new DataGridViewTextBoxColumn
			{
				HeaderText = "Следующее состояние",
				Name = "ColumnTo",
				ReadOnly = true,
				Width = 200
			};
			var ColumnDefinition = new DataGridViewTextBoxColumn
			{
				AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
				HeaderText = "Описание ситуации",
				Name = "ColumnDefinition",
				ReadOnly = true
			};
			var ColumnPercent = new DataGridViewTextBoxColumn
			{
				HeaderText = "Вероятность",
				Name = "ColumnPercent",
				ReadOnly = true
			};

			dataGridView.Columns.AddRange(new DataGridViewColumn[] {
			ColumnId,
			ColumnNumber,
			ColumnFrom,
			ColumnTo,
			ColumnDefinition,
			ColumnPercent});

			groupBox.Text = "Ситуации по мерам энтропий";

			ChangeVisibiles("buttonAdd", false);
			ChangeVisibiles("buttonDel", false);
			ChangeVisibiles("buttonClear", false);
		}

		protected override void LoadData()
		{
			int i = 0;
			foreach (var entropy in _list)
			{
				dataGridView.Rows.Add();
				dataGridView.Rows[i].Cells[0].Value = entropy.Id;
				dataGridView.Rows[i].Cells[1].Value = entropy.NumberSituation;
				dataGridView.Rows[i].Cells[2].Value = entropy.StartState;
				dataGridView.Rows[i].Cells[3].Value = entropy.EndState;
				dataGridView.Rows[i].Cells[4].Value = entropy.Description;
				dataGridView.Rows[i].Cells[5].Value = entropy.CountMeet;
				i++;
			}
		}
	}
}
