using DTE_Interface_Level.Enums;
using System.Collections.Generic;

namespace DTE_Implement_Level.StaticClasses
{
	/// <summary>
	/// Возможные лингвистические значения меры энтропии по нечеткой тенденции
	/// </summary>
	/// <remarks>
	/// Используется ...
	/// </remarks>
	public static class EntropyByUX
	{
        public static List<LingvistUX> Entropyes { get; } = new List<LingvistUX>()
            {
                {LingvistUX.Достоверно},//Definite
                {LingvistUX.Вероятно},//Probably
                {LingvistUX.ВероятноМакс},//Probably
                {LingvistUX.ВероятноМин},//Probably
                {LingvistUX.Неопределено},//Undefine
                {LingvistUX.НеопределеноМин},//Undefine
				{LingvistUX.НеопределеноМакс}//Undefine
            };

        public static List<LingvistUX> EntropyesNot4Forecast { get; } = new List<LingvistUX>()
            {
                {LingvistUX.Достоверно},//Definite
                {LingvistUX.Вероятно},//Probably
                {LingvistUX.Неопределено}//Undefine
            };

        public static List<LingvistUX> Entropyes4Forecast { get; } = new List<LingvistUX>()
            {
                {LingvistUX.Достоверно},//Definite
                {LingvistUX.ВероятноМакс},//Probably
                {LingvistUX.ВероятноМин},//Probably
                {LingvistUX.НеопределеноМин},//Undefine
				{LingvistUX.НеопределеноМакс}//Undefine
            };
    }
}