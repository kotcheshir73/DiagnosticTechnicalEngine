using DTE_Interface_Level.Enums;
using DTE_Model_Level.BaseClassies;

namespace DTE_Model_Level.Models
{
    /// <summary>
    /// Гранула по мере энтропии по нечеткой тенденции
    /// </summary>
    public class GranuleFT : BaseClassDiagnosticTest
	{
		/// <summary>
		/// Позиция гранулы
		/// </summary>
		public int GranulePosition { get; set; }
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