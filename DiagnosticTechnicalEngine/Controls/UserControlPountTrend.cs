using ServicesModule;
using System;
using System.Windows.Forms;

namespace DiagnosticTechnicalEngine.Controls
{
	public partial class UserControlPountTrend : UserControl
	{
		private int _seriesId;

		private PointTrendService _logicClass;

		public int SeriesId { set { _seriesId = value; if (_seriesId > 0) { LoadData(); } } }

		public UserControlPountTrend()
		{
			InitializeComponent();
		}

		private void LoadData()
		{
			_logicClass = new PointTrendService();

			var ruleTrend = _logicClass.GetListPointTrend(_seriesId);
			if (ruleTrend == null)
			{
				MessageBox.Show("Ошибка при загрузке: " + _logicClass.Error, "Анализ временных рядов",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			dataGridView.Rows.Clear();
			int i = 0;
			foreach (var rule in ruleTrend)
			{
				dataGridView.Rows.Add();
				dataGridView.Rows[i].Cells[0].Value = rule.Id;
				dataGridView.Rows[i].Cells[1].Value = rule.StartPoint;
				dataGridView.Rows[i].Cells[2].Value = rule.FinishPoint;
				dataGridView.Rows[i].Cells[3].Value = rule.Count;
				dataGridView.Rows[i].Cells[4].Value = rule.Weight;
				i++;
			}
		}

		private void buttonAdd_Click(object sender, EventArgs e)
		{
			Forms.FormPointTrend form = new Forms.FormPointTrend(_seriesId);
			if (form.ShowDialog() == DialogResult.OK)
				LoadData();
		}

		private void buttonUpd_Click(object sender, EventArgs e)
		{
			if (dataGridView.SelectedRows.Count > 0)
			{
				Forms.FormPointTrend form = new Forms.FormPointTrend(_seriesId, 
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
						if (!_logicClass.DelPointTrend(Convert.ToInt32(dataGridView.SelectedRows[i].Cells[0].Value)))
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

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
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
						if (!_logicClass.DelPointTrendFromSeries(_seriesId))
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

		private void buttonMakeRules_Click(object sender, EventArgs e)
		{
			Forms.FormMakePoints form = new Forms.FormMakePoints(_seriesId);
			if (form.ShowDialog() == DialogResult.OK)
				LoadData();
		}
    }
}
