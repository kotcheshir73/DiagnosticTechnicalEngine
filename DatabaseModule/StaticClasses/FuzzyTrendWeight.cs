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
				{FuzzyTrendLabel.ПадениеСильное, -3},
				{FuzzyTrendLabel.ПадениеСреднее, -2},
				{FuzzyTrendLabel.ПадениеСлабое, -1},
				{FuzzyTrendLabel.СтабильностьСредняя, 0},
				{FuzzyTrendLabel.РостСлабый, 1},
				{FuzzyTrendLabel.РостСредний, 2},
				{FuzzyTrendLabel.РостСильный, 3}
			};
		/// <summary>
		/// Веса для расчета меры энтропии по нечеткой тенденции
		/// </summary>
		public static Dictionary<FuzzyTrendLabel, int> TrendWeights { get { return _trendWeights; } }
	}
}
