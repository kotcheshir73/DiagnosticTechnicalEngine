using System;

namespace DatabaseModule
{
	/// <summary>
	/// Информация по точке ряда
	/// </summary>
	public class PointInfo
	{
		public int Id { get; set; }

		public int DiagnosticTestId { get; set; }

		public DiagnosticTest DiagnosticTest { get; set; }
		/// <summary>
		/// Значение (числовое точки)
		/// </summary>
		public double? Value { get; set; }
		/// <summary>
		/// Временная метка
		/// </summary>
		public DateTime? Date { get; set; }
		/// <summary>
		/// Значение функции принадлежности
		/// </summary>
		public double? Fux { get; set; }
		/// <summary>
		/// Позиция функции принадлежности относителньо центра кластера (для прогнозирования)
		/// </summary>
		public bool? PositionFUX { get; set; }
        /// <summary>
        /// Последняя точка ряда
        /// </summary>
        public bool IsLast { get; set; }
		/// <summary>
		/// Идентификатор нечеткой метки
		/// </summary>
		public int? FuzzyLabelId { get; set; }
		/// <summary>
		/// Нечеткая метка
		/// </summary>
		public FuzzyLabel FuzzyLabel { get; set; }
		/// <summary>
		/// Идентификатор нечеткой тенденции
		/// </summary>
		public int? FuzzyTrendId { get; set; }
		/// <summary>
		/// Нечеткая тенденция
		/// </summary>
		public FuzzyTrend FuzzyTrend { get; set; }
		/// <summary>
		/// Значение меры энтропии по функции принадлежности
		/// </summary>
		public double EntropuUX { get; set; }
		/// <summary>
		/// Значение меры энтропии по нечеткой тенденции
		/// </summary>
		public double EntropyFT { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public int? StatisticsByEntropyId { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public StatisticsByEntropy StatisticsByEntropy { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public int? StatisticsByFuzzyId { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public StatisticsByFuzzy StatisticsByFuzzy { get; set; }
	}
}
