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

            var trends = (new FuzzyTrendService()).GetListFuzzyTrend(_seriesId).ToList();
            comboBoxStartStateFT.DataSource = trends.Select(t => new { Value = t.Id, Display = t.TrendName }).ToList();
            comboBoxStartStateFT.ValueMember = "Value";
            comboBoxStartStateFT.DisplayMember = "Display";
            comboBoxEndStateFT.DataSource = trends.Select(t => new { Value = t.Id, Display = t.TrendName }).ToList();
            comboBoxEndStateFT.ValueMember = "Value";
            comboBoxEndStateFT.DisplayMember = "Display";

            var labels = (new FuzzyLabelService()).GetListFuzzyLabel(_seriesId);
            comboBoxStartStateFL.DataSource = labels.Select(t => new { Value = t.Id, Display = t.FuzzyLabelName }).ToList();
            comboBoxStartStateFL.ValueMember = "Value";
            comboBoxStartStateFL.DisplayMember = "Display";
            comboBoxEndStateFL.DataSource = labels.Select(t => new { Value = t.Id, Display = t.FuzzyLabelName }).ToList();
            comboBoxEndStateFL.ValueMember = "Value";
            comboBoxEndStateFL.DisplayMember = "Display";
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
			comboBoxStartStateFL.SelectedValue = elem.StartStateFuzzyLabelId;
            comboBoxStartStateFL.Enabled = false;
			comboBoxStartStateFT.SelectedValue = elem.StartStateFuzzyTrendId;
            comboBoxStartStateFT.Enabled = false;
			comboBoxEndStateFL.SelectedValue = elem.EndStateFuzzyLabelId;
            comboBoxEndStateFL.Enabled = false;
			comboBoxEndStateFT.SelectedValue = elem.EndStateFuzzyTrendId;
            comboBoxEndStateFT.Enabled = false;
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
