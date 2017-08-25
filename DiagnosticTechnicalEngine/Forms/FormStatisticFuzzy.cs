using ServicesModule;
using System;
using System.Linq;
using System.Windows.Forms;

namespace DiagnosticTechnicalEngine.Forms
{
	public partial class FormStatisticFuzzy : Form
	{
		private int _id;

		private int _seriesId;

		private StatisticsByFuzzyService _logicClass;

		public FormStatisticFuzzy(int seriesId, int id)
		{
			InitializeComponent();
			_id = id;
			_seriesId = seriesId;

			var dbclassLabels = new FuzzyLabelService();
			var listFuzzyLabels = dbclassLabels.GetListFuzzyLabel(_seriesId);
			if (listFuzzyLabels == null)
			{
				MessageBox.Show("Список меток пуст: " + dbclassLabels.Error, "Анализ временных рядов",
				 MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			if (listFuzzyLabels.Count() == 0)
			{
				MessageBox.Show("Список меток пуст", "Анализ временных рядов",
				 MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			var dbclassTrends = new FuzzyTrendService();
			var listFuzzyTrends = dbclassTrends.GetListFuzzyTrend(_seriesId);
			if (listFuzzyLabels == null)
			{
				MessageBox.Show("Список меток пуст: " + dbclassTrends.Error, "Анализ временных рядов",
				 MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			foreach (var labels in listFuzzyLabels)
			{
				comboBoxStartStateFL.Items.Add(labels.FuzzyLabelName);
				comboBoxEndStateFL.Items.Add(labels.FuzzyLabelName);
			}
			foreach (var trend in listFuzzyTrends)
			{
				comboBoxStartStateFT.Items.Add(trend.TrendName);
				comboBoxEndStateFT.Items.Add(trend.TrendName);
			}
		}

		private void FormStatisticFuzzy_Load(object sender, EventArgs e)
		{
			_logicClass = new StatisticsByFuzzyService();
			var elem = _logicClass.GetElemStatisticsByFuzzy(_id);
			if (elem == null)
			{
				MessageBox.Show("Ошибка при загрузке: " + _logicClass.Error, "Анализ временных рядов",
				 MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			textBoxNumberSituation.Text = elem.NumberSituation.ToString();
			comboBoxStartStateFL.Text = elem.StartState.Split('-')[0];
			comboBoxStartStateFT.Text = elem.StartState.Split('-')[1];
			comboBoxEndStateFL.Text = elem.EndState.Split('-')[0];
			comboBoxEndStateFT.Text = elem.EndState.Split('-')[1];
			textBoxDescription.Text = elem.Description;
			textBoxNumberSituation.Enabled = false;
		}

		private void buttonClose_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.None;
			Close();
		}
	}
}
