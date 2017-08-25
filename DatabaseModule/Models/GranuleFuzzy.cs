namespace DatabaseModule
{
	/// <summary>
	/// Гранула по нечетким меткам и тенденции
	/// </summary>
	public class GranuleFuzzy
	{
		public int Id { get; set; }

		public int DiagnosticTestId { get; set; }

		public DiagnosticTest DiagnosticTest { get; set; }
		/// <summary>
		/// Позиция гранулы
		/// </summary>
		public int GranulePosition { get; set; }
		/// <summary>
		/// Значение нечеткой метки
		/// </summary>
		public string FuzzyLabel { get; set; }
		/// <summary>
		/// Значение нечеткой тенденции
		/// </summary>
		public string FuzzyTrend { get; set; }
		/// <summary>
		/// Количество точек в грануле
		/// </summary>
		public int Count { get; set; }
	}
}
