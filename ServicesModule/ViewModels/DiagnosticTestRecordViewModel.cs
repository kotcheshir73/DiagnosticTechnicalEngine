namespace ServicesModule.ViewModels
{
	public class DiagnosticTestRecordViewModel
	{
		public int Id { get; set; }

		public int DiagnosticTestId { get; set; }

		public int? PointNumber { get; set; }

		public string Description { get; set; }

		public double? Probability { get; set; }
	}
}
