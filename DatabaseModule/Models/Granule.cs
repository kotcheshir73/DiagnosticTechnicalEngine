using DatabaseModule.BaseClassies;

namespace DatabaseModule
{
    /// <summary>
	/// Гранула
	/// </summary>
    public class Granule : BaseClassDiagnosticTest
    {
        /// <summary>
        /// Позиция гранулы
        /// </summary>
        public int GranulePosition { get; set; }
        /// <summary>
        /// Значение меры энтропии по функции принадлежности
        /// </summary>
        public LingvistUX LingvistUX { get; set; }
        /// <summary>
        /// Значение меры энтропии по нечеткой тенденции
        /// </summary>
        public LingvistFT LingvistFT { get; set; }
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
