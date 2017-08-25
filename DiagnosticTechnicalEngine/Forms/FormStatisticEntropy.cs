using ServicesModule;
using DatabaseModule;
using System;
using System.Windows.Forms;

namespace DiagnosticTechnicalEngine.Forms
{
	public partial class FormStatisticEntropy : Form
	{
		private int _id;

		private StatisticsByEntropyService _logicClass;

		public FormStatisticEntropy(int id)
		{
			InitializeComponent();
			_id = id;

			for (int i = 0; i < EntropyByUX.Entropyes.Count; ++i)
			{
				comboBoxStartStateUX.Items.Add(EntropyByUX.Entropyes[i]);
				comboBoxEndStateUX.Items.Add(EntropyByUX.Entropyes[i]);
			}
			for (int i = 0; i < EntropyByFT.Entropyes.Count; ++i)
			{
				comboBoxStartStateFT.Items.Add(EntropyByFT.Entropyes[i]);
				comboBoxEndStateFT.Items.Add(EntropyByFT.Entropyes[i]);
			}
		}

		private void FormStatisticEntropy_Load(object sender, EventArgs e)
		{
			_logicClass = new StatisticsByEntropyService();
			var elem = _logicClass.GetElemStatisticsByEntropy(_id);
			if (elem == null)
			{
				MessageBox.Show("Ошибка при загрузке: " + _logicClass.Error, "Анализ временных рядов",
				 MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			textBoxNumberSituation.Text = elem.NumberSituation.ToString();
			comboBoxStartStateUX.SelectedIndex = comboBoxStartStateUX.Items.IndexOf(elem.StartStateLingvistUX);
			comboBoxStartStateFT.SelectedIndex = comboBoxStartStateFT.Items.IndexOf(elem.StartStateLingvistFT);
			comboBoxEndStateUX.SelectedIndex = comboBoxEndStateUX.Items.IndexOf(elem.EndStateLingvistUX);
			comboBoxEndStateFT.SelectedIndex = comboBoxEndStateFT.Items.IndexOf(elem.EndStateLingvistFT);
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
