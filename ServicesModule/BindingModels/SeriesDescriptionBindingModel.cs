using System.ComponentModel.DataAnnotations;

namespace ServicesModule.BindingModels
{
	public class SeriesDescriptionBindingModel
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "required")]
		public string SeriesName { get; set; }

		[Required(ErrorMessage = "required")]
		public string SeriesDiscription { get; set; }
	}
}
