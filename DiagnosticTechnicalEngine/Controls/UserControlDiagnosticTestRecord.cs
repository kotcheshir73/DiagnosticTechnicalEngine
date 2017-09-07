using ServicesModule;
using System;
using System.Windows.Forms;

namespace DiagnosticTechnicalEngine.Controls
{
    public partial class UserControlDiagnosticTestRecord : UserControl
    {
        private int _diagnosticTestId;

        private DiagnosticTestRecordService _logicClass;

        public int DiagnosticTestId { set { _diagnosticTestId = value; if (_diagnosticTestId > 0) { LoadData(); } } }

        public UserControlDiagnosticTestRecord()
        {
            InitializeComponent();
        }

        public void LoadData()
        {
            _logicClass = new DiagnosticTestRecordService();

            //var diagnosticTestRecords = _logicClass.GetListDiagnosticTestRecord(_diagnosticTestId);
            //if (diagnosticTestRecords == null)
            //{
            //    MessageBox.Show("Ошибка при загрузке: " + _logicClass.Error, "Анализ временных рядов",
            //        MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            //var logic = new DiagnosticTestService();
            //var elem = logic.GetElemDiagnosticTest(_diagnosticTestId);

            //dataGridView.Rows.Clear();
            //int i = 0;
            //foreach (var record in diagnosticTestRecords)
            //{
            //    dataGridView.Rows.Add();
            //    dataGridView.Rows[i].Cells[0].Value = record.Id;
            //    dataGridView.Rows[i].Cells[1].Value = record.AnomalyId;
            //    dataGridView.Rows[i].Cells[2].Value = record.PointNumber;
            //    dataGridView.Rows[i].Cells[3].Value = record.Description;
            //    i++;
            //}
        }

        private void buttonWatch_Click(object sender, System.EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                Forms.FormAnomalyInfo form = new Forms.FormAnomalyInfo(_diagnosticTestId,
                    Convert.ToInt32(dataGridView.SelectedRows[0].Cells[1].Value));
                if (form.ShowDialog() == DialogResult.OK)
                    LoadData();
            }
        }

        private void dataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            buttonWatch_Click(sender, e);
        }

        private void buttonRefresh_Click(object sender, System.EventArgs e)
        {
            LoadData();
        }
    }
}
