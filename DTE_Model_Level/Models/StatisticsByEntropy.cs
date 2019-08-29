using DTE_Interface_Level.Enums;
using DTE_Model_Level.BaseClassies;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTE_Model_Level.Models
{
    /// <summary>
    /// Статистика ситуаций по паре мер энтропий
    /// </summary>
    public class StatisticsByEntropy : BaseClassStatisticBy
	{
		/// <summary>
		/// Значение меры энтропии по функции принадлежности в начальной точке 
		/// </summary>
		public LingvistUX StartStateLingvistUX { get; set; }
		/// <summary>
		/// Значение меры энтропии по нечеткой тенденции в начальной точке
		/// </summary>
		public LingvistFT StartStateLingvistFT { get; set; }
		/// <summary>
		/// Значение меры энтропии по функции принадлежности в конечной точке 
		/// </summary>
		public LingvistUX EndStateLingvistUX { get; set; }
		/// <summary>
		/// Значение меры энтропии по нечеткой тенденции в конечной точке
		/// </summary>
		public LingvistFT EndStateLingvistFT { get; set; }
		/// <summary>
		/// Значение пары в начальной точке
		/// </summary>
		[NotMapped]
		public override string StartState
		{
			get
			{
				return string.Format("{0}-{1}", StartStateLingvistUX, StartStateLingvistFT);
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
				return string.Format("{0}-{1}", EndStateLingvistUX, EndStateLingvistFT);
			}
		}
	}
}