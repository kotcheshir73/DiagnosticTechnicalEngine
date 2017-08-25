using ServicesModule;
using ServicesModule.BindingModels;
using DatabaseModule;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace DiagnosticTechnicalEngine.Forms
{
	public partial class FormRuleTrend : Form
    {
        private int? _id;

        private int _seriesId;

        private RuleTrendsService _logicClass;

        public FormRuleTrend(int seriesId, int? id = null)
        {
            InitializeComponent();
            _id = id;
            _seriesId = seriesId;

			comboBoxTrends.DataSource = (new FuzzyTrendService()).GetListFuzzyTrend(_seriesId).Select(t => new {ValueMember = t.Id, DisplayNumber = t.TrendName });
            comboBoxTrends.ValueMember = "Value";
            comboBoxTrends.DisplayMember = "Display";
            var list = (new FuzzyLabelService()).GetListFuzzyLabel(_seriesId);

			comboBoxFuzzyLabelFrom.DataSource = list.Select(t => new { ValueMember = t.Id, DisplayNumber = t.FuzzyLabelName });
			comboBoxFuzzyLabelFrom.ValueMember = "Value";
			comboBoxFuzzyLabelFrom.DisplayMember = "Display";

			comboBoxFuzzyLabelTo.DataSource = list.Select(t => new { ValueMember = t.Id, DisplayNumber = t.FuzzyLabelName });
			comboBoxFuzzyLabelTo.ValueMember = "Value";
			comboBoxFuzzyLabelTo.DisplayMember = "Display";
        }

        private void FormRuleTrend_Load(object sender, EventArgs e)
        {
            _logicClass = new RuleTrendsService();
            if (_id.HasValue)
            {
				var elem = _logicClass.GetElemRuleTrend(_id.Value);
				if(elem != null)
				{
					comboBoxTrends.SelectedValue = elem.FuzzyTrendId;
					comboBoxFuzzyLabelFrom.SelectedValue = elem.FuzzyLabelFromId;
					comboBoxFuzzyLabelTo.SelectedValue = elem.FuzzyLabelToId;
				}
				
                buttonSave.Enabled = false;
            }
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonSave.Enabled = true;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (!_id.HasValue)
            {
				if (!_logicClass.AddRuleTrend(new RuleTrendBindingModel
				{
					SeriesId = _seriesId,
					FuzzyTrendId = Convert.ToInt32(comboBoxTrends.SelectedValue),
					FuzzyLabelFromId = Convert.ToInt32(comboBoxFuzzyLabelFrom.SelectedValue),
					FuzzyLabelToId = Convert.ToInt32(comboBoxFuzzyLabelTo.SelectedValue),
					FuzzyTrendName = Converter.ToFuzzyTrendLabel(comboBoxTrends.Text)
				}))
				{
					MessageBox.Show("Ошибка при добавлении: " + _logicClass.Error, "Анализ временных рядов",
					 MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
				else
				{
					DialogResult = DialogResult.OK;
					Close();
				}
			}
            else
            {
				if (!_logicClass.UpdRuleTrend(new RuleTrendBindingModel
				{
					Id = _id.Value,
					SeriesId = _seriesId,
					FuzzyTrendId = Convert.ToInt32(comboBoxTrends.SelectedValue),
					FuzzyLabelFromId = Convert.ToInt32(comboBoxFuzzyLabelFrom.SelectedValue),
					FuzzyLabelToId = Convert.ToInt32(comboBoxFuzzyLabelTo.SelectedValue),
					FuzzyTrendName = Converter.ToFuzzyTrendLabel(comboBoxTrends.Text)
				}))
				{
					MessageBox.Show("Ошибка при изменении: " + _logicClass.Error, "Анализ временных рядов",
					 MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
				else
				{
					DialogResult = DialogResult.OK;
					Close();
				}
			}
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            if (buttonSave.Enabled)
            {
                if (MessageBox.Show("Сохранить изменения?", "Анализ временных рядов", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    buttonSave_Click(sender, e);
                }
                else
                {
                    DialogResult = DialogResult.Cancel;
                    Close();
                }
            }
            else
            {
                DialogResult = DialogResult.None;
                Close();
            }
        }
    }
}
