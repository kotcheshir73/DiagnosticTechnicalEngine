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
		public int FuzzyLabelId { get; set; }

		[Required(ErrorMessage = "required")]
		public int FuzzyTrendId { get; set; }

		[Required(ErrorMessage = "required")]
		public int Count { get; set; }
	}
}
