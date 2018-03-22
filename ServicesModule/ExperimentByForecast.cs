using DatabaseModule;
using DatabaseModule.Models;
using NLog;
using ServicesModule.BindingModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ServicesModule
{
    public class ExperimentByForecast
    {
        private int countCenters = 7;

        // private int countTasks = 5;

        private List<PointInfo> _points;

        private int _countPoints;

        private int _countPointsForMemmory = 5;

        private object loadTxtObj = new object();

        private object createFuzzyLabels = new object();

        private object createFuzzyTrends = new object();

        private object createRuleTrends = new object();

        private object createPointTrends = new object();

        private object genSituationsByEntropy = new object();

        private object genSituationsByFuzzy = new object();

        private object runForecast = new object();

        private ModelDiagnosticTest mdt;

        public void RunExperiment(string path)
        {
            mdt = new ModelDiagnosticTest();
            if (Directory.Exists(path))
            {
                var info = new DirectoryInfo(path);
                var files = info.GetFiles();
                // log.Info(string.Format("Начали тесты {0}", files.Length));
                List<Task> tasks = new List<Task>();
                foreach (var file in files)
                {
                    // tasks.Add(Task.Run(() => MakeTest(file)));
                    MakeTest(file);
                }
                //  Task.WaitAll(tasks.ToArray());
            }
        }

        private bool MakeTest(FileInfo file)
        {
            using (var _context = new DissertationDbContext())
            {
                try
                {
                    var entity = ModelConvector.ToSeriesDescription(new SeriesDescriptionBindingModel
                    {
                        SeriesName = file.Name,
                        NeedForecast = true
                    });
                    _context.SeriesDescriptions.Add(entity);
                    _context.SaveChanges();

                    #region Временной ряд
                    var res = CreateFuzzyLabel(file.FullName, entity.Id);
                    if (!res)
                    {
                        return false;
                    }
                    _context.LogDatas.Add(new LogData
                    {
                        DateLog = DateTime.Now,
                        MessageLogType = "Info",
                        MessageLogTitle = file.Name,
                        MessageLog = string.Format("{0} нечеткие метки получены", file.Name)
                    });

                    res = CreateFuzzyTrend(file.FullName, entity.Id);
                    if (!res)
                    {
                        return false;
                    }
                    _context.LogDatas.Add(new LogData
                    {
                        DateLog = DateTime.Now,
                        MessageLogType = "Info",
                        MessageLogTitle = file.Name,
                        MessageLog = string.Format("{0} нечеткие тенденции получены", file.Name)
                    });

                    res = CreateRuleTrend(file.FullName, entity.Id);
                    if (!res)
                    {
                        return false;
                    }
                    _context.LogDatas.Add(new LogData
                    {
                        DateLog = DateTime.Now,
                        MessageLogType = "Info",
                        MessageLogTitle = file.Name,
                        MessageLog = string.Format("{0} правила для тенденций получены", file.Name)
                    });

                    res = CreatePointTrend(file.FullName, entity.Id);
                    if (!res)
                    {
                        return false;
                    }
                    _context.LogDatas.Add(new LogData
                    {
                        DateLog = DateTime.Now,
                        MessageLogType = "Info",
                        MessageLogTitle = file.Name,
                        MessageLog = string.Format("{0} точки для тенденций получены", file.Name)
                    });

                    res = GenerateSituationsByEntropy(file.FullName, entity.Id);
                    if (!res)
                    {
                        return false;
                    }
                    _context.LogDatas.Add(new LogData
                    {
                        DateLog = DateTime.Now,
                        MessageLogType = "Info",
                        MessageLogTitle = file.Name,
                        MessageLog = string.Format("{0} ситуации по энтропии получены", file.Name)
                    });

                    res = GenerateSituationsByFuzzy(file.FullName, entity.Id);
                    if (!res)
                    {
                        return false;
                    }
                    _context.LogDatas.Add(new LogData
                    {
                        DateLog = DateTime.Now,
                        MessageLogType = "Info",
                        MessageLogTitle = file.Name,
                        MessageLog = string.Format("{0} ситуации по нечеткости получены", file.Name)
                    });
                    #endregion

                    lock (runForecast)
                    {
                        _countPoints = 0;
                        _points = new List<PointInfo>();
                        var test = ModelConvector.ToDiagnosticTest(new DiagnosticTestBindingModel
                        {
                            TestNumber = "1",
                            FileName = file.FullName,
                            TypeFile = TypeFile.Текстовый,
                            DatasInFile = new List<TypeDataInFile> { TypeDataInFile.ЧисловоеЗначение },
                            SeriesDiscriptionId = entity.Id,
                            CountPointsForMemmory = 5
                        });
                        test.DateTest = DateTime.Now;
                        test.Count = 0;
                        _context.DiagnosticTests.Add(test);
                        _context.SaveChanges();
                        _context.LogDatas.Add(new LogData
                        {
                            DateLog = DateTime.Now,
                            MessageLogType = "Info",
                            MessageLogTitle = file.Name,
                            MessageLog = string.Format("{0} создали тест", file.Name)
                        });

                        var values = LoadFromTxt(file.FullName);

                        if (values != null && values.Count > 1)
                        {
                            _context.LogDatas.Add(new LogData
                            {
                                DateLog = DateTime.Now,
                                MessageLogType = "Info",
                                MessageLogTitle = file.Name,
                                MessageLog = string.Format("{0} загрузили данные", file.Name)
                            });
                            for (int i = 0; i < values.Count - 1; ++i)
                            {
                                AddNewPoint(new PointInfo
                                {
                                    SeriesDiscriptionId = entity.Id,
                                    DiagnosticTestId = test.Id,
                                    Value = values[i]
                                }, entity.Id);
                            }
                            _context.LogDatas.Add(new LogData
                            {
                                DateLog = DateTime.Now,
                                MessageLogType = "Info",
                                MessageLogTitle = file.Name,
                                MessageLog = string.Format("{0} обработали данные", file.Name)
                            });
                            using (var transaction = _context.Database.BeginTransaction())
                            {
                                test.Count = _countPoints;
                                var lastPoint = _points[_points.Count - 1];
                                lastPoint.IsLast = true;
                                ClearPoint(lastPoint);
                                _context.PointInfos.Add(lastPoint);
                                _context.SaveChanges();
                                var preLastPoint = _points[_points.Count - 2];
                                ClearPoint(preLastPoint);
                                _context.PointInfos.Add(preLastPoint);
                                _context.SaveChanges();
                                transaction.Commit();
                            }
                            _context.LogDatas.Add(new LogData
                            {
                                DateLog = DateTime.Now,
                                MessageLogType = "Info",
                                MessageLogTitle = file.Name,
                                MessageLog = string.Format("{0} сохранили последние точки", file.Name)
                            });

                            var forecast = mdt.GetForecast(test.Id);
                            var forecasts = string.Join(";", mdt.GetForecastByPointTrend(test.Id));
                            _context.LogDatas.Add(new LogData
                            {
                                DateLog = DateTime.Now,
                                MessageLogType = "Info",
                                MessageLogTitle = file.Name,
                                MessageLog = string.Format("{0} получили прогноз", file.Name)
                            });
                            var realValue = values[values.Count - 1];
                            _context.ExperimentFileResults.Add(new ExperimentFileResult
                            {
                                DateExperiment = DateTime.Now,
                                Forecast = forecast,
                                ForecastsByPoint = forecasts,
                                RealValue = realValue,
                                FileName = file.Name
                            });
                            _context.SaveChanges();

                            _context.LogDatas.Add(new LogData
                            {
                                DateLog = DateTime.Now,
                                MessageLogType = "Info",
                                MessageLogTitle = file.Name,
                                MessageLog = string.Format("{0} сохранили прогноз", file.FullName)
                            });
                        }
                        else
                        {
                            _context.SaveChanges();
                            _context.LogDatas.Add(new LogData
                            {
                                DateLog = DateTime.Now,
                                MessageLogType = "Error",
                                MessageLogTitle = file.Name,
                                MessageLog = string.Format("{0} не получили точек", file.FullName)
                            });
                        }
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    _context.LogDatas.Add(new LogData
                    {
                        DateLog = DateTime.Now,
                        MessageLog = string.Format("MakeTest {0}: {1}", file.FullName, ex.Message),
                        MessageLogType = "Error"
                    });
                    return false;
                }
            }
        }

        private bool CreateFuzzyLabel(string fileName, int seriesId)
        {
            lock (createFuzzyLabels)
            {
                try
                {
                    int _countClasters = countCenters;
                    while (true)
                    {
                        var clust = new ModelClustering(fileName, 1, _countClasters);
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
                    throw new Exception(string.Format("CreateFuzzyLabel {0}: {1}", fileName, ex.Message));
                }
            }
        }

        private bool CreateFuzzyTrend(string fileName, int seriesId)
        {
            lock (createFuzzyTrends)
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
        }

        private bool CreateRuleTrend(string fileName, int seriesId)
        {
            lock (createRuleTrends)
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
        }

        private bool CreatePointTrend(string fileName, int seriesId)
        {
            lock (createPointTrends)
            {
                try
                {
                    return ModelGenerate.CalcPointsTrend(new PointTrendCalcBindingModel
                    {
                        FileName = fileName,
                        TypeFile = TypeFile.Текстовый,
                        DatasInFile = new List<TypeDataInFile> { TypeDataInFile.ЧисловоеЗначение },
                        SeriesDiscriptionId = seriesId
                    }); ;
                }
                catch (Exception ex)
                {
                    throw new Exception(string.Format("CreatePointTrend {0}: {1}", fileName, ex.Message));
                }
            }
        }

        private bool GenerateSituationsByEntropy(string fileName, int seriesId)
        {
            lock (genSituationsByEntropy)
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
        }

        private bool GenerateSituationsByFuzzy(string fileName, int seriesId)
        {
            lock (genSituationsByFuzzy)
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
        }

        /// <summary>
        /// Загрузка точек из файла
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private List<double> LoadFromTxt(string fileName)
        {
            List<double> values = new List<double>();
            lock (loadTxtObj)
            {
                StreamReader stream = null;
                try
                {
                    stream = new StreamReader(fileName);
                    string read = stream.ReadLine();
                    while (read != null)
                    {
                        read = read.Replace(" ", "");
                        if (double.TryParse(read.Replace('.', ','), out double val))
                        {
                            values.Add(val);
                        }
                        else if (double.TryParse(read.Replace(',', '.'), out val))
                        {
                            values.Add(val);
                        }
                        else
                        {
                            values.Add(Convert.ToDouble(read));
                        }

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
                    {
                        stream.Close();
                    }
                }
            }
            return values;
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
                // увеличиваем общее количество обработанных точек
                _countPoints++;

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
                if (_points.Count == _countPointsForMemmory)
                {//Храним не более _countPointsForMemmory точек
                    _points.RemoveAt(0);
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

        private void ClearPoint(PointInfo point)
        {
            point.FuzzyLabel = null;
            point.FuzzyTrend = null;
            point.DiagnosticTest = null;
            point.StatisticsByEntropy = null;
            point.StatisticsByFuzzy = null;
        }

        public List<ExperimentFileResult> Result(DateTime date)
        {
            using (var _context = new DissertationDbContext())
            {
                var dateStart = date.Date;
                var dateFinifh = date.Date.AddDays(1);
                return _context.ExperimentFileResults.Where(ex => ex.DateExperiment >= dateStart && ex.DateExperiment <= dateFinifh).ToList();
            }
        }
    }
}
