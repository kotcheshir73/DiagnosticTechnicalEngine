using DTE_Implement_Level.Implementations;
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

		private UserControlStatisticByEntropy controlStatisticByEntropy;

		private UserControlStatisticByFuzzy controlStatisticByFuzzy;

		private UserControlAnomalyInfo controlAnomalyInfo;

		private UserControlDiagnosticTest controlDiagnosticTest;

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
				TabIndex = 3
			};
			controlPountTrend.Initialize(new PointTrendService());
			controlRuleTrend = new UserControlRuleTrend
			{
				BackColor = System.Drawing.Color.Transparent,
				Location = new System.Drawing.Point(0, 276),
				MinimumSize = new System.Drawing.Size(530, 200),
				Name = "userControlPountTrend",
				Size = new System.Drawing.Size(600, 200),
				TabIndex = 4
			};
			controlRuleTrend.Initialize(new RuleTrendsService());
			controlStatisticByEntropy = new UserControlStatisticByEntropy
			{
				BackColor = System.Drawing.Color.Transparent,
				Location = new System.Drawing.Point(0, 482),
				MinimumSize = new System.Drawing.Size(530, 200),
				Name = "userControlStatisticByEntropy",
				Size = new System.Drawing.Size(1206, 300),
				TabIndex = 5
			};
			controlStatisticByEntropy.Initialize(new StatisticsByEntropyService());
			controlStatisticByFuzzy = new UserControlStatisticByFuzzy
			{
				BackColor = System.Drawing.Color.Transparent,
				Location = new System.Drawing.Point(0, 788),
				MinimumSize = new System.Drawing.Size(530, 200),
				Name = "userControlStatisticByEntropy",
				Size = new System.Drawing.Size(1206, 300),
				TabIndex = 6
			};
			controlStatisticByFuzzy.Initialize(new StatisticsByFuzzyService());
			controlAnomalyInfo = new UserControlAnomalyInfo
			{
				BackColor = System.Drawing.Color.Transparent,
				Location = new System.Drawing.Point(0, 1094),
				MinimumSize = new System.Drawing.Size(530, 200),
				Name = "userControlStatisticByEntropy",
				Size = new System.Drawing.Size(1206, 300),
				TabIndex = 7
			};
			controlAnomalyInfo.Initialize(new AnomalyInfoService());
			controlDiagnosticTest = new UserControlDiagnosticTest
			{
				BackColor = System.Drawing.Color.Transparent,
				Location = new System.Drawing.Point(0, 1394),
				MinimumSize = new System.Drawing.Size(530, 200),
				Name = "userControlStatisticByEntropy",
				Size = new System.Drawing.Size(1206, 300),
				TabIndex = 7
			};
			controlDiagnosticTest.Initialize(new DiagnosticTestService());
			groupBoxSeries.Controls.Add(controlFuzzyLabel);
			groupBoxSeries.Controls.Add(controlFuzzyTrend);
			groupBoxSeries.Controls.Add(controlPountTrend);
			groupBoxSeries.Controls.Add(controlRuleTrend);
			groupBoxSeries.Controls.Add(controlStatisticByEntropy);
			groupBoxSeries.Controls.Add(controlStatisticByFuzzy);
			groupBoxSeries.Controls.Add(controlAnomalyInfo);
			groupBoxSeries.Controls.Add(controlDiagnosticTest);


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
			controlStatisticByEntropy.ParentId = _seriesId;
			controlStatisticByFuzzy.ParentId = _seriesId;
			controlAnomalyInfo.ParentId = _seriesId;
			controlDiagnosticTest.ParentId = _seriesId;
        }
    }
}
