﻿using ServicesModule;
using System;
using System.Windows.Forms;

namespace DiagnosticTechnicalEngine.Controls
{
    public partial class UserControlDiagnosticTest : UserControl
	{
		private int _seriesId;

		private DiagnosticTestService _logicClass;

		public int SeriesId { set { _seriesId = value; if (_seriesId > 0) { LoadData(); } } }

		public UserControlDiagnosticTest()
		{
			InitializeComponent();
		}

		private void LoadData()
		{
			_logicClass = new DiagnosticTestService();

			//var diagnosticTests = _logicClass.GetListDiagnosticTest(_seriesId);
			//if (diagnosticTests == null)
			//{
			//	MessageBox.Show("Ошибка при загрузке: " + _logicClass.Error, "Анализ временных рядов",
			//		MessageBoxButtons.OK, MessageBoxIcon.Error);
			//	return;
			//}
			//dataGridView.Rows.Clear();
			//int i = 0;
			//foreach (var test in diagnosticTests)
			//{
			//	dataGridView.Rows.Add();
			//	dataGridView.Rows[i].Cells[0].Value = test.Id;
   //             dataGridView.Rows[i].Cells[1].Value = test.TestNumber;
   //             dataGridView.Rows[i].Cells[2].Value = test.FileName;
			//	dataGridView.Rows[i].Cells[3].Value = test.DateTest.ToString();
   //             dataGridView.Rows[i].Cells[4].Value = test.NeedForecast;
			//	i++;
			//}
		}

		private void buttonAdd_Click(object sender, EventArgs e)
		{
			Forms.FormDiagnosticTest form = new Forms.FormDiagnosticTest(null, _seriesId);
			if (form.ShowDialog() == DialogResult.OK)
				LoadData();
		}

		private void buttonWatch_Click(object sender, EventArgs e)
		{
			if (dataGridView.SelectedRows.Count > 0)
			{
				Forms.FormDiagnosticTest form = new Forms.FormDiagnosticTest(
														Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value), null);
                form.Show();
			}
        }

        private void dataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            buttonWatch_Click(sender, e);
        }

        private void buttonDel_Click(object sender, EventArgs e)
		{
			if (dataGridView.SelectedRows.Count > 0)
			{
				if (MessageBox.Show("Вы хотите удалить?", "Анализ временных рядов", MessageBoxButtons.YesNo,
					MessageBoxIcon.Question) == DialogResult.Yes)
				{
					for (int i = 0; i < dataGridView.SelectedRows.Count; ++i)
					{
						//if (!_logicClass.DelDiagnosticTest(Convert.ToInt32(dataGridView.SelectedRows[i].Cells[0].Value)))
						//{
						//	MessageBox.Show("Ошибка при удалении: " + _logicClass.Error, "Анализ временных рядов",
						//		MessageBoxButtons.OK, MessageBoxIcon.Error);
						//	return;
						//}
					}
					LoadData();
				}
			}
		}

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void buttonForecast_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                for (int i = 0; i < dataGridView.SelectedRows.Count; ++i)
                {
                    //var value = _logicClass.GetForecast(Convert.ToInt32(dataGridView.SelectedRows[i].Cells[0].Value));
                    //MessageBox.Show("Прогнозное значение: " + value);
                }
            }
        }
    }
}
