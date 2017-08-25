using ServicesModule;
using ServicesModule.BindingModels;
using System;
using System.Windows.Forms;

namespace DiagnosticTechnicalEngine.Forms
{
	public partial class FormPointTrend : Form
	{
		private int? _id;

		private int _seriesId;

		private BLClassPointTrend _logicClass;

		public FormPointTrend(int seriesId, int? id = null)
		{
			InitializeComponent();
			_id = id;
			_seriesId = seriesId;
		}

		private void FormPointTrend_Load(object sender, EventArgs e)
		{
			_logicClass = new BLClassPointTrend();
			if (_id.HasValue)
			{
				var elem = _logicClass.GetElemPointTrend(_id.Value);
				if (elem != null)
				{
					textBoxStartPoint.Text = elem.StartPoint.ToString();
					textBoxFinishPoint.Text = elem.FinishPoint.ToString();
					textBoxCount.Text = elem.Count.ToString();
					textBoxWeight.Text = elem.Weight.ToString();	
				}

				buttonSave.Enabled = false;
			}
		}

		private void textBox_TextChanged(object sender, EventArgs e)
		{
			buttonSave.Enabled = true;
		}

		private void buttonSave_Click(object sender, EventArgs e)
		{
			if (!_id.HasValue)
			{
				if (!_logicClass.AddPointTrend(new PointTrendBindingModel
				{
					SeriesId = _seriesId,
					StartPoint = Convert.ToInt32(textBoxStartPoint.Text),
					FinishPoint = Convert.ToInt32(textBoxFinishPoint.Text),
					Count = Convert.ToInt32(textBoxCount.Text),
					Weight = Convert.ToDouble(textBoxWeight.Text)
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
				if (!_logicClass.UpdPointTrend(new PointTrendBindingModel
				{
					Id = _id.Value,
					SeriesId = _seriesId,
					StartPoint = Convert.ToInt32(textBoxStartPoint.Text),
					FinishPoint = Convert.ToInt32(textBoxFinishPoint.Text),
					Count = Convert.ToInt32(textBoxCount.Text),
					Weight = Convert.ToDouble(textBoxWeight.Text)
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
