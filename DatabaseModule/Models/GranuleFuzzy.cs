using DatabaseModule.BaseClassies;

namespace DatabaseModule
{
	/// <summary>
	/// Гранула по нечетким меткам и тенденции
	/// </summary>
	public class GranuleFuzzy : BaseClassDiagnosticTest
	{
		/// <summary>
		/// Позиция гранулы
		/// </summary>
		public int GranulePosition { get; set; }
		/// <summary>
		/// Значение нечеткой метки
		/// </summary>
		public virtual FuzzyLabel FuzzyLabel { get; set; }
        /// <summary>
        /// Идентификатор нечеткой метки
        /// </summary>
        public int FuzzyLabelId { get; set; }
        /// <summary>
        /// Значение нечеткой тенденции
        /// </summary>
        public virtual FuzzyTrend FuzzyTrend { get; set; }
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
