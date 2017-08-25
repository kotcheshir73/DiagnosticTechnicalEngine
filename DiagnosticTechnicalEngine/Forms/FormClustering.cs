using ServicesModule;
using ServicesModule.BindingModels;
using DatabaseModule;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace DiagnosticTechnicalEngine.Forms
{
	public partial class FormClustering : Form
    {
        private int _seriesId;

        public FormClustering(int seriesId)
        {
            InitializeComponent();
            _seriesId = seriesId;
        }

        private void buttonLoadFromExcel_Click(object sender, EventArgs e)
        {
            int countCenters = 0;
            if (!int.TryParse(textBoxCountClusters.Text, out countCenters))
            {
                MessageBox.Show("Не удалось получить число центров кластеров", "Анализ временных рядов",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Excel files(*.xls)|*.xls|Excel files(*.xlsx)|*.xlsx";
            if(dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var clust = new Clustering(dialog.FileName, 0, countCenters);
                if (clust.Calc())
                {
                    dataGridView.Rows.Clear();
                    var points = clust.Points;
                    for (int i = 0; i < countCenters; ++i )
                    {
                        if (points.Count > 0)
                        {
                            var point = points.First(r => r.x == points.Min(rex => rex.x));
                            dataGridView.Rows.Add();
                            var clustPoints = points.Where(r => r.clusterIndex == point.clusterIndex);
                            dataGridView.Rows[i].Cells[0].Value = "Кластер " + (i + 1);
                            dataGridView.Rows[i].Cells[1].Value = i + 1;
                            dataGridView.Rows[i].Cells[2].Value = clustPoints.Min(rex => rex.x);
                            dataGridView.Rows[i].Cells[3].Value = clust.Centers[(int)point.clusterIndex].x;
                            dataGridView.Rows[i].Cells[4].Value = clustPoints.Max(rex => rex.x);
                            points.RemoveAll(r => r.clusterIndex == point.clusterIndex);
                        }
                        else
                        {
                            dataGridView.Rows.Add();
                            dataGridView.Rows[i].Cells[0].Value = "Кластер " + (i + 1);
                            dataGridView.Rows[i].Cells[1].Value = i + 1;
                            dataGridView.Rows[i].Cells[2].Value = 0;
                            dataGridView.Rows[i].Cells[3].Value = 0;
                            dataGridView.Rows[i].Cells[4].Value = 0;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Ошибка при кластеризации", "Анализ временных рядов",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonLoadFromTxt_Click(object sender, EventArgs e)
        {
            int countCenters = 0;
            if (!int.TryParse(textBoxCountClusters.Text, out countCenters))
            {
                MessageBox.Show("Не удалось получить число центров кластеров", "Анализ временных рядов",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "TXT files(*.txt)|*.txt";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var clust = new Clustering(dialog.FileName, 1, countCenters);
                if (clust.Calc())
                {
                    dataGridView.Rows.Clear();
                    var points = clust.Points;
                    for (int i = 0; i < countCenters; ++i)
                    {
                        if (points.Count > 0)
                        {
                            var point = points.First(r => r.x == points.Min(rex => rex.x));
                            dataGridView.Rows.Add();
                            var clustPoints = points.Where(r => r.clusterIndex == point.clusterIndex);
                            dataGridView.Rows[i].Cells[0].Value = "Кластер " + (i + 1);
                            dataGridView.Rows[i].Cells[1].Value = i + 1;
                            dataGridView.Rows[i].Cells[2].Value = clustPoints.Min(rex => rex.x);
                            dataGridView.Rows[i].Cells[3].Value = clust.Centers[(int)point.clusterIndex].x;
                            dataGridView.Rows[i].Cells[4].Value = clustPoints.Max(rex => rex.x);
                            points.RemoveAll(r => r.clusterIndex == point.clusterIndex);
                        }
                        else
                        {
                            dataGridView.Rows.Add();
                            dataGridView.Rows[i].Cells[0].Value = "Кластер " + (i + 1);
                            dataGridView.Rows[i].Cells[1].Value = i + 1;
                            dataGridView.Rows[i].Cells[2].Value = 0;
                            dataGridView.Rows[i].Cells[3].Value = 0;
                            dataGridView.Rows[i].Cells[4].Value = 0;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Ошибка при кластеризации", "Анализ временных рядов",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Сохранить кластеры?", "Анализ временных рядов", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var logic = new BLClassFuzzyLabel();
                for(int i = 0; i < dataGridView.Rows.Count; ++i)
                {
                    if (!logic.AddFuzzyLabel(new FuzzyLabelBindingModel
					{
						SeriesId = _seriesId,
						FuzzyLabelType = FuzzyLabelType.ClustFCM,
						FuzzyLabelName = dataGridView.Rows[i].Cells[0].Value.ToString(),
						Weigth = Convert.ToInt32(
						dataGridView.Rows[i].Cells[1].Value),
						MinVal = Convert.ToDouble(dataGridView.Rows[i].Cells[2].Value),
						Center = Convert.ToDouble(dataGridView.Rows[i].Cells[3].Value),
						MaxVal = Convert.ToDouble(dataGridView.Rows[i].Cells[4].Value)
					}))
                    {
                        MessageBox.Show("Ошибка при добавлении: " + logic.Error, "Анализ временных рядов",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
        }
    }
}
