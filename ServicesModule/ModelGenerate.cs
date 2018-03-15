using DatabaseModule;
using ServicesModule.BindingModels;
using ServicesModule.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ServicesModule
{
    public static class ModelGenerate
    {
        private static List<PointInfo> _points;

        /// <summary>
        /// Генерация нечетких тенденций
        /// </summary>
        /// <param name="seriesId"></param>
        public static void GenerateFuzzyTrends(int seriesId)
        {
            using (var _context = new DissertationDbContext())
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    foreach (FuzzyTrendLabel elem in Enum.GetValues(typeof(FuzzyTrendLabel)))
                    {
                        _context.FuzzyTrends.Add(ModelConvector.ToFuzzyTrend(new FuzzyTrendBindingModel
                        {
                            SeriesId = seriesId,
                            TrendName = elem,
                            Weight = Converter.ToFuzzyTrendLabelWeight(elem)
                        }));
                        _context.SaveChanges();
                    }
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        /// <summary>
        /// Генерируем правила определения тенденции по нечетким меткам
        /// </summary>
        /// <param name="seriesId"></param>
        /// <returns></returns>
        public static List<RuleTrendViewModel> GenerateRuleTrends(int seriesId)
        {
            var logicFL = new FuzzyLabelService();
            var logicFT = new FuzzyTrendService();
            var labels = logicFL.GetElements(seriesId);
            var trends = logicFT.GetElements(seriesId);
            // формируем правила нечетких тенденций
            List<RuleTrendViewModel> rules = new List<RuleTrendViewModel>();
            // проходимся по всем нечетким меткам ряда            
            foreach (var labFrom in labels)
            {
                foreach (var labTo in labels)
                {
                    rules.Add(new RuleTrendViewModel
                    {
                        SeriesDiscriptionId = seriesId,
                        FuzzyTrendName = FuzzyTrendLabel.Неопределено.ToString(),
                        FuzzyTrendWeight = labTo.FuzzyLabelWeight - labFrom.FuzzyLabelWeight,
                        FuzzyLabelFromId = labFrom.Id,
                        FuzzyLabelFromName = labFrom.FuzzyLabelName,
                        FuzzyLabelToId = labTo.Id,
                        FuzzyLabelToName = labTo.FuzzyLabelName
                    });
                }
            }
            // сортируем правила по весам
            rules = rules.OrderBy(r => r.FuzzyTrendWeight).ToList();

            DistributePointTrendsByTrends(rules, trends);

            return rules;
        }
        /// <summary>
        /// Распределить нечеткие тенденции по весам в правилах
        /// </summary>
        /// <param name="rules"></param>
        /// <param name="trends"></param>
        private static void DistributePointTrendsByTrends(List<RuleTrendViewModel> rules, IEnumerable<FuzzyTrendViewModel> trends)
        {
            var lessZeroTrends = trends.Where(t => t.Weight < 0 && t.Weight > -100).OrderBy(t => t.Weight).ToList();
            var lessZeroRules = rules.Where(r => r.FuzzyTrendWeight < 0).ToList();

            if(lessZeroTrends.Count > 0 && lessZeroRules.Count > 0)
            {
                var delta = ((double)lessZeroRules.Min(r => r.FuzzyTrendWeight) * -1 + 1) / lessZeroTrends.Count;
                int i = 0;
                for (double a = lessZeroRules.Min(r => r.FuzzyTrendWeight) - 1; i < lessZeroTrends.Count && a < 0; ++i, a+= delta)
                {
                    var applyRules = rules.Where(r => r.FuzzyTrendWeight > a && r.FuzzyTrendWeight <= a + delta).ToList();
                    foreach(var rule in applyRules)
                    {
                        rule.FuzzyTrendName = lessZeroTrends[i].TrendName;
                    }
                }
            }
            else if (lessZeroTrends.Count > 0 && lessZeroRules.Count == 0)
            {
                throw new Exception("CalcPointTrends: есть тренды с весами меньше 0, но нет парвил с весами меньше 0");
            }
            else if (lessZeroTrends.Count == 0 && lessZeroRules.Count > 0)
            {
                throw new Exception("CalcPointTrends: есть правила с весами меньше 0, но нет трендов с весами меньше 0");
            }
            
            var zeroTrends = trends.FirstOrDefault(t => t.Weight == 0);
            var zeroRules = rules.Where(r => r.FuzzyTrendWeight == 0).ToList();
            foreach (var rule in zeroRules)
            {
                rule.FuzzyTrendName = zeroTrends.TrendName;
            }

            var moreZeroTrends = trends.Where(t => t.Weight > 0).OrderByDescending(t => t.Weight).ToList();
            var moreZeroRules = rules.Where(r => r.FuzzyTrendWeight > 0).ToList();

            if (moreZeroTrends.Count > 0 && moreZeroRules.Count > 0)
            {
                var delta = ((double)moreZeroRules.Max(r => r.FuzzyTrendWeight) + 1) / moreZeroTrends.Count;
                int i = 0;
                for (double a = moreZeroRules.Max(r => r.FuzzyTrendWeight) + 1; i < moreZeroTrends.Count && a > 0; ++i, a -= delta)
                {
                    var applyRules = rules.Where(r => r.FuzzyTrendWeight < a && r.FuzzyTrendWeight >= a - delta).ToList();
                    foreach (var rule in applyRules)
                    {
                        rule.FuzzyTrendName = moreZeroTrends[i].TrendName;
                    }
                }
            }
            else if (moreZeroTrends.Count > 0 && moreZeroRules.Count == 0)
            {
                throw new Exception("CalcPointTrends: есть тренды с весами большими 0, но нет парвил с весами большими 0");
            }
            else if (moreZeroTrends.Count == 0 && moreZeroRules.Count > 0)
            {
                throw new Exception("CalcPointTrends: есть правила с весами большими 0, но нет трендов с весами большими 0");
            }
        }

        public static void GenerateSituationsByFuzzy(int seriesId)
        {
            using (var _context = new DissertationDbContext())
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var labels = _context.FuzzyLabels.Where(fl => fl.SeriesDiscriptionId == seriesId).ToList();
                    var trends = _context.FuzzyTrends.Where(ft => ft.SeriesDiscriptionId == seriesId).ToList();
                    int counter = 0;
                    for (int i = 0; i < labels.Count; ++i)
                    {
                        for (int j = 0; j < trends.Count; ++j)
                        {
                            for (int t = 0; t < labels.Count; ++t)
                            {
                                for (int r = 0; r < trends.Count; ++r)
                                {
                                    _context.StatisticsByFuzzys.Add(new StatisticsByFuzzy
                                    {
                                        NumberSituation = counter++,
                                        SeriesDiscriptionId = seriesId,
                                        StartStateFuzzyLabelId = labels[i].Id,
                                        StartStateFuzzyTrendId = trends[j].Id,
                                        EndStateFuzzyLabelId = labels[t].Id,
                                        EndStateFuzzyTrendId = trends[r].Id,
                                        CountMeet = 0
                                    });
                                    _context.SaveChanges();
                                }
                            }
                        }
                    }
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public static void GenerateSituationsByEntropy(int seriesId)
        {
            using (var _context = new DissertationDbContext())
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var needForecast = _context.SeriesDescriptions.SingleOrDefault(sd => sd.Id == seriesId).NeedForecast;
                    var labels = EntropyByFT.Entropyes;
                    var trends = (needForecast) ? EntropyByUX.Entropyes4Forecast : EntropyByUX.EntropyesNot4Forecast;
                    int counter = 0;
                    for (int i = 0; i < labels.Count; ++i)
                    {
                        for (int j = 0; j < trends.Count; ++j)
                        {
                            for (int t = 0; t < labels.Count; ++t)
                            {
                                for (int r = 0; r < trends.Count; ++r)
                                {
                                    _context.StatisticsByEntropys.Add(new StatisticsByEntropy
                                    {
                                        NumberSituation = counter++,
                                        SeriesDiscriptionId = seriesId,
                                        StartStateLingvistUX = trends[j],
                                        StartStateLingvistFT = labels[i],
                                        EndStateLingvistUX = trends[r],
                                        EndStateLingvistFT = labels[t],
                                        CountMeet = 0
                                    });
                                    _context.SaveChanges();
                                }
                            }
                        }
                    }
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool CalcPointsTrend(PointTrendCalcBindingModel model)
        {
            _points = new List<PointInfo>();
            bool flag = true;

            switch (model.TypeFile)
            {
                case TypeFile.Excel:
                    flag = LoadFromExcel(model.FileName, model.DatasInFile, model.SeriesDiscriptionId);
                    break;
                case TypeFile.Текстовый:
                    flag = LoadFromTxt(model.FileName, model.DatasInFile, model.SeriesDiscriptionId);
                    break;
            }
            if(flag)
            {
                flag = SetWeightForPoint(model.SeriesDiscriptionId);
            }
            return flag;
        }
        /// <summary>
        /// Загрузка точек из файла и внесение статистики по каждой точке, через вызов метода AddNewPoint
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="elements"></param>
        /// <param name="seriesId"></param>
        /// <returns></returns>
        private static bool LoadFromExcel(string fileName, List<TypeDataInFile> elements, int seriesId)
        {
            var excel = new Microsoft.Office.Interop.Excel.Application();
            try
            {
                var workbook = excel.Workbooks.Open(fileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing);
                var excelworksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets.get_Item(1);
                var excelcell = excelworksheet.get_Range("A2", "A2");
                while (excelcell.Value2 != null)
                {
                    PointInfo point = new PointInfo();
                    for (int i = 0; i < elements.Count; ++i)
                    {
                        var tempexcelcell = excelcell.get_Offset(0, i);
                        switch (elements[i])
                        {
                            case TypeDataInFile.ЧисловоеЗначение:
                                point.Value = Convert.ToDouble(tempexcelcell.Value2);
                                break;
                            case TypeDataInFile.Дата:
                                point.Date = DateTime.FromOADate(Convert.ToDouble(tempexcelcell.Value2));
                                break;
                        }
                    }
                    if (!point.Value.HasValue)
                    {
                        throw new Exception("Недостаточно данных для расчетов, нужна или нечеткая метка или числовое значение");
                    }
                    AddNewPoint(point, seriesId);

                    excelcell = excelcell.get_Offset(1, 0);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                excel.Quit();
            }
            return true;
        }
        /// <summary>
        /// Загрузка точек из файла и внесение статистики по каждой точке, через вызов метода AddNewPoint
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="elements"></param>
        /// <param name="seriesId"></param>
        /// <returns></returns>
        private static bool LoadFromTxt(string fileName, List<TypeDataInFile> elements, int seriesId)
        {
            StreamReader stream = null;
            try
            {
                stream = new StreamReader(fileName);
                string read = stream.ReadLine();
                while (read != null)
                {
                    read = read.Replace(" ", "");
                    var elems = read.Split(' ');
                    if (elems.Length != elements.Count)
                    {
                        throw new Exception("Не совпадают данные из файла и ожидаемые");
                    }
                    PointInfo point = new PointInfo();
                    for (int i = 0; i < elements.Count; ++i)
                    {
                        switch (elements[i])
                        {
                            case TypeDataInFile.ЧисловоеЗначение:
                                double val = 0;
                                if (double.TryParse(read.Replace('.', ','), out val))
                                    point.Value = val;
                                else if (double.TryParse(read.Replace(',', '.'), out val))
                                    point.Value = val;
                                else
                                    point.Value = Convert.ToDouble(elems[i]);
                                break;
                            case TypeDataInFile.Дата:
                                point.Date = DateTime.FromOADate(Convert.ToDouble(elems[i]));
                                break;
                        }
                    }
                    if (!point.Value.HasValue)
                    {
                        throw new Exception("Недостаточно данных для расчетов, нужна или нечеткая метка или числовое значение");
                    }
                    AddNewPoint(point, seriesId);

                    read = stream.ReadLine();
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
            return true;
        }
        /// <summary>
        /// Обработка новой точки
        /// </summary>
        /// <param name="point"></param>
        /// <param name="seriesId"></param>
        /// <returns></returns>
        private static bool AddNewPoint(PointInfo point, int seriesId)
        {
            using (var _context = new DissertationDbContext())
            {
                try
                {
                    if (_points.Count > 0)
                    {//если уже есть точки, получить тенденцию
                        point = ModelCalculator.CalcFUX(point, seriesId);
                        var fuzzyLabelId = _points[_points.Count - 1].FuzzyLabelId;
                        var rule = _context.RuleTrends.SingleOrDefault(r => r.FuzzyLabelFromId == fuzzyLabelId && r.FuzzyLabelToId == point.FuzzyLabelId);
                        if (rule == null)
                        {
                            throw new Exception(string.Format("Нет правила для такого сочитания нечетких меток: {0} и {1}",
                                  _points[_points.Count - 1].FuzzyLabel.FuzzyLabelName, point.FuzzyLabel.FuzzyLabelName));
                        }
                        point.FuzzyTrendId = rule.FuzzyTrendId;
                        point.FuzzyTrend = _context.FuzzyTrends.Single(ft => ft.Id == rule.FuzzyTrendId);

                        if (_points.Count > 3)
                        {//если есть возможность, получить энтропию по тенденции
                            var xNow = Converter.ToFuzzyTrendLabelWeight(_points[_points.Count - 1].FuzzyTrend.TrendName);
                            if (xNow == Converter.TrendWeightNotFound)
                            {
                                throw new Exception(string.Format("Не найден вес для тенденции {0}", _points[_points.Count - 1].FuzzyTrend.TrendName));
                            }
                            var xLast = Converter.ToFuzzyTrendLabelWeight(_points[_points.Count - 2].FuzzyTrend.TrendName);
                            if (xLast == Converter.TrendWeightNotFound)
                            {
                                throw new Exception(string.Format("Не найден вес для тенденции {0}", _points[_points.Count - 2].FuzzyTrend.TrendName));
                            }
                            var xLastLast = Converter.ToFuzzyTrendLabelWeight(_points[_points.Count - 3].FuzzyTrend.TrendName);
                            if (xLastLast == Converter.TrendWeightNotFound)
                            {
                                throw new Exception(string.Format("Не найден вес для тенденции {0}", _points[_points.Count - 3].FuzzyTrend.TrendName));
                            }
                            // скорость преращения тенденции в предыдущей точке
                            var speedTrendLast = xLastLast - xLast;
                            // скорость преращения тенденции в ткущей точке
                            var speedTrend = xLast - xNow;
                            int beforePoint = ModelCalculator.CalcPointOnPhasePlane(_points[_points.Count - 2].FuzzyTrend.TrendName, speedTrendLast);
                            int nextPoint = ModelCalculator.CalcPointOnPhasePlane(_points[_points.Count - 1].FuzzyTrend.TrendName, speedTrend);
                            var pointTrend = _context.PointTrends.FirstOrDefault(p => p.StartPoint == beforePoint && p.FinishPoint == nextPoint && p.SeriesDiscriptionId == seriesId);
                            if (pointTrend == null)
                            {
                                pointTrend = new PointTrend
                                {
                                    StartPoint = beforePoint,
                                    FinishPoint = nextPoint,
                                    Count = 1,
                                    Weight = 0,
                                    SeriesDiscriptionId = seriesId,
                                    Trends = point.FuzzyTrend.TrendName.ToString()
                                };
                                _context.PointTrends.Add(pointTrend);
                            }
                            else
                            {
                                if (!pointTrend.Trends.Contains(point.FuzzyTrend.TrendName.ToString()))
                                {
                                    pointTrend.Trends += string.Format(", {0}", point.FuzzyTrend.TrendName);
                                }
                                pointTrend.Count++;
                            }
                            _context.SaveChanges();
                        }
                    }
                    else
                    {
                        point = ModelCalculator.CalcFUX(point, seriesId);
                    }
                    if (_points.Count == 5)
                    {
                        _points.RemoveAt(0);
                    }
                    _points.Add(point);//занести точку

                    return true;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        /// <summary>
        /// Настройка весов для созданныых точек
        /// </summary>
        /// <param name="seriesId"></param>
        /// <returns></returns>
        private static bool SetWeightForPoint(int seriesId)
        {
            using (var _context = new DissertationDbContext())
            {
                try
                {
                    var groupPoints = _context.PointTrends.Where(pt => pt.SeriesDiscriptionId == seriesId).GroupBy(pt => pt.StartPoint).ToList();
                    foreach(var groupPoint in groupPoints)
                    {
                        var points = groupPoint.OrderByDescending(pt => pt.Count).ToList();
                        List<int> deltas = new List<int>();
                        if(points.Count == 0)
                        { }
                        else if(points.Count == 1)
                        {
                            points[0].Weight = 1;
                            _context.SaveChanges();
                            continue;
                        }
                        else if(points.Count == 2)
                        {
                            var delta = Math.Abs(points[0].Count - points[1].Count);
                            if(delta < 5)
                            {
                                points[0].Weight = 0.5;
                                points[1].Weight = 0.5;
                            }
                            else
                            {
                                points[0].Weight = 1;
                                points[1].Weight = 0.5;
                            }
                        }
                        else if (points.Count == 3)
                        {
                            var delta1 = Math.Abs(points[0].Count - points[1].Count);
                            var delta2 = Math.Abs(points[1].Count - points[2].Count);
                            if (delta1 < delta2)
                            {
                                points[0].Weight = 0.5;
                                points[1].Weight = 0.5;
                            }
                            else
                            {
                                points[0].Weight = 1;
                                points[1].Weight = 0.5;
                                points[2].Weight = 0.5;
                            }
                        }
                        else
                        {
                            points[0].Weight = 1;
                            for(int i = 1; i < points.Count; ++i)
                            {
                                points[i].Weight = 0.5;
                            }
                        }
                        _context.SaveChanges();
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
    }
}
