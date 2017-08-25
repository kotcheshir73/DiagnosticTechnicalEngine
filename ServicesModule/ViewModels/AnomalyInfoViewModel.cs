using DatabaseModule;

namespace ServicesModule.ViewModels
{
	public class AnomalyInfoViewModel
	{
		public int Id { get; set; }

		public int DiagnosticTestId { get; set; }

		public TypeSituation TypeSituation { get; set; }

		public string AnomalyName { get; set; }

		public int AnomalySituation { get; set; }

		public string SetSituations { get; set; }

		public TypeMemoryValue TypeMemoryValue { get; set; }

		public string SetValues { get; set; }

		public string Description { get; set; }

		public int CountMeet { get; set; }

		public bool NotAnomaly { get; set; }

		public bool NotDetected { get; set; }
	}
}
