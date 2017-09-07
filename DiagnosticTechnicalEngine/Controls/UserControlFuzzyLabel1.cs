using DiagnosticTechnicalEngine.StandartClasses;
using ServicesModule.BindingModels;
using ServicesModule.ViewModels;
using System;
using System.Windows.Forms;

namespace DiagnosticTechnicalEngine.Controls
{
	public class UserControlFuzzyLabel1 : StandartControl<FuzzyLabelViewModel, FuzzyLabelBindingModel>
	{
		private DataGridViewTextBoxColumn ColumnId;
		private DataGridViewTextBoxColumn ColumnType;
		private DataGridViewTextBoxColumn ColumnName;
		private DataGridViewTextBoxColumn ColumnWeight;
		private DataGridViewTextBoxColumn ColumnMinVal;
		private DataGridViewTextBoxColumn ColumnCenter;
		private DataGridViewTextBoxColumn ColumnMaxVal;

		protected override void InitializeComponent()
		{
			base.InitializeComponent();
			ColumnId = new DataGridViewTextBoxColumn();
			ColumnType = new DataGridViewTextBoxColumn();
			ColumnName = new DataGridViewTextBoxColumn();
			ColumnWeight = new DataGridViewTextBoxColumn();
			ColumnMinVal = new DataGridViewTextBoxColumn();
			ColumnCenter = new DataGridViewTextBoxColumn();
			ColumnMaxVal = new DataGridViewTextBoxColumn();
			// 
			// ColumnId
			// 
			ColumnId.HeaderText = "ColumnId";
			ColumnId.Name = "ColumnId";
			ColumnId.ReadOnly = true;
			ColumnId.Visible = false;
			// 
			// ColumnType
			// 
			ColumnType.HeaderText = "Тип";
			ColumnType.Name = "ColumnType";
			ColumnType.ReadOnly = true;
			ColumnType.Width = 150;
			// 
			// ColumnName
			// 
			ColumnName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			ColumnName.HeaderText = "Название";
			ColumnName.Name = "ColumnName";
			ColumnName.ReadOnly = true;
			// 
			// ColumnWeight
			// 
			ColumnWeight.HeaderText = "Вес";
			ColumnWeight.Name = "ColumnWeight";
			ColumnWeight.ReadOnly = true;
			ColumnWeight.Width = 50;
			// 
			// ColumnMinVal
			// 
			ColumnMinVal.HeaderText = "Мин";
			ColumnMinVal.Name = "ColumnMinVal";
			ColumnMinVal.ReadOnly = true;
			ColumnMinVal.Width = 50;
			// 
			// ColumnCenter
			// 
			ColumnCenter.HeaderText = "Центр";
			ColumnCenter.Name = "ColumnCenter";
			ColumnCenter.ReadOnly = true;
			ColumnCenter.Width = 50;
			// 
			// ColumnMaxVal
			// 
			ColumnMaxVal.HeaderText = "Макс";
			ColumnMaxVal.Name = "ColumnMaxVal";
			ColumnMaxVal.ReadOnly = true;
			ColumnMaxVal.Width = 50;


			dataGridView.Columns.AddRange(new DataGridViewColumn[] {
			ColumnId,
			ColumnType,
			ColumnName,
			ColumnWeight,
			ColumnMinVal,
			ColumnCenter,
			ColumnMaxVal});

			groupBox.Text = "Нечеткие метки";

			// 
			// buttonClustreing
			// 
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
			base.LoadData();
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
			Forms.FormClustering form = new Forms.FormClustering(_seriesId);
			if (form.ShowDialog() == DialogResult.OK)
				LoadData();
		}
	}
}
