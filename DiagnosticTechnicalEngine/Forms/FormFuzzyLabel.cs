using ServicesModule;
using ServicesModule.BindingModels;
using DatabaseModule;
using System;
using System.Windows.Forms;

namespace DiagnosticTechnicalEngine.Forms
{
	public partial class FormFuzzyLabel : Form
    {
        private int? _id;

        private int _seriesId;

        private FuzzyLabelService _logicClass;

        public FormFuzzyLabel(int seriesId, int? id = null)
        {
            InitializeComponent();
            _id = id;
            _seriesId = seriesId;
        }

        private void FormFuzzyLabel_Load(object sender, EventArgs e)
        {
            _logicClass = new FuzzyLabelService();
			foreach (var elem in Enum.GetValues(typeof(FuzzyLabelType)))
			{
				comboBoxType.Items.Add(elem.ToString());
			}
			comboBoxType.SelectedIndex = 0;
			if (_id.HasValue)
            {
                var elem = _logicClass.GetElemFuzzyLabel(_id.Value);
                if (elem == null)
                {
                    MessageBox.Show("Ошибка при загрузке: " + _logicClass.Error, "Анализ временных рядов",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                comboBoxType.SelectedIndex = comboBoxType.Items.IndexOf(elem.FuzzyLabelType);
                comboBoxType.Enabled = false;
                textBoxName.Text = elem.FuzzyLabelName;
                textBoxWeight.Text = elem.FuzzyLabelWeight.ToString();
                textBoxMinVal.Text = elem.FuzzyLabelMinVal.ToString();
                textBoxCenter.Text = elem.FuzzyLabelCenter.ToString();
                textBoxMaxVal.Text = elem.FuzzyLabelMaxVal.ToString();
                buttonSave.Enabled = false;
            }
        }

        private void comboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonSave.Enabled = true;
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            buttonSave.Enabled = true;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
			if (!_id.HasValue)
			{
				if (!_logicClass.AddFuzzyLabel(new FuzzyLabelBindingModel
				{
					SeriesId = _seriesId,
					FuzzyLabelType = Converter.ToFuzzyLabelType(comboBoxType.Text),
					FuzzyLabelName = textBoxName.Text,
					Weigth = Convert.ToInt32(textBoxWeight.Text),
					MinVal = Convert.ToDouble(textBoxMinVal.Text),
					Center = Convert.ToDouble(textBoxCenter.Text),
					MaxVal = Convert.ToDouble(textBoxMaxVal.Text)
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
                if (!_logicClass.UpdFuzzyLabel(new FuzzyLabelBindingModel
				{
					Id = _id.Value,
					SeriesId = _seriesId,
					FuzzyLabelType = Converter.ToFuzzyLabelType(comboBoxType.Text),
					FuzzyLabelName = textBoxName.Text,
					Weigth = Convert.ToInt32(textBoxWeight.Text),
					MinVal = Convert.ToDouble(textBoxMinVal.Text),
					Center = Convert.ToDouble(textBoxCenter.Text),
					MaxVal = Convert.ToDouble(textBoxMaxVal.Text)
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
