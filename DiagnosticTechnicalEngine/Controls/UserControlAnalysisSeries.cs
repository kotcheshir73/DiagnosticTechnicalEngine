﻿using DTE_Implement_Level;
using DTE_Implement_Level.StaticClasses;
using DTE_Interface_Level.BindingModels;
using DTE_Interface_Level.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace DiagnosticTechnicalEngine.Controls
{
    public partial class UserControlAnalysisSeries : UserControl
	{
		private int? _seriesId;

		OpenFileDialog _dialog;

		List<TypeDataInFile> _list;

		private string _typeFile;

		private StreamWriter _writer;

		public int? SeriesId
		{
			set
			{
				_seriesId = value;
				buttonLoad.Enabled = _seriesId.HasValue;
			}
		}

		public UserControlAnalysisSeries()
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
            if(textBoxNumber.Text == "")
            {
                MessageBox.Show("Укажите номер теста", "Анализ временных рядов",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
			if (listBoxSelected.Items.Count == 0)
			{
				MessageBox.Show("Укажите что считывать", "Анализ временных рядов",
				 MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			_list = new List<TypeDataInFile>();
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

			_dialog = new OpenFileDialog();
			_typeFile = comboBoxTypeFile.Text;
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
				if (checkBoxSaveLog.Checked)
				{
					_writer = new StreamWriter(_dialog.FileName + "_log.txt");
				}
				richTextBox.Text = "";
				richTextBox.SelectionAlignment = HorizontalAlignment.Center;
				richTextBox.SelectionFont = new Font("Microsoft Sans Serif", 14f, FontStyle.Bold);
				richTextBox.AppendText("Результат анализа:\r\n");
				richTextBox.SelectionAlignment = HorizontalAlignment.Left;

				var logic = new ModelDiagnosticTest();
				try
				{
					logic.MakeDiagnosticTest(new DiagnosticTestBindingModel
					{
						TestNumber = textBoxNumber.Text,
						FileName = _dialog.FileName,
						TypeFile = Converter.ToTypeFile(_typeFile),
						DatasInFile = _list,
						SeriesDiscriptionId = _seriesId.Value,
						CountPointsForMemmory = Convert.ToInt32(textBoxCountPointsForMemmory.Text),
						MessagerEvent = AddMessage,
						MessageCountPoint = AddValue,
						MakeGranuleUX = checkBoxGranuleUX.Checked,
						MakeGranuleFT = checkBoxGranuleFT.Checked,
						MakeGranuleEntropy = checkBoxGranuleEntropy.Checked,
						MakeGranuleFuzzy = checkBoxGranuleFuzzy.Checked
					});
					if (checkBoxSaveLog.Checked)
					{
						_writer.WriteLine("Сделано");
					}
					else
					{
						MessageBox.Show("Сделано", "Анализ временных рядов",
						 MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
				}
				catch (Exception ex)
				{
					if (checkBoxSaveLog.Checked)
					{
						_writer.WriteLine("Ошибка при обработке: " + ex.Message);
					}
					else
					{
						MessageBox.Show("Ошибка при обработке: " + ex.Message, "Анализ временных рядов", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
				finally
				{
					if (checkBoxSaveLog.Checked)
					{
						_writer.Close();
					}
				}
			}
		}

		private void AddMessage(string text)
		{
			richTextBox.SelectionFont = new Font("Microsoft Sans Serif", 12f);
			richTextBox.AppendText(text + "\r\n");

			if (checkBoxSaveLog.Checked)
			{
				_writer.WriteLine(text);
			}
		}

		private void AddValue(string text)
		{
			labelCountLoadPoints.Text = "Обработано: " + text;
		}
	}
}
