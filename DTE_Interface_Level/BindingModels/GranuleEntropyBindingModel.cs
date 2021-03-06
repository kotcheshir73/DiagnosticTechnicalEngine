﻿using System.ComponentModel.DataAnnotations;

namespace DTE_Interface_Level.BindingModels
{
	public class GranuleEntropyBindingModel
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "required")]
		public int DiagnosticTestId { get; set; }

		[Required(ErrorMessage = "required")]
		public int GranulePosition { get; set; }

		[Required(ErrorMessage = "required")]
		public string LingvistUX { get; set; }

		[Required(ErrorMessage = "required")]
		public string LingvistFT { get; set; }

		[Required(ErrorMessage = "required")]
		public int Count { get; set; }
	}
}