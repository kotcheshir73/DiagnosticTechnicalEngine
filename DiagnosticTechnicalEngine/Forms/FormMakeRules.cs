using ServicesModule;
using ServicesModule.BindingModels;
using DatabaseModule;
using System;
using System.Windows.Forms;

namespace DiagnosticTechnicalEngine.Forms
{
	public partial class FormMakeRules : Form
	{
		private int _seriesId;

		BLClassRuleTrends rules;

		public FormMakeRules(int seriesId)
		{
			InitializeComponent();
			_seriesId = seriesId;
		}

		private void buttonMakeRules_Click(object sender, EventArgs e)
		{
			rules = new BLClassRuleTrends();
			var list = rules.MakeRules(_seriesId);
			if (list != null)
			{
				dataGridView.Rows.Clear();
				for (int i = 0; i < list.Count; ++i)
				{
					dataGridView.Rows.Add();
					dataGridView.Rows[i].Cells[1].Value = list[i].FuzzyTrendName;
					dataGridView.Rows[i].Cells[2].Value = list[i].FuzzyTrendWeight;
					dataGridView.Rows[i].Cells[3].Value = list[i].FuzzyLabelFromName;
					dataGridView.Rows[i].Cells[4].Value = list[i].FuzzyLabelToName;
					dataGridView.Rows[i].Cells[5].Value = list[i].FuzzyTrendId;
					dataGridView.Rows[i].Cells[6].Value = list[i].FuzzyLabelFromId;
					dataGridView.Rows[i].Cells[7].Value = list[i].FuzzyLabelToId;
				}
			}
			else
			{
				MessageBox.Show("Ошибка при : ", "Анализ временных рядов",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void buttonApply_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Сохранить правила?", "Анализ временных рядов", MessageBoxButtons.YesNo,
					MessageBoxIcon.Question) == DialogResult.Yes)
			{
				for (int i = 0; i < dataGridView.Rows.Count; ++i)
				{
					if (!rules.AddRuleTrend(new RuleTrendBindingModel
					{
						SeriesId = _seriesId,
						FuzzyTrendName = Converter.ToFuzzyTrendLabel(dataGridView.Rows[i].Cells[1].Value.ToString()),
						FuzzyTrendId = Convert.ToInt32(dataGridView.Rows[i].Cells[5].Value),
						FuzzyLabelFromId = Convert.ToInt32(dataGridView.Rows[i].Cells[6].Value),
						FuzzyLabelToId = Convert.ToInt32(dataGridView.Rows[i].Cells[7].Value)
					}))
					{
						MessageBox.Show("Ошибка при добавлении: " + rules.Error, "Анализ временных рядов",
						 MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}
				}
				DialogResult = DialogResult.OK;
				Close();
			}
		}
	}
}
