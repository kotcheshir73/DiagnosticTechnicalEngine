using DTE_Interface_Level.Enums;
using DTE_Model_Level.BaseClassies;

namespace DTE_Model_Level.Models
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