using ServicesModule;
using System.Windows.Forms;

namespace DiagnosticTechnicalEngine.Controls
{
	public partial class UserControlGranuleFT : UserControl
	{
		private int _diagnosticTestId;

		private GranuleFTService _logicClass;

		public int DiagnosticTestId { set { _diagnosticTestId = value; if (_diagnosticTestId > 0) { LoadData(); } } }

		public UserControlGranuleFT()
		{
			InitializeComponent();
		}

		private void LoadData()
		{
			_logicClass = new GranuleFTService();

			//var granules = _logicClass.GetListGranuleFT(_diagnosticTestId);
			//if (granules == null)
			//{
			//	MessageBox.Show("Ошибка при загрузке: " + _logicClass.Error, "Анализ временных рядов",
			//		MessageBoxButtons.OK, MessageBoxIcon.Error);
			//	return;
			//}
			//dataGridView.Rows.Clear();
			//int i = 0;
			//foreach (var granule in granules)
			//{
			//	dataGridView.Rows.Add();
			//	dataGridView.Rows[i].Cells[0].Value = granule.GranulePosition;
			//	dataGridView.Rows[i].Cells[1].Value = granule.LingvistFT;
			//	dataGridView.Rows[i].Cells[2].Value = granule.Count;
			//	i++;

			//}
		}

		private void buttonRefresh_Click(object sender, System.EventArgs e)
		{
			LoadData();
		}
	}
}
