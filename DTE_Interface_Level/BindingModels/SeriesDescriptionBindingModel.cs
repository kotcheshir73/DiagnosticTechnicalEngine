using System.ComponentModel.DataAnnotations;

namespace DTE_Interface_Level.BindingModels
{
    public class SeriesDescriptionBindingModel
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "required")]
		public string SeriesName { get; set; }

		[Required(ErrorMessage = "required")]
		public string SeriesDiscription { get; set; }

		[Required(ErrorMessage = "required")]
		public bool NeedForecast { get; set; }
	}
}