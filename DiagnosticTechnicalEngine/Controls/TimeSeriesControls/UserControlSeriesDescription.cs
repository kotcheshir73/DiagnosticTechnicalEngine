using DiagnosticTechnicalEngine.Forms;
using DiagnosticTechnicalEngine.StandartClasses;
using DTE_Interface_Level.BindingModels;
using DTE_Interface_Level.ViewModels;
using System;
using System.Windows.Forms;

namespace DiagnosticTechnicalEngine.Controls
{
    public class UserControlSeriesDescription : StandartSeriesControl<SeriesDescriptionViewModel, SeriesDescriptionBindingModel, FormSeriesDescription>
	{
		private event Action<int> _onSelect;

		public void AddEvent(Action<int> method)
		{
			_onSelect += method;
		}

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
			var ColumnName = new DataGridViewTextBoxColumn
			{
				AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
				HeaderText = "Название",
				Name = "ColumnName",
				ReadOnly = true
			};

			dataGridView.Columns.AddRange(new DataGridViewColumn[] {
			ColumnId,
			ColumnName});

			groupBox.Text = "Временные ряды";

			var buttonOpen = new Button
			{
				Anchor = AnchorStyles.Left,
				Location = new System.Drawing.Point(273, 3),
				Name = "buttonOpen",
				Size = new System.Drawing.Size(75, 23),
				TabIndex = 5,
				Text = "Открыть",
				UseVisualStyleBackColor = true
			};
			buttonOpen.Click += new EventHandler(ButtonOpen_Click);

			panel.Controls.Add(buttonOpen);

			ChangeVisibiles("buttonClear", false);
		}

		protected override void LoadData()
		{
			int i = 0;
			foreach (var series in _list)
			{
				dataGridView.Rows.Add();
				dataGridView.Rows[i].Cells[0].Value = series.Id;
				dataGridView.Rows[i].Cells[1].Value = series.SeriesName;
				i++;
			}
		}

		private void ButtonOpen_Click(object sender, EventArgs e)
		{
			if (_onSelect != null && dataGridView.SelectedRows.Count > 0)
			{
				_onSelect(Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value));
			}
		}
	}
}
