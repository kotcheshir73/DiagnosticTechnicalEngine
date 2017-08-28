using ServicesModule;
using ServicesModule.BindingModels;
using DatabaseModule;
using System;
using System.Windows.Forms;

namespace DiagnosticTechnicalEngine.Forms
{
	public partial class FormAnomalyInfo : Form
	{
		private int _id;

		private int _diagnosticTestId;

		private AnomalyInfoService _logicClass;

		public FormAnomalyInfo(int seriesId, int id)
		{
			InitializeComponent();
			_id = id;
		}

		private void FormAnomalyInfo_Load(object sender, EventArgs e)
		{
			_logicClass = new AnomalyInfoService();
			foreach (var val in Enum.GetValues(typeof(TypeSituation)))
			{
				comboBoxTypeSituation.Items.Add(val.ToString());
			}
			comboBoxTypeSituation.SelectedIndex = 0;
			foreach (var val in Enum.GetValues(typeof(TypeMemoryValue)))
			{
				comboBoxTypeMemory.Items.Add(val.ToString());
			}
			comboBoxTypeMemory.SelectedIndex = 0;

			var elem = _logicClass.GetElemAnomalyInfo(_id);
			if (elem == null)
			{
				MessageBox.Show("Ошибка при загрузке: " + _logicClass.Error, "Анализ временных рядов",
				 MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			_diagnosticTestId = elem.DiagnosticTestId;
			comboBoxTypeSituation.SelectedIndex = comboBoxTypeSituation.Items.IndexOf(elem.TypeSituation);
			textBoxName.Text = elem.AnomalyName;
			textBoxAnomalySituation.Text = elem.AnomalySituation.ToString();
			textBoxSetSituation.Text = elem.SetSituations;
			comboBoxTypeMemory.SelectedIndex = comboBoxTypeMemory.Items.IndexOf(elem.TypeMemoryValue);
			textBoxSetValues.Text = elem.SetValues;
			textBoxDescription.Text = elem.Description;
			checkBoxNotAnomaly.Checked = elem.NotAnomaly;
			checkBoxNotDetected.Checked = elem.NotDetected;
			comboBoxTypeSituation.Enabled = false;
			buttonSave.Enabled = false;

            textBoxDesription.Text = elem.Rashifrovka;

            switch (elem.TypeMemoryValue)
            {
                case TypeMemoryValue.ПоЗначению:
                    chart.Titles["Title"].Text = "График аномалии " + elem.AnomalyName +
                        " по значению точек ряда";
                    break;
                case TypeMemoryValue.ПоФункции:
                    chart.Titles["Title"].Text = "График аномалии " + elem.AnomalyName +
                        " по функции принадлежности точек ряда";
                    break;
            }
            for (int i = 0; i < elem.SetValues.Split(';').Length; ++i)
            {
                chart.Series["Series"].Points.AddXY(i, Convert.ToDouble(elem.SetValues.Split(';')[i]));
            }
        }

		private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			buttonSave.Enabled = true;
		}

		private void textBox_TextChanged(object sender, EventArgs e)
		{
			buttonSave.Enabled = true;
		}

		private void checkBox_CheckedChanged(object sender, EventArgs e)
		{
			buttonSave.Enabled = true;
		}

		private void buttonSave_Click(object sender, EventArgs e)
		{
			if (!_logicClass.UpdAnomalyInfo(new AnomalyInfoBindingModel
			{
				Id = _id,
				DiagnosticTestId = _diagnosticTestId,
				TypeSituation = comboBoxTypeSituation.Text,
				AnomalyName = textBoxName.Text,
				AnomalySituation =
				Convert.ToInt32(textBoxAnomalySituation.Text),
				SetSituations = textBoxSetSituation.Text,
				TypeMemoryValue = comboBoxTypeMemory.Text,
				SetValues = textBoxSetValues.Text,
				Description = textBoxDescription.Text,
				NotAnomaly = checkBoxNotAnomaly.Checked,
				NotDetected = checkBoxNotDetected.Checked
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
