using DatabaseModule;
using System.Linq;

namespace ServicesModule.ViewModels
{
	public class StatisticsByFuzzyViewModel
	{
		public int Id { get; set; }

		public int DiagnosticTestId { get; set; }

		public int NumberSituation { get; set; }

		public string Description { get; set; }

		public int StartStateFuzzyLabelId { get; set; }

		public int StartStateFuzzyTrendId { get; set; }

		public int EndStateFuzzyLabelId { get; set; }

		public int EndStateFuzzyTrendId { get; set; }

		public string StartState
		{
			get
			{
				using (var _context = new DissertationDbContext())
				{
					return string.Format("{0} - {1}", _context.FuzzyLabels.SingleOrDefault(fl => fl.Id == StartStateFuzzyLabelId).FuzzyLabelName,
					  _context.FuzzyTrends.SingleOrDefault(ft => ft.Id == StartStateFuzzyTrendId).TrendName);
				}
			}
		}

		public string EndState
		{
			get
			{
				using (var _context = new DissertationDbContext())
				{
					return string.Format("{0} - {1}", _context.FuzzyLabels.SingleOrDefault(fl => fl.Id == EndStateFuzzyLabelId).FuzzyLabelName,
					_context.FuzzyTrends.SingleOrDefault(ft => ft.Id == EndStateFuzzyTrendId).TrendName);
				}
			}
		}

		public int CountMeet { get; set; }
	}
}
