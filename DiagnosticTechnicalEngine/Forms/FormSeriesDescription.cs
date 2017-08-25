using ServicesModule;
using ServicesModule.BindingModels;
using System;
using System.Windows.Forms;

namespace DiagnosticTechnicalEngine.Forms
{
	public partial class FormSeriesDescription : Form
	{
		private int? _id;

		private SeriesDescriptionService _logicClass;

		public FormSeriesDescription(int? id = null)
		{
			InitializeComponent();
			_id = id;
		}

		private void FormSeriesDescription_Load(object sender, EventArgs e)
		{
			_logicClass = new SeriesDescriptionService();
			if (_id.HasValue)
			{
				var elem = _logicClass.GetElemSeriesDescrip(_id.Value);
				if (elem == null)
				{
					MessageBox.Show("Ошибка при загрузке: " + _logicClass.Error, "Анализ временных рядов",
					 MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
				textBoxName.Text = elem.SeriesName;
				textBoxDescription.Text = elem.SeriesDiscription;
				buttonSave.Enabled = false;
			}
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
			if (!_id.HasValue)
			{
				if (!_logicClass.AddSeriesDescrip(new SeriesDescriptionBindingModel
				{
					SeriesName = textBoxName.Text,
					SeriesDiscription = textBoxDescription.Text
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
				if (!_logicClass.UpdSeriesDescrip(new SeriesDescriptionBindingModel
				{
					Id = _id.Value,
					SeriesName = textBoxName.Text,
					SeriesDiscription = textBoxDescription.Text
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
