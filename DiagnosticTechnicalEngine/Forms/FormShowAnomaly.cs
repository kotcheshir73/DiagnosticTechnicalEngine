using ServicesModule;
using System;
using System.Windows.Forms;

namespace DiagnosticTechnicalEngine.Forms
{
	public partial class FormShowAnomaly : Form
    {
        private int _id;

        private AnomalyInfoService _logicClass;

        public FormShowAnomaly(int id)
        {
            InitializeComponent();
            _id = id;
        }

        private void FormShowAnomaly_Load(object sender, EventArgs e)
        {
            _logicClass = new AnomalyInfoService();
            if (_id != 0)
            {
                //var elem = _logicClass.GetElemAnomalyInfo(_id);
                //if (elem == null)
                //{
                //    MessageBox.Show("Ошибка при загрузке: " + _logicClass.Error, "Анализ временных рядов",
                //     MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}
                //switch(elem.TypeMemoryValues)
                //{
                //    case 0:
                //        chart.Titles["Title"].Text = "График аномалии " + elem.AnomalyName + 
                //            " по значению точек ряда";
                //        break;
                //    case 1:
                //        chart.Titles["Title"].Text = "График аномалии " + elem.AnomalyName + 
                //            " по функции принадлежности точек ряда";
                //        break;
                //    default:
                //        if(elem.SetValues == "")
                //        {
                //            MessageBox.Show("Нет значений для отображения", "Анализ временных рядов",
                //             MessageBoxButtons.OK, MessageBoxIcon.Error);
                //            return;
                //        }
                //        chart.Titles["Title"].Text = "График аномалии " + elem.AnomalyName;
                //        break;
                //}
                //for(int i = 0; i < elem.SetValues.Split(';').Length; ++i)
                //{
                //    chart.Series["Series"].Points.AddXY(i, Convert.ToDouble(elem.SetValues.Split(';')[i]));
                //}
            }
        }
    }
}
