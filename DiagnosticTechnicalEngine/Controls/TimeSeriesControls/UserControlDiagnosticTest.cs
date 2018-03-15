using DiagnosticTechnicalEngine.Forms;
using DiagnosticTechnicalEngine.StandartClasses;
using ServicesModule;
using ServicesModule.BindingModels;
using ServicesModule.ViewModels;
using System;
using System.Text;
using System.Windows.Forms;

namespace DiagnosticTechnicalEngine.Controls
{
    public class UserControlDiagnosticTest : StandartSeriesControl<DiagnosticTestViewModel, DiagnosticTestBindingModel, FormDiagnosticTest>
    {
        protected override void InitializeComponent()
        {
            base.InitializeComponent();
            var ColumnId = new DataGridViewTextBoxColumn
            {
                HeaderText = "Id",
                Name = "ColumnId",
                ReadOnly = true,
                Visible = false
            };
            var ColumnNumber = new DataGridViewTextBoxColumn
            {
                HeaderText = "Номер",
                Name = "ColumnNumber",
                ReadOnly = true
            };
            var ColumnFileName = new DataGridViewTextBoxColumn
            {
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                HeaderText = "Путь до файла",
                Name = "ColumnFileName",
                ReadOnly = true
            };
            var ColumnDate = new DataGridViewTextBoxColumn
            {
                HeaderText = "Дата",
                Name = "ColumnDate",
                ReadOnly = true,
                Width = 140
            };

            dataGridView.Columns.AddRange(new DataGridViewColumn[] {
            ColumnId,
            ColumnNumber,
            ColumnFileName,
            ColumnDate});

            groupBox.Text = "Диагностические тесты";

            var buttonForecast = new Button
            {
                Anchor = AnchorStyles.Right,
                Location = new System.Drawing.Point(490, 3),
                Name = "buttonForecast",
                Size = new System.Drawing.Size(100, 23),
                TabIndex = 5,
                Text = "Прогноз",
                UseVisualStyleBackColor = true
            };
            buttonForecast.Click += new EventHandler(ButtonForecast_Click);

            panel.Controls.Add(buttonForecast);
        }

        protected override void LoadData()
        {
            int i = 0;
            foreach (var diagnostic in _list)
            {
                dataGridView.Rows.Add();
                dataGridView.Rows[i].Cells[0].Value = diagnostic.Id;
                dataGridView.Rows[i].Cells[1].Value = diagnostic.TestNumber;
                dataGridView.Rows[i].Cells[2].Value = diagnostic.FileName;
                dataGridView.Rows[i].Cells[3].Value = diagnostic.DateTest.ToLongDateString();
                i++;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonForecast_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView.SelectedRows.Count > 0)
                {
                    StringBuilder sb = new StringBuilder();
                    ModelDiagnosticTest mdt = new ModelDiagnosticTest();
                    for (int i = 0; i < dataGridView.SelectedRows.Count; ++i)
                    {
                        var forecast = mdt.GetForecast(Convert.ToInt32(dataGridView.SelectedRows[i].Cells[0].Value));
                        sb.AppendLine(forecast.ToString());
                    }
                    MessageBox.Show(string.Format("Результат: {0}",sb.ToString()), "Прогноз", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Прогноз", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
