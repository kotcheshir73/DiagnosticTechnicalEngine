﻿using DTE_Interface_Level.Enums;
using DTE_Model_Level.BaseClassies;

namespace DTE_Model_Level.Models
{
    /// <summary>
    /// Нечектая метка
    /// </summary>
    public class FuzzyLabel : BaseClassSeriesDescription
	{
		/// <summary>
		/// Варинат получения нечеткой метки
		/// </summary>
		public FuzzyLabelType FuzzyLabelType { get; set; }
		/// <summary>
		/// Лингвистическое название нечеткой метки
		/// </summary>
        public string FuzzyLabelName { get; set; }
		/// <summary>
		/// Вес нечеткой метки
		/// </summary>
        public int FuzzyLabelWeight { get; set; }
		/// <summary>
		/// Минимальное значение, при котором точку можно отнсети к этой метки
		/// Или граничное значение метки при расчете прогнозного значения
		/// </summary>
        public double FuzzyLabelMinVal { get; set; }
		/// <summary>
		/// Центральное значение, при котором точку 100% можно отнсети к этой метки
		/// Или значение метки при расчете прогнозного значения 
		/// </summary>
		public double FuzzyLabelCenter { get; set; }
		/// <summary>
		/// Максимальное значение, при котором точку можно отнсети к этой метки
		/// Или граничное значение метки при расчете прогнозного значения
		/// </summary>
		public double FuzzyLabelMaxVal { get; set; }
	}
}