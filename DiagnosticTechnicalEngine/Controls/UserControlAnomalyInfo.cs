using ServicesModule;
using System;
using System.Windows.Forms;

namespace DiagnosticTechnicalEngine.Controls
{
	public partial class UserControlAnomalyInfo : UserControl
	{
		private int _diagnosticTestId;

		private AnomalyInfoService _logicClass;

		public int DiagnosticTestId { set { _diagnosticTestId = value; if (_diagnosticTestId > 0) { LoadData(); } } }

		public UserControlAnomalyInfo()
		{
			InitializeComponent();
		}

		public void LoadData()
		{
			_logicClass = new AnomalyInfoService();

			var anomalyInfo = _logicClass.GetListAnomalyInfo(_diagnosticTestId);
			if (anomalyInfo == null)
			{
				MessageBox.Show("Ошибка при загрузке: " + _logicClass.Error, "Анализ временных рядов",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			var logic = new DiagnosticTestService();
			var elem = logic.GetElemDiagnosticTest(_diagnosticTestId);

			dataGridView.Rows.Clear();
			int i = 0;
			foreach (var anomaly in anomalyInfo)
			{
				dataGridView.Rows.Add();
				dataGridView.Rows[i].Cells[0].Value = anomaly.Id;
				dataGridView.Rows[i].Cells[1].Value = anomaly.AnomalyName;
				dataGridView.Rows[i].Cells[2].Value = anomaly.SetSituations + " -> " + anomaly.AnomalySituation;
				dataGridView.Rows[i].Cells[3].Value = anomaly.CountMeet;
				dataGridView.Rows[i].Cells[4].Value = anomaly.Description;
				dataGridView.Rows[i].Cells[5].Value = anomaly.NotAnomaly;
				dataGridView.Rows[i].Cells[6].Value = anomaly.NotDetected;
				i++;
			}
		}

		private void buttonWatch_Click(object sender, EventArgs e)
		{
			if (dataGridView.SelectedRows.Count > 0)
			{
				Forms.FormAnomalyInfo form = new Forms.FormAnomalyInfo(_diagnosticTestId,
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
