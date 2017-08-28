using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseModule
{
	/// <summary>
	/// Статистика ситуаций по паре мер энтропий
	/// </summary>
	public class StatisticsByEntropy : StatisticBy
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
