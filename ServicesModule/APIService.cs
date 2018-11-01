using DatabaseModule;
using DatabaseModule.BaseClassies;
using DatabaseModule.Models;
using ServicesModule.BindingModels;
using ServicesModule.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServicesModule
{
    public class APIService
    {
        private int countCenters = 7;

        private List<PointInfo> _points;

        private List<KeyValuePair<AnomalyInfo, int>> _anomalyDetected;

        private int _countPoints;

        public bool InitSeries(SeriesDescriptionBindingModel model, List<APIData> list)
        {
            _points = new List<PointInfo>();
            using (var _context = new DissertationDbContext())
            {
                var series = _context.SeriesDescriptions.FirstOrDefault(x => x.SeriesName == model.SeriesName);
                if (series != null)
                {
                    throw new Exception("Уже есть серия с таким названием");
                }

                var entity = ModelConvector.ToSeriesDescription(new SeriesDescriptionBindingModel
                {
                    SeriesName = model.SeriesName,
                    SeriesDiscription = model.SeriesDiscription,
                    NeedForecast = model.NeedForecast
                });
                _context.SeriesDescriptions.Add(entity);
                _context.SaveChanges();

                #region Временной ряд
                var res = CreateFuzzyLabel(list, entity.Id);
                if (!res)
                {
                    return false;
                }
                _context.LogDatas.Add(new LogData
                {
                    DateLog = DateTime.Now,
                    MessageLogType = "Info",
                    MessageLogTitle = model.SeriesName,
                    MessageLog = string.Format("{0} нечеткие метки получены", model.SeriesName)
                });

                res = CreateFuzzyTrend(model.SeriesName, entity.Id);
                if (!res)
                {
                    return false;
                }
                _context.LogDatas.Add(new LogData
                {
                    DateLog = DateTime.Now,
                    MessageLogType = "Info",
                    MessageLogTitle = model.SeriesName,
                    MessageLog = string.Format("{0} нечеткие тенденции получены", model.SeriesName)
                });

                res = CreateRuleTrend(model.SeriesName, entity.Id);
                if (!res)
                {
                    return false;
                }
                _context.LogDatas.Add(new LogData
                {
                    DateLog = DateTime.Now,
                    MessageLogType = "Info",
                    MessageLogTitle = model.SeriesName,
                    MessageLog = string.Format("{0} правила для тенденций получены", model.SeriesName)
                });

                res = CreatePointTrend(model.SeriesName, entity.Id, list);
                if (!res)
                {
                    return false;
                }
                _context.LogDatas.Add(new LogData
                {
                    DateLog = DateTime.Now,
                    MessageLogType = "Info",
                    MessageLogTitle = model.SeriesName,
                    MessageLog = string.Format("{0} точки для тенденций получены", model.SeriesName)
                });

                res = GenerateSituationsByEntropy(model.SeriesName, entity.Id);
                if (!res)
                {
                    return false;
                }
                _context.LogDatas.Add(new LogData
                {
                    DateLog = DateTime.Now,
                    MessageLogType = "Info",
                    MessageLogTitle = model.SeriesName,
                    MessageLog = string.Format("{0} ситуации по энтропии получены", model.SeriesName)
                });

                res = GenerateSituationsByFuzzy(model.SeriesName, entity.Id);
                if (!res)
                {
                    return false;
                }
                _context.LogDatas.Add(new LogData
                {
                    DateLog = DateTime.Now,
                    MessageLogType = "Info",
                    MessageLogTitle = model.SeriesName,
                    MessageLog = string.Format("{0} ситуации по нечеткости получены", model.SeriesName)
                });
                #endregion
            }

            return true;
        }

        public string GetSeriesUrl(SeriesDescriptionBindingModel model)
        {
            using (var _context = new DissertationDbContext())
            {
                var series = _context.SeriesDescriptions.FirstOrDefault(x => x.SeriesName == model.SeriesName);
                if (series == null)
                {
                    throw new Exception("Не найдена серия с таким названием");
                }

                return series.SeriesDiscription;
            }
        }

        private bool CreateFuzzyLabel(List<APIData> list, int seriesId)
        {
            try
            {
                int _countClasters = countCenters;
                while (true)
                {
                    var clust = new ModelClustering("", 2, _countClasters, list);
                    if (clust.Calc())
                    {
                        var points = clust.Points;
                        var logic = new FuzzyLabelService();
                        List<FuzzyLabelBindingModel> fuzzyPoints = new List<FuzzyLabelBindingModel>();
                        for (int i = 0; i < countCenters; ++i)
                        {
                            if (points.Count > 0)
                            {
                                var point = points.First(r => r.x == points.Min(rex => rex.x));
                                var clustPoints = points.Where(r => r.clusterIndex == point.clusterIndex);
                                fuzzyPoints.Add(new FuzzyLabelBindingModel
                                {
                                    SeriesId = seriesId,
                                    FuzzyLabelType = FuzzyLabelType.ClustFCM,
                                    FuzzyLabelName = "Кластер " + (i + 1),
                                    Weigth = i + 1,
                                    MinVal = clustPoints.Min(rex => rex.x),
                                    Center = clust.Centers[(int)point.clusterIndex].x,
                                    MaxVal = clustPoints.Max(rex => rex.x)
                                });
                                points.RemoveAll(r => r.clusterIndex == point.clusterIndex);
                            }
                            else
                            {
                                fuzzyPoints.Add(new FuzzyLabelBindingModel
                                {
                                    SeriesId = seriesId,
                                    FuzzyLabelType = FuzzyLabelType.ClustFCM,
                                    FuzzyLabelName = "Кластер " + (i + 1),
                                    Weigth = i + 1,
                                    MinVal = 0,
                                    Center = 0,
                                    MaxVal = 0
                                });
                            }
                        }
                        double delta = 5;
                        fuzzyPoints[fuzzyPoints.Count - 1].MaxVal += delta;
                        for (int i = 0; i < fuzzyPoints.Count - 1; ++i)
                        {
                            fuzzyPoints[i].MinVal -= delta;
                            delta = (fuzzyPoints[i + 1].MinVal - fuzzyPoints[i].MaxVal) / 2 + 5;
                            fuzzyPoints[i].MaxVal += delta;
                            logic.InsertElement(fuzzyPoints[i]);
                        }
                        fuzzyPoints[fuzzyPoints.Count - 1].MinVal -= delta;
                        logic.InsertElement(fuzzyPoints[fuzzyPoints.Count - 1]);
                        return true;
                    }
                    _countClasters--;
                    if (_countClasters < 0)
                    {
                        throw new Exception("Кластеризация не прошла");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("CreateFuzzyLabel {0}: {1}", "", ex.Message));
            }
        }

        private bool CreateFuzzyTrend(string fileName, int seriesId)
        {
            try
            {
                ModelGenerate.GenerateFuzzyTrends(seriesId);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("CreateFuzzyTrend {0}: {1}", fileName, ex.Message));
            }
        }

        private bool CreateRuleTrend(string fileName, int seriesId)
        {
            try
            {
                var list = ModelGenerate.GenerateRuleTrends(seriesId);
                var rules = new RuleTrendsService();
                if (list != null)
                {
                    for (int i = 0; i < list.Count; ++i)
                    {
                        rules.InsertElement(new RuleTrendBindingModel
                        {
                            SeriesId = seriesId,
                            FuzzyTrendName = Converter.ToFuzzyTrendLabel(list[i].FuzzyTrendName),
                            FuzzyTrendId = Convert.ToInt32(list[i].FuzzyTrendId),
                            FuzzyLabelFromId = Convert.ToInt32(list[i].FuzzyLabelFromId),
                            FuzzyLabelToId = Convert.ToInt32(list[i].FuzzyLabelToId)
                        });
                    }
                    return true;
                }
                else
                {
                    throw new Exception("Не получен список правил");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("CreateRuleTrend {0}: {1}", fileName, ex.Message));
            }
        }

        private bool CreatePointTrend(string fileName, int seriesId, List<APIData> list)
        {
            try
            {
                return ModelGenerate.CalcPointsTrend(new PointTrendCalcBindingModel
                {
                    TypeFile = TypeFile.API,
                    DatasInFile = new List<TypeDataInFile> { TypeDataInFile.ЧисловоеЗначение },
                    SeriesDiscriptionId = seriesId,
                    List = list
                });
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("CreatePointTrend {0}: {1}", fileName, ex.Message));
            }
        }

        private bool GenerateSituationsByEntropy(string fileName, int seriesId)
        {
            try
            {
                ModelGenerate.GenerateSituationsByEntropy(seriesId);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("GenerateSituationsByEntropy {0}: {1}", fileName, ex.Message));
            }
        }

        private bool GenerateSituationsByFuzzy(string fileName, int seriesId)
        {
            try
            {
                ModelGenerate.GenerateSituationsByFuzzy(seriesId);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("GenerateSituationsByFuzzy {0}: {1}", fileName, ex.Message));
            }
        }

        public double MakeForecast(SeriesDescriptionBindingModel model, List<APIData> list)
        {
            if (list.Count < 3)
            {
                throw new Exception("Мало точек для прогноза");
            }
            _points = new List<PointInfo>();
            using (var _context = new DissertationDbContext())
            {
                var series = _context.SeriesDescriptions.FirstOrDefault(x => x.SeriesName == model.SeriesName);
                if (series == null)
                {
                    throw new Exception("Не найдена серия с таким названием");
                }

                if (list != null && list.Count > 1)
                {
                    for (int i = 0; i < list.Count; ++i)
                    {
                        AddNewPoint(new PointInfo
                        {
                            SeriesDiscriptionId = series.Id,
                            Value = list[i].Value
                        }, series.Id, false);
                    }

                    return GetForecast(_points[_points.Count - 1], _points[_points.Count - 2], series.Id);
                }
            }
            return 0;
        }

        /// <summary>
        /// Обработка новой точки
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        private void AddNewPoint(PointInfo point, int seriesId, bool makeDiagnostic)
        {
            using (var _context = new DissertationDbContext())
            {
                if (!point.Fux.HasValue)
                {//вычисляем функцию принадлежности и меру энтропии по функции принадлежности
                    point = ModelCalculator.CalcFUX(point, seriesId);
                    if (point == null)
                    {
                        throw new Exception("AddNewPoint: Не удалось получить функцию принадлежности");
                    }
                    point.EntropuUX = ModelCalculator.CalcEntropyByUX(point.Fux.Value);
                }

                if (_points.Count > 0)
                {//если уже есть точки, получить тенденцию
                    var labelFromId = _points[_points.Count - 1].FuzzyLabelId;
                    var rule = _context.RuleTrends.SingleOrDefault(r =>
                                                        r.FuzzyLabelFromId == labelFromId &&
                                                        r.FuzzyLabelToId == point.FuzzyLabelId &&
                                                        r.SeriesDiscriptionId == point.SeriesDiscriptionId);
                    if (rule == null)
                    {
                        throw new Exception(string.Format("AddNewPoint: Нет правила для такого сочитания нечетких меток: {0} и {1}",
                                                        _points[_points.Count - 1].FuzzyLabel.FuzzyLabelName,
                                                        point.FuzzyLabel.FuzzyLabelName));
                    }
                    point.FuzzyTrendId = rule.FuzzyTrendId;
                    point.FuzzyTrend = _context.FuzzyTrends.Single(ft => ft.Id == rule.FuzzyTrendId);

                    if (_points.Count > 2)
                    {
                        point.EntropyFT = ModelCalculator.CalcEntropyByFT(point.FuzzyTrend.TrendName,
                                                                            _points[_points.Count - 1].FuzzyTrend.TrendName,
                                                                            _points[_points.Count - 2].FuzzyTrend.TrendName,
                                                                            point.SeriesDiscriptionId);
                    }

                    if (_points.Count > 1)
                    {//получить состояния
                        var stateFuzzy = GetStateFuzzy(point);
                        if (stateFuzzy == null)
                        {
                            throw new Exception("AddNewPoint: Не определили номер ситуации по нечеткости");
                        }
                        point.StatisticsByFuzzyId = stateFuzzy.Id;
                        point.StatisticsByFuzzy = stateFuzzy;
                        if (_points.Count > 4)
                        {
                            var stateEntropy = GetStateEntropy(point);
                            if (stateEntropy == null)
                            {
                                throw new Exception("AddNewPoint: Не определили номер ситуации по энтропии");
                            }
                            point.StatisticsByEntropyId = stateEntropy.Id;
                            point.StatisticsByEntropy = stateEntropy;
                        }
                        if (makeDiagnostic)
                        {
                            // определения возможного наступления аномалии
                            AnomalyDetected(point);
                            // поиск новых аномалий
                            CheckNewState(point);
                        }
                    }
                }
                _points.Add(point);//занести точку;
            }
        }

        /// <summary>
        /// Определение ситуации по энтропиям, увеличение статистики по этой ситуации
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        private StatisticsByEntropy GetStateEntropy(PointInfo point)
        {
            using (var _context = new DissertationDbContext())
            {
                var startEntropyUX = Converter.ToLingvistUX(_points[_points.Count - 1].EntropuUX, _points[_points.Count - 1].PositionFUX);
                var startEntropyFT = Converter.ToLingvistFT(_points[_points.Count - 1].EntropyFT);
                var endEntropyUX = Converter.ToLingvistUX(point.EntropuUX, point.PositionFUX);
                var endEntropyFT = Converter.ToLingvistFT(point.EntropyFT);
                var stateEntropy = _context.StatisticsByEntropys.SingleOrDefault(r =>
                                                r.StartStateLingvistUX == startEntropyUX &&
                                                r.StartStateLingvistFT == startEntropyFT &&
                                                r.EndStateLingvistUX == endEntropyUX &&
                                                r.EndStateLingvistFT == endEntropyFT &&
                                                r.SeriesDiscriptionId == point.SeriesDiscriptionId);
                if (stateEntropy == null)
                {
                    var number = _context.StatisticsByEntropys
                                            .Where(sbf => sbf.SeriesDiscriptionId == point.SeriesDiscriptionId)
                                            .Select(sbf => sbf.NumberSituation)
                                            .DefaultIfEmpty()
                                            .Max() + 1;
                    stateEntropy = new StatisticsByEntropy
                    {
                        SeriesDiscriptionId = point.SeriesDiscriptionId,
                        StartStateLingvistUX = startEntropyUX,
                        StartStateLingvistFT = startEntropyFT,
                        EndStateLingvistUX = endEntropyUX,
                        EndStateLingvistFT = endEntropyFT,
                        NumberSituation = number,
                        CountMeet = 1
                    };
                    _context.StatisticsByEntropys.Add(stateEntropy);
                }
                else
                {
                    stateEntropy.CountMeet++;
                }
                _context.SaveChanges();
                return stateEntropy;
            }
        }

        /// <summary>
        /// Определение ситуации по нечеткости, увеличение статистики по этой ситуации
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        private StatisticsByFuzzy GetStateFuzzy(PointInfo point)
        {
            using (var _context = new DissertationDbContext())
            {
                var startLabelId = _points[_points.Count - 1].FuzzyLabelId;
                var startTrendId = _points[_points.Count - 1].FuzzyTrendId;
                var stateFuzzy = _context.StatisticsByFuzzys.SingleOrDefault(r =>
                                            r.StartStateFuzzyLabelId == startLabelId &&
                                            r.StartStateFuzzyTrendId == startTrendId &&
                                            r.EndStateFuzzyLabelId == point.FuzzyLabelId &&
                                            r.EndStateFuzzyTrendId == point.FuzzyTrendId &&
                                            r.SeriesDiscriptionId == point.SeriesDiscriptionId);
                if (stateFuzzy == null)
                {
                    var number = _context.StatisticsByFuzzys
                                        .Where(sbf => sbf.SeriesDiscriptionId == point.SeriesDiscriptionId)
                                        .Select(sbf => sbf.NumberSituation)
                                        .DefaultIfEmpty()
                                        .Max() + 1;
                    stateFuzzy = new StatisticsByFuzzy
                    {
                        SeriesDiscriptionId = point.SeriesDiscriptionId,
                        StartStateFuzzyLabelId = startLabelId.Value,
                        StartStateFuzzyTrendId = startTrendId.Value,
                        EndStateFuzzyLabelId = point.FuzzyLabelId.Value,
                        EndStateFuzzyTrendId = point.FuzzyTrendId.Value,
                        NumberSituation = number,
                        CountMeet = 1
                    };
                    _context.StatisticsByFuzzys.Add(stateFuzzy);
                }
                else
                {
                    stateFuzzy.CountMeet++;
                }
                _context.SaveChanges();
                return stateFuzzy;
            }
        }

        private double GetForecast(PointInfo LastPoint, PointInfo PreLastPoint, int seriesId)
        {
            using (var _context = new DissertationDbContext())
            {
                // результат - прогнозное значение
                double result = 0;
                // пока что - эот будет значение в последней точке
                result = LastPoint.Value.Value;
                // определяем ситуации по энтропии и по неопределенности
                var entropy = ModelConvector.ToStatisticsByEntropy(_context.StatisticsByEntropys.Single(dt => dt.Id == LastPoint.StatisticsByEntropyId));
                var fuzzy = ModelConvector.ToStatisticsByFuzzy(_context.StatisticsByFuzzys.Single(dt => dt.Id == LastPoint.StatisticsByFuzzyId));

                // 1 - отбираем ситуации из двух наборов
                var listStatEntropyOrdered = _context.StatisticsByEntropys
                                                .Where(r =>
                                                    r.StartStateLingvistFT == entropy.EndStateLingvistFT &&
                                                    r.StartStateLingvistUX == entropy.EndStateLingvistUX &&
                                                    r.SeriesDiscriptionId == entropy.SeriesDiscriptionId)
                                                .OrderByDescending(r => r.CountMeet)
                                                .ToList();
                var listStatFuzzyOrdered = _context.StatisticsByFuzzys
                                                .Where(r =>
                                                    r.StartStateFuzzyLabelId == fuzzy.EndStateFuzzyLabelId &&
                                                    r.StartStateFuzzyTrendId == fuzzy.EndStateFuzzyTrendId &&
                                                    r.SeriesDiscriptionId == fuzzy.SeriesDiscriptionId)
                                                .OrderByDescending(r => r.CountMeet)
                                                .ToList();

                int indexEntropy = 0;

                int indexFuzzy = 0;

                bool fuzzyLabelEqFuzzyTrend = false;

                bool fuzzyTrendEqEntropyTrend = false;

                #region ищем оптимальное сочетание
                while (!fuzzyLabelEqFuzzyTrend && !fuzzyTrendEqEntropyTrend)
                {
                    StatisticsByFuzzy tempStateFuzzy = null;
                    fuzzyLabelEqFuzzyTrend = false;
                    // сбрасываем счетчик по энтропии
                    indexEntropy = 0;
                    // получаем ситуацию по нечеткости
                    while (indexFuzzy < listStatFuzzyOrdered.Count)
                    {
                        tempStateFuzzy = listStatFuzzyOrdered[indexFuzzy];
                        // находим правило для нечеткой тенденции и нечетких меток
                        var rule = _context.RuleTrends.SingleOrDefault(r =>
                                    r.FuzzyLabelFromId == tempStateFuzzy.StartStateFuzzyLabelId &&
                                    r.FuzzyLabelToId == tempStateFuzzy.EndStateFuzzyLabelId &&
                                    r.FuzzyTrendId == tempStateFuzzy.EndStateFuzzyTrendId);
                        // убеждаемся, что есть такое правило 
                        fuzzyLabelEqFuzzyTrend = rule != null;
                        if (fuzzyLabelEqFuzzyTrend)
                        {
                            break;
                        }
                        indexFuzzy++;
                    }
                    // получаем ситуацию по энтропии (ищем с первой ситуации, пока не найдем нужную или не дойдем до конца), (если нашли ситуацию по нечеткости)
                    while (indexEntropy < listStatEntropyOrdered.Count && fuzzyLabelEqFuzzyTrend)
                    {
                        var tempStateEntropy = listStatEntropyOrdered[indexEntropy];

                        // получаем тенденцию в прогнозной точки
                        int newPointPhasePlane = ModelCalculator.CalcPointFromFFT(LastPoint.FuzzyTrend.TrendName, PreLastPoint.FuzzyTrend.TrendName, tempStateEntropy, seriesId);
                        // получаем знак прогнозируемой тенденции
                        double featureTrendSign = ModelCalculator.CalcTrendByPointOnPhasePlane(newPointPhasePlane);
                        var featureTrend = _context.FuzzyTrends.SingleOrDefault(t => t.Id == tempStateFuzzy.EndStateFuzzyTrendId);
                        // 0 - будет означать стабильность
                        if (featureTrendSign == 0)
                        {
                            fuzzyTrendEqEntropyTrend = featureTrend.TrendName == FuzzyTrendLabel.СтабильностьСредняя;
                        }
                        // если больше 0, то это рост
                        else if (featureTrendSign > 0)
                        {
                            fuzzyTrendEqEntropyTrend = (featureTrend.TrendName == FuzzyTrendLabel.РостСильный) ||
                                                        (featureTrend.TrendName == FuzzyTrendLabel.РостСлабый) ||
                                                        (featureTrend.TrendName == FuzzyTrendLabel.РостСредний);
                        }
                        // если меньше 0, то это падение
                        else
                        {
                            fuzzyTrendEqEntropyTrend = (featureTrend.TrendName == FuzzyTrendLabel.ПадениеСильное) ||
                                                        (featureTrend.TrendName == FuzzyTrendLabel.ПадениеСлабое) ||
                                                        (featureTrend.TrendName == FuzzyTrendLabel.ПадениеСреднее);
                        }
                        if (fuzzyTrendEqEntropyTrend)
                        {
                            break;
                        }
                        indexEntropy++;
                    }
                    // если дошли до конца по нечеткости, но так и не получили сочетания, просто берем первые по выпадению
                    if (indexFuzzy == listStatFuzzyOrdered.Count && !fuzzyLabelEqFuzzyTrend)
                    {
                        indexEntropy = 0;
                        indexFuzzy = 0;
                        break;
                    }
                }
                if (indexEntropy == listStatEntropyOrdered.Count)
                {
                    indexEntropy = 0;
                }
                #endregion

                var stateFuzzy = listStatFuzzyOrdered[indexFuzzy];
                var fuzzyLabel = _context.FuzzyLabels
                        .SingleOrDefault(r => r.Id == stateFuzzy.EndStateFuzzyLabelId && r.SeriesDiscriptionId == seriesId);
                var newEntropyPUX = listStatEntropyOrdered[indexEntropy].EndStateLingvistUX;

                if (listStatFuzzyOrdered[indexFuzzy].StartStateFuzzyTrendId == fuzzy.EndStateFuzzyTrendId)
                {// тенденция неизменна
                    if (listStatEntropyOrdered[indexEntropy].EndStateLingvistUX == entropy.EndStateLingvistUX)
                    // если значение меры энтропии по функции принадлежности в предыдущей точке 
                    // равно значению меры энтропии в текущей, то берем значение в предыдущей в качестве прогнозного
                    {
                        var trendName = _context.FuzzyTrends.Single(dt => dt.Id == fuzzy.EndStateFuzzyTrendId).TrendName;
                        switch (trendName)
                        {
                            case FuzzyTrendLabel.СтабильностьСредняя:
                                return LastPoint.Value.Value;
                            case FuzzyTrendLabel.РостСильный:
                            case FuzzyTrendLabel.РостСлабый:
                            case FuzzyTrendLabel.РостСредний:
                            case FuzzyTrendLabel.ПадениеСильное:
                            case FuzzyTrendLabel.ПадениеСлабое:
                            case FuzzyTrendLabel.ПадениеСреднее:
                                //получить прирост по последним точкам
                                return LastPoint.Value.Value * 2 - PreLastPoint.Value.Value;
                        }
                        return LastPoint.Value.Value;
                    }
                }
                // значения не совпадают, значит идет незначителньое изменение в точке
                else
                {
                    if (newEntropyPUX == LingvistUX.Достоверно)
                    // центр нечеткой метки
                    {
                        return fuzzyLabel.FuzzyLabelCenter;
                    }
                    else if (newEntropyPUX == LingvistUX.ВероятноМин)
                    {
                        return (fuzzyLabel.FuzzyLabelCenter - fuzzyLabel.FuzzyLabelMinVal) / 2;
                    }
                    else if (newEntropyPUX == LingvistUX.ВероятноМакс)
                    {
                        return (fuzzyLabel.FuzzyLabelMaxVal - fuzzyLabel.FuzzyLabelCenter) / 2;
                    }
                    else if (newEntropyPUX == LingvistUX.НеопределеноМин)
                    {
                        return (fuzzyLabel.FuzzyLabelMinVal);
                    }
                    else if (newEntropyPUX == LingvistUX.НеопределеноМакс)
                    {
                        return (fuzzyLabel.FuzzyLabelMaxVal);
                    }
                    else
                    {
                        throw new Exception("невозможно найти прогнозное значение");
                    }
                }

                return result;
            }
        }

        public List<DiagnosticTestRecordViewModel> Diagnostic(SeriesDescriptionBindingModel model, List<APIData> list)
        {
            if (list.Count < 3)
            {
                throw new Exception("Мало точек для диагностики");
            }
            using (var _context = new DissertationDbContext())
            {
                _points = new List<PointInfo>();
                var series = _context.SeriesDescriptions.FirstOrDefault(x => x.SeriesName == model.SeriesName);
                if (series == null)
                {
                    throw new Exception("Не найдена серия с таким названием");
                }
                var test = new DiagnosticTest
                {
                    SeriesDiscriptionId = series.Id,
                    TestNumber = series.SeriesName,
                    DateTest = DateTime.Now,
                    Count = 0
                };
                _context.DiagnosticTests.Add(test);
                _context.SaveChanges();
                _anomalyDetected = new List<KeyValuePair<AnomalyInfo, int>>();
                _countPoints = 0;
                if (list != null && list.Count > 1)
                {
                    for (int i = 0; i < list.Count; ++i)
                    {
                        _countPoints++;
                        AddNewPoint(new PointInfo
                        {
                            DiagnosticTestId = test.Id,
                            SeriesDiscriptionId = series.Id,
                            Value = list[i].Value
                        }, series.Id, true);
                    }
                }

                var listResult = _context.DiagnosticTestRecords.Where(x => x.DiagnosticTestId == test.Id)
                    .Select(ModelConvector.ToDiagnosticTestRecord).ToList();

                return listResult;
            }
        }

        private void AnomalyDetected(PointInfo point)
        {
            if (point.StatisticsByEntropy != null)
            {
                AnomalyDetectedByElem(point.StatisticsByEntropy, TypeSituation.ПоЭнтропии, point.DiagnosticTestId);
            }
            if (point.StatisticsByFuzzy != null)
            {
                AnomalyDetectedByElem(point.StatisticsByFuzzy, TypeSituation.ПоНечеткости, point.DiagnosticTestId);
            }
        }

        private void AnomalyDetectedByElem(BaseClassStatisticBy statistic, TypeSituation type, int diagnosticTestId)
        {
            using (var _context = new DissertationDbContext())
            {
                if (_anomalyDetected.Count > 0)
                {//проверить уже имеющиеся аномалии
                    for (int i = 0; i < _anomalyDetected.Count; ++i)
                    {
                        if (_anomalyDetected[i].Key.TypeSituation != type)
                        {
                            continue;
                        }
                        int state = Convert.ToInt32(_anomalyDetected[i].Key.SetSituations.Split(',')[_anomalyDetected[i].Value]);

                        if (state == statistic.NumberSituation)
                        {//подтверждение
                            _anomalyDetected[i] = new KeyValuePair<AnomalyInfo, int>(_anomalyDetected[i].Key, _anomalyDetected[i].Value + 1);
                            int lenght = _anomalyDetected[i].Key.SetSituations.Split(',').Length;
                            if (lenght == _anomalyDetected[i].Value)
                            {//Обнаружена аномалия (т.е. следующая точка будет аномальной)
                                var anomalyId = _anomalyDetected[i].Key.Id;
                                var anomaly = _context.AnomalyInfos.SingleOrDefault(a => a.Id == anomalyId);
                                anomaly.CountMeet++;

                                var probability = Math.Round((((double)statistic.CountMeet) / _countPoints) * 100, 2);

                                var message = string.Format("Точка № {0}. Возникла аномалия: {1} ({2}%)", _countPoints,
                                    _anomalyDetected[i].Key.AnomalyName, probability);

                                _context.DiagnosticTestRecords.Add(new DiagnosticTestRecord
                                {
                                    DiagnosticTestId = diagnosticTestId,
                                    PointNumber = _countPoints,
                                    Description = message,
                                    AnomalyInfoId = anomalyId
                                });
                                _context.SaveChanges();

                                if (AnalysAnomaly(_anomalyDetected[i].Key))
                                {//аномалия встречается слишком часто, удаляем ее
                                    anomaly.NotAnomaly = true;
                                    _anomalyDetected.RemoveAll(r => r.Key.Id == _anomalyDetected[i].Key.Id);
                                }
                                else
                                {
                                    _anomalyDetected.RemoveAt(i);
                                }
                                _context.SaveChanges();
                                return;
                            }
                        }
                        else
                        {
                            _anomalyDetected.RemoveAt(i);
                            i--;
                        }
                    }
                }
                //проверить другие аномалии
                var listAnomaly = _context.AnomalyInfos.Where(ai => ai.TypeSituation == type &&
                                                                    ai.SeriesDiscriptionId == statistic.SeriesDiscriptionId)
                                                        .ToList();
                foreach (var anomaly in listAnomaly)
                {
                    int state = Convert.ToInt32(anomaly.SetSituations.Split(',')[0]);

                    if (!anomaly.NotAnomaly && !anomaly.NotDetected)
                    {
                        if (state == statistic.NumberSituation)
                        {
                            _anomalyDetected.Add(new KeyValuePair<AnomalyInfo, int>(anomaly, 1));
                        }
                    }
                }
            }
        }

        private void CheckNewState(PointInfo point)
        {//список самых вероятных исходов
            if (point.StatisticsByFuzzy != null)
            {
                CheckNewStateByElem(point.StatisticsByFuzzy, TypeSituation.ПоНечеткости, point);
            }

            if (point.StatisticsByEntropy != null)
            {
                CheckNewStateByElem(point.StatisticsByEntropy, TypeSituation.ПоЭнтропии, point);
            }
        }

        private void CheckNewStateByElem(BaseClassStatisticBy statistic, TypeSituation type, PointInfo point)
        {
            using (var _context = new DissertationDbContext())
            {
                if ((((double)statistic.CountMeet) / _countPoints) * 100 < 1)
                {//новая аномалия
                    string setSituations = "";
                    string setValues = "";
                    TypeMemoryValue typeMemory = (point.Value.HasValue) ? TypeMemoryValue.ПоЗначению : TypeMemoryValue.ПоФункции;
                    var notDetected = true;
                    for (int i = 0; i < _points.Count; ++i)
                    {//собираем все номера ситуаций до этой (до 10 точек)
                        var tempEntropy = type == TypeSituation.ПоНечеткости ?
                                                        _points[i].StatisticsByFuzzy as BaseClassStatisticBy :
                                                        _points[i].StatisticsByEntropy as BaseClassStatisticBy;
                        if (tempEntropy != null)
                        {
                            setSituations += tempEntropy.NumberSituation;
                            if (i < _points.Count - 1)
                            {
                                setSituations += ",";
                            }
                            setValues += (_points[i].Value ?? _points[i].Fux.Value) + ";";
                            if (i > 0)
                            {
                                var temp2Entropy = type == TypeSituation.ПоНечеткости ?
                                                        _points[i - 1].StatisticsByFuzzy as BaseClassStatisticBy :
                                                        _points[i - 1].StatisticsByEntropy as BaseClassStatisticBy;
                                if (temp2Entropy != null)
                                {
                                    if (tempEntropy.NumberSituation != temp2Entropy.NumberSituation)
                                    {
                                        notDetected = false;
                                    }
                                }
                            }
                        }
                    }
                    //последний номер - аномальное состояние
                    setValues += (point.Value ?? point.Fux.Value);

                    if (setSituations.Split(',').Length < 6)
                    {
                        //_evMessage?.Invoke("Точка №" + _countPoints + ". Зафиксирована аномалия по энтропии, но имеется менее 5 точек для ее идентифкации: " + setSituations);
                    }
                    else
                    {//ищем среди аномалий аномалию с такой последовательностью
                        var elem = _context.AnomalyInfos.SingleOrDefault(r => r.TypeSituation == type && r.SetSituations == setSituations &&
                                                            r.SeriesDiscriptionId == point.SeriesDiscriptionId);
                        if (elem == null)
                        {
                            string typeString = (type == TypeSituation.ПоНечеткости ? "нечеткости" : "энтропии");
                            string name = string.Format("Аномалия по {0}: {1} -> {2}", typeString, setSituations, statistic.NumberSituation);

                            var anomaly = new AnomalyInfo
                            {
                                SeriesDiscriptionId = point.SeriesDiscriptionId,
                                AnomalyName = name,
                                TypeSituation = type,
                                TypeMemoryValue = typeMemory,
                                AnomalySituation = statistic.NumberSituation,
                                CountMeet = 1,
                                NotAnomaly = false,
                                NotDetected = notDetected,
                                SetSituations = setSituations,
                                SetValues = setValues
                            };

                            _context.AnomalyInfos.Add(anomaly);
                            var probability = Math.Round((((double)statistic.CountMeet) / _countPoints) * 100, 2);
                            var message = string.Format("Точка № {0}. Обнаружена аномалия по {1}: {2} ({3}%)", _countPoints,
                                    typeString, setSituations, probability);
                            //_evMessage(message);

                            _context.SaveChanges();

                            _context.DiagnosticTestRecords.Add(new DiagnosticTestRecord
                            {
                                DiagnosticTestId = point.DiagnosticTestId,
                                PointNumber = _countPoints,
                                Description = message,
                                AnomalyInfoId = anomaly.Id
                            });
                            _context.SaveChanges();

                        }
                    }

                }
            }
        }

        private bool AnalysAnomaly(AnomalyInfo anomaly)
        {//список самых вероятных исходов
            using (var _context = new DissertationDbContext())
            {
                if (anomaly.TypeSituation == TypeSituation.ПоЭнтропии)
                {//
                    var stateEntropy = _context.StatisticsByEntropys.SingleOrDefault(r => r.NumberSituation == anomaly.AnomalySituation &&
                                                r.SeriesDiscriptionId == anomaly.SeriesDiscriptionId);
                    if (stateEntropy == null)
                    {
                        //if (_evMessage != null)
                        //{
                        //    _evMessage("Точка №" + _countPoints + ". Анализ частоты встречи аномалии по энтропии. Неизвестное состояние №" +
                        //        anomaly.AnomalySituation);
                            return false;
                        //}
                    }
                    if ((((double)stateEntropy.CountMeet) / _countPoints) * 100 > 5)
                    {
                        //if (_evMessage != null)
                        //{
                        //    _evMessage("Точка №" + _countPoints + ". Аномалия " + anomaly.AnomalyName +
                        //        " встречается очень часто, значит это не аномалия.");
                            return true;
                       // }
                    }
                }
                if (anomaly.TypeSituation == TypeSituation.ПоНечеткости)
                {//
                    var stateFuzzy = _context.StatisticsByFuzzys.SingleOrDefault(r => r.NumberSituation == anomaly.AnomalySituation &&
                                                r.SeriesDiscriptionId == anomaly.SeriesDiscriptionId);
                    if (stateFuzzy == null)
                    {
                        //if (_evMessage != null)
                        //{
                        //    _evMessage("Точка №" + _countPoints + ". Анализ частоты встречи аномалии по нечеткости. Неизвестное состояние №" +
                        //        anomaly.AnomalySituation);
                            return false;
                       // }
                    }
                    if ((((double)stateFuzzy.CountMeet) / _countPoints) * 100 > 5)
                    {
                       // if (_evMessage != null)
                       // {
                       //     _evMessage("Точка №" + _countPoints + ". Аномалия " + anomaly.AnomalyName +
                       //         " встречается очень часто, значит это не аномалия.");
                            return true;
                        //}
                    }
                }

                return false;
            }
        }
    }
}
