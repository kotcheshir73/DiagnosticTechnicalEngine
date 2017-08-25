namespace DatabaseModule
{
	public class DiagnosticTestRecord
	{
		public int Id { get; set; }

		public int DiagnosticTestId { get; set; }

		public DiagnosticTest DiagnosticTest { get; set; }

		public int? PointNumber { get; set; }

		public string Description { get; set; }

		public double? Probability { get; set; }
	}
}
