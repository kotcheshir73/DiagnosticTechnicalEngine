using DTE_Interface_Level.Enums;
using DTE_Model_Level.BaseClassies;

namespace DTE_Model_Level.Models
{
    /// <summary>
    /// Гранула по мерам энтропий
    /// </summary>
    public class GranuleEntropy : BaseClassDiagnosticTest
	{
		/// <summary>
		/// Позиция гранулы
		/// </summary>
		public int GranulePosition { get; set; }
		/// <summary>
		/// Значение меры энтропии по функции принадлежности
		/// </summary>
		public LingvistUX LingvistUX { get; set; }
		/// <summary>
		/// Значение меры энтропии по нечеткой тенденции
		/// </summary>
		public LingvistFT LingvistFT { get; set; }
		/// <summary>
		/// Количество точек в грануле
		/// </summary>
		public int Count { get; set; }
	}
}