using DatabaseModule;
using System.ComponentModel.DataAnnotations;

namespace ServicesModule.BindingModels
{
	public class RuleTrendBindingModel
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "required")]
		public int SeriesId { get; set; }

		public FuzzyTrendLabel FuzzyTrendName { get; set; }

		public int? FuzzyTrendId { get; set; }

		[Required(ErrorMessage = "required")]
		public int FuzzyLabelFromId { get; set; }

		[Required(ErrorMessage = "required")]
		public int FuzzyLabelToId { get; set; }
	}
}
