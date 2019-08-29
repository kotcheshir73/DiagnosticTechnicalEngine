using System.ComponentModel.DataAnnotations;

namespace DTE_Interface_Level.BindingModels
{
	public class AnomalyInfoBindingModel
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "required")]
		public int SeriesDiscriptionId { get; set; }

		[Required(ErrorMessage = "required")]
		public string TypeSituation { get; set; }

		[Required(ErrorMessage = "required")]
		public string AnomalyName { get; set; }

		[Required(ErrorMessage = "required")]
		public int AnomalySituation { get; set; }

		[Required(ErrorMessage = "required")]
		public string SetSituations { get; set; }

		[Required(ErrorMessage = "required")]
		public string TypeMemoryValue { get; set; }

		[Required(ErrorMessage = "required")]
		public string SetValues { get; set; }

		[Required(ErrorMessage = "required")]
		public string Description { get; set; }

		[Required(ErrorMessage = "required")]
		public int CountMeet { get; set; }

		[Required(ErrorMessage = "required")]
		public bool NotAnomaly { get; set; }

		[Required(ErrorMessage = "required")]
		public bool NotDetected { get; set; }
	}
}