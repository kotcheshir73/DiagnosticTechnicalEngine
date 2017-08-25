using DatabaseModule;

namespace ServicesModule.ViewModels
{
	public class GranuleFTViewModel
	{
		public int Id { get; set; }

		public int DiagnosticTestId { get; set; }

		public int GranulePosition { get; set; }

		public LingvistFT LingvistFT { get; set; }

		public int Count { get; set; }
	}
}
