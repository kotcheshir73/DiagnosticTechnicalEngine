using ServicesModule;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            foreach (var elem in list)
            {
                var smapOne = SMAP(elem.Forecast, elem.RealValue);
                totalSmap1 += smapOne;
                double smapeTwo = 0;
                var forecastes = elem.ForecastsByPoint.Split(';');
                foreach(var forc in forecastes)
                {
                    smapeTwo += SMAP(Convert.ToDouble(forc), elem.RealValue);
                }
                smapeTwo /= forecastes.Length;
                totalSmap2 += smapeTwo;
                dataGridView1.Rows.Add(new object[] { elem.FileName, elem.RealValue, elem.Forecast, elem.ForecastsByPoint, smapOne.ToString("p"), smapeTwo.ToString("p") });
            }
            totalSmap1 /= list.Count;
            totalSmap2 /= list.Count;
            textBox1.Text = totalSmap1.ToString("p");
            textBox2.Text = totalSmap2.ToString("p");
        }

        private double SMAP(double forecast, double real)
        {
            return Math.Abs(forecast - real) / ((Math.Abs(forecast) + Math.Abs(real)) / 2);
        }
    }
}
