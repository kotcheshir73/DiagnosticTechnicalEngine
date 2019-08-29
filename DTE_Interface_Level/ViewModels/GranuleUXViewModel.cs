using DTE_Interface_Level.Enums;

namespace DTE_Interface_Level.ViewModels
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