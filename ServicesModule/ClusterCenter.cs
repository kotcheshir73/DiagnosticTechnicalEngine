namespace ServicesModule
{
	/// <summary>
	/// Центр кластера
	/// </summary>
	public class ClusterCenter
	{
		public double x { set; get; }

		public string label { set; get; }

		public ClusterCenter(double _x)
		{
			x = _x;
			label = "";
		}
	}
}
