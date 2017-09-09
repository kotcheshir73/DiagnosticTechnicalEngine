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

		private UserControlFuzzyLabel controlFuzzyLabel;

		private UserControlFuzzyTrend controlFuzzyTrend;

		private UserControlPountTrend controlPountTrend;

		private UserControlRuleTrend controlRuleTrend;

		public UserControlSeriesInfo()
		{
			InitializeComponent();
			controlFuzzyLabel = new UserControlFuzzyLabel
			{
				BackColor = System.Drawing.Color.Transparent,
				Location = new System.Drawing.Point(0, 70),
				MinimumSize = new System.Drawing.Size(530, 200),
				Name = "userControlFuzzyLabel",
				Size = new System.Drawing.Size(600, 200),
				TabIndex = 1
			};
			controlFuzzyLabel.Initialize(new FuzzyLabelService());
			controlFuzzyTrend = new UserControlFuzzyTrend
			{
				BackColor = System.Drawing.Color.Transparent,
				Location = new System.Drawing.Point(606, 70),
				MinimumSize = new System.Drawing.Size(530, 200),
				Name = "userControlFuzzyTrend",
				Size = new System.Drawing.Size(600, 200),
				TabIndex = 2
			};
			controlFuzzyTrend.Initialize(new FuzzyTrendService());
			controlPountTrend = new UserControlPountTrend
			{
				BackColor = System.Drawing.Color.Transparent,
				Location = new System.Drawing.Point(606, 276),
				MinimumSize = new System.Drawing.Size(530, 200),
				Name = "userControlPountTrend",
				Size = new System.Drawing.Size(600, 200),
				TabIndex = 1
			};
			controlPountTrend.Initialize(new PointTrendService());
			controlRuleTrend = new UserControlRuleTrend
			{
				BackColor = System.Drawing.Color.Transparent,
				Location = new System.Drawing.Point(0, 276),
				MinimumSize = new System.Drawing.Size(530, 200),
				Name = "userControlPountTrend",
				Size = new System.Drawing.Size(600, 200),
				TabIndex = 1
			};
			controlRuleTrend.Initialize(new RuleTrendsService());
			groupBoxSeries.Controls.Add(controlFuzzyLabel);
			groupBoxSeries.Controls.Add(controlFuzzyTrend);
			groupBoxSeries.Controls.Add(controlPountTrend);
			groupBoxSeries.Controls.Add(controlRuleTrend);


			Visible = false;
        }

        private void LoadData()
        {
            _logicClass = new SeriesDescriptionService();

            var series = _logicClass.GetElement(_seriesId);
            groupBoxSeries.Text = series.SeriesName;
            labelDescription.Text = series.SeriesDiscription;
			controlFuzzyLabel.ParentId = _seriesId;
			controlFuzzyTrend.ParentId = _seriesId;
			controlRuleTrend.ParentId = _seriesId;
			controlPountTrend.ParentId = _seriesId;
            userControlDiagnosticTest.SeriesId = _seriesId;
        }
    }
}
