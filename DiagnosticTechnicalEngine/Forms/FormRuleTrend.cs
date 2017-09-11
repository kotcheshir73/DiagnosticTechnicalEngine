using DatabaseModule;
using DiagnosticTechnicalEngine.StandartClasses;
using ServicesModule;
using ServicesModule.BindingModels;
using ServicesModule.ViewModels;
using System;
using System.Linq;
using System.Windows.Forms;

namespace DiagnosticTechnicalEngine.Forms
{
	public class FormRuleTrend : StandartForm<RuleTrendViewModel, RuleTrendBindingModel>
	{
		private Label labelTrend;
		private Label labelFuzzyLabelFrom;
		private Label labelFuzzyLabelTo;
		private ComboBox comboBoxTrends;
		private ComboBox comboBoxFuzzyLabelFrom;
		private ComboBox comboBoxFuzzyLabelTo;

		protected override void InitializeComponent()
		{
			base.InitializeComponent();
			SuspendLayout();
			labelTrend = new Label
			{
				AutoSize = true,
				Location = new System.Drawing.Point(12, 9),
				Name = "labelTrend",
				Size = new System.Drawing.Size(65, 13),
				TabIndex = 0,
				Text = "Тенденция:"
			};
			labelFuzzyLabelFrom = new Label
			{
				AutoSize = true,
				Location = new System.Drawing.Point(12, 52),
				Name = "labelFuzzyLabelFrom",
				Size = new System.Drawing.Size(147, 13),
				TabIndex = 2,
				Text = "Нечеткая метка - источник:"
			};
			labelFuzzyLabelTo = new Label
			{
				AutoSize = true,
				Location = new System.Drawing.Point(12, 95),
				Name = "labelFuzzyLabelTo",
				Size = new System.Drawing.Size(151, 13),
				TabIndex = 4,
				Text = "Нечеткая метка - приемник:"
			};
			comboBoxTrends = new ComboBox
			{
				DropDownStyle = ComboBoxStyle.DropDownList,
				FormattingEnabled = true,
				Location = new System.Drawing.Point(83, 6),
				Name = "comboBoxTrends",
				Size = new System.Drawing.Size(250, 21),
				TabIndex = 1
			};
			comboBoxTrends.SelectedIndexChanged += new EventHandler(ComboBox_SelectedIndexChanged);
			comboBoxFuzzyLabelFrom = new ComboBox
			{
				DropDownStyle = ComboBoxStyle.DropDownList,
				FormattingEnabled = true,
				Location = new System.Drawing.Point(169, 49),
				Name = "comboBoxFuzzyLabelFrom",
				Size = new System.Drawing.Size(164, 21),
				TabIndex = 3
			};
			comboBoxFuzzyLabelFrom.SelectedIndexChanged += new EventHandler(ComboBox_SelectedIndexChanged);
			comboBoxFuzzyLabelTo = new ComboBox
			{
				DropDownStyle = ComboBoxStyle.DropDownList,
				FormattingEnabled = true,
				Location = new System.Drawing.Point(169, 92),
				Name = "comboBoxFuzzyLabelTo",
				Size = new System.Drawing.Size(164, 21),
				TabIndex = 5
			};
			comboBoxFuzzyLabelTo.SelectedIndexChanged += new EventHandler(ComboBox_SelectedIndexChanged);

			buttonSave.Location = new System.Drawing.Point(83, 129);
			buttonClose.Location = new System.Drawing.Point(210, 129);

			ClientSize = new System.Drawing.Size(344, 162);
			Controls.Add(labelTrend);
			Controls.Add(labelFuzzyLabelTo);
			Controls.Add(labelFuzzyLabelFrom);
			Controls.Add(comboBoxTrends);
			Controls.Add(comboBoxFuzzyLabelTo);
			Controls.Add(comboBoxFuzzyLabelFrom);
			Name = "FormRuleTrend";
			Text = "Правила вычилсения тенденции";
			ResumeLayout(false);
			PerformLayout();
		}

		protected override void LoadComboBox()
		{
			try
			{
				var trends = (new FuzzyTrendService()).GetElements(_parentId).ToList();
				comboBoxTrends.DataSource = trends.Select(t => new { Value = t.Id, Display = t.TrendName }).ToList();
				comboBoxTrends.ValueMember = "Value";
				comboBoxTrends.DisplayMember = "Display";

				var labels = (new FuzzyLabelService()).GetElements(_parentId);
				comboBoxFuzzyLabelFrom.DataSource = labels.Select(t => new { Value = t.Id, Display = t.FuzzyLabelName }).ToList();
				comboBoxFuzzyLabelFrom.ValueMember = "Value";
				comboBoxFuzzyLabelFrom.DisplayMember = "Display";
				comboBoxFuzzyLabelTo.DataSource = labels.Select(t => new { Value = t.Id, Display = t.FuzzyLabelName }).ToList();
				comboBoxFuzzyLabelTo.ValueMember = "Value";
				comboBoxFuzzyLabelTo.DisplayMember = "Display";
			}
			catch (Exception ex)
			{
				MessageBox.Show("Ошибка при загрузке: " + ex.Message, "Анализ временных рядов", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		protected override void LoadElement()
		{
			comboBoxTrends.SelectedValue = _element.FuzzyTrendId;
			comboBoxFuzzyLabelFrom.SelectedValue = _element.FuzzyLabelFromId;
			comboBoxFuzzyLabelTo.SelectedValue = _element.FuzzyLabelToId;
		}

		protected override RuleTrendBindingModel GetInsertedElement()
		{
			return new RuleTrendBindingModel
			{
				SeriesId = _parentId,
				FuzzyTrendId = Convert.ToInt32(comboBoxTrends.SelectedValue),
				FuzzyLabelFromId = Convert.ToInt32(comboBoxFuzzyLabelFrom.SelectedValue),
				FuzzyLabelToId = Convert.ToInt32(comboBoxFuzzyLabelTo.SelectedValue),
				FuzzyTrendName = Converter.ToFuzzyTrendLabel(comboBoxTrends.Text)
			};
		}

		protected override RuleTrendBindingModel GetUpdateedElement()
		{
			return new RuleTrendBindingModel
			{
				Id = _id.Value,
				SeriesId = _parentId,
				FuzzyTrendId = Convert.ToInt32(comboBoxTrends.SelectedValue),
				FuzzyLabelFromId = Convert.ToInt32(comboBoxFuzzyLabelFrom.SelectedValue),
				FuzzyLabelToId = Convert.ToInt32(comboBoxFuzzyLabelTo.SelectedValue),
				FuzzyTrendName = Converter.ToFuzzyTrendLabel(comboBoxTrends.Text)
			};
		}
	}
}
