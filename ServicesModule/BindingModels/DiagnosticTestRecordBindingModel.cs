﻿using System.ComponentModel.DataAnnotations;

namespace ServicesModule.BindingModels
{
	public class DiagnosticTestRecordBindingModel
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "required")]
		public int DiagnosticTestId { get; set; }

		public int? PointNumber { get; set; }

		[Required(ErrorMessage = "required")]
		public string Description { get; set; }

		public double? Probability { get; set; }
	}
}
