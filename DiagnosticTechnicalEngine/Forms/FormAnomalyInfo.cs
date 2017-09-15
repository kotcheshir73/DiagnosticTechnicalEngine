using DatabaseModule;
using DiagnosticTechnicalEngine.StandartClasses;
using ServicesModule.BindingModels;
using ServicesModule.ViewModels;
using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DiagnosticTechnicalEngine.Forms
{
	public class FormAnomalyInfo : StandartForm<AnomalyInfoViewModel, AnomalyInfoBindingModel>
	{
		#region Контролы для работы
		private Label labelName;
		private Label labelSetSituation;
		private Label labelDescription;
		private Label labelType;
		private Label labelTypeMemory;
		private Label labelSetValues;
		private Label labelAnomalySituation;
		private TextBox textBoxName;
		private TextBox textBoxSetSituation;
		private TextBox textBoxDescription;
		private TextBox textBoxSetValues;
		private TextBox textBoxDesription;
		private TextBox textBoxAnomalySituation;
		private ComboBox comboBoxTypeSituation;
		private ComboBox comboBoxTypeMemory;
		private CheckBox checkBoxNotAnomaly;
		private CheckBox checkBoxNotDetected;
		private Chart chart;
		private TabPage tabPageMainInfo;
		private TabPage tabPageGraphic;
		private TabPage tabPageDescription;
		private TabControl tabControl;
		#endregion

		protected override void InitializeComponent()
		{
			base.InitializeComponent();
			SuspendLayout();
			labelName = new Label
			{
				AutoSize = true,
				Location = new System.Drawing.Point(6, 51),
				Name = "labelName",
				Size = new System.Drawing.Size(60, 13),
				TabIndex = 2,
				Text = "Название:"
			};
			labelSetSituation = new Label
			{
				AutoSize = true,
				Location = new System.Drawing.Point(6, 113),
				Name = "labelSetSituation",
				Size = new System.Drawing.Size(98, 13),
				TabIndex = 4,
				Text = "Набор состояний:"
			};
			labelDescription = new Label
			{
				AutoSize = true,
				Location = new System.Drawing.Point(332, 13),
				Name = "labelDescription",
				Size = new System.Drawing.Size(60, 13),
				TabIndex = 10,
				Text = "Описание:"
			};
			labelType = new Label
			{
				AutoSize = true,
				Location = new System.Drawing.Point(6, 13),
				Name = "labelType",
				Size = new System.Drawing.Size(158, 13),
				TabIndex = 0,
				Text = "К каким ситуациям относить:"
			};
			labelTypeMemory = new Label
			{
				AutoSize = true,
				Location = new System.Drawing.Point(6, 151),
				Name = "labelTypeMemory",
				Size = new System.Drawing.Size(132, 13),
				TabIndex = 6,
				Text = "Тип хранимых значений:"
			};
			labelSetValues = new Label
			{
				AutoSize = true,
				Location = new System.Drawing.Point(6, 190),
				Name = "labelSetValues",
				Size = new System.Drawing.Size(92, 13),
				TabIndex = 8,
				Text = "Набор значений:"
			};
			labelAnomalySituation = new Label
			{
				AutoSize = true,
				Location = new System.Drawing.Point(6, 80),
				Name = "labelAnomalySituation",
				Size = new System.Drawing.Size(158, 13),
				TabIndex = 15,
				Text = "Номер аномальной ситуации:"
			};
			textBoxName = new TextBox
			{
				Location = new System.Drawing.Point(110, 48),
				Name = "textBoxName",
				Size = new System.Drawing.Size(216, 20),
				TabIndex = 3
			};
			textBoxName.TextChanged += new EventHandler(TextBox_TextChanged);
			textBoxSetSituation = new TextBox
			{
				Location = new System.Drawing.Point(110, 110),
				MaxLength = 50,
				Name = "textBoxSetSituation",
				Size = new System.Drawing.Size(216, 20),
				TabIndex = 5
			};
			textBoxSetSituation.TextChanged += new EventHandler(TextBox_TextChanged);
			textBoxDescription = new TextBox
			{
				Location = new System.Drawing.Point(332, 32),
				Multiline = true,
				Name = "textBoxDescription",
				Size = new System.Drawing.Size(189, 175),
				TabIndex = 11
			};
			textBoxDescription.TextChanged += new EventHandler(TextBox_TextChanged);
			textBoxSetValues = new TextBox
			{
				Location = new System.Drawing.Point(110, 187),
				MaxLength = 50,
				Name = "textBoxSetValues",
				Size = new System.Drawing.Size(216, 20),
				TabIndex = 9
			};
			textBoxSetValues.TextChanged += new EventHandler(TextBox_TextChanged);
			textBoxAnomalySituation = new TextBox
			{
				Location = new System.Drawing.Point(170, 77),
				Name = "textBoxAnomalySituation",
				Size = new System.Drawing.Size(156, 20),
				TabIndex = 16
			};
			textBoxAnomalySituation.TextChanged += new EventHandler(TextBox_TextChanged);
			textBoxDesription = new TextBox
			{
				Dock = System.Windows.Forms.DockStyle.Fill,
				Location = new System.Drawing.Point(0, 0),
				Multiline = true,
				Name = "textBoxDesription",
				ReadOnly = true,
				Size = new System.Drawing.Size(536, 276),
				TabIndex = 0
			};
			textBoxDesription.TextChanged += new EventHandler(TextBox_TextChanged);
			comboBoxTypeSituation = new ComboBox
			{
				DropDownStyle = ComboBoxStyle.DropDownList,
				FormattingEnabled = true,
				Location = new System.Drawing.Point(170, 10),
				Name = "comboBoxTypeSituation",
				Size = new System.Drawing.Size(156, 21),
				TabIndex = 1
			};
			comboBoxTypeSituation.SelectedIndexChanged += new EventHandler(ComboBox_SelectedIndexChanged);
			comboBoxTypeMemory = new ComboBox
			{
				DropDownStyle = ComboBoxStyle.DropDownList,
				FormattingEnabled = true,
				Location = new System.Drawing.Point(170, 148),
				Name = "comboBoxTypeMemory",
				Size = new System.Drawing.Size(156, 21),
				TabIndex = 7
			};
			comboBoxTypeMemory.SelectedIndexChanged += new EventHandler(ComboBox_SelectedIndexChanged);
			checkBoxNotAnomaly = new CheckBox
			{
				AutoSize = true,
				CheckAlign = System.Drawing.ContentAlignment.TopCenter,
				Location = new System.Drawing.Point(26, 225),
				Name = "checkBoxNotAnomaly",
				Size = new System.Drawing.Size(78, 31),
				TabIndex = 14,
				Text = "Не аномалия",
				TextAlign = System.Drawing.ContentAlignment.TopCenter,
				UseVisualStyleBackColor = true
			};
			checkBoxNotAnomaly.CheckedChanged += new EventHandler(CheckBox_CheckedChanged);
			checkBoxNotDetected = new CheckBox
			{
				AutoSize = true,
				CheckAlign = System.Drawing.ContentAlignment.TopCenter,
				Location = new System.Drawing.Point(125, 225),
				Name = "checkBoxNotDetected",
				Size = new System.Drawing.Size(94, 31),
				TabIndex = 17,
				Text = "Не фиксируется",
				TextAlign = System.Drawing.ContentAlignment.TopCenter,
				UseVisualStyleBackColor = true
			};
			checkBoxNotDetected.CheckedChanged += new EventHandler(CheckBox_CheckedChanged);
			ChartArea chartArea = new ChartArea
			{
				Name = "ChartArea"
			};
			chartArea.AxisX.MajorGrid.Enabled = false;
			chartArea.AxisY.MajorGrid.Enabled = false;
			Series series = new Series
			{
				ChartArea = "ChartArea",
				ChartType = SeriesChartType.Line,
				IsValueShownAsLabel = true,
				MarkerBorderWidth = 2,
				MarkerSize = 8,
				MarkerStyle = MarkerStyle.Square,
				Name = "Series",
				XValueType = ChartValueType.Double,
				YValueType = ChartValueType.Int32
			};
			Title title = new Title
			{
				Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204))),
				Name = "Title",
				Text = "График аномалии"
			};
			chart = new Chart
			{
				Dock = DockStyle.Fill,
				Location = new System.Drawing.Point(3, 3),
				Name = "chart",
				Size = new System.Drawing.Size(530, 270),
				TabIndex = 2
			};
			chart.ChartAreas.Add(chartArea);
			chart.Series.Add(series);
			chart.Titles.Add(title);
			((System.ComponentModel.ISupportInitialize)(chart)).BeginInit();
			tabPageMainInfo = new TabPage
			{
				Location = new System.Drawing.Point(4, 22),
				Name = "tabPageMainInfo",
				Padding = new Padding(3),
				Size = new System.Drawing.Size(536, 276),
				TabIndex = 0,
				Text = "Основная информация",
				UseVisualStyleBackColor = true
			};
			tabPageMainInfo.SuspendLayout();
			tabPageMainInfo.Controls.Add(labelType);
			tabPageMainInfo.Controls.Add(buttonClose);
			tabPageMainInfo.Controls.Add(buttonSave);
			tabPageMainInfo.Controls.Add(checkBoxNotDetected);
			tabPageMainInfo.Controls.Add(labelName);
			tabPageMainInfo.Controls.Add(checkBoxNotAnomaly);
			tabPageMainInfo.Controls.Add(textBoxAnomalySituation);
			tabPageMainInfo.Controls.Add(textBoxName);
			tabPageMainInfo.Controls.Add(labelAnomalySituation);
			tabPageMainInfo.Controls.Add(labelDescription);
			tabPageMainInfo.Controls.Add(textBoxDescription);
			tabPageMainInfo.Controls.Add(labelSetSituation);
			tabPageMainInfo.Controls.Add(textBoxSetSituation);
			tabPageMainInfo.Controls.Add(textBoxSetValues);
			tabPageMainInfo.Controls.Add(comboBoxTypeSituation);
			tabPageMainInfo.Controls.Add(labelSetValues);
			tabPageMainInfo.Controls.Add(labelTypeMemory);
			tabPageMainInfo.Controls.Add(comboBoxTypeMemory);
			tabPageGraphic = new TabPage
			{
				Location = new System.Drawing.Point(4, 22),
				Name = "tabPageGraphic",
				Padding = new Padding(3),
				Size = new System.Drawing.Size(536, 276),
				TabIndex = 1,
				Text = "График",
				UseVisualStyleBackColor = true
			};
			tabPageGraphic.SuspendLayout();
			tabPageGraphic.Controls.Add(chart);
			tabPageDescription = new TabPage
			{
				Location = new System.Drawing.Point(4, 22),
				Name = "tabPageDescription",
				Size = new System.Drawing.Size(536, 276),
				TabIndex = 2,
				Text = "Описание ситуаций",
				UseVisualStyleBackColor = true
			};
			tabPageDescription.SuspendLayout();
			tabPageDescription.Controls.Add(textBoxDesription);
			tabControl = new TabControl
			{
				Dock = DockStyle.Fill,
				Location = new System.Drawing.Point(0, 0),
				Name = "tabControl1",
				SelectedIndex = 0,
				Size = new System.Drawing.Size(544, 302),
				TabIndex = 0
			};
			tabControl.SuspendLayout();
			tabControl.Controls.Add(tabPageMainInfo);
			tabControl.Controls.Add(tabPageDescription);
			tabControl.Controls.Add(tabPageGraphic);

			buttonSave.Location = new System.Drawing.Point(306, 230);
			buttonClose.Location = new System.Drawing.Point(433, 230);


			ClientSize = new System.Drawing.Size(544, 302);
			Controls.Add(tabControl);
			Name = "FormAnomalyInfo";
			Text = "Информация по аномалии";
			tabControl.ResumeLayout(false);
			tabPageMainInfo.ResumeLayout(false);
			tabPageMainInfo.PerformLayout();
			tabPageGraphic.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(chart)).EndInit();
			tabPageDescription.ResumeLayout(false);
			tabPageDescription.PerformLayout();
			ResumeLayout(false);
		}

		protected override void LoadComboBox()
		{
			foreach (var val in Enum.GetValues(typeof(TypeSituation)))
			{
				comboBoxTypeSituation.Items.Add(val.ToString());
			}
			comboBoxTypeSituation.SelectedIndex = 0;
			foreach (var val in Enum.GetValues(typeof(TypeMemoryValue)))
			{
				comboBoxTypeMemory.Items.Add(val.ToString());
			}
			comboBoxTypeMemory.SelectedIndex = 0;
		}

		protected override void LoadElement()
		{
			comboBoxTypeSituation.SelectedIndex = comboBoxTypeSituation.Items.IndexOf(_element.TypeSituation);
			textBoxName.Text = _element.AnomalyName;
			textBoxAnomalySituation.Text = _element.AnomalySituation.ToString();
			textBoxSetSituation.Text = _element.SetSituations;
			comboBoxTypeMemory.SelectedIndex = comboBoxTypeMemory.Items.IndexOf(_element.TypeMemoryValue);
			textBoxSetValues.Text = _element.SetValues;
			textBoxDescription.Text = _element.Description;
			checkBoxNotAnomaly.Checked = _element.NotAnomaly;
			checkBoxNotDetected.Checked = _element.NotDetected;
			comboBoxTypeSituation.Enabled = false;
			buttonSave.Enabled = false;

			textBoxDesription.Text = _element.Rashifrovka;

			switch (_element.TypeMemoryValue)
			{
				case TypeMemoryValue.ПоЗначению:
					chart.Titles["Title"].Text = "График аномалии " + _element.AnomalyName +
						" по значению точек ряда";
					break;
				case TypeMemoryValue.ПоФункции:
					chart.Titles["Title"].Text = "График аномалии " + _element.AnomalyName +
						" по функции принадлежности точек ряда";
					break;
			}
			for (int i = 0; i < _element.SetValues.Split(';').Length; ++i)
			{
				chart.Series["Series"].Points.AddXY(i, Convert.ToDouble(_element.SetValues.Split(';')[i]));
			}
		}

		protected override AnomalyInfoBindingModel GetUpdateedElement()
		{
			return new AnomalyInfoBindingModel
			{
				Id = _id.Value,
				SeriesDiscriptionId = _parentId,
				TypeSituation = comboBoxTypeSituation.Text,
				AnomalyName = textBoxName.Text,
				AnomalySituation =
				Convert.ToInt32(textBoxAnomalySituation.Text),
				SetSituations = textBoxSetSituation.Text,
				TypeMemoryValue = comboBoxTypeMemory.Text,
				SetValues = textBoxSetValues.Text,
				Description = textBoxDescription.Text,
				NotAnomaly = checkBoxNotAnomaly.Checked,
				NotDetected = checkBoxNotDetected.Checked
			};
		}
	}
}
