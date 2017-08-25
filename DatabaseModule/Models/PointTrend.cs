namespace DatabaseModule
{
	/// <summary>
	/// Данные по переходам между точками фазового пространства
	/// </summary>
	public class PointTrend
	{
		public int Id { get; set; }

		public int SeriesDiscriptionId { get; set; }

		public SeriesDescription SeriesDescription { get; set; }

		public int StartPoint { get; set; }

		public int FinishPoint { get; set; }

		public int Count { get; set; }

		public double Weight { get; set; }
	}
}
