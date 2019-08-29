using DiagnosticTechnicalEngine.Forms;
using DiagnosticTechnicalEngine.StandartClasses;
using DTE_Interface_Level.BindingModels;
using DTE_Interface_Level.ViewModels;
using System;
using System.Windows.Forms;

namespace DiagnosticTechnicalEngine.Controls
{
    public class UserControlRuleTrend : StandartSeriesControl<RuleTrendViewModel, RuleTrendBindingModel, FormRuleTrend>
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
			var ColumnTrendName = new DataGridViewTextBoxColumn
			{
				AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
				HeaderText = "Тенденция",
				Name = "ColumnTrendName",
				ReadOnly = true
			};
			var ColumnFuzzyLabelFrom = new DataGridViewTextBoxColumn
			{
				AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
				HeaderText = "Нечеткая метка - исходник",
				Name = "ColumnFuzzyLabelFrom",
				ReadOnly = true
			};
			var ColumnFuzzyLabelTo = new DataGridViewTextBoxColumn
			{
				AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
				HeaderText = "Нечеткая метка - приемник",
				Name = "ColumnFuzzyLabelTo",
				ReadOnly = true
			};

			dataGridView.Columns.AddRange(new DataGridViewColumn[] {
			ColumnId,
			ColumnTrendName,
			ColumnFuzzyLabelFrom,
			ColumnFuzzyLabelTo});

			groupBox.Text = "Правила вычисления тенденций";

			var buttonMakeRules = new Button
			{
				Anchor = AnchorStyles.Right,
				Location = new System.Drawing.Point(490, 3),
				Name = "buttonMakeRules",
				Size = new System.Drawing.Size(100, 23),
				TabIndex = 4,
				Text = "Сформировать",
				UseVisualStyleBackColor = true
			};
			buttonMakeRules.Click += new EventHandler(ButtonMakeRules_Click);

			panel.Controls.Add(buttonMakeRules);
		}

		protected override void LoadData()
		{
			int i = 0;
			foreach (var rule in _list)
			{
				dataGridView.Rows.Add();
				dataGridView.Rows[i].Cells[0].Value = rule.Id;
				dataGridView.Rows[i].Cells[1].Value = rule.FuzzyTrendName;
				dataGridView.Rows[i].Cells[2].Value = rule.FuzzyLabelFromName;
				dataGridView.Rows[i].Cells[3].Value = rule.FuzzyLabelToName;
				i++;
			}
		}

		private void ButtonMakeRules_Click(object sender, EventArgs e)
		{
			FormMakeRules form = new FormMakeRules(_parentId);
			if (form.ShowDialog() == DialogResult.OK)
				LoadData();
		}
	}
}
