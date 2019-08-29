using DiagnosticTechnicalEngine.Forms;
using DiagnosticTechnicalEngine.StandartClasses;
using DTE_Implement_Level;
using DTE_Interface_Level.BindingModels;
using DTE_Interface_Level.ViewModels;
using System;
using System.Windows.Forms;

namespace DiagnosticTechnicalEngine.Controls
{
    public class UserControlStatisticByFuzzy : StandartSeriesControl<StatisticsByFuzzyViewModel, StatisticsByFuzzyBindingModel, FormStatisticByFuzzy>
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

			groupBox.Text = "Ситуации по нечеткости";

			var buttonMakeSituations = new Button
			{
				Anchor = AnchorStyles.Right,
				Location = new System.Drawing.Point(490, 3),
				Name = "buttonMakeRules",
				Size = new System.Drawing.Size(100, 23),
				TabIndex = 4,
				Text = "Сформировать",
				UseVisualStyleBackColor = true
			};
			buttonMakeSituations.Click += new EventHandler(ButtonMakeSituations_Click);

			panel.Controls.Add(buttonMakeSituations);

			ChangeVisibiles("buttonAdd", false);
			ChangeVisibiles("buttonDel", false);
			ChangeVisibiles("buttonClear", false);
		}

		protected override void LoadData()
		{
			int i = 0;
			foreach (var fuzzy in _list)
			{
				dataGridView.Rows.Add();
				dataGridView.Rows[i].Cells[0].Value = fuzzy.Id;
				dataGridView.Rows[i].Cells[1].Value = fuzzy.NumberSituation;
				dataGridView.Rows[i].Cells[2].Value = fuzzy.GetStartState();
				dataGridView.Rows[i].Cells[3].Value = fuzzy.GetEndState();
				dataGridView.Rows[i].Cells[4].Value = fuzzy.Description;
				dataGridView.Rows[i].Cells[5].Value = fuzzy.CountMeet;
				i++;
			}
		}

		private void ButtonMakeSituations_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Вы хотите сгенрировать ситуации по нечеткости?", "Анализ временных рядов", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				try
				{
					ModelGenerate.GenerateSituationsByFuzzy(_parentId);
					MessageBox.Show("Готово", "Анализ временных рядов", MessageBoxButtons.OK, MessageBoxIcon.Information);
					LoadData();
				}
				catch (Exception ex)
				{
					MessageBox.Show("Ошибка при генерации: " + ex.Message, "Анализ временных рядов", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				LoadData();
			}
		}
	}
}
