using DTE_Interface_Level.Enums;
using System.Collections.Generic;

namespace DTE_Implement_Level_List.StaticClasses
{
	/// <summary>
	/// Значение нечетких элементарных тенденций и их вес
	/// </summary>
	public static class FuzzyTrendWeight
	{
        /// <summary>
        /// Веса для расчета меры энтропии по нечеткой тенденции
        /// </summary>
        public static Dictionary<FuzzyTrendLabel, int> TrendWeights { get; } = new Dictionary<FuzzyTrendLabel, int>()
            {
                {FuzzyTrendLabel.ПадениеСильное, -3},
                {FuzzyTrendLabel.ПадениеСреднее, -2},
                {FuzzyTrendLabel.ПадениеСлабое, -1},
                {FuzzyTrendLabel.СтабильностьСредняя, 0},
                {FuzzyTrendLabel.РостСлабый, 1},
                {FuzzyTrendLabel.РостСредний, 2},
                {FuzzyTrendLabel.РостСильный, 3}
            };
    }
}