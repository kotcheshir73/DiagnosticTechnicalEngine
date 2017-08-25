using System.Collections.Generic;

namespace DatabaseModule
{
	/// <summary>
	/// Возможные лингвистические значения меры энтропии по нечеткой тенденции
	/// </summary>
	/// <remarks>
	/// Используется ...
	/// </remarks>
	public static class EntropyByUX
	{
		private static List<LingvistUX> _entropyes = new List<LingvistUX>()
			{
				{LingvistUX.Достоверно},//Definite
                {LingvistUX.Вероятно},//Probably
                {LingvistUX.ВероятноМакс},//Probably
                {LingvistUX.ВероятноМин},//Probably
                {LingvistUX.Неопределено},//Undefine
                {LingvistUX.НеопределеноМин},//Undefine
				{LingvistUX.НеопределеноМакс}//Undefine
            };
		private static List<LingvistUX> _entropyesNot4Forecast = new List<LingvistUX>()
			{
				{LingvistUX.Достоверно},//Definite
                {LingvistUX.Вероятно},//Probably
                {LingvistUX.Неопределено}//Undefine
            };
		private static List<LingvistUX> _entropyes4Forecast = new List<LingvistUX>()
			{
				{LingvistUX.Достоверно},//Definite
                {LingvistUX.ВероятноМакс},//Probably
                {LingvistUX.ВероятноМин},//Probably
                {LingvistUX.НеопределеноМин},//Undefine
				{LingvistUX.НеопределеноМакс}//Undefine
            };

		public static List<LingvistUX> Entropyes { get { return _entropyes; } }

		public static List<LingvistUX> EntropyesNot4Forecast { get { return _entropyesNot4Forecast; } }

		public static List<LingvistUX> Entropyes4Forecast { get { return _entropyes4Forecast; } }
	}
}
