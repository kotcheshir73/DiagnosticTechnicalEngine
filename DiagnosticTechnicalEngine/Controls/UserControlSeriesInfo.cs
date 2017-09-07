using DiagnosticTechnicalEngine.Forms;
using ServicesModule;
using System.Windows.Forms;

namespace DiagnosticTechnicalEngine.Controls
{
    public partial class UserControlSeriesInfo : UserControl
    {
        private int _seriesId;

        private SeriesDescriptionService _logicClass;

        public int SeriesId { set { _seriesId = value; if (_seriesId > 0) { Visible = true; LoadData(); } } }

		private UserControlFuzzyLabel1 controlFuzzyLabel;

		public UserControlSeriesInfo()
		{
			InitializeComponent();
			controlFuzzyLabel = new UserControlFuzzyLabel1();
			controlFuzzyLabel.Initialize(new FuzzyLabelService(), new FormFuzzyLabel());
			controlFuzzyLabel.BackColor = System.Drawing.Color.Transparent;
			controlFuzzyLabel.Location = new System.Drawing.Point(0, 70);
			controlFuzzyLabel.MinimumSize = new System.Drawing.Size(530, 200);
			controlFuzzyLabel.Name = "userControlFuzzyLabel";
			controlFuzzyLabel.Size = new System.Drawing.Size(600, 200);
			controlFuzzyLabel.TabIndex = 1;
			groupBoxSeries.Controls.Add(controlFuzzyLabel);


			Visible = false;
        }

        private void LoadData()
        {

            _logicClass = new SeriesDescriptionService();

            var series = _logicClass.GetElement(_seriesId);
            groupBoxSeries.Text = series.SeriesName;
            labelDescription.Text = series.SeriesDiscription;
			controlFuzzyLabel.SeriesId = _seriesId;
			userControlFuzzyTrend.SeriesId = _seriesId;
            userControlRuleTrend.SeriesId = _seriesId;
			userControlPountTrend.SeriesId = _seriesId;
            userControlDiagnosticTest.SeriesId = _seriesId;
        }
    }
}
