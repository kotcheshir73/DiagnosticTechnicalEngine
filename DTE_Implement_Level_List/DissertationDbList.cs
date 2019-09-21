using DTE_Model_Level.Models;
using System.Collections.Generic;

namespace DTE_Implement_Level_List
{
    public class DissertationDbList
	{
        private static DissertationDbList instance;

        private DissertationDbList()
        {
            SeriesDescriptions = new List<SeriesDescription>();
            FuzzyLabels = new List<FuzzyLabel>();
            FuzzyTrends = new List<FuzzyTrend>();
            RuleTrends = new List<RuleTrend>();
            PointTrends = new List<PointTrend>();
            AnomalyInfos = new List<AnomalyInfo>();
            StatisticsByEntropys = new List<StatisticsByEntropy>();
            StatisticsByFuzzys = new List<StatisticsByFuzzy>();
            Granules = new List<Granule>();
            GranuleUXs = new List<GranuleUX>();
            GranuleFTs = new List<GranuleFT>();
            GranuleEntropys = new List<GranuleEntropy>();
            GranuleFuzzys = new List<GranuleFuzzy>();
            DiagnosticTests = new List<DiagnosticTest>();
            DiagnosticTestRecords = new List<DiagnosticTestRecord>();
        }

        public static DissertationDbList getInstance()
        {
            if (instance == null)
                instance = new DissertationDbList();
            return instance;
        }

        public List<SeriesDescription> SeriesDescriptions { set; get; }

		public List<FuzzyLabel> FuzzyLabels { set; get; }

		public List<FuzzyTrend> FuzzyTrends { set; get; }

		public List<RuleTrend> RuleTrends { get; set; }

		public List<PointTrend> PointTrends { get; set; }

		public List<AnomalyInfo> AnomalyInfos { set; get; }

		public List<StatisticsByEntropy> StatisticsByEntropys { set; get; }

		public List<StatisticsByFuzzy> StatisticsByFuzzys { set; get; }

        public List<Granule> Granules { get; set; }

        public List<GranuleUX> GranuleUXs { get; set; }

		public List<GranuleFT> GranuleFTs { get; set; }

		public List<GranuleEntropy> GranuleEntropys { get; set; }

		public List<GranuleFuzzy> GranuleFuzzys { get; set; }

		public List<DiagnosticTest> DiagnosticTests { get; set; }

		public List<DiagnosticTestRecord> DiagnosticTestRecords { get; set; }
    }
}