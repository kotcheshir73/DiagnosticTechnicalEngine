using ServicesModule;
using System.Windows.Forms;

namespace DiagnosticTechnicalEngine.Controls
{
    public partial class UserControlSeriesInfo : UserControl
    {
        private int _seriesId;

        private SeriesDescriptionService _logicClass;

        public int SeriesId { set { _seriesId = value; if (_seriesId > 0) { Visible = true; LoadData(); } } }

        public UserControlSeriesInfo()
        {
            InitializeComponent();
            Visible = false;
        }

        private void LoadData()
        {

            _logicClass = new SeriesDescriptionService();

            var series = _logicClass.GetElemSeriesDescrip(_seriesId);
            if (series == null)
            {
                MessageBox.Show("Ошибка при загрузке: " + _logicClass.Error, "Анализ временных рядов",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            groupBoxSeries.Text = series.SeriesName;
            labelDescription.Text = series.SeriesDiscription;
            userControlFuzzyLabel.SeriesId = _seriesId;
			userControlFuzzyTrend.SeriesId = _seriesId;
            userControlRuleTrend.SeriesId = _seriesId;
			userControlPountTrend.SeriesId = _seriesId;
            userControlDiagnosticTest.SeriesId = _seriesId;
        }
    }
}
