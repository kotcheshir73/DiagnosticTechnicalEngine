using DTE_Interface_Level.Enums;
using System.Collections.Generic;

namespace DTE_Implement_Level_List.StaticClasses
{
	/// <summary>
	/// Возможные лингвистические значения меры энтропии по нечеткой тенденции
	/// </summary>
	/// <remarks>
	/// Используется ...
	/// </remarks>
	public static class EntropyByFT
	{
        public static List<LingvistFT> Entropyes { get; } = new List<LingvistFT>()
            {
                {LingvistFT.Стабильность},//Stability
                {LingvistFT.Изменение},//Change
                {LingvistFT.Аномалия}//Anomaly
            };
    }
}