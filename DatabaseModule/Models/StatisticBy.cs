namespace DatabaseModule
{
	public class StatisticBy
	{
		public int Id { get; set; }

		public int DiagnosticTestId { get; set; }

		public DiagnosticTest DiagnosticTest { get; set; }
		/// <summary>
		/// Номер ситуации
		/// </summary>
		public int NumberSituation { get; set; }
		/// <summary>
		/// Описание ситуации
		/// </summary>
		public string Description { get; set; }
		/// <summary>
		/// Сколкьо раз ситуация встречалась во ВР
		/// </summary>
		public int CountMeet { get; set; }
	}
}
