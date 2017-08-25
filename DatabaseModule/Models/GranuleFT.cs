namespace DatabaseModule
{
	/// <summary>
	/// Гранула по мере энтропии по нечеткой тенденции
	/// </summary>
	public class GranuleFT
	{
		public int Id { get; set; }

		public int DiagnosticTestId { get; set; }

		public DiagnosticTest DiagnosticTest { get; set; }
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
