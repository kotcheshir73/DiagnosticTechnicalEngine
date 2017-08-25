namespace ServicesModule
{
	/// <summary>
	/// Точка кластера
	/// </summary>
	public class ClusterPoint
	{
		public double x { set; get; }
		public double clusterIndex { set; get; }

		public ClusterPoint(double _x)
		{
			x = _x;
			clusterIndex = -1.0;
		}
	}
}
