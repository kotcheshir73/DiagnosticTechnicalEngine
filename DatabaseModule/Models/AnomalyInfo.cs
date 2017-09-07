using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Data.Entity;
using DatabaseModule.BaseClassies;

namespace DatabaseModule
{
	/// <summary>
	/// Информация по аномалии
	/// </summary>
    public class AnomalyInfo : BaseClassSeriesDescription
	{
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

        [NotMapped]
        public string Rashfrovka
        {
            get
            {
                using (var _context = new DissertationDbContext())
                {
                    var sb = new StringBuilder();
                    sb.AppendLine("Ситуации:");
                    var situations = SetSituations.Split(',');
					BaseClassStatisticBy statistic = null;
                    foreach (var sit in situations)
                    {
                        int number = Convert.ToInt32(sit);
                        switch(TypeSituation)
                        {
                            case TypeSituation.ПоНечеткости:
                                statistic = _context.StatisticsByFuzzys
                                                    .Include(stf => stf.EndStateFuzzyLabel)
                                                    .Include(stf => stf.EndStateFuzzyTrend)
                                                    .Include(stf => stf.StartStateFuzzyLabel)
                                                    .Include(stf => stf.StartStateFuzzyTrend)
                                                    .FirstOrDefault(stf => stf.NumberSituation == number &&
                                                        stf.SeriesDiscriptionId == SeriesDiscriptionId);
                                break;
                            case TypeSituation.ПоЭнтропии:
                                statistic = _context.StatisticsByEntropys.FirstOrDefault(ste => ste.NumberSituation == number &&
                                                        ste.SeriesDiscriptionId == SeriesDiscriptionId);
                                break;
                        }
                        sb.AppendLine(string.Format("{0} -> {1}", statistic.StartState, statistic.EndState));
                    }
                    sb.AppendLine("Аномалия:");
                    switch (TypeSituation)
                    {
                        case TypeSituation.ПоНечеткости:
                            statistic = _context.StatisticsByFuzzys
                                                    .Include(stf => stf.EndStateFuzzyLabel)
                                                    .Include(stf => stf.EndStateFuzzyTrend)
                                                    .Include(stf => stf.StartStateFuzzyLabel)
                                                    .Include(stf => stf.StartStateFuzzyTrend)
                                                    .FirstOrDefault(stf => stf.NumberSituation == AnomalySituation &&
                                                    stf.SeriesDiscriptionId == SeriesDiscriptionId);
                            break;
                        case TypeSituation.ПоЭнтропии:
                            statistic = _context.StatisticsByEntropys.FirstOrDefault(stf => stf.NumberSituation == AnomalySituation &&
                                                    stf.SeriesDiscriptionId == SeriesDiscriptionId);
                            break;
                    }
                    sb.AppendLine(string.Format("{0} -> {1}", statistic.StartState, statistic.EndState));

                    return sb.ToString();
                }
            }
        }
	}
}
