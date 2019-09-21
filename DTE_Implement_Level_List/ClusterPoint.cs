namespace DTE_Implement_Level_List
{
	/// <summary>
	/// Точка кластера
	/// </summary>
	public class ClusterPoint
	{
		public double X { set; get; }

		public double ClusterIndex { set; get; }

		public ClusterPoint(double _x)
		{
			X = _x;
			ClusterIndex = -1.0;
		}
	}
}