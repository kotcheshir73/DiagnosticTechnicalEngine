namespace DTE_Interface_Level.ViewModels
{
	public class RuleTrendViewModel
	{
		public int Id { get; set; }

		public int SeriesDiscriptionId { get; set; }

		public int FuzzyTrendId { get; set; }
		/// <summary>
		/// Нечеткая тенденция
		/// </summary>
		public string FuzzyTrendName { get; set; }
		/// <summary>
		/// Вес нечеткой тенденции
		/// </summary>
		public int FuzzyTrendWeight { get; set; }

		public int FuzzyLabelFromId { get; set; }
		/// <summary>
		/// При переходе между какими метками возникает такая тенденция
		/// </summary>
		public string FuzzyLabelFromName { get; set; }

		public int FuzzyLabelToId { get; set; }
		/// <summary>
		/// При переходе между какими метками возникает такая тенденция
		/// </summary>
		public string FuzzyLabelToName { get; set; }
	}
}