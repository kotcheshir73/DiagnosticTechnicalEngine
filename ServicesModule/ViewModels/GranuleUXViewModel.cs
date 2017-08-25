using DatabaseModule;

namespace ServicesModule.ViewModels
{
	public class GranuleUXViewModel
	{
		public int Id { get; set; }

		public int DiagnosticTestId { get; set; }

		public int GranulePosition { get; set; }

		public LingvistUX LingvistUX { get; set; }

		public int Count { get; set; }
	}
}
