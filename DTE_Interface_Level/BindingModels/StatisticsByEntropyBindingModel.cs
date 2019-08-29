using System.ComponentModel.DataAnnotations;

namespace DTE_Interface_Level.BindingModels
{
	public class StatisticsByEntropyBindingModel
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "required")]
		public int SeriesDiscriptionId { get; set; }

		[Required(ErrorMessage = "required")]
		public int NumberSituation { get; set; }

		[Required(ErrorMessage = "required")]
		public string Description { get; set; }

		[Required(ErrorMessage = "required")]
		public string StartStateLingvistUX { get; set; }

		[Required(ErrorMessage = "required")]
		public string StartStateLingvistFT { get; set; }

		[Required(ErrorMessage = "required")]
		public string EndStateLingvistUX { get; set; }

		[Required(ErrorMessage = "required")]
		public string EndStateLingvistFT { get; set; }

		[Required(ErrorMessage = "required")]
		public int CountMeet { get; set; }
	}
}