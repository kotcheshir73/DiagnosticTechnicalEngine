using DTE_Interface_Level.Enums;
using System;

namespace DTE_Implement_Level_List.StaticClasses
{
	public static class Converter
	{
        public static int TrendWeightNotFound = -100;
		/// <summary>
		/// Получение лингвистического значения меры энтропии по нечеткой тенденции
		/// </summary>
		/// <param name="delta">числовое значение меры энтропии по нечеткой тенденции</param>
		/// <returns></returns>
		public static LingvistFT ToLingvistFT(double delta)
		{
			if (delta == 0)
			{
				return LingvistFT.Стабильность;
			}
			else if (delta == 0.5)
			{
				return LingvistFT.Изменение;
			}
			else
			{
				return LingvistFT.Аномалия;
			}
		}
		/// <summary>
		/// Получение числового значения меры энтропии по нечеткой тенденции
		/// </summary>
		/// <param name="name">лингвистическое значение меры энтропии по нечеткой тенденции</param>
		/// <returns></returns>
		public static double ToEntropyByFT(LingvistFT name)
		{
			if (name == LingvistFT.Стабильность)
			{
				return 0;
			}
			else if (name == LingvistFT.Изменение)
			{
				return 0.5;
			}
			else
			{
				return 1;
			}
		}
		/// <summary>
		/// Получение лингвистического значения меры энтропии по функции принадлежности
		/// </summary>
		/// <param name="delta">числовое значение меры энтропии по функции принадлежности</param>
		/// <returns></returns>
		public static LingvistUX ToLingvistUX(double funcX, bool? pos)
		{
			if (funcX >= 0 && funcX < 0.3)
			{
				return LingvistUX.Достоверно;
			}
			else if (funcX >= 0.3 && funcX < 0.7)
			{
				if(pos.HasValue)
				{
					if (pos.Value) return LingvistUX.ВероятноМакс;
					if (!pos.Value) return LingvistUX.ВероятноМин;
				}
				return LingvistUX.Вероятно;
			}
			else
			{
				if (pos.HasValue)
				{
					if (pos.Value) return LingvistUX.НеопределеноМакс;
					if (!pos.Value) return LingvistUX.НеопределеноМин;
				}
				return LingvistUX.Неопределено;
			}
		}
		/// <summary>
		/// Получение лингвистического значения меры энтропии по нечеткой тенденции
		/// </summary>
		/// <param name="text"></param>
		/// <returns></returns>
		public static LingvistFT ToLingvistFT(string text)
		{
			return (LingvistFT)Enum.Parse(typeof(LingvistFT), text);
		}
		/// <summary>
		/// Получение лингвистического значения меры энтропии по функции принадлежности
		/// </summary>
		/// <param name="text"></param>
		/// <returns></returns>
		public static LingvistUX ToLingvistUX(string text)
		{
			return (LingvistUX)Enum.Parse(typeof(LingvistUX), text);
		}
		/// <summary>
		/// Получение веса нечеткой тенденции по названию
		/// </summary>
		/// <param name="trendName"></param>
		/// <returns></returns>
		public static int ToFuzzyTrendLabelWeight(FuzzyTrendLabel trendName)
		{
			if (FuzzyTrendWeight.TrendWeights.ContainsKey(trendName))
				return FuzzyTrendWeight.TrendWeights[trendName];
			else
				return TrendWeightNotFound;
		}
		/// <summary>
		/// Получение веса нечеткой тенденции по названию
		/// </summary>
		/// <param name="trendName"></param>
		/// <returns></returns>
		public static int ToFuzzyTrendLabelWeight(string trendName)
		{
			return ToFuzzyTrendLabelWeight(ToFuzzyTrendLabel(trendName));
		}
		/// <summary>
		/// Получение лингвистического значения по номеру
		/// </summary>
		/// <param name="i"></param>
		/// <returns></returns>
		public static FuzzyTrendLabel ToFuzzyTrendLabel(int i)
		{
			switch (i)
			{
				case -3:
					return FuzzyTrendLabel.ПадениеСильное;
				case -2:
					return FuzzyTrendLabel.ПадениеСильное;
				case -1:
					return FuzzyTrendLabel.ПадениеСильное;
				case 0:
					return FuzzyTrendLabel.СтабильностьСредняя;
				case 1:
					return FuzzyTrendLabel.РостСлабый;
				case 2:
					return FuzzyTrendLabel.РостСредний;
				case 3:
					return FuzzyTrendLabel.РостСильный;
				default:
					return FuzzyTrendLabel.Неопределено;
			}
		}
		
		public static FuzzyTrendLabel ToFuzzyTrendLabel(string text)
		{
			return (FuzzyTrendLabel)Enum.Parse(typeof(FuzzyTrendLabel), text);
		}

		public static FuzzyLabelType ToFuzzyLabelType(string text)
		{
			return (FuzzyLabelType)Enum.Parse(typeof(FuzzyLabelType), text);
		}

		public static TypeSituation ToTypeSituation(string text)
		{
			return (TypeSituation)Enum.Parse(typeof(TypeSituation), text);
		}

		public static TypeMemoryValue ToTypeMemoryValue(string text)
		{
			return (TypeMemoryValue)Enum.Parse(typeof(TypeMemoryValue), text);
		}

		public static TypeFile ToTypeFile(string text)
		{
			return (TypeFile)Enum.Parse(typeof(TypeFile), text);
		}

		public static TypeDataInFile ToTypeDataInFile(string text)
		{
			return (TypeDataInFile)Enum.Parse(typeof(TypeDataInFile), text);
		}
	}
}
