using DiagnosticTechnicalEngine.Forms;
using DiagnosticTechnicalEngine.StandartClasses;
using ServicesModule.BindingModels;
using ServicesModule.ViewModels;
using System;
using System.Windows.Forms;

namespace DiagnosticTechnicalEngine.Controls
{
	public class UserControlPountTrend : StandartControl<PointTrendViewModel, PointTrendBindingModel, FormPointTrend>
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
			var ColumnStartPoint = new DataGridViewTextBoxColumn
			{
				AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
				HeaderText = "Нначальная точка",
				Name = "ColumnStartPoint",
				ReadOnly = true
			};
			var ColumnFinishPount = new DataGridViewTextBoxColumn
			{
				AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
				HeaderText = "Конечная точка",
				Name = "ColumnFinishPount",
				ReadOnly = true
			};
			var ColumnCount = new DataGridViewTextBoxColumn
			{
				AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
				HeaderText = "Количество",
				Name = "ColumnCount",
				ReadOnly = true
			};
			var ColumnWeight = new DataGridViewTextBoxColumn
			{
				AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
				HeaderText = "Вес",
				Name = "ColumnWeight",
				ReadOnly = true
			};

			dataGridView.Columns.AddRange(new DataGridViewColumn[] {
			ColumnId,
			ColumnStartPoint,
			ColumnFinishPount,
			ColumnCount,
			ColumnWeight});

			groupBox.Text = "Точки фазовой плоскости (1 - самый частый, 0,5 - все остальные)";

			var buttonMakeRules = new Button
			{
				Anchor = AnchorStyles.Right,
				Location = new System.Drawing.Point(490, 3),
				Name = "buttonMakeRules",
				Size = new System.Drawing.Size(100, 23),
				TabIndex = 5,
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
				dataGridView.Rows[i].Cells[1].Value = rule.StartPoint;
				dataGridView.Rows[i].Cells[2].Value = rule.FinishPoint;
				dataGridView.Rows[i].Cells[3].Value = rule.Count;
				dataGridView.Rows[i].Cells[4].Value = rule.Weight;
				i++;
			}
		}

		private void ButtonMakeRules_Click(object sender, EventArgs e)
		{
			FormMakePoints form = new FormMakePoints(_parentId);
			if (form.ShowDialog() == DialogResult.OK)
				LoadData();
		}
	}
}
