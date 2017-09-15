using DiagnosticTechnicalEngine.StandartClasses;
using ServicesModule.BindingModels;
using ServicesModule.ViewModels;
using System;
using System.Windows.Forms;

namespace DiagnosticTechnicalEngine.Forms
{
	public class FormSeriesDescription : StandartForm<SeriesDescriptionViewModel, SeriesDescriptionBindingModel>
	{
		#region Контролы для работы
		private Label labelName;
		private Label labelDescription;
		private TextBox textBoxName;
		private TextBox textBoxDescription;
		private CheckBox checkBoxNeedForecast;
		#endregion

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
			labelDescription = new Label
			{
				AutoSize = true,
				Location = new System.Drawing.Point(12, 46),
				Name = "labelDescription",
				Size = new System.Drawing.Size(60, 13),
				TabIndex = 2,
				Text = "Описание:"
			};
			textBoxName = new TextBox
			{
				Location = new System.Drawing.Point(78, 6),
				MaxLength = 50,
				Name = "textBoxName",
				Size = new System.Drawing.Size(250, 20),
				TabIndex = 1
			};
			textBoxName.TextChanged += new EventHandler(TextBox_TextChanged);
			textBoxDescription = new TextBox
			{
				Location = new System.Drawing.Point(78, 43),
				Multiline = true,
				Name = "textBoxDescription",
				Size = new System.Drawing.Size(250, 130),
				TabIndex = 3
			};
			textBoxDescription.TextChanged += new EventHandler(TextBox_TextChanged);
			checkBoxNeedForecast = new CheckBox
			{
				AutoSize = true,
				Location = new System.Drawing.Point(94, 184),
				Name = "checkBoxNeedForecast",
				Size = new System.Drawing.Size(103, 17),
				TabIndex = 4,
				Text = "Нужен прогноз",
				UseVisualStyleBackColor = true
			};
			checkBoxNeedForecast.CheckedChanged += new EventHandler(CheckBox_CheckedChanged);

			buttonSave.Location = new System.Drawing.Point(94, 219);
			buttonClose.Location = new System.Drawing.Point(221, 219);

			ClientSize = new System.Drawing.Size(344, 254);
			Controls.Add(checkBoxNeedForecast);
			Controls.Add(textBoxDescription);
			Controls.Add(labelDescription);
			Controls.Add(textBoxName);
			Controls.Add(labelName);
			Name = "FormSeriesDescription";
			Text = "Описание временного ряда";
			ResumeLayout(false);
			PerformLayout();
		}

		protected override void LoadElement()
		{
			textBoxName.Text = _element.SeriesName;
			textBoxDescription.Text = _element.SeriesDiscription;
			checkBoxNeedForecast.Checked = _element.NeedForecast;
			buttonSave.Enabled = false;
		}

		protected override SeriesDescriptionBindingModel GetInsertedElement()
		{
			return new SeriesDescriptionBindingModel
			{
				SeriesName = textBoxName.Text,
				SeriesDiscription = textBoxDescription.Text,
				NeedForecast = checkBoxNeedForecast.Checked
			};
		}

		protected override SeriesDescriptionBindingModel GetUpdateedElement()
		{
			return new SeriesDescriptionBindingModel
			{
				Id = _id.Value,
				SeriesName = textBoxName.Text,
				SeriesDiscription = textBoxDescription.Text,
				NeedForecast = checkBoxNeedForecast.Checked
			};
		}
	}
}
