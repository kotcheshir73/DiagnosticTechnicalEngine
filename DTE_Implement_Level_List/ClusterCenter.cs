namespace DTE_Implement_Level_List
{
	/// <summary>
	/// Центр кластера
	/// </summary>
	public class ClusterCenter
	{
		public double X { set; get; }

		public string Label { set; get; }

		public ClusterCenter(double _x)
		{
			X = _x;
			Label = "";
		}
	}
}