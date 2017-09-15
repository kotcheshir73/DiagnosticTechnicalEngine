using DiagnosticTechnicalEngine.Forms;
using DiagnosticTechnicalEngine.StandartClasses;
using ServicesModule;
using ServicesModule.BindingModels;
using ServicesModule.ViewModels;
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

			panel.Controls.Add(buttonWatch);
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
	}
}
