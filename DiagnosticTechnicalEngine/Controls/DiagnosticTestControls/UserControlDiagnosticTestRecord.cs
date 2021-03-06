﻿using DiagnosticTechnicalEngine.Forms;
using DiagnosticTechnicalEngine.StandartClasses;
using DTE_Implement_Level;
using DTE_Implement_Level.Implementations;
using DTE_Interface_Level.BindingModels;
using DTE_Interface_Level.ViewModels;
using System;
using System.Windows.Forms;

namespace DiagnosticTechnicalEngine.Controls
{
    public class UserControlDiagnosticTestRecord : StandartDiagnosticTestControl<DiagnosticTestRecordViewModel, DiagnosticTestRecordBindingModel>
	{
		protected override void InitializeComponent()
		{
			base.InitializeComponent();

			var ColumnId = new DataGridViewTextBoxColumn
			{
				HeaderText = "Id",
				Name = "ColumnId",
				ReadOnly = true,
				Visible = false
			};
			var ColumnAnomalyId = new DataGridViewTextBoxColumn
			{
				HeaderText = "ColumnAnomalyId",
				Name = "ColumnAnomalyId",
				ReadOnly = true,
				Visible = false
			};
			var ColumnName = new DataGridViewTextBoxColumn
			{
				AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
				HeaderText = "Точка",
				Name = "ColumnName",
				ReadOnly = true,
				Width = 62
			};
			var ColumnSetSituation = new DataGridViewTextBoxColumn
			{
				AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
				HeaderText = "Набор ситуаций",
				Name = "ColumnSetSituation",
				ReadOnly = true
			};

			dataGridView.Columns.AddRange(new DataGridViewColumn[] {
			ColumnId,
			ColumnAnomalyId,
			ColumnName,
			ColumnSetSituation});

			groupBox.Text = "Записи теста";

			var buttonWatch = new Button
			{
				Anchor = ((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left),
				Location = new System.Drawing.Point(103, 3),
				Name = "buttonWatch",
				Size = new System.Drawing.Size(95, 23),
				TabIndex = 0,
				Text = "Посмотреть",
				UseVisualStyleBackColor = true
			};
			buttonWatch.Click += new EventHandler(ButtonWatch_Click);

            var buttonForecast = new Button
            {
                Anchor = ((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left),
                Location = new System.Drawing.Point(203, 3),
                Name = "buttonForecast",
                Size = new System.Drawing.Size(95, 23),
                TabIndex = 0,
                Text = "Прогноз",
                UseVisualStyleBackColor = true
            };
            buttonForecast.Click += new EventHandler(ButtonForecast_Click);

            panel.Controls.Add(buttonWatch);
            panel.Controls.Add(buttonForecast);
        }

		protected override void LoadData()
		{
			int i = 0;
			foreach (var record in _list)
			{
				dataGridView.Rows.Add();
				dataGridView.Rows[i].Cells[0].Value = record.Id;
				dataGridView.Rows[i].Cells[1].Value = record.AnomalyId;
				dataGridView.Rows[i].Cells[2].Value = record.PointNumber;
				dataGridView.Rows[i].Cells[3].Value = record.Description;
				i++;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ButtonWatch_Click(object sender, EventArgs e)
		{
			if (dataGridView.SelectedRows.Count > 0)
			{
				var form = new FormAnomalyInfo();
				form.Initialize(new AnomalyInfoService(), _parentId, Convert.ToInt32(dataGridView.SelectedRows[0].Cells[1].Value));
				if (form.ShowDialog() == DialogResult.OK)
					LoadData();
			}
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonForecast_Click(object sender, EventArgs e)
        {
            try
            {
                ModelDiagnosticTest mdt = new ModelDiagnosticTest();
                var forecast = mdt.GetForecast(_parentId);
                MessageBox.Show(string.Format("Результат: {0}", forecast), "Прогноз", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Прогноз", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
