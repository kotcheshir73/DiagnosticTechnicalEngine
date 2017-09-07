using ServicesModule;
using System;
using System.Windows.Forms;

namespace DiagnosticTechnicalEngine.Controls
{
	public partial class UserControlStatisticFuzzy : UserControl
	{
		private int _diagnosticTestId;

		private int _seriesId;

		private StatisticsByFuzzyService _logicClass;

		public int DiagnosticTestId { set { _diagnosticTestId = value; if (_diagnosticTestId > 0) { LoadData(); } } }

		public UserControlStatisticFuzzy()
        {
            InitializeComponent();
        }

        public void LoadData()
        {
   //         _logicClass = new StatisticsByFuzzyService();

   //         var statisticsByFuzzy = _logicClass.GetListStatisticsByFuzzy(_diagnosticTestId);
   //         if (statisticsByFuzzy == null)
   //         {
   //             MessageBox.Show("Ошибка при загрузке: " + _logicClass.Error, "Анализ временных рядов",
   //                 MessageBoxButtons.OK, MessageBoxIcon.Error);
   //             return;
			//}
			//var logic = new DiagnosticTestService();
			//var elem = logic.GetElemDiagnosticTest(_diagnosticTestId);
			//_seriesId = elem.SeriesDiscriptionId;

			//dataGridView.Rows.Clear();
			//int i = 0;
			//foreach (var fuzzy in statisticsByFuzzy)
			//{
			//	dataGridView.Rows.Add();
			//	dataGridView.Rows[i].Cells[0].Value = fuzzy.Id;
			//	dataGridView.Rows[i].Cells[1].Value = fuzzy.NumberSituation;
			//	dataGridView.Rows[i].Cells[2].Value = fuzzy.StartState;
			//	dataGridView.Rows[i].Cells[3].Value = fuzzy.EndState;
			//	dataGridView.Rows[i].Cells[4].Value = fuzzy.Description;
			//	if (elem != null)
			//	{
			//		if (elem.Count > 0)
			//		{
			//			dataGridView.Rows[i].Cells[5].Value = (double)fuzzy.CountMeet / elem.Count;
			//		}
			//		else
			//		{
			//			dataGridView.Rows[i].Cells[5].Value = fuzzy.CountMeet;
			//		}
			//	}
			//	else
			//	{
			//		dataGridView.Rows[i].Cells[5].Value = fuzzy.CountMeet;
			//	}
			//	i++;
			//}
		}

		private void buttonWatch_Click(object sender, EventArgs e)
		{
			if (dataGridView.SelectedRows.Count > 0)
			{
				Forms.FormStatisticFuzzy form = new Forms.FormStatisticFuzzy(_seriesId,
					Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value));
				if (form.ShowDialog() == DialogResult.OK)
					LoadData();
			}
		}

        private void dataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            buttonWatch_Click(sender, e);
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
