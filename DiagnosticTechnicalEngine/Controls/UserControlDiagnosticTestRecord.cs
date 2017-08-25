using ServicesModule;
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

            var anomalyInfo = _logicClass.GetListDiagnosticTestRecord(_diagnosticTestId);
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
                dataGridView.Rows[i].Cells[1].Value = anomaly.PointNumber;
                dataGridView.Rows[i].Cells[2].Value = anomaly.Description;
                dataGridView.Rows[i].Cells[3].Value = anomaly.Probability;
                i++;
            }
        }
    }
}
