using ServicesModule;
using System;
using System.Windows.Forms;

namespace DiagnosticTechnicalEngine.Controls
{
    public partial class UserControlFuzzyTrend : UserControl
	{
		private int _seriesId;

		private FuzzyTrendService _logicClass;

		public int SeriesId { set { _seriesId = value; if (_seriesId > 0) { LoadData(); } } }

		public UserControlFuzzyTrend()
		{
			InitializeComponent();
		}

		private void LoadData()
		{
			_logicClass = new FuzzyTrendService();

			//var fuzzyTrend = _logicClass.GetListFuzzyTrend(_seriesId);
			//if (fuzzyTrend == null)
			//{
			//	MessageBox.Show("Ошибка при загрузке: " + _logicClass.Error, "Анализ временных рядов",
			//		MessageBoxButtons.OK, MessageBoxIcon.Error);
			//	return;
			//}
			//dataGridView.Rows.Clear();
			//int i = 0;
			//foreach(var trend in fuzzyTrend)
			//{
			//	dataGridView.Rows.Add();
			//	dataGridView.Rows[i].Cells[0].Value = trend.Id;
			//	dataGridView.Rows[i].Cells[1].Value = trend.TrendName;
			//	dataGridView.Rows[i].Cells[2].Value = trend.Weight;
			//	i++;
			//}
		}

		private void buttonAdd_Click(object sender, EventArgs e)
		{
			Forms.FormFuzzyTrend form = new Forms.FormFuzzyTrend(_seriesId);
			if (form.ShowDialog() == DialogResult.OK)
				LoadData();
		}

		private void buttonUpd_Click(object sender, EventArgs e)
		{
			if (dataGridView.SelectedRows.Count > 0)
			{
				Forms.FormFuzzyTrend form = new Forms.FormFuzzyTrend(_seriesId,
					Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value));
				if (form.ShowDialog() == DialogResult.OK)
					LoadData();
			}
        }

        private void dataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            buttonUpd_Click(sender, e);
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
						//if (!_logicClass.DelFuzzyTrend(Convert.ToInt32(dataGridView.SelectedRows[i].Cells[0].Value)))
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

		private void buttonClear_Click(object sender, EventArgs e)
		{
			if (dataGridView.SelectedRows.Count > 0)
			{
				if (MessageBox.Show("Вы хотите удалить?", "Анализ временных рядов", MessageBoxButtons.YesNo,
					MessageBoxIcon.Question) == DialogResult.Yes)
				{
					for (int i = 0; i < dataGridView.SelectedRows.Count; ++i)
					{
						//if (!_logicClass.DelFuzzyTrendFromSeries(_seriesId))
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

        private void buttonGeneric_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Вы хотите сгенрировать нечеткие тенденции?", "Анализ временных рядов", MessageBoxButtons.YesNo,
					MessageBoxIcon.Question) == DialogResult.Yes)
			{
				//if (!_logicClass.Generate(_seriesId))
				//{
				//	MessageBox.Show("Ошибка при генерации: " + _logicClass.Error, "Анализ временных рядов",
				//		MessageBoxButtons.OK, MessageBoxIcon.Error);
				//	return;
				//}
				LoadData();
			}
		}
    }
}
