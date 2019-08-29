using DTE_Model_Level.Models;

namespace DTE_Model_Level.BaseClassies
{
	public class BaseClassSeriesDescription : BaseClass
	{
		public int SeriesDiscriptionId { get; set; }

		public virtual SeriesDescription SeriesDescription { get; set; }
	}
}