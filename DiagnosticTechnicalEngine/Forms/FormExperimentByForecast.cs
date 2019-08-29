using DTE_Implement_Level;
using System;
using System.Windows.Forms;

namespace DiagnosticTechnicalEngine.Forms
{
    public partial class FormExperimentByForecast : Form
    {
        public FormExperimentByForecast()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ExperimentByForecast ex = new ExperimentByForecast();
            var list = ex.Result(dateTimePicker1.Value);
            var totalSmap1 = 0.0;
            var totalSmap2 = 0.0;
            int totalcount = 0;
            foreach (var elem in list)
            {
                var smapOne = SMAP(elem.Forecast, elem.RealValue);
                totalSmap1 += smapOne;
                double smapeTwo = 0;
                var forecastes = elem.ForecastsByPoint.Replace(elem.Forecast.ToString(), "").Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries );
                if (forecastes.Length > 0)
                {
                    foreach (var forc in forecastes)
                    {
                        smapeTwo += SMAP(Convert.ToDouble(forc), elem.RealValue);
                    }
                    smapeTwo /= forecastes.Length;
                    totalSmap2 += smapeTwo;
                    totalcount++;
                }
                dataGridView1.Rows.Add(new object[] { elem.FileName, elem.RealValue, elem.Forecast, string.Join(";", forecastes), elem.ForecastsByPoint,
                    smapOne.ToString("p"), smapeTwo.ToString("p") });
            }
            totalSmap1 /= list.Count;
            totalSmap2 /= totalcount;
            textBox1.Text = totalSmap1.ToString("p");
            textBox2.Text = totalSmap2.ToString("p");
        }

        private double SMAP(double forecast, double real)
        {
            return Math.Abs(forecast - real) / ((Math.Abs(forecast) + Math.Abs(real)) / 2);
        }
    }
}
