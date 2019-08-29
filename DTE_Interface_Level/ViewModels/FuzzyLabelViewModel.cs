namespace DTE_Interface_Level.ViewModels
{
	public class FuzzyLabelViewModel
	{
		public int Id { get; set; }

		public int SeriesDiscriptionId { get; set; }

		public string FuzzyLabelType { get; set; }

		public string FuzzyLabelName { get; set; }

		public int FuzzyLabelWeight { get; set; }

		public double FuzzyLabelMinVal { get; set; }

		public double FuzzyLabelCenter { get; set; }

		public double FuzzyLabelMaxVal { get; set; }
	}
}