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
		private Label labelType;
		private ComboBox comboBoxType;
		private TextBox textBoxName;
		private Label labelName;
		private Label labelWeight;
		private TextBox textBoxWeight;
		private TextBox textBoxMinVal;
		private Label labelMinVal;
		private TextBox textBoxCenter;
		private Label labelCenter;
		private TextBox textBoxMaxVal;
		private Label labelMaxVal;

		protected override void InitializeComponent()
		{
			base.InitializeComponent();
			labelType = new Label();
			comboBoxType = new ComboBox();
			textBoxName = new TextBox();
			labelName = new Label();
			labelWeight = new Label();
			textBoxWeight = new TextBox();
			textBoxMinVal = new TextBox();
			labelMinVal = new Label();
			textBoxCenter = new TextBox();
			labelCenter = new Label();
			textBoxMaxVal = new TextBox();
			labelMaxVal = new Label();
			buttonClose = new Button();
			buttonSave = new Button();
			SuspendLayout();
			// 
			// labelType
			// 
			labelType.AutoSize = true;
			labelType.Location = new System.Drawing.Point(12, 9);
			labelType.Name = "labelType";
			labelType.Size = new System.Drawing.Size(63, 13);
			labelType.TabIndex = 0;
			labelType.Text = "Тип метки:";
			// 
			// comboBoxType
			// 
			comboBoxType.DropDownStyle = ComboBoxStyle.DropDownList;
			comboBoxType.FormattingEnabled = true;
			comboBoxType.Location = new System.Drawing.Point(81, 6);
			comboBoxType.Name = "comboBoxType";
			comboBoxType.Size = new System.Drawing.Size(250, 21);
			comboBoxType.TabIndex = 1;
			comboBoxType.SelectedIndexChanged += new EventHandler(ComboBoxType_SelectedIndexChanged);
			// 
			// textBoxName
			// 
			textBoxName.Location = new System.Drawing.Point(81, 43);
			textBoxName.MaxLength = 50;
			textBoxName.Name = "textBoxName";
			textBoxName.Size = new System.Drawing.Size(250, 20);
			textBoxName.TabIndex = 3;
			textBoxName.TextChanged += new EventHandler(TextBox_TextChanged);
			// 
			// labelName
			// 
			labelName.AutoSize = true;
			labelName.Location = new System.Drawing.Point(12, 46);
			labelName.Name = "labelName";
			labelName.Size = new System.Drawing.Size(60, 13);
			labelName.TabIndex = 2;
			labelName.Text = "Название:";
			// 
			// labelWeight
			// 
			labelWeight.AutoSize = true;
			labelWeight.Location = new System.Drawing.Point(12, 85);
			labelWeight.Name = "labelWeight";
			labelWeight.Size = new System.Drawing.Size(29, 13);
			labelWeight.TabIndex = 4;
			labelWeight.Text = "Вес:";
			// 
			// textBoxWeight
			// 
			textBoxWeight.Location = new System.Drawing.Point(81, 82);
			textBoxWeight.MaxLength = 4;
			textBoxWeight.Name = "textBoxWeight";
			textBoxWeight.Size = new System.Drawing.Size(50, 20);
			textBoxWeight.TabIndex = 5;
			textBoxWeight.TextAlign = HorizontalAlignment.Right;
			textBoxWeight.TextChanged += new EventHandler(TextBox_TextChanged);
			// 
			// textBoxMinVal
			// 
			textBoxMinVal.Location = new System.Drawing.Point(155, 121);
			textBoxMinVal.MaxLength = 10;
			textBoxMinVal.Name = "textBoxMinVal";
			textBoxMinVal.Size = new System.Drawing.Size(50, 20);
			textBoxMinVal.TabIndex = 7;
			textBoxMinVal.TextAlign = HorizontalAlignment.Right;
			textBoxMinVal.TextChanged += new EventHandler(TextBox_TextChanged);
			// 
			// labelMinVal
			// 
			labelMinVal.AutoSize = true;
			labelMinVal.Location = new System.Drawing.Point(12, 124);
			labelMinVal.Name = "labelMinVal";
			labelMinVal.Size = new System.Drawing.Size(131, 13);
			labelMinVal.TabIndex = 6;
			labelMinVal.Text = "Минимальное значение:";
			// 
			// textBoxCenter
			// 
			textBoxCenter.Location = new System.Drawing.Point(257, 82);
			textBoxCenter.MaxLength = 10;
			textBoxCenter.Name = "textBoxCenter";
			textBoxCenter.Size = new System.Drawing.Size(50, 20);
			textBoxCenter.TabIndex = 9;
			textBoxCenter.TextAlign = HorizontalAlignment.Right;
			textBoxCenter.TextChanged += new EventHandler(TextBox_TextChanged);
			// 
			// labelCenter
			// 
			labelCenter.AutoSize = true;
			labelCenter.Location = new System.Drawing.Point(210, 85);
			labelCenter.Name = "labelCenter";
			labelCenter.Size = new System.Drawing.Size(41, 13);
			labelCenter.TabIndex = 8;
			labelCenter.Text = "Центр:";
			// 
			// textBoxMaxVal
			// 
			textBoxMaxVal.Location = new System.Drawing.Point(155, 156);
			textBoxMaxVal.MaxLength = 10;
			textBoxMaxVal.Name = "textBoxMaxVal";
			textBoxMaxVal.Size = new System.Drawing.Size(50, 20);
			textBoxMaxVal.TabIndex = 11;
			textBoxMaxVal.TextAlign = HorizontalAlignment.Right;
			textBoxMaxVal.TextChanged += new EventHandler(TextBox_TextChanged);
			// 
			// labelMaxVal
			// 
			labelMaxVal.AutoSize = true;
			labelMaxVal.Location = new System.Drawing.Point(12, 159);
			labelMaxVal.Name = "labelMaxVal";
			labelMaxVal.Size = new System.Drawing.Size(137, 13);
			labelMaxVal.TabIndex = 10;
			labelMaxVal.Text = "Максимальное значение:";
			// 
			// buttonClose
			// 
			buttonClose.Location = new System.Drawing.Point(196, 187);
			// 
			// buttonSave
			// 
			buttonSave.Location = new System.Drawing.Point(69, 187);
			// 
			// FormFuzzyLabel
			// 
			Controls.Add(textBoxMaxVal);
			Controls.Add(labelMaxVal);
			Controls.Add(textBoxCenter);
			Controls.Add(labelCenter);
			Controls.Add(textBoxMinVal);
			Controls.Add(labelMinVal);
			Controls.Add(textBoxWeight);
			Controls.Add(labelWeight);
			Controls.Add(textBoxName);
			Controls.Add(labelName);
			Controls.Add(comboBoxType);
			Controls.Add(labelType);
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
			comboBoxType.SelectedIndex = comboBoxType.Items.IndexOf(_element.FuzzyLabelType);
			comboBoxType.Enabled = false;
			textBoxName.Text = _element.FuzzyLabelName;
			textBoxWeight.Text = _element.FuzzyLabelWeight.ToString();
			textBoxMinVal.Text = _element.FuzzyLabelMinVal.ToString();
			textBoxCenter.Text = _element.FuzzyLabelCenter.ToString();
			textBoxMaxVal.Text = _element.FuzzyLabelMaxVal.ToString();
			buttonSave.Enabled = false;
		}

		protected override FuzzyLabelBindingModel GetInsertedElement()
		{
			return new FuzzyLabelBindingModel
			{
				SeriesId = _seriesId,
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
				SeriesId = _seriesId,
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
