using DiagnosticTechnicalEngine.StandartClasses;
using DTE_Interface_Level.BindingModels;
using DTE_Interface_Level.ViewModels;
using System;
using System.Windows.Forms;

namespace DiagnosticTechnicalEngine.Forms
{
    public class FormPointTrend : StandartForm<PointTrendViewModel, PointTrendBindingModel>
	{
		private Label labelStartPoint;
		private Label labelFinishPoint;
		private Label labelCount;
		private Label labelWeight;
		private TextBox textBoxStartPoint;
		private TextBox textBoxFinishPoint;
		private TextBox textBoxCount;
		private TextBox textBoxWeight;

		protected override void InitializeComponent()
		{
			base.InitializeComponent();
			SuspendLayout();
			labelStartPoint = new Label
			{
				AutoSize = true,
				Location = new System.Drawing.Point(12, 9),
				Name = "labelStartPoint",
				Size = new System.Drawing.Size(96, 13),
				TabIndex = 0,
				Text = "Начальная точка:"
			};
			labelFinishPoint = new Label
			{
				AutoSize = true,
				Location = new System.Drawing.Point(186, 9),
				Name = "labelFinishPoint",
				Size = new System.Drawing.Size(89, 13),
				TabIndex = 2,
				Text = "Конечная точка:"
			};
			labelCount = new Label
			{
				AutoSize = true,
				Location = new System.Drawing.Point(12, 43),
				Name = "labelCount",
				Size = new System.Drawing.Size(100, 13),
				TabIndex = 4,
				Text = "Количство встреч:"
			};
			labelWeight = new Label
			{
				AutoSize = true,
				Location = new System.Drawing.Point(186, 43),
				Name = "labelWeight",
				Size = new System.Drawing.Size(29, 13),
				TabIndex = 6,
				Text = "Вес:"
			};
			textBoxStartPoint = new TextBox
			{
				Location = new System.Drawing.Point(118, 6),
				Name = "textBoxStartPoint",
				ReadOnly = true,
				Size = new System.Drawing.Size(47, 20),
				TabIndex = 1
			};
			textBoxStartPoint.TextChanged += new EventHandler(TextBox_TextChanged);
			textBoxFinishPoint = new TextBox
			{
				Location = new System.Drawing.Point(288, 6),
				Name = "textBoxFinishPoint",
				ReadOnly = true,
				Size = new System.Drawing.Size(47, 20),
				TabIndex = 3
			};
			textBoxFinishPoint.TextChanged += new EventHandler(TextBox_TextChanged);
			textBoxCount = new TextBox
			{
				Location = new System.Drawing.Point(118, 40),
				Name = "textBoxCount",
				ReadOnly = true,
				Size = new System.Drawing.Size(47, 20),
				TabIndex = 5
			};
			textBoxCount.TextChanged += new EventHandler(TextBox_TextChanged);
			textBoxWeight = new TextBox
			{
				Location = new System.Drawing.Point(288, 40),
				Name = "textBoxWeight",
				Size = new System.Drawing.Size(47, 20),
				TabIndex = 7
			};
			textBoxWeight.TextChanged += new EventHandler(TextBox_TextChanged); 

			buttonSave.Location = new System.Drawing.Point(72, 83);
			buttonClose.Location = new System.Drawing.Point(199, 83);


			ClientSize = new System.Drawing.Size(355, 121);
			Controls.Add(labelStartPoint);
			Controls.Add(labelFinishPoint);
			Controls.Add(labelCount);
			Controls.Add(labelWeight);
			Controls.Add(textBoxStartPoint);
			Controls.Add(textBoxFinishPoint);
			Controls.Add(textBoxCount);
			Controls.Add(textBoxWeight);
			Name = "FormPointTrend";
			Text = "Правило смены точек на фазовом простарнстве";
			ResumeLayout(false);
			PerformLayout();
		}

		protected override void LoadElement()
		{
			textBoxStartPoint.Text = _element.StartPoint.ToString();
			textBoxFinishPoint.Text = _element.FinishPoint.ToString();
			textBoxCount.Text = _element.Count.ToString();
			textBoxWeight.Text = _element.Weight.ToString();
		}

		protected override PointTrendBindingModel GetInsertedElement()
		{
			return new PointTrendBindingModel
			{
				SeriesId = _parentId,
				StartPoint = Convert.ToInt32(textBoxStartPoint.Text),
				FinishPoint = Convert.ToInt32(textBoxFinishPoint.Text),
				Count = Convert.ToInt32(textBoxCount.Text),
				Weight = Convert.ToDouble(textBoxWeight.Text)
			};
		}

		protected override PointTrendBindingModel GetUpdateedElement()
		{
			return new PointTrendBindingModel
			{
				Id = _id.Value,
				SeriesId = _parentId,
				StartPoint = Convert.ToInt32(textBoxStartPoint.Text),
				FinishPoint = Convert.ToInt32(textBoxFinishPoint.Text),
				Count = Convert.ToInt32(textBoxCount.Text),
				Weight = Convert.ToDouble(textBoxWeight.Text)
			};
		}
	}
}
