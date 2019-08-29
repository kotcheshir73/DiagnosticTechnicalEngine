using DTE_Model_Level.BaseClassies;

namespace DTE_Model_Level.Models
{
    /// <summary>
    /// Данные по переходам между точками фазового пространства
    /// </summary>
    public class PointTrend : BaseClassSeriesDescription
	{
		public int StartPoint { get; set; }

		public int FinishPoint { get; set; }

		public int Count { get; set; }

		public double Weight { get; set; }

        public string Trends { get; set; }
	}
}