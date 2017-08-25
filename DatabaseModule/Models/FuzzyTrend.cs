namespace DatabaseModule
{
	/// <summary>
	/// Нечеткая тенденциия
	/// </summary>
	public class FuzzyTrend
    {
        public int Id { get; set; }

        public int SeriesDiscriptionId { get; set; }

		public SeriesDescription SeriesDescription { get; set; }
		/// <summary>
		/// Название нечеткой тенденции
		/// </summary>
        public FuzzyTrendLabel TrendName { get; set; }
		/// <summary>
		/// Вес нечеткой тенденции
		/// </summary>
		public int Weight { get; set; }
	}
}
