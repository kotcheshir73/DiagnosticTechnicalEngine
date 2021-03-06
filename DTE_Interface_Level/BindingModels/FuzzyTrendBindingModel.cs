﻿using DTE_Interface_Level.Enums;
using System.ComponentModel.DataAnnotations;

namespace DTE_Interface_Level.BindingModels
{
    public class FuzzyTrendBindingModel
	{
		public int Id { get; set; }

		public int SeriesId { get; set; }

		[Required(ErrorMessage = "required")]
		public FuzzyTrendLabel TrendName { get; set; }

		[Required(ErrorMessage = "required")]
		public int Weight { get; set; }
	}
}