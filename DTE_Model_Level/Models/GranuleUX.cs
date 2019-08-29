using DTE_Interface_Level.Enums;
using DTE_Model_Level.BaseClassies;

namespace DTE_Model_Level.Models
{
    /// <summary>
    /// Гранула по мере энтропии по функции принадлежности
    /// </summary>
    public class GranuleUX : BaseClassDiagnosticTest
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
		/// Количество точек в грануле
		/// </summary>
		public int Count { get; set; }
	}
}