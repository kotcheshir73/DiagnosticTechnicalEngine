using ServicesModule;
using System;
using System.Windows.Forms;

namespace DiagnosticTechnicalEngine.Controls
{
	public partial class UserControlGranuleFuzzy : UserControl
	{
		private int _diagnosticTestId;

		private BLClassGranuleFuzzy _logicClass;

		public int DiagnosticTestId { set { _diagnosticTestId = value; if (_diagnosticTestId > 0) { LoadData(); } } }

		public UserControlGranuleFuzzy()
		{
			InitializeComponent();
		}

		private void LoadData()
		{
			_logicClass = new BLClassGranuleFuzzy();

			var granules = _logicClass.GetListGranuleFuzzy(_diagnosticTestId);
			if (granules == null)
			{
				MessageBox.Show("Ошибка при загрузке: " + _logicClass.Error, "Анализ временных рядов",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			dataGridView.Rows.Clear();
			int i = 0;
			foreach (var granule in granules)
			{
				dataGridView.Rows.Add();
				dataGridView.Rows[i].Cells[0].Value = granule.GranulePosition;
				dataGridView.Rows[i].Cells[1].Value = granule.FuzzyLabelName + " " + granule.FuzzyTrendName;
				dataGridView.Rows[i].Cells[2].Value = granule.Count;
				i++;

			}
		}

		private void buttonRefresh_Click(object sender, EventArgs e)
		{
			LoadData();
		}
	}
}
