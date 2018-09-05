﻿using DiagnosticTechnicalEngine.StandartClasses;
using ServicesModule.BindingModels;
using ServicesModule.ViewModels;
using System.Windows.Forms;

namespace DiagnosticTechnicalEngine.Controls
{
	public class UserControlGranuleFuzzy : StandartDiagnosticTestControl<GranuleFuzzyViewModel, GranuleFuzzyBindingModel>
	{
		protected override void InitializeComponent()
		{
			base.InitializeComponent();

			var ColumnPosition = new DataGridViewTextBoxColumn
			{
				HeaderText = "Позиция",
				Name = "ColumnPosition",
				ReadOnly = true
			};
			var ColumnName = new DataGridViewTextBoxColumn
			{
				AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
				HeaderText = "Значение",
				Name = "ColumnName",
				ReadOnly = true
			};
            var ColumnPoint = new DataGridViewTextBoxColumn
            {
                HeaderText = "Точка",
                Name = "ColumnPoint",
                ReadOnly = true
            };
            var ColumnCount = new DataGridViewTextBoxColumn
			{
				HeaderText = "Количество",
				Name = "ColumnCount",
				ReadOnly = true
			};

			dataGridView.Columns.AddRange(new DataGridViewColumn[] {
			ColumnPosition,
			ColumnName,
            ColumnPoint,
            ColumnCount});

			groupBox.Text = "Гранулы по Нечеткости";
		}

		protected override void LoadData()
		{
			int i = 0;
            int point = 1;
			foreach (var granule in _list)
			{
				dataGridView.Rows.Add();
				dataGridView.Rows[i].Cells[0].Value = granule.GranulePosition;
				dataGridView.Rows[i].Cells[1].Value = granule.FuzzyLabelName + " " + granule.FuzzyTrendName;
                dataGridView.Rows[i].Cells[2].Value = point;
                dataGridView.Rows[i].Cells[3].Value = granule.Count;
				i++;
                point += granule.Count;

            }
		}
	}
}
