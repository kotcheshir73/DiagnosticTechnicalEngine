using System.Collections.Generic;

namespace DatabaseModule
{
	/// <summary>
	/// Значение нечетких элементарных тенденций и их вес
	/// </summary>
	public static class FuzzyTrendWeight
	{
		private static Dictionary<FuzzyTrendLabel, int> _trendWeights = new Dictionary<FuzzyTrendLabel, int>()
			{
				{FuzzyTrendLabel.ПадениеСильное, 0},
				{FuzzyTrendLabel.ПадениеСреднее, 1},
				{FuzzyTrendLabel.ПадениеСлабое, 2},
				{FuzzyTrendLabel.СтабильностьСредняя, 3},
				{FuzzyTrendLabel.РостСлабый, 4},
				{FuzzyTrendLabel.РостСредний, 5},
				{FuzzyTrendLabel.РостСильный, 6}
			};
		/// <summary>
		/// Веса для расчета меры энтропии по нечеткой тенденции
		/// </summary>
		public static Dictionary<FuzzyTrendLabel, int> TrendWeights { get { return _trendWeights; } }
	}
}
