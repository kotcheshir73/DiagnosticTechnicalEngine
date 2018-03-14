namespace DatabaseModule.BaseClassies
{
	public class BaseClassSeriesDescription : BaseClass
	{
		public int SeriesDiscriptionId { get; set; }

		public virtual SeriesDescription SeriesDescription { get; set; }
	}
}
