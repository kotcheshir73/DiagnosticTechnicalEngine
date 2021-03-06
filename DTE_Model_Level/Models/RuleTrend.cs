﻿using DTE_Model_Level.BaseClassies;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTE_Model_Level.Models
{
    /// <summary>
    /// Правила получения нечеткой тенденции на основании двух нечектих меток
    /// </summary>
    public class RuleTrend : BaseClassSeriesDescription
	{
		public int FuzzyTrendId { get; set; }
		/// <summary>
		/// Нечеткая тенденция
		/// </summary>
		public virtual FuzzyTrend FuzzyTrend { get; set; }

		public int FuzzyLabelFromId { get; set; }
		/// <summary>
		/// При переходе между какими метками возникает такая тенденция
		/// </summary>
		[ForeignKey("FuzzyLabelFromId")]
		public virtual FuzzyLabel FuzzyLabelFrom { get; set; }

		public int FuzzyLabelToId { get; set; }
		/// <summary>
		/// При переходе между какими метками возникает такая тенденция
		/// </summary>
		[ForeignKey("FuzzyLabelToId")]
		public virtual FuzzyLabel FuzzyLabelTo { get; set; }
	}
}