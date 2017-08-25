namespace ServicesModule.ViewModels
{
	public class PointTrendViewModel
	{
		public int Id { get; set; }

		public int SeriesDiscriptionId { get; set; }

		public int StartPoint { get; set; }
		
		public int FinishPoint { get; set; }
		
		public int Count { get; set; }

		public double Weight { get; set; }
	}
}
