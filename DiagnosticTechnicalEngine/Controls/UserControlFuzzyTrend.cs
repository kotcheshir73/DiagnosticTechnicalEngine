using DiagnosticTechnicalEngine.Forms;
using DiagnosticTechnicalEngine.StandartClasses;
using ServicesModule;
using ServicesModule.BindingModels;
using ServicesModule.ViewModels;
using System;
using System.Windows.Forms;

namespace DiagnosticTechnicalEngine.Controls
{
	public class UserControlFuzzyTrend : StandartControl<FuzzyTrendViewModel, FuzzyTrendBindingModel, FormFuzzyTrend>
	{
		protected override void InitializeComponent()
		{
			base.InitializeComponent();

			var ColumnId = new DataGridViewTextBoxColumn
			{
				HeaderText = "ColumnId",
				Name = "ColumnId",
				ReadOnly = true,
				Visible = false
			};
			var ColumnName = new DataGridViewTextBoxColumn
			{
				AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
				HeaderText = "Название",
				Name = "ColumnName",
				ReadOnly = true
			};
			var ColumnWeight = new DataGridViewTextBoxColumn
			{
				HeaderText = "Вес",
				Name = "ColumnWeight",
				ReadOnly = true
			};

			dataGridView.Columns.AddRange(new DataGridViewColumn[] {
			ColumnId,
			ColumnName,
			ColumnWeight});

			groupBox.Text = "Нечеткие тенденции";

			var buttonGeneric = new Button
			{
				Anchor = AnchorStyles.Right,
				Location = new System.Drawing.Point(490, 3),
				Name = "buttonGeneric",
				Size = new System.Drawing.Size(100, 23),
				TabIndex = 5,
				Text = "Сгенерировать",
				UseVisualStyleBackColor = true
			};
			buttonGeneric.Click += new EventHandler(ButtonGeneric_Click);

			panel.Controls.Add(buttonGeneric);
		}

		protected override void LoadData()
		{
			int i = 0;
			foreach (var trend in _list)
			{
				dataGridView.Rows.Add();
				dataGridView.Rows[i].Cells[0].Value = trend.Id;
				dataGridView.Rows[i].Cells[1].Value = trend.TrendName;
				dataGridView.Rows[i].Cells[2].Value = trend.Weight;
				i++;
			}
		}

		private void ButtonGeneric_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Вы хотите сгенрировать нечеткие тенденции?", "Анализ временных рядов", MessageBoxButtons.YesNo,
					MessageBoxIcon.Question) == DialogResult.Yes)
			{
				try
				{
					ModelGenerate.GenerateFuzzyTrends(_parentId);
				}
				catch(Exception ex)
				{
					MessageBox.Show("Ошибка при генерации: " + ex.Message, "Анализ временных рядов",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				LoadData();
			}
		}
	}
}
