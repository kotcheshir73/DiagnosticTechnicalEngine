namespace DatabaseModule
{
	/// <summary>
	/// Информация по аномалии
	/// </summary>
    public class AnomalyInfo
    {
        public int Id { get; set; }

		public int DiagnosticTestId { get; set; }

		public DiagnosticTest DiagnosticTest { get; set; }
		/// <summary>
		/// По какой паре определена аномалия
		/// </summary>
		public TypeSituation TypeSituation { get; set; }
		/// <summary>
		/// Название аномалии
		/// </summary>
        public string AnomalyName { get; set; }
		/// <summary>
		/// Номер ситуации, которая считается аномальной
		/// </summary>
        public int AnomalySituation { get; set; }
		/// <summary>
		/// Набор ситуаций, предшествующих аномальной
		/// </summary>
        public string SetSituations { get; set; }
		/// <summary>
		/// Какой вариант хранения числовых значений для посторения графика используется
		/// </summary>
		public TypeMemoryValue TypeMemoryValue { get; set; }
		/// <summary>
		/// Числовые значения для посторения графика. Храняться с разделителем ';'
		/// </summary>
        public string SetValues { get; set; }
		/// <summary>
		/// Описание аномалии
		/// </summary>
        public string Description { get; set; }
		/// <summary>
		/// Сколько раз аномалия встречалась во ВР
		/// </summary>
        public int CountMeet { get; set; }
		/// <summary>
		/// Найденная ситуация является не аномальной
		/// </summary>
        public bool NotAnomaly { get; set; }
		/// <summary>
		/// Данную аномалию невозможно выявить, так как точки, предшествующие ей имеют одинаковые значения
		/// </summary>
        public bool NotDetected { get; set; }
	}
}
