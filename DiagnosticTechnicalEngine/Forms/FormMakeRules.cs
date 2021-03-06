﻿using DTE_Implement_Level;
using DTE_Implement_Level.Implementations;
using DTE_Implement_Level.StaticClasses;
using DTE_Interface_Level.BindingModels;
using System;
using System.Windows.Forms;

namespace DiagnosticTechnicalEngine.Forms
{
    public partial class FormMakeRules : Form
	{
		private int _seriesId;

		public FormMakeRules(int seriesId)
		{
			InitializeComponent();
			_seriesId = seriesId;
		}

		private void buttonMakeRules_Click(object sender, EventArgs e)
		{
			var list = ModelGenerate.GenerateRuleTrends(_seriesId);
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
			try
			{
				var rules = new RuleTrendsService();
				if (MessageBox.Show("Сохранить правила?", "Анализ временных рядов", MessageBoxButtons.YesNo,
						MessageBoxIcon.Question) == DialogResult.Yes)
				{
					for (int i = 0; i < dataGridView.Rows.Count; ++i)
					{
						rules.InsertElement(new RuleTrendBindingModel
						{
							SeriesId = _seriesId,
							FuzzyTrendName = Converter.ToFuzzyTrendLabel(dataGridView.Rows[i].Cells[1].Value.ToString()),
							FuzzyTrendId = Convert.ToInt32(dataGridView.Rows[i].Cells[5].Value),
							FuzzyLabelFromId = Convert.ToInt32(dataGridView.Rows[i].Cells[6].Value),
							FuzzyLabelToId = Convert.ToInt32(dataGridView.Rows[i].Cells[7].Value)
						});
					}
					DialogResult = DialogResult.OK;
					Close();
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show("Ошибка при добавлении: " + ex.Message, "Анализ временных рядов", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}
