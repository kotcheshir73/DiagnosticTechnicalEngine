using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseModule
{
	/// <summary>
	/// 
	/// </summary>
	public class DiagnosticTest
	{
		public int Id { get; set; }

        public string TestNumber { get; set; }

		public int SeriesDiscriptionId { get; set; }

		public SeriesDescription SeriesDescription { get; set; }

		public DateTime DateTest { get; set; }

		public int Count { get; set; }
		/// <summary>
		/// Нужен прогноз или нет
		/// </summary>
		public bool NeedForecast { get; set; }

		public string FileName { get; set; }
		/// <summary>
		/// Последняя тчока ряда
		/// </summary>
		public PointInfo FirstPoint { get; set; }
		/// <summary>
		/// Предпоследняя точка ряда
		/// </summary>
		public PointInfo SecondPoint { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[ForeignKey("DiagnosticTestId")]
		public virtual ICollection<DiagnosticTestRecord> DiagnosticTestRecords { get; set; }
		/// <summary>
		/// Ситуации по паре энтропий
		/// </summary>
		[ForeignKey("DiagnosticTestId")]
		public virtual ICollection<StatisticsByEntropy> StatisticsByEntropys { get; set; }
		/// <summary>
		/// Ситуации по нечеткой паре
		/// </summary>
		[ForeignKey("DiagnosticTestId")]
		public virtual ICollection<StatisticsByFuzzy> StatisticsByFuzzys { get; set; }
		/// <summary>
		/// Набор возможных аномалий в ряду
		/// </summary>
		[ForeignKey("DiagnosticTestId")]
		public virtual ICollection<AnomalyInfo> AnomalyInfos { get; set; }
		/// <summary>
		/// Гранулы по мере энтропии по функции принадлежности
		/// </summary>
		[ForeignKey("DiagnosticTestId")]
		public virtual ICollection<GranuleUX> GranuleUXs { get; set; }
		/// <summary>
		/// Гранулы по мере энтропии по нечеткой тенденции
		/// </summary>
		[ForeignKey("DiagnosticTestId")]
		public virtual ICollection<GranuleFT> GranuleFTs { get; set; }
		/// <summary>
		/// Гранулы по мерам энтропий
		/// </summary>
		[ForeignKey("DiagnosticTestId")]
		public virtual ICollection<GranuleEntropy> GranuleEntropys { get; set; }
		/// <summary>
		/// Гранулы по нечеткости
		/// </summary>
		[ForeignKey("DiagnosticTestId")]
		public virtual ICollection<GranuleFuzzy> GranuleFuzzys { get; set; }
	}
}
