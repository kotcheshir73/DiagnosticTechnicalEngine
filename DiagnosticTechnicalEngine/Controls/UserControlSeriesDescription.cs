using ServicesModule;
using System;
using System.Windows.Forms;

namespace DiagnosticTechnicalEngine.Controls
{
    public partial class UserControlSeriesDescription : UserControl
    {
        private SeriesDescriptionService _logicClass;

        private event Action<int> _onSelect;

        public UserControlSeriesDescription()
        {
            InitializeComponent();
        }

        public void LoadData()
        {

            _logicClass = new SeriesDescriptionService();

			var seriesDescrip = _logicClass.GetElements(0);
			dataGridView.Rows.Clear();
			int i = 0;
			foreach (var series in seriesDescrip)
			{
				dataGridView.Rows.Add();
				dataGridView.Rows[i].Cells[0].Value = series.Id;
				dataGridView.Rows[i].Cells[1].Value = series.SeriesName;
				i++;
			}
		}

        public void AddEvent(Action<int> method)
        {
            _onSelect += method;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Forms.FormSeriesDescription form = new Forms.FormSeriesDescription();
            if (form.ShowDialog() == DialogResult.OK)
                LoadData();
        }

        private void buttonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                Forms.FormSeriesDescription form = new Forms.FormSeriesDescription(
                    Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value));
                if (form.ShowDialog() == DialogResult.OK)
                    LoadData();
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if(dataGridView.SelectedRows.Count > 0)
            {
                if(MessageBox.Show("Вы хотите удалить?", "Анализ временных рядов", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    for(int i = 0; i < dataGridView.SelectedRows.Count; ++i)
                    {
                        //if(!_logicClass.DelSeriesDescrip(Convert.ToInt32(dataGridView.SelectedRows[i].Cells[0].Value)))
                        //{
                        //    MessageBox.Show("Ошибка при удалении: " + _logicClass.Error, "Анализ временных рядов",
                        //        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //    return;
                        //}
                    }
                    LoadData();
                }
            }
        }

        private void dataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(_onSelect != null && dataGridView.SelectedRows.Count > 0)
            {
                _onSelect(Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value));
            }
        }
    }
}
