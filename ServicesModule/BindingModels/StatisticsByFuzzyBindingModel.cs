using System.ComponentModel.DataAnnotations;

namespace ServicesModule.BindingModels
{
	public class StatisticsByFuzzyBindingModel
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "required")]
		public int DiagnosticTestId { get; set; }

		[Required(ErrorMessage = "required")]
		public int NumberSituation { get; set; }

		[Required(ErrorMessage = "required")]
		public string Description { get; set; }

		[Required(ErrorMessage = "required")]
		public int StartStateFuzzyLabelId { get; set; }

		[Required(ErrorMessage = "required")]
		public int StartStateFuzzyTrendId { get; set; }

		[Required(ErrorMessage = "required")]
		public int EndStateFuzzyLabelId { get; set; }

		[Required(ErrorMessage = "required")]
		public int EndStateFuzzyTrendId { get; set; }

		[Required(ErrorMessage = "required")]
		public int CountMeet { get; set; }
	}
}
