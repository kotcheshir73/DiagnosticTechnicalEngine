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
			if (!int.TryParse(textBoxCountClusters.Text, out int countCenters))
			{
				MessageBox.Show("Не удалось получить число центров кластеров", "Анализ временных рядов",
				 MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			OpenFileDialog dialog = new OpenFileDialog
			{
				Filter = "Excel files(*.xls)|*.xls|Excel files(*.xlsx)|*.xlsx"
			};
			if (dialog.ShowDialog() == DialogResult.OK)
            {
                var clust = new ModelClustering(dialog.FileName, 0, countCenters);
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
			if (!int.TryParse(textBoxCountClusters.Text, out int countCenters))
			{
				MessageBox.Show("Не удалось получить число центров кластеров", "Анализ временных рядов",
				 MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			OpenFileDialog dialog = new OpenFileDialog
			{
				Filter = "TXT files(*.txt)|*.txt"
			};
			if (dialog.ShowDialog() == DialogResult.OK)
            {
                var clust = new ModelClustering(dialog.FileName, 1, countCenters);
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
                var logic = new FuzzyLabelService();
                for(int i = 0; i < dataGridView.Rows.Count; ++i)
                {
					try
					{
						logic.InsertElement(new FuzzyLabelBindingModel
						{
							SeriesId = _seriesId,
							FuzzyLabelType = FuzzyLabelType.ClustFCM,
							FuzzyLabelName = dataGridView.Rows[i].Cells[0].Value.ToString(),
							Weigth = Convert.ToInt32(
							 dataGridView.Rows[i].Cells[1].Value),
							MinVal = Convert.ToDouble(dataGridView.Rows[i].Cells[2].Value),
							Center = Convert.ToDouble(dataGridView.Rows[i].Cells[3].Value),
							MaxVal = Convert.ToDouble(dataGridView.Rows[i].Cells[4].Value)
						});
					}
					catch(Exception ex)
					{
						MessageBox.Show("Ошибка при добавлении: " + ex.Message, "Анализ временных рядов",
						 MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
