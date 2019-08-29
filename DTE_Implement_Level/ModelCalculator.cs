using DTE_Implement_Level.StaticClasses;
using DTE_Interface_Level.Enums;
using DTE_Interface_Level.ViewModels;
using DTE_Model_Level.BaseClassies;
using DTE_Model_Level.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Text;

namespace DTE_Implement_Level
{
    public static class ModelCalculator
    {
        /// <summary>
        /// Вычисление значения функции принадлежности и определение нечеткой метки, к которой принадлежит точка
        /// </summary>
        public static PointInfo CalcFUX(PointInfo point, int? seriesId = null)
        {
            if (!seriesId.HasValue && point.SeriesDiscriptionId > 0)
            {
                seriesId = point.SeriesDiscriptionId;
            }
            if ((point.DiagnosticTest == null || point.DiagnosticTest.SeriesDiscriptionId == 0) && !seriesId.HasValue)
            {
                throw new Exception("Невозможно получить нечеткие метки");
            }
            using (var _context = new DissertationDbContext())
            {   // индекс нечеткой метки, к которой будет принадлежать точка
                var fuzzyLabels = (seriesId.HasValue) ?
                    _context.FuzzyLabels.Where(fl => fl.SeriesDiscriptionId == seriesId.Value).ToList() :
                    _context.FuzzyLabels.Where(fl => fl.SeriesDiscriptionId == point.DiagnosticTest.SeriesDiscriptionId).ToList();
                var needForecast = _context.SeriesDescriptions.SingleOrDefault(sd => sd.Id == seriesId.Value)?.NeedForecast ?? false;
                switch (fuzzyLabels.First().FuzzyLabelType)
                {
                    case FuzzyLabelType.FuzzyTriangle://фаззификация
                                                      // вычисляем функцию принадлежности к первой нечетой метке
                        point.Fux = CalcNu(point.Value.Value, fuzzyLabels.First().FuzzyLabelMinVal, fuzzyLabels.First().FuzzyLabelCenter, fuzzyLabels.First().FuzzyLabelMaxVal);
                        point.FuzzyLabel = fuzzyLabels.First();
                        point.FuzzyLabelId = fuzzyLabels.First().Id;
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
        public static double CalcEntropyByFT(FuzzyTrendLabel lastPointFTN, FuzzyTrendLabel beforeLastPointFTN, FuzzyTrendLabel beforeBeforeLastPointFTN,
            int seriesId, out int pointNext)
        {
            var xNow = Converter.ToFuzzyTrendLabelWeight(lastPointFTN);
            if (xNow == Converter.TrendWeightNotFound)
            {
                throw new Exception(string.Format("Не найден вес для тенденции {0}", lastPointFTN));
            }
            var xLast = Converter.ToFuzzyTrendLabelWeight(beforeLastPointFTN);
            if (xLast == Converter.TrendWeightNotFound)
            {
                throw new Exception(string.Format("Не найден вес для тенденции {0}", beforeLastPointFTN));
            }
            var xLastLast = Converter.ToFuzzyTrendLabelWeight(beforeBeforeLastPointFTN);
            if (xLastLast == Converter.TrendWeightNotFound)
            {
                throw new Exception(string.Format("Не найден вес для тенденции {0}", beforeBeforeLastPointFTN));
            }
            // точка на фазовой полскости для предыдущей точки ряда
            var beforePoint = CalcPointOnPhasePlane(beforeLastPointFTN, xLastLast - xLast);
            // точка на фазовой плоскости для текущей точки ряда
            var nextPoint = CalcPointOnPhasePlane(lastPointFTN, xLast - xNow);
            pointNext = nextPoint;
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
                    point.Count++;
                    _context.SaveChanges();
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
        public static int CalcPointFromFFT(double fft, int point, int seriesId)
        {
            using (var _context = new DissertationDbContext())
            {
                var points = _context.PointTrends.Where(x => x.SeriesDiscriptionId == seriesId && x.StartPoint == point).ToList();
                if (points != null && points.Count > 0)
                {
                    var p = points.FirstOrDefault(x => x.Weight == fft);
                    if (p != null)
                    {
                        return p.FinishPoint;
                    }
                    if (fft == 0)
                    {
                        p = points.FirstOrDefault(x => x.Weight == 0.5);
                        if (p != null)
                        {
                            return p.FinishPoint;
                        }
                        p = points.FirstOrDefault(x => x.Weight == 1);
                        if (p != null)
                        {
                            return p.FinishPoint;
                        }
                    }
                    else if (fft == 1)
                    {
                        p = points.FirstOrDefault(x => x.Weight == 0.5);
                        if (p != null)
                        {
                            return p.FinishPoint;
                        }
                        p = points.FirstOrDefault(x => x.Weight == 0);
                        if (p != null)
                        {
                            return p.FinishPoint;
                        }
                    }
                    else if (fft == 0.5)
                    {
                        p = points.FirstOrDefault(x => x.Weight == 1);
                        if (p != null)
                        {
                            return p.FinishPoint;
                        }
                        p = points.FirstOrDefault(x => x.Weight == 0);
                        if (p != null)
                        {
                            return p.FinishPoint;
                        }
                    }
                    throw new Exception(string.Format("CalcPointFromFFT({0}): Не нашли для точки {1} точку по весу {2}", seriesId, point, fft));
                }
                else
                {
                    throw new Exception(string.Format("CalcPointFromFFT({0}): Не найдены точки тенденция для ряда", seriesId));
                }
            }

        }

        /// <summary>
        /// Вычисляется точка по значении меры энтропии по нечеткой тенденции и точке фазовой плоскости по предыдущей тенденции (для прогнозирования)
        /// </summary>
        /// <param name="lastPointFTN"></param>
        /// <param name="beforeLastPointFTN"></param>
        /// <param name="tempStateEntropy"></param>
        /// <returns></returns>
        public static int CalcPointFromFFT(FuzzyTrendLabel lastPointFTN, FuzzyTrendLabel beforeLastPointFTN, StatisticsByEntropy tempStateEntropy, int seriesId)
        {
            var xLast = Converter.ToFuzzyTrendLabelWeight(lastPointFTN);
            if (xLast == Converter.TrendWeightNotFound)
                throw new Exception("Не найден вес для тенденции " + lastPointFTN);
            var xLastLast = Converter.ToFuzzyTrendLabelWeight(beforeLastPointFTN);
            if (xLastLast == Converter.TrendWeightNotFound)
                throw new Exception("Не найден вес для тенденции " + beforeLastPointFTN);
            var speedTrendLast = xLastLast - xLast;

            return CalcPointFromFFT(Converter.ToEntropyByFT(tempStateEntropy.EndStateLingvistFT),
                    CalcPointOnPhasePlane(lastPointFTN, speedTrendLast), seriesId);
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

        public static int GetPoint(FuzzyTrendLabel lastPointFTN, FuzzyTrendLabel beforeLastPointFTN)
        {
            var xNow = Converter.ToFuzzyTrendLabelWeight(lastPointFTN);
            if (xNow == Converter.TrendWeightNotFound)
            {
                throw new Exception(string.Format("Не найден вес для тенденции {0}", lastPointFTN));
            }
            var xLast = Converter.ToFuzzyTrendLabelWeight(beforeLastPointFTN);
            if (xLast == Converter.TrendWeightNotFound)
            {
                throw new Exception(string.Format("Не найден вес для тенденции {0}", beforeLastPointFTN));
            }
            // точка на фазовой плоскости для текущей точки ряда
            return CalcPointOnPhasePlane(lastPointFTN, xLast - xNow);
        }

        public static string GetDescription(this AnomalyInfo ai)
        {
            using (var _context = new DissertationDbContext())
            {
                var sb = new StringBuilder();
                sb.AppendLine("Ситуации:");
                var situations = ai.SetSituations.Split(',');
                BaseClassStatisticBy statistic = null;
                foreach (var sit in situations)
                {
                    int number = Convert.ToInt32(sit);
                    switch (ai.TypeSituation)
                    {
                        case TypeSituation.ПоНечеткости:
                            statistic = _context.StatisticsByFuzzys
                                                .Include(stf => stf.EndStateFuzzyLabel)
                                                .Include(stf => stf.EndStateFuzzyTrend)
                                                .Include(stf => stf.StartStateFuzzyLabel)
                                                .Include(stf => stf.StartStateFuzzyTrend)
                                                .FirstOrDefault(stf => stf.NumberSituation == number &&
                                                    stf.SeriesDiscriptionId == ai.SeriesDiscriptionId);
                            break;
                        case TypeSituation.ПоЭнтропии:
                            statistic = _context.StatisticsByEntropys.FirstOrDefault(ste => ste.NumberSituation == number &&
                                                    ste.SeriesDiscriptionId == ai.SeriesDiscriptionId);
                            break;
                    }
                    sb.AppendLine(string.Format("{0} -> {1}", statistic.StartState, statistic.EndState));
                }
                sb.AppendLine("Аномалия:");
                switch (ai.TypeSituation)
                {
                    case TypeSituation.ПоНечеткости:
                        statistic = _context.StatisticsByFuzzys
                                                .Include(stf => stf.EndStateFuzzyLabel)
                                                .Include(stf => stf.EndStateFuzzyTrend)
                                                .Include(stf => stf.StartStateFuzzyLabel)
                                                .Include(stf => stf.StartStateFuzzyTrend)
                                                .FirstOrDefault(stf => stf.NumberSituation == ai.AnomalySituation &&
                                                stf.SeriesDiscriptionId == ai.SeriesDiscriptionId);
                        break;
                    case TypeSituation.ПоЭнтропии:
                        statistic = _context.StatisticsByEntropys.FirstOrDefault(stf => stf.NumberSituation == ai.AnomalySituation &&
                                                stf.SeriesDiscriptionId == ai.SeriesDiscriptionId);
                        break;
                }
                sb.AppendLine(string.Format("{0} -> {1}", statistic.StartState, statistic.EndState));

                return sb.ToString();
            }
        }

        public static string GetStartState(this StatisticsByFuzzyViewModel model)
        {
            using (var _context = new DissertationDbContext())
            {
                return string.Format("{0} - {1}", _context.FuzzyLabels.SingleOrDefault(fl => fl.Id == model.StartStateFuzzyLabelId).FuzzyLabelName,
                  _context.FuzzyTrends.SingleOrDefault(ft => ft.Id == model.StartStateFuzzyTrendId).TrendName);
            }
        }

        public static string GetEndState(this StatisticsByFuzzyViewModel model)
        {
            using (var _context = new DissertationDbContext())
            {
                return string.Format("{0} - {1}", _context.FuzzyLabels.SingleOrDefault(fl => fl.Id == model.EndStateFuzzyLabelId).FuzzyLabelName,
                _context.FuzzyTrends.SingleOrDefault(ft => ft.Id == model.EndStateFuzzyTrendId).TrendName);
            }
        }
    }
}