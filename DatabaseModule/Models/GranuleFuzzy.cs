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
		public FuzzyLabel FuzzyLabel { get; set; }
        /// <summary>
        /// Идентификатор нечеткой метки
        /// </summary>
        public int FuzzyLabelId { get; set; }
        /// <summary>
        /// Значение нечеткой тенденции
        /// </summary>
        public FuzzyTrend FuzzyTrend { get; set; }
        /// <summary>
        /// Идентификатор нечеткой тенденции
        /// </summary>
        public int FuzzyTrendId { get; set; }
        /// <summary>
        /// Количество точек в грануле
        /// </summary>
        public int Count { get; set; }
	}
}
