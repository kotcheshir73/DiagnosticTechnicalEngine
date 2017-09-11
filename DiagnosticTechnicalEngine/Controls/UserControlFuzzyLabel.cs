using DiagnosticTechnicalEngine.Forms;
using DiagnosticTechnicalEngine.StandartClasses;
using ServicesModule.BindingModels;
using ServicesModule.ViewModels;
using System;
using System.Windows.Forms;

namespace DiagnosticTechnicalEngine.Controls
{
	public class UserControlFuzzyLabel : StandartControl<FuzzyLabelViewModel, FuzzyLabelBindingModel, FormFuzzyLabel>
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
			var ColumnType = new DataGridViewTextBoxColumn
			{
				HeaderText = "Тип",
				Name = "ColumnType",
				ReadOnly = true,
				Width = 150
			};
			var ColumnName = new DataGridViewTextBoxColumn
			{
				AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
				HeaderText = "Название",
				Name = "ColumnName",
				ReadOnly = true
			};
			var ColumnWeight = new DataGridViewTextBoxColumn
			{
				HeaderText = "Вес",
				Name = "ColumnWeight",
				ReadOnly = true,
				Width = 50
			};
			var ColumnMinVal = new DataGridViewTextBoxColumn
			{
				HeaderText = "Мин",
				Name = "ColumnMinVal",
				ReadOnly = true,
				Width = 50
			};
			var ColumnCenter = new DataGridViewTextBoxColumn
			{
				HeaderText = "Центр",
				Name = "ColumnCenter",
				ReadOnly = true,
				Width = 50
			};
			var ColumnMaxVal = new DataGridViewTextBoxColumn
			{
				HeaderText = "Макс",
				Name = "ColumnMaxVal",
				ReadOnly = true,
				Width = 50
			};

			dataGridView.Columns.AddRange(new DataGridViewColumn[] {
			ColumnId,
			ColumnType,
			ColumnName,
			ColumnWeight,
			ColumnMinVal,
			ColumnCenter,
			ColumnMaxVal});

			groupBox.Text = "Нечеткие метки";
			
			var buttonClustreing = new Button
			{
				Anchor = AnchorStyles.Right,
				Location = new System.Drawing.Point(490, 3),
				Name = "buttonClustreing",
				Size = new System.Drawing.Size(100, 23),
				TabIndex = 5,
				Text = "Кластеризация",
				UseVisualStyleBackColor = true
			};
			buttonClustreing.Click += new EventHandler(ButtonClustreing_Click);

			panel.Controls.Add(buttonClustreing);
		}

		protected override void LoadData()
		{
			int i = 0;
			foreach (var label in _list)
			{
				dataGridView.Rows.Add();
				dataGridView.Rows[i].Cells[0].Value = label.Id;
				dataGridView.Rows[i].Cells[1].Value = label.FuzzyLabelType;
				dataGridView.Rows[i].Cells[2].Value = label.FuzzyLabelName;
				dataGridView.Rows[i].Cells[3].Value = label.FuzzyLabelWeight;
				dataGridView.Rows[i].Cells[4].Value = label.FuzzyLabelMinVal;
				dataGridView.Rows[i].Cells[5].Value = label.FuzzyLabelCenter;
				dataGridView.Rows[i].Cells[6].Value = label.FuzzyLabelMaxVal;
				i++;
			}
		}

		private void ButtonClustreing_Click(object sender, EventArgs e)
		{
			Forms.FormClustering form = new Forms.FormClustering(_parentId);
			if (form.ShowDialog() == DialogResult.OK)
				LoadData();
		}
	}
}
