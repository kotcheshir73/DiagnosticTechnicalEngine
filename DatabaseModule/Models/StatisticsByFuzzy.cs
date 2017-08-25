using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseModule
{
	/// <summary>
	/// Статистика ситуаций по паре нечетких
	/// </summary>
	public class StatisticsByFuzzy : StatisticBy
	{		
		public int StartStateFuzzyLabelId { get; set; }
		/// <summary>
		/// Значение нечеткой метки в начальной точке 
		/// </summary>
		[ForeignKey("StartStateFuzzyLabelId")]
		public FuzzyLabel StartStateFuzzyLabel { get; set; }

		public int StartStateFuzzyTrendId { get; set; }
		/// <summary>
		/// Значение нечеткой тенденции в начальной точке
		/// </summary>
		[ForeignKey("StartStateFuzzyTrendId")]
		public FuzzyTrend StartStateFuzzyTrend { get; set; }

		public int EndStateFuzzyLabelId { get; set; }
		/// <summary>
		/// Значение нечеткой метки в конечной точке 
		/// </summary>
		[ForeignKey("EndStateFuzzyLabelId")]
		public FuzzyLabel EndStateFuzzyLabel { get; set; }

		public int EndStateFuzzyTrendId { get; set; }
		/// <summary>
		/// Значение нечеткой тенденции в конечной точке
		/// </summary>
		[ForeignKey("EndStateFuzzyTrendId")]
		public FuzzyTrend EndStateFuzzyTrend { get; set; }
		/// <summary>
		/// Значение пары в начальной точке
		/// </summary>
		[NotMapped]
		public string StartState
		{
			get
			{
				return string.Format("{0}-{1}", StartStateFuzzyLabel.FuzzyLabelName, StartStateFuzzyTrend.TrendName);
			}
		}
		/// <summary>
		/// Значение пары в конечной точке
		/// </summary>
		[NotMapped]
		public string EndState { get; }
	}
}
