using ServicesModule;
using System;
using System.Windows.Forms;

namespace DiagnosticTechnicalEngine.Controls
{
	public partial class UserControlFuzzyLabel : UserControl
    {
        private int _seriesId;

        private BLClassFuzzyLabel _logicClass;

        public int SeriesId { set { _seriesId = value; if (_seriesId > 0) { LoadData(); } } }

        public UserControlFuzzyLabel()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            _logicClass = new BLClassFuzzyLabel();

            var fuzzyLabel = _logicClass.GetListFuzzyLabel(_seriesId);
            if (fuzzyLabel == null)
            {
                MessageBox.Show("Ошибка при загрузке: " + _logicClass.Error, "Анализ временных рядов",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            dataGridView.Rows.Clear();
			int i = 0;
			foreach (var label in fuzzyLabel)
			{
				dataGridView.Rows.Add();
				dataGridView.Rows[i].Cells[0].Value = label.Id;
				dataGridView.Rows[i].Cells[1].Value = label.FuzzyLabelType;
				dataGridView.Rows[i].Cells[2].Value = label.FuzzyLabelName;
				dataGridView.Rows[i].Cells[3].Value = label.FuzzyLabelWeight;
				dataGridView.Rows[i].Cells[4].Value = label.FuzzyLabelMinVal;
				dataGridView.Rows[i].Cells[5].Value = label.FuzzyLabelCenter;
				dataGridView.Rows[i].Cells[6].Value = label.FuzzyLabelMaxVal;
				i++;

			}
		}

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Forms.FormFuzzyLabel form = new Forms.FormFuzzyLabel(_seriesId);
            if (form.ShowDialog() == DialogResult.OK)
                LoadData();
        }

        private void buttonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                Forms.FormFuzzyLabel form = new Forms.FormFuzzyLabel(_seriesId, 

					Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value));
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
                        if (!_logicClass.DelFuzzyLabel(Convert.ToInt32(dataGridView.SelectedRows[i].Cells[0].Value)))
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

        private void buttonClear_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Вы хотите удалить?", "Анализ временных рядов", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    for (int i = 0; i < dataGridView.SelectedRows.Count; ++i)
                    {
                        if (!_logicClass.DelFuzzyLabelFromSeries(_seriesId))
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

        private void buttonClustreing_Click(object sender, EventArgs e)
        {
            Forms.FormClustering form = new Forms.FormClustering(_seriesId);
            if (form.ShowDialog() == DialogResult.OK)
                LoadData();
        }
	}
}
