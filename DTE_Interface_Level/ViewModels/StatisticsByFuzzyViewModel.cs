namespace DTE_Interface_Level.ViewModels
{
    public class StatisticsByFuzzyViewModel
	{
		public int Id { get; set; }

		public int SeriesDiscriptionId { get; set; }

		public int NumberSituation { get; set; }

		public string Description { get; set; }

		public int StartStateFuzzyLabelId { get; set; }

		public int StartStateFuzzyTrendId { get; set; }

		public int EndStateFuzzyLabelId { get; set; }

		public int EndStateFuzzyTrendId { get; set; }

		public int CountMeet { get; set; }
	}
}