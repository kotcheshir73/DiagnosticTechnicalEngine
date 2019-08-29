﻿using DiagnosticTechnicalEngine.StandartClasses;
using DTE_Interface_Level.BindingModels;
using DTE_Interface_Level.ViewModels;
using System.Windows.Forms;

namespace DiagnosticTechnicalEngine.Controls
{
    public class UserControlGranuleUX : StandartDiagnosticTestControl<GranuleUXViewModel, GranuleUXBindingModel>
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
			var ColumnCount = new DataGridViewTextBoxColumn
			{
				HeaderText = "Количество",
				Name = "ColumnCount",
				ReadOnly = true
			};

			dataGridView.Columns.AddRange(new DataGridViewColumn[] {
			ColumnPosition,
			ColumnName,
			ColumnCount});

			groupBox.Text = "Гранулы по мерам энтропий";
		}

		protected override void LoadData()
		{
			int i = 0;
			foreach (var granule in _list)
			{
				dataGridView.Rows.Add();
				dataGridView.Rows[i].Cells[0].Value = granule.GranulePosition;
				dataGridView.Rows[i].Cells[1].Value = granule.LingvistUX;
				dataGridView.Rows[i].Cells[2].Value = granule.Count;
				i++;
			}
		}
	}
}
