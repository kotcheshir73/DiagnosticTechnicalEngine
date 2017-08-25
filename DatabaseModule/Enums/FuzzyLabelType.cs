namespace DatabaseModule
{
	/// <summary>
	/// Варинаты получения нечетких меток
	/// </summary>
	public enum FuzzyLabelType
	{
		/// <summary>
		///  Через треугольную функцию принадлежности
		/// </summary>
		FuzzyTriangle,
		/// <summary>
		/// Через FCM-кластеризацию
		/// </summary>
		ClustFCM
	}
}
