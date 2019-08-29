using DTE_Model_Level.BaseClassies;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTE_Model_Level.Models
{
    /// <summary>
    /// Статистика ситуаций по паре нечетких
    /// </summary>
    public class StatisticsByFuzzy : BaseClassStatisticBy
	{
        public int StartStateFuzzyLabelId { get; set; }
        /// <summary>
        /// Значение нечеткой метки в начальной точке 
        /// </summary>
        [ForeignKey("StartStateFuzzyLabelId")]
        public virtual FuzzyLabel StartStateFuzzyLabel { get; set; }

        public int StartStateFuzzyTrendId { get; set; }
        /// <summary>
        /// Значение нечеткой тенденции в начальной точке
        /// </summary>
        [ForeignKey("StartStateFuzzyTrendId")]
        public virtual FuzzyTrend StartStateFuzzyTrend { get; set; }

        public int EndStateFuzzyLabelId { get; set; }
        /// <summary>
        /// Значение нечеткой метки в конечной точке 
        /// </summary>
        [ForeignKey("EndStateFuzzyLabelId")]
        public virtual FuzzyLabel EndStateFuzzyLabel { get; set; }

        public int EndStateFuzzyTrendId { get; set; }
        /// <summary>
        /// Значение нечеткой тенденции в конечной точке
        /// </summary>
        [ForeignKey("EndStateFuzzyTrendId")]
        public virtual FuzzyTrend EndStateFuzzyTrend { get; set; }
        /// <summary>
        /// Значение пары в начальной точке
        /// </summary>
        [NotMapped]
        public override string StartState
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
        public override string EndState
        {
            get
            {
                return string.Format("{0}-{1}", EndStateFuzzyLabel.FuzzyLabelName, EndStateFuzzyTrend.TrendName);
            }
        }
    }
}