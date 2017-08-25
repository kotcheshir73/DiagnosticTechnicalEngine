using System.ComponentModel.DataAnnotations;

namespace ServicesModule.BindingModels
{
	public class GranuleFTBindingModel
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "required")]
		public int DiagnosticTestId { get; set; }

		[Required(ErrorMessage = "required")]
		public int GranulePosition { get; set; }

		[Required(ErrorMessage = "required")]
		public string LingvistFT { get; set; }

		[Required(ErrorMessage = "required")]
		public int Count { get; set; }
	}
}
