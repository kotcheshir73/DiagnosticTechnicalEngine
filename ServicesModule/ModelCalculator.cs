using DatabaseModule;
using System;
using System.Linq;

namespace ServicesModule
{
    public static class ModelCalculator
	{
		/// <summary>
		/// Вычисление значения функции принадлежности и определение нечеткой метки, к которой принадлежит точка
		/// </summary>
		public static PointInfo CalcFUX(PointInfo point)
		{
			using (var _context = new DissertationDbContext())
			{   // индекс нечеткой метки, к которой будет принадлежать точка
				var fuzzyLabels = _context.FuzzyLabels.Where(fl => fl.SeriesDiscriptionId == point.DiagnosticTest.SeriesDiscriptionId);
				var needForecast = point.DiagnosticTest.NeedForecast;
				switch (fuzzyLabels.First().FuzzyLabelType)
				{
					case FuzzyLabelType.FuzzyTriangle://фаззификация
													  // вычисляем функцию принадлежности к первой нечетой метке
						point.Fux = CalcNu(point.Value.Value, fuzzyLabels.First().FuzzyLabelMinVal, fuzzyLabels.First().FuzzyLabelCenter, fuzzyLabels.First().FuzzyLabelMaxVal);
						// идем по остальным нечетким меткам
						foreach (var fuzzyLabel in fuzzyLabels)
						{
							if (point.Fux < CalcNu(point.Value.Value, fuzzyLabel.FuzzyLabelMinVal, fuzzyLabel.FuzzyLabelCenter, fuzzyLabel.FuzzyLabelMaxVal))
							{
								point.FuzzyLabel = fuzzyLabel;
								point.FuzzyLabelId = fuzzyLabel.Id;
								point.Fux = CalcNu(point.Value.Value, fuzzyLabel.FuzzyLabelMinVal, fuzzyLabel.FuzzyLabelCenter, fuzzyLabel.FuzzyLabelMaxVal);
							}
						}
						break;
					case FuzzyLabelType.ClustFCM:
						double max = -1;
						foreach (var fuzzyLabel in fuzzyLabels)
						{
							double top = CalcDistanse(point.Value.Value, fuzzyLabel.FuzzyLabelCenter);
							if (top < 1.0) top = Math.Pow(10, -5);
							double sum = 0.0;
							foreach (var tempFuzzyLabel in fuzzyLabels)
							{
								double distance = CalcDistanse(point.Value.Value, tempFuzzyLabel.FuzzyLabelCenter);
								if (distance < 1.0) distance = Math.Pow(10, -5);
								sum += Math.Pow(top / distance, 2.0);
							}
							if (max < 1.0 / sum)
							{
								max = 1.0 / sum;
								point.FuzzyLabel = fuzzyLabel;
								point.FuzzyLabelId = fuzzyLabel.Id;
								point.Fux = CalcNu(point.Value.Value, fuzzyLabel.FuzzyLabelMinVal, fuzzyLabel.FuzzyLabelCenter, fuzzyLabel.FuzzyLabelMaxVal);
							}
						}
						break;
				}
				if (point.FuzzyLabel == null)
				{
					return null;
				}
				if (needForecast)
				{
					// если значение функции энтропии меньше значения центра, то точка лежит левее центра
					if (point.Value.Value < point.FuzzyLabel.FuzzyLabelCenter)
					{
						point.PositionFUX = false;
					}
					// иначе - правее центра (центр не рассматриваем, нет нужды)
					else
					{
						point.PositionFUX = true;
					}
				}
				return point;
			}
		}
		/// <summary>
		/// Вычисление функции принадлежности
		/// </summary>
		/// <param name="value"></param>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <param name="c"></param>
		/// <returns></returns>
		public static double CalcNu(double value, double a, double b, double c)
		{
			if (value >= a && value <= b)
				return (value - a) / (b - a);
			else if (value > b && value <= c)
				return (c - value) / (c - b);
			return 0;
		}
		/// <summary>
		/// Расчет растояния от точки до центра
		/// </summary>
		/// <param name="value"></param>
		/// <param name="center"></param>
		/// <returns></returns>
		public static double CalcDistanse(double value, double center)
		{
			return Math.Sqrt(Math.Pow(value - center, 2));
		}

		/// <summary>
		/// Вычисление значения энтропии по функции принадлежности
		/// </summary>
		/// <param name="fUx">функции принадлежности</param>
		/// <returns></returns>
		public static double CalcEntropyByUX(double fUx)
		{
			double value = 0;
			if (fUx > 0)
			{
				value += fUx * Math.Log(fUx);
			}
			if (1 - fUx > 0)
			{
				value += (1 - fUx) * Math.Log(1 - fUx);
			}
			return value * -1;
		}
		/// <summary>
		/// Вычисление значения энтропии по нечеткой тенденции
		/// </summary>
		/// <param name="point"></param>
		/// <returns></returns>
		public static double CalcEntropyByFT(FuzzyTrendLabel lastPointFTN, FuzzyTrendLabel beforeLastPointFTN, FuzzyTrendLabel beforeBeforeLastPointFTN, int seriesId)
		{
			var xNow = Converter.ToFuzzyTrendLabelWeight(lastPointFTN);
			if (xNow == -1)
			{
				throw new Exception(string.Format("Не найден вес для тенденции {0}", lastPointFTN));
			}
			var xLast = Converter.ToFuzzyTrendLabelWeight(beforeLastPointFTN);
			if (xLast == -1)
			{
				throw new Exception(string.Format("Не найден вес для тенденции {0}", beforeLastPointFTN));
			}
			var xLastLast = Converter.ToFuzzyTrendLabelWeight(beforeBeforeLastPointFTN);
			if (xLastLast == -1)
			{
				throw new Exception(string.Format("Не найден вес для тенденции {0}", beforeBeforeLastPointFTN));
			}
			// точка на фазовой полскости для предыдущей точки ряда
			var beforePoint = CalcPointOnPhasePlane(beforeLastPointFTN, xLastLast - xLast);
			// точка на фазовой плоскости для текущей точки ряда
			var nextPoint = CalcPointOnPhasePlane(lastPointFTN, xLast - xNow);
			// получаем энтропию
			using (var _context = new DissertationDbContext())
			{
				var point = _context.PointTrends.FirstOrDefault(rec => rec.StartPoint == beforePoint && rec.FinishPoint == nextPoint && rec.SeriesDiscriptionId == seriesId);
				if (point == null)
				{
					return 1;
				}
				else
				{
					return 1.0 - point.Weight;
				}
			}
		}
		/// <summary>
		/// Расчет точки на фазовой плоскости
		/// </summary>
		/// <param name="trend">вес тенденции</param>
		/// <param name="speedTrend">скорость тенденции</param>
		/// <returns></returns>
		public static int CalcPointOnPhasePlane(FuzzyTrendLabel trend, int speedTrend)
		{
			if (trend == FuzzyTrendLabel.СтабильностьСредняя && speedTrend == 0)
			{
				return 0;
			}
			else if (trend.ToString().Contains("Рост") && speedTrend > 0)
			{
				return 1;
			}
			else if (trend.ToString().Contains("Падение") && speedTrend > 0)
			{
				return 2;
			}
			else if (trend.ToString().Contains("Падение") && speedTrend < 0)
			{
				return 3;
			}
			else if (trend.ToString().Contains("Рост") && speedTrend < 0)
			{
				return 4;
			}
			else if (trend == FuzzyTrendLabel.СтабильностьСредняя && speedTrend > 0)
			{
				return 5;
			}
			else if (trend == FuzzyTrendLabel.СтабильностьСредняя && speedTrend < 0)
			{
				return 6;
			}
			else if (trend.ToString().Contains("Рост") && speedTrend == 0)
			{
				return 7;
			}
			else if (trend.ToString().Contains("Падение") && speedTrend == 0)
			{
				return 8;
			}
			else
			{
				return -1;
			}
		}

		/// <summary>
		/// Вычисляется точка по значении меры энтропии по нечеткой тенденции и точке фазовой плоскости по предыдущей тенденции (для прогнозирования)
		/// </summary>
		/// <param name="fft">значение меры энтропии</param>
		/// <param name="point">точка фазовой плоскости по предыдущей тенденции</param>
		/// <returns></returns>
		public static int CalcPointFromFFT(double fft, int point)
		{
			switch (point)
			{
				case 0://0, 1, 3
					if (fft == 0)
					{
						return 0;
					}
					else if (fft == 0.5)
					{
						return 1;//(3)
					}
					return 1;
				case 1://3, 4, 6
					if (fft == 0)
					{
						return 6;
					}
					else if (fft == 0.5)
					{
						return 3;//(4)
					}
					return -1;
				case 2://3, 5 - мало вероятные события
					if (fft == 0.5)
					{
						return 3;//(5)
					}
					return -1;
				case 3://1, 2, 3, 5
					if (fft == 0)
					{
						return 5;
					}
					else if (fft == 0.5)
					{
						return 1;//(2, 3)
					}
					return -1;
				case 4://1, 3, 4, 6- мало вероятные события
					if (fft == 0.5)
					{
						return 1;//(3,4,6)
					}
					return -1;
				case 5://0, 1, 3
				case 6://0, 1, 3
					if (fft == 0)
					{
						return 0;
					}
					else if (fft == 0.5)
					{
						return 1;//(3)
					}
					return -1;
				case 7://недопустимые случаи
				case 8://
					return -1;
				default:
					return -1;
			}

		}
		/// <summary>
		/// Вычисляется точка по значении меры энтропии по нечеткой тенденции и точке фазовой плоскости по предыдущей тенденции (для прогнозирования)
		/// </summary>
		/// <param name="lastPointFTN"></param>
		/// <param name="beforeLastPointFTN"></param>
		/// <param name="tempStateEntropy"></param>
		/// <returns></returns>
		public static int CalcPointFromFFT(FuzzyTrendLabel lastPointFTN, FuzzyTrendLabel beforeLastPointFTN, StatisticsByEntropy tempStateEntropy)
		{
			var xLast = Converter.ToFuzzyTrendLabelWeight(lastPointFTN);
			if (xLast == -1)
				throw new Exception("Не найден вес для тенденции " + lastPointFTN);
			var xLastLast = Converter.ToFuzzyTrendLabelWeight(beforeLastPointFTN);
			if (xLastLast == -1)
				throw new Exception("Не найден вес для тенденции " + beforeLastPointFTN);
			var speedTrendLast = xLastLast - xLast;

			return CalcPointFromFFT(Converter.ToEntropyByFT(tempStateEntropy.EndStateLingvistFT),
					CalcPointOnPhasePlane(lastPointFTN, speedTrendLast));
		}
		/// <summary>
		/// Вычисление тенденции по точке фазовой плоскости (определяем знак, - или + или 0)
		/// </summary>
		/// <param name="point"></param>
		/// <returns></returns>
		public static double CalcTrendByPointOnPhasePlane(int point)
		{
			switch (point)
			{
				case 0:
				case 5:
				case 6:
					return 0;
				case 1:
				case 4:
				case 7:
					return 1;
				case 2:
				case 3:
				case 8:
					return -1;
				default:
					return 0;
			}
		}

	}
}
