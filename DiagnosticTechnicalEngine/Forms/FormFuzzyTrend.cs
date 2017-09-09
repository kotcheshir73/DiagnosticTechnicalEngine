using DatabaseModule;
using DiagnosticTechnicalEngine.StandartClasses;
using ServicesModule.BindingModels;
using ServicesModule.ViewModels;
using System;
using System.Windows.Forms;

namespace DiagnosticTechnicalEngine.Forms
{
	public class FormFuzzyTrend : StandartForm<FuzzyTrendViewModel, FuzzyTrendBindingModel>
	{
		private Label labelName;
		private Label labelWeight;
		private ComboBox comboBoxTrendNames;
		private TextBox textBoxWeight;

		protected override void InitializeComponent()
		{
			base.InitializeComponent();
			SuspendLayout();
			labelName = new Label
			{
				AutoSize = true,
				Location = new System.Drawing.Point(12, 9),
				Name = "labelName",
				Size = new System.Drawing.Size(60, 13),
				TabIndex = 0,
				Text = "Название:"
			};
			labelWeight = new Label
			{
				AutoSize = true,
				Location = new System.Drawing.Point(12, 48),
				Name = "labelWeight",
				Size = new System.Drawing.Size(29, 13),
				TabIndex = 2,
				Text = "Вес:"
			};
			comboBoxTrendNames = new ComboBox
			{
				DropDownStyle = ComboBoxStyle.DropDownList,
				FormattingEnabled = true,
				Location = new System.Drawing.Point(78, 6),
				Name = "comboBoxTrendNames",
				Size = new System.Drawing.Size(250, 21),
				TabIndex = 1
			};
			textBoxWeight = new TextBox
			{
				Location = new System.Drawing.Point(81, 45),
				MaxLength = 4,
				Name = "textBoxWeight",
				Size = new System.Drawing.Size(50, 20),
				TabIndex = 3,
				TextAlign = HorizontalAlignment.Right
			};
			textBoxWeight.TextChanged += new EventHandler(TextBox_TextChanged);

			buttonSave.Location = new System.Drawing.Point(90, 82);
			buttonClose.Location = new System.Drawing.Point(217, 82);


			ClientSize = new System.Drawing.Size(344, 122);
			Controls.Add(labelName);
			Controls.Add(labelWeight);
			Controls.Add(comboBoxTrendNames);
			Controls.Add(textBoxWeight);
			Name = "FormFuzzyTrend";
			Text = "Нечеткая тенденция";
			ResumeLayout(false);
			PerformLayout();
		}

		protected override void LoadComboBox()
		{
			foreach (var elem in Enum.GetValues(typeof(FuzzyTrendLabel)))
			{
				comboBoxTrendNames.Items.Add(elem.ToString());
			}
			comboBoxTrendNames.SelectedIndex = 0;
		}

		protected override void LoadElement()
		{
			base.LoadElement();
			if(_element != null)
			{
				comboBoxTrendNames.SelectedIndex = comboBoxTrendNames.Items.IndexOf(_element.TrendName);
				comboBoxTrendNames.Enabled = false;
				textBoxWeight.Text = _element.Weight.ToString();
				buttonSave.Enabled = false;
			}
		}

		protected override FuzzyTrendBindingModel GetInsertedElement()
		{
			return new FuzzyTrendBindingModel
			{
				SeriesId = _parentId,
				TrendName = Converter.ToFuzzyTrendLabel(comboBoxTrendNames.Text),
				Weight = Convert.ToInt32(textBoxWeight.Text)
			};
		}

		protected override FuzzyTrendBindingModel GetUpdateedElement()
		{
			return new FuzzyTrendBindingModel
			{
				Id = _id.Value,
				SeriesId = _parentId,
				TrendName = Converter.ToFuzzyTrendLabel(comboBoxTrendNames.Text),
				Weight = Convert.ToInt32(textBoxWeight.Text)
			};
		}
	}
}
