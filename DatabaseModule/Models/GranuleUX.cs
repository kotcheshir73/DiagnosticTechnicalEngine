namespace DatabaseModule
{
	/// <summary>
	/// Гранула по мере энтропии по функции принадлежности
	/// </summary>
	public class GranuleUX
	{
		public int Id { get; set; }

		public int DiagnosticTestId { get; set; }

		public DiagnosticTest DiagnosticTest { get; set; }
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
