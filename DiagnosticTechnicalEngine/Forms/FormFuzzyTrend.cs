using DatabaseModule;
using ServicesModule;
using ServicesModule.BindingModels;
using System;
using System.Windows.Forms;

namespace DiagnosticTechnicalEngine.Forms
{
	public partial class FormFuzzyTrend : Form
	{
		private int? _id;

		private int _seriesId;

		private FuzzyTrendService _logicClass;

		public FormFuzzyTrend(int seriesId, int? id = null)
		{
			InitializeComponent();
			_id = id;
			_seriesId = seriesId;
		}

		private void FormFuzzyTrend_Load(object sender, EventArgs e)
		{
			try
			{
				_logicClass = new FuzzyTrendService();
				foreach (var elem in Enum.GetValues(typeof(FuzzyTrendLabel)))
				{
					comboBoxTrendNames.Items.Add(elem.ToString());
				}
				comboBoxTrendNames.SelectedIndex = 0;
				if (_id.HasValue)
				{
					var elem = _logicClass.GetElement(_id.Value);
					comboBoxTrendNames.SelectedIndex = comboBoxTrendNames.Items.IndexOf(elem.TrendName);
					comboBoxTrendNames.Enabled = false;
					textBoxWeight.Text = elem.Weight.ToString();
					buttonSave.Enabled = false;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Ошибка при загрузке: " + ex.Message, "Анализ временных рядов",
				 MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void textBox_TextChanged(object sender, EventArgs e)
		{
			buttonSave.Enabled = true;
		}

		private void buttonSave_Click(object sender, EventArgs e)
		{
			try
			{
				if (!_id.HasValue)
				{
					_logicClass.InsertElement(new FuzzyTrendBindingModel
					{
						SeriesId = _seriesId,
						TrendName = Converter.ToFuzzyTrendLabel(comboBoxTrendNames.Text),
						Weight = Convert.ToInt32(textBoxWeight.Text)
					});
				}
				else
				{
					_logicClass.UpdateElement(new FuzzyTrendBindingModel
					{
						Id = _id.Value,
						SeriesId = _seriesId,
						TrendName = Converter.ToFuzzyTrendLabel(comboBoxTrendNames.Text),
						Weight = Convert.ToInt32(textBoxWeight.Text)
					});
				}
				DialogResult = DialogResult.OK;
				Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Ошибка при сохранении: " + ex.Message, "Анализ временных рядов",
				 MessageBoxButtons.OK, MessageBoxIcon.Error);
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
