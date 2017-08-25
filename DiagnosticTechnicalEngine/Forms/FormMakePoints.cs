using ServicesModule;
using ServicesModule.BindingModels;
using DatabaseModule;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DiagnosticTechnicalEngine.Forms
{
	public partial class FormMakePoints : Form
	{
		private int _seriesId;

		public FormMakePoints(int seriesId)
		{
			InitializeComponent();

			listBoxElements.Items.Clear();
			foreach (var elem in Enum.GetValues(typeof(TypeDataInFile)))
			{
				listBoxElements.Items.Add(elem.ToString());
			}

			comboBoxTypeFile.Items.Clear();
			foreach (var elem in Enum.GetValues(typeof(TypeFile)))
			{
				comboBoxTypeFile.Items.Add(elem.ToString());
			}
			_seriesId = seriesId;
		}

		private void buttonSelect_Click(object sender, EventArgs e)
		{
			if (listBoxElements.SelectedIndex != -1)
			{
				if (listBoxSelected.Items.Count > 0)
				{
					for (int i = 0; i < listBoxSelected.Items.Count; ++i)
						if (listBoxSelected.Items[i] == listBoxElements.Items[listBoxElements.SelectedIndex])
						{
							MessageBox.Show("Уже есть", "Анализ временных рядов",
							 MessageBoxButtons.OK, MessageBoxIcon.Error);
							return;
						}
				}
				listBoxSelected.Items.Add(listBoxElements.Items[listBoxElements.SelectedIndex]);
			}
		}

		private void buttonCancelSelect_Click(object sender, EventArgs e)
		{
			if (listBoxSelected.SelectedIndex != -1)
			{
				listBoxSelected.Items.RemoveAt(listBoxSelected.SelectedIndex);
			}
		}
		
		private void buttonUpToList_Click(object sender, EventArgs e)
		{
			if (listBoxSelected.SelectedIndex > 0)
			{
				var elem = listBoxSelected.Items[listBoxSelected.SelectedIndex - 1];
				listBoxSelected.Items[listBoxSelected.SelectedIndex - 1] =
					listBoxSelected.Items[listBoxSelected.SelectedIndex];
				listBoxSelected.Items[listBoxSelected.SelectedIndex] = elem;
				listBoxSelected.SelectedIndex--;
			}
		}

		private void buttonDownToList_Click(object sender, EventArgs e)
		{
			if (listBoxSelected.SelectedIndex < listBoxSelected.Items.Count - 1 && listBoxSelected.SelectedIndex > -1)
			{
				var elem = listBoxSelected.Items[listBoxSelected.SelectedIndex + 1];
				listBoxSelected.Items[listBoxSelected.SelectedIndex + 1] =
					listBoxSelected.Items[listBoxSelected.SelectedIndex];
				listBoxSelected.Items[listBoxSelected.SelectedIndex] = elem;
				listBoxSelected.SelectedIndex++;
			}
		}

		private void buttonLoad_Click(object sender, EventArgs e)
		{
			if (listBoxSelected.Items.Count == 0)
			{
				MessageBox.Show("Укажите что считывать", "Анализ временных рядов",
				 MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			var _list = new List<TypeDataInFile>();
			for (int i = 0; i < listBoxSelected.Items.Count; ++i)
			{
				_list.Add(Converter.ToTypeDataInFile(listBoxSelected.Items[i].ToString()));
			}
			if (comboBoxTypeFile.SelectedIndex == -1)
			{
				MessageBox.Show("Укажите тип файла", "Анализ временных рядов",
				 MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			var _dialog = new OpenFileDialog();
			var _typeFile = comboBoxTypeFile.Text;
			switch (comboBoxTypeFile.SelectedIndex)
			{
				case 1:
					_dialog.Filter = "Excel files(*.xls)|*.xls|Excel files(*.xlsx)|*.xlsx";
					break;
				case 0:
					_dialog.Filter = "Txt files (*.txt)|*.txt";
					break;
			}
			if (_dialog.ShowDialog() == DialogResult.OK)
			{

				var logic = new PointTrendService();
				if (!logic.CalcPointsTrend(new PointTrendCalcBindingModel
				{
					FileName = _dialog.FileName,
					TypeFile = Converter.ToTypeFile(_typeFile),
					DatasInFile = _list,
					SeriesDiscriptionId = _seriesId
				}))
				{
					MessageBox.Show("Ошибка при обработке: " + logic.Error, "Анализ временных рядов",
					 MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else
				{
					MessageBox.Show("Сделано", "Анализ временных рядов", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
		}
	}
}
