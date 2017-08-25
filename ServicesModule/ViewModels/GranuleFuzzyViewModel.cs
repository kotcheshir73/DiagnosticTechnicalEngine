namespace ServicesModule.ViewModels
{
	public class GranuleFuzzyViewModel
	{
		public int Id { get; set; }

		public int DiagnosticTestId { get; set; }

		public int GranulePosition { get; set; }

		public string FuzzyLabelName { get; set; }

		public string FuzzyTrendName { get; set; }

		public int Count { get; set; }
	}
}
