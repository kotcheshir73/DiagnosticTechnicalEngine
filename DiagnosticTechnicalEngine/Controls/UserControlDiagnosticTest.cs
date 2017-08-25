using ServicesModule;
using System;
using System.Windows.Forms;

namespace DiagnosticTechnicalEngine.Controls
{
    public partial class UserControlDiagnosticTest : UserControl
	{
		private int _seriesId;

		private BLClassDiagnosticTest _logicClass;

		public int SeriesId { set { _seriesId = value; if (_seriesId > 0) { LoadData(); } } }

		public UserControlDiagnosticTest()
		{
			InitializeComponent();
		}

		private void LoadData()
		{
			_logicClass = new BLClassDiagnosticTest();

			var diagnosticTests = _logicClass.GetListDiagnosticTest(_seriesId);
			if (diagnosticTests == null)
			{
				MessageBox.Show("Ошибка при загрузке: " + _logicClass.Error, "Анализ временных рядов",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			dataGridView.Rows.Clear();
			int i = 0;
			foreach (var test in diagnosticTests)
			{
				dataGridView.Rows.Add();
				dataGridView.Rows[i].Cells[0].Value = test.Id;
				dataGridView.Rows[i].Cells[1].Value = test.FileName;
				dataGridView.Rows[i].Cells[2].Value = test.DateTest.ToLongDateString();
				i++;

			}
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
				if (form.ShowDialog() == DialogResult.OK)
					LoadData();
			}
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
						if (!_logicClass.DelDiagnosticTest(Convert.ToInt32(dataGridView.SelectedRows[i].Cells[0].Value)))
						{
							MessageBox.Show("Ошибка при удалении: " + _logicClass.Error, "Анализ временных рядов",
								MessageBoxButtons.OK, MessageBoxIcon.Error);
							return;
						}
					}
					LoadData();
				}
			}
		}
	}
}
