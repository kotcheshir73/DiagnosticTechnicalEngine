﻿using DatabaseModule;
using DatabaseModule.Models;
using ServicesModule.BindingModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServicesModule
{
    public class APIService
    {
        private int countCenters = 7;

        private List<PointInfo> _points;

        public bool InitSeries(SeriesDescriptionBindingModel model, List<APIData> list)
        {
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
                    NeedForecast = true
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

        private bool CreateFuzzyLabel(List<APIData> list, int seriesId)
        {
            try
            {
                int _countClasters = countCenters;
                while (true)
                {
                    var clust = new ModelClustering("", 1, _countClasters, list);
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
                        }, series.Id);
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
        private void AddNewPoint(PointInfo point, int seriesId)
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
    }
}
