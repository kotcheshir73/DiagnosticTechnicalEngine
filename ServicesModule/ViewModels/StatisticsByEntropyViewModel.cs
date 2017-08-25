using DatabaseModule;

namespace ServicesModule.ViewModels
{
	public class StatisticsByEntropyViewModel
	{
		public int Id { get; set; }

		public int DiagnosticTestId { get; set; }

		public int NumberSituation { get; set; }

		public string Description { get; set; }

		public LingvistUX StartStateLingvistUX { get; set; }

		public LingvistFT StartStateLingvistFT { get; set; }

		public LingvistUX EndStateLingvistUX { get; set; }

		public LingvistFT EndStateLingvistFT { get; set; }

		public string StartState { get { return string.Format("{0} - {1}", StartStateLingvistUX, StartStateLingvistFT); } }

		public string EndState { get { return string.Format("{0} - {1}", EndStateLingvistUX, EndStateLingvistFT); } }

		public int CountMeet { get; set; }
	}
}
