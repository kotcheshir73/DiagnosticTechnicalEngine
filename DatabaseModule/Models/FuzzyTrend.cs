using DatabaseModule.BaseClassies;

namespace DatabaseModule
{
	/// <summary>
	/// Нечеткая тенденциия
	/// </summary>
	public class FuzzyTrend : BaseClassSeriesDescription
	{
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
