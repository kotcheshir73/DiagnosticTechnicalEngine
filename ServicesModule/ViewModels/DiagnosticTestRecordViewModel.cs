﻿namespace ServicesModule.ViewModels
{
	public class DiagnosticTestRecordViewModel
	{
		public int Id { get; set; }

		public int DiagnosticTestId { get; set; }

        public int AnomalyId { get; set; }

		public int? PointNumber { get; set; }

		public string Description { get; set; }
	}
}
