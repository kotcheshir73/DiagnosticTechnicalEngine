using System.Collections.Generic;

namespace DatabaseModule
{
	/// <summary>
	/// Возможные лингвистические значения меры энтропии по нечеткой тенденции
	/// </summary>
	/// <remarks>
	/// Используется ...
	/// </remarks>
	public static class EntropyByFT
	{
		private static List<LingvistFT> _entropyes = new List<LingvistFT>()
			{
				{LingvistFT.Стабильность},//Stability
                {LingvistFT.Изменение},//Change
                {LingvistFT.Аномалия}//Anomaly
            };

		public static List<LingvistFT> Entropyes { get { return _entropyes; } }
	}
}
