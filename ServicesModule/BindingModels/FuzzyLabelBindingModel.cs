using DatabaseModule;
using System.ComponentModel.DataAnnotations;

namespace ServicesModule.BindingModels
{
	public class FuzzyLabelBindingModel
	{
		public int Id { get; set;}

		[Required(ErrorMessage = "required")]
		public int SeriesId { get; set; }

		[Required(ErrorMessage = "required")]
		public FuzzyLabelType FuzzyLabelType { get; set; }

		[Required(ErrorMessage = "required")]
		public string FuzzyLabelName { get; set; }

		[Required(ErrorMessage = "required")]
		public int Weigth { get; set; }

		[Required(ErrorMessage = "required")]
		public double MinVal { get; set; }

		[Required(ErrorMessage = "required")]
		public double Center { get; set; }

		[Required(ErrorMessage = "required")]
		public double MaxVal { get; set; }
	}
}
