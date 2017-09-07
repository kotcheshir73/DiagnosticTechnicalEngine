using ServicesModule;
using System;
using System.Windows.Forms;

namespace DiagnosticTechnicalEngine.Controls
{
    public partial class UserControlStatisticEntropy : UserControl
    {
        private int _diagnosticTestId;

        private StatisticsByEntropyService _logicClass;

        public int DiagnosticTestId { set { _diagnosticTestId = value; if (_diagnosticTestId > 0) { LoadData(); } } }

        public UserControlStatisticEntropy()
        {
            InitializeComponent();
        }

        public void LoadData()
        {
            //_logicClass = new StatisticsByEntropyService();

            //var statisticsByEntropy = _logicClass.GetListStatisticsByEntropy(_diagnosticTestId);
            //if (statisticsByEntropy == null)
            //{
            //    MessageBox.Show("Ошибка при загрузке: " + _logicClass.Error, "Анализ временных рядов",
            //        MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            //var logic = new DiagnosticTestService();
            //var elem = logic.GetElemDiagnosticTest(_diagnosticTestId);

            //dataGridView.Rows.Clear();
            //int i = 0;
            //foreach (var entropy in statisticsByEntropy)
            //{
            //    dataGridView.Rows.Add();
            //    dataGridView.Rows[i].Cells[0].Value = entropy.Id;
            //    dataGridView.Rows[i].Cells[1].Value = entropy.NumberSituation;
            //    dataGridView.Rows[i].Cells[2].Value = entropy.StartState;
            //    dataGridView.Rows[i].Cells[3].Value = entropy.EndState;
            //    dataGridView.Rows[i].Cells[4].Value = entropy.Description;
            //    if (elem != null)
            //    {
            //        if (elem.Count > 0)
            //        {
            //            dataGridView.Rows[i].Cells[5].Value = (double)entropy.CountMeet / elem.Count;
            //        }
            //        else
            //        {
            //            dataGridView.Rows[i].Cells[5].Value = entropy.CountMeet;
            //        }
            //    }
            //    else
            //    {
            //        dataGridView.Rows[i].Cells[5].Value = entropy.CountMeet;
            //    }
            //    i++;
            //}
        }

        private void buttonWatch_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                Forms.FormStatisticEntropy form = new Forms.FormStatisticEntropy(
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
