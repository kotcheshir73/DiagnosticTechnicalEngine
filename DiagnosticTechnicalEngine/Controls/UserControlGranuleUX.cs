using ServicesModule;
using System;
using System.Windows.Forms;

namespace DiagnosticTechnicalEngine.Controls
{
	public partial class UserControlGranuleUX : UserControl
	{
		private int _diagnosticTestId;

		private GranuleUXService _logicClass;

		public int DiagnosticTestId { set { _diagnosticTestId = value; if (_diagnosticTestId > 0) { LoadData(); } } }

		public UserControlGranuleUX()
		{
			InitializeComponent();
		}

		private void LoadData()
		{
			_logicClass = new GranuleUXService();

			//var granules = _logicClass.GetListGranuleUX(_diagnosticTestId);
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
			//	dataGridView.Rows[i].Cells[1].Value = granule.LingvistUX;
			//	dataGridView.Rows[i].Cells[2].Value = granule.Count;
			//	i++;

			//}
		}

		private void buttonRefresh_Click(object sender, EventArgs e)
		{
			LoadData();
		}
    }
}
