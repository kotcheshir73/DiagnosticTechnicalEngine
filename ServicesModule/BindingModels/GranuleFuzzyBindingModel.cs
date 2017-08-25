using System.ComponentModel.DataAnnotations;

namespace ServicesModule.BindingModels
{
	public class GranuleFuzzyBindingModel
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "required")]
		public int DiagnosticTestId { get; set; }

		[Required(ErrorMessage = "required")]
		public int GranulePosition { get; set; }

		[Required(ErrorMessage = "required")]
		public string FuzzyLabelName { get; set; }

		[Required(ErrorMessage = "required")]
		public string FuzzyTrendName { get; set; }

		[Required(ErrorMessage = "required")]
		public int Count { get; set; }
	}
}
