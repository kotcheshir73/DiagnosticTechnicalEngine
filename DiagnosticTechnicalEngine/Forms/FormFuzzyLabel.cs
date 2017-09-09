using DatabaseModule;
using DiagnosticTechnicalEngine.StandartClasses;
using ServicesModule.BindingModels;
using ServicesModule.ViewModels;
using System;
using System.Windows.Forms;

namespace DiagnosticTechnicalEngine.Forms
{
	public class FormFuzzyLabel : StandartForm<FuzzyLabelViewModel, FuzzyLabelBindingModel>
	{
		#region Контролы для работы с нечеькой меткой
		private Label labelType;
		private Label labelName;
		private Label labelWeight;
		private Label labelMinVal;
		private Label labelCenter;
		private Label labelMaxVal;
		private ComboBox comboBoxType;
		private TextBox textBoxName;
		private TextBox textBoxWeight;
		private TextBox textBoxMinVal;
		private TextBox textBoxCenter;
		private TextBox textBoxMaxVal;
		#endregion

		protected override void InitializeComponent()
		{
			base.InitializeComponent();
			SuspendLayout();
			labelType = new Label
			{
				AutoSize = true,
				Location = new System.Drawing.Point(12, 9),
				Name = "labelType",
				Size = new System.Drawing.Size(63, 13),
				TabIndex = 0,
				Text = "Тип метки:"
			};
			labelName = new Label
			{
				AutoSize = true,
				Location = new System.Drawing.Point(12, 46),
				Name = "labelName",
				Size = new System.Drawing.Size(60, 13),
				TabIndex = 2,
				Text = "Название:"
			};
			labelWeight = new Label
			{
				AutoSize = true,
				Location = new System.Drawing.Point(12, 85),
				Name = "labelWeight",
				Size = new System.Drawing.Size(29, 13),
				TabIndex = 4,
				Text = "Вес:"
			};
			labelMinVal = new Label
			{
				AutoSize = true,
				Location = new System.Drawing.Point(12, 124),
				Name = "labelMinVal",
				Size = new System.Drawing.Size(131, 13),
				TabIndex = 6,
				Text = "Минимальное значение:"
			};
			labelCenter = new Label
			{
				AutoSize = true,
				Location = new System.Drawing.Point(210, 85),
				Name = "labelCenter",
				Size = new System.Drawing.Size(41, 13),
				TabIndex = 8,
				Text = "Центр:"
			};
			labelMaxVal = new Label
			{
				AutoSize = true,
				Location = new System.Drawing.Point(12, 159),
				Name = "labelMaxVal",
				Size = new System.Drawing.Size(137, 13),
				TabIndex = 10,
				Text = "Максимальное значение:"
			};

			comboBoxType = new ComboBox
			{
				DropDownStyle = ComboBoxStyle.DropDownList,
				FormattingEnabled = true,
				Location = new System.Drawing.Point(81, 6),
				Name = "comboBoxType",
				Size = new System.Drawing.Size(250, 21),
				TabIndex = 1
			};
			comboBoxType.SelectedIndexChanged += new EventHandler(ComboBox_SelectedIndexChanged);
			textBoxName = new TextBox
			{
				Location = new System.Drawing.Point(81, 43),
				MaxLength = 50,
				Name = "textBoxName",
				Size = new System.Drawing.Size(250, 20),
				TabIndex = 3
			};
			textBoxName.TextChanged += new EventHandler(TextBox_TextChanged);
			textBoxWeight = new TextBox
			{
				Location = new System.Drawing.Point(81, 82),
				MaxLength = 4,
				Name = "textBoxWeight",
				Size = new System.Drawing.Size(50, 20),
				TabIndex = 5,
				TextAlign = HorizontalAlignment.Right
			};
			textBoxWeight.TextChanged += new EventHandler(TextBox_TextChanged);
			textBoxMinVal = new TextBox
			{
				Location = new System.Drawing.Point(155, 121),
				MaxLength = 10,
				Name = "textBoxMinVal",
				Size = new System.Drawing.Size(50, 20),
				TabIndex = 7,
				TextAlign = HorizontalAlignment.Right
			};
			textBoxMinVal.TextChanged += new EventHandler(TextBox_TextChanged);
			textBoxCenter = new TextBox
			{
				Location = new System.Drawing.Point(257, 82),
				MaxLength = 10,
				Name = "textBoxCenter",
				Size = new System.Drawing.Size(50, 20),
				TabIndex = 9,
				TextAlign = HorizontalAlignment.Right
			};
			textBoxCenter.TextChanged += new EventHandler(TextBox_TextChanged);
			textBoxMaxVal = new TextBox
			{
				Location = new System.Drawing.Point(155, 156),
				MaxLength = 10,
				Name = "textBoxMaxVal",
				Size = new System.Drawing.Size(50, 20),
				TabIndex = 11,
				TextAlign = HorizontalAlignment.Right
			};
			textBoxMaxVal.TextChanged += new EventHandler(TextBox_TextChanged);

			buttonSave.Location = new System.Drawing.Point(69, 187);
			buttonClose.Location = new System.Drawing.Point(196, 187);


			ClientSize = new System.Drawing.Size(344, 222);
			Controls.Add(labelType);
			Controls.Add(labelName);
			Controls.Add(labelWeight);
			Controls.Add(labelMinVal);
			Controls.Add(labelCenter);
			Controls.Add(labelMaxVal);
			Controls.Add(comboBoxType);
			Controls.Add(textBoxName);
			Controls.Add(textBoxWeight);
			Controls.Add(textBoxMinVal);
			Controls.Add(textBoxCenter);
			Controls.Add(textBoxMaxVal);
			Name = "FormFuzzyLabel";
			Text = "Нечеткая метка";
			ResumeLayout(false);
			PerformLayout();
		}

		protected override void LoadComboBox()
		{
			foreach (var elem in Enum.GetValues(typeof(FuzzyLabelType)))
			{
				comboBoxType.Items.Add(elem.ToString());
			}
			comboBoxType.SelectedIndex = 0;
		}

		protected override void LoadElement()
		{
			base.LoadElement();
			if (_element != null)
			{
				comboBoxType.SelectedIndex = comboBoxType.Items.IndexOf(_element.FuzzyLabelType);
				comboBoxType.Enabled = false;
				textBoxName.Text = _element.FuzzyLabelName;
				textBoxWeight.Text = _element.FuzzyLabelWeight.ToString();
				textBoxMinVal.Text = _element.FuzzyLabelMinVal.ToString();
				textBoxCenter.Text = _element.FuzzyLabelCenter.ToString();
				textBoxMaxVal.Text = _element.FuzzyLabelMaxVal.ToString();
				buttonSave.Enabled = false;
			}
		}

		protected override FuzzyLabelBindingModel GetInsertedElement()
		{
			return new FuzzyLabelBindingModel
			{
				SeriesId = _parentId,
				FuzzyLabelType = Converter.ToFuzzyLabelType(comboBoxType.Text),
				FuzzyLabelName = textBoxName.Text,
				Weigth = Convert.ToInt32(textBoxWeight.Text),
				MinVal = Convert.ToDouble(textBoxMinVal.Text),
				Center = Convert.ToDouble(textBoxCenter.Text),
				MaxVal = Convert.ToDouble(textBoxMaxVal.Text)
			};
		}

		protected override FuzzyLabelBindingModel GetUpdateedElement()
		{
			return new FuzzyLabelBindingModel
			{
				Id = _id.Value,
				SeriesId = _parentId,
				FuzzyLabelType = Converter.ToFuzzyLabelType(comboBoxType.Text),
				FuzzyLabelName = textBoxName.Text,
				Weigth = Convert.ToInt32(textBoxWeight.Text),
				MinVal = Convert.ToDouble(textBoxMinVal.Text),
				Center = Convert.ToDouble(textBoxCenter.Text),
				MaxVal = Convert.ToDouble(textBoxMaxVal.Text)
			};
		}
	}
}
