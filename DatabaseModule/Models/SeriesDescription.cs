using DatabaseModule.BaseClassies;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseModule
{
	/// <summary>
	/// Информаци по временому ряду
	/// </summary>
    public class SeriesDescription : BaseClass
    {
		/// <summary>
		/// Название ряда
		/// </summary>
        public string SeriesName { get; set; }
		/// <summary>
		/// Описание ряда
		/// </summary>
        public string SeriesDiscription { get; set; }
		/// <summary>
		/// Нужен прогноз или нет
		/// </summary>
		public bool NeedForecast { get; set; }
		/// <summary>
		/// Нечеткие метки, относящиеся к НВР
		/// </summary>
		[ForeignKey("SeriesDiscriptionId")]
		public virtual ICollection<FuzzyLabel> FuzzyLabels { get; set; }
		/// <summary>
		/// Нечеткие тенденции
		/// </summary>
		[ForeignKey("SeriesDiscriptionId")]
		public virtual ICollection<FuzzyTrend> FuzzyTrends { get; set; }
		/// <summary>
		/// Правила вычисления нечетких тенденций по нечетким меткам
		/// </summary>
		[ForeignKey("SeriesDiscriptionId")]
		public virtual ICollection<RuleTrend> RuleTrends { get; set; }
		/// <summary>
		/// Данные по переходам между точками фазового пространства
		/// </summary>
		[ForeignKey("SeriesDiscriptionId")]
		public virtual ICollection<PointTrend> PointTrends { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[ForeignKey("SeriesDiscriptionId")]
		public virtual ICollection<DiagnosticTest> DiagnosticTests { get; set; }
		/// <summary>
		/// Набор возможных аномалий в ряду
		/// </summary>
		[ForeignKey("SeriesDiscriptionId")]
		public virtual ICollection<AnomalyInfo> AnomalyInfos { get; set; }
		/// <summary>
		/// Ситуации по паре энтропий
		/// </summary>
		[ForeignKey("SeriesDiscriptionId")]
		public virtual ICollection<StatisticsByEntropy> StatisticsByEntropys { get; set; }
		/// <summary>
		/// Ситуации по нечеткой паре
		/// </summary>
		[ForeignKey("SeriesDiscriptionId")]
		public virtual ICollection<StatisticsByFuzzy> StatisticsByFuzzys { get; set; }
	}
}
