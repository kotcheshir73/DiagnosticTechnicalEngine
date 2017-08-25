using DatabaseModule;
using ServicesModule.BindingModels;
using ServicesModule.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;

namespace ServicesModule
{
    public class PointTrendService
    {
        private string _error;

        private List<PointInfo> _points;

        private List<RuleTrendViewModel> _rules;

        private List<FuzzyLabelViewModel> _labels;

        public string Error { get { return _error; } }

        public IEnumerable<PointTrendViewModel> GetListPointTrend(int parentId)
        {
            try
            {
                using (var _context = new DissertationDbContext())
                {
                    return _context.PointTrends
                                .Where(pt => pt.SeriesDiscriptionId == parentId)
                                .ToList()
                                .OrderBy(pt => pt.StartPoint)
                                .Select(pt => ModelConvector.ToPointTrend(pt));
                }
            }
            catch (Exception ex)
            {
                _error = ex.Message;
                return null;
            }
        }

        public PointTrendViewModel GetElemPointTrend(int id)
        {
            try
            {
                using (var _context = new DissertationDbContext())
                {
                    return ModelConvector.ToPointTrend(_context.PointTrends.SingleOrDefault(pt => pt.Id == id));
                }
            }
            catch (Exception ex)
            {
                _error = ex.Message;
                return null;
            }
        }

        public bool AddPointTrend(PointTrendBindingModel model)
        {
            using (var _context = new DissertationDbContext())
            {
                try
                {
                    var list = _context.PointTrends.Where(pt => pt.SeriesDiscriptionId == model.SeriesId);
                    if (list.FirstOrDefault(pt => pt.StartPoint == model.StartPoint &&
                                                    pt.FinishPoint == model.FinishPoint) != null)
                    {
                        _error = "Уже есть Такое правило!";
                        return false;
                    }
                    _context.PointTrends.Add(ModelConvector.ToPointTrend(model));
                    _context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    _error = ex.Message;
                    return false;
                }
            }
        }

        public bool UpdPointTrend(PointTrendBindingModel model)
        {
            using (var _context = new DissertationDbContext())
            {
                try
                {
                    var list = _context.PointTrends.Where(pt => pt.SeriesDiscriptionId == model.SeriesId);
                    var elem = _context.PointTrends.SingleOrDefault(pt => pt.Id == model.Id);
                    if (list.FirstOrDefault(pt => pt.Id != model.Id &&
                                                    pt.StartPoint == model.StartPoint &&
                                                    pt.FinishPoint == model.FinishPoint) != null)
                    {
                        _error = "Уже есть такое правило!";
                        return false;
                    }
                    elem = ModelConvector.ToPointTrend(model, elem);

                    _context.Entry(elem).State = EntityState.Modified;
                    _context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    _error = ex.Message;
                    return false;
                }
            }
        }

        public bool DelPointTrend(int id)
        {
            using (var _context = new DissertationDbContext())
            {
                _context.PointTrends.Remove(_context.PointTrends.Single(pt => pt.Id == id));
                _context.SaveChanges();
                return true;
            }
        }

        public bool DelPointTrendFromSeries(int seriesId)
        {
            using (var _context = new DissertationDbContext())
            {
                _context.PointTrends.RemoveRange(_context.PointTrends.Where(pt => pt.SeriesDiscriptionId == seriesId));
                _context.SaveChanges();
                return true;
            }
        }

        public bool CalcPointsTrend(PointTrendCalcBindingModel model)
        {
            _points = new List<PointInfo>();
            var FuzzyLabel = new FuzzyLabelService();
            _labels = FuzzyLabel.GetListFuzzyLabel(model.SeriesDiscriptionId).ToList();
            if (_labels == null)
            {
                throw new Exception(string.Format("Не получили нечеткие метки: {0}", FuzzyLabel.Error));
            }
            if (_labels.Count == 0)
            {
                throw new Exception("Нет нечетких меток");
            }
            var rulesTrend = new RuleTrendsService();
            _rules = rulesTrend.GetListRuleTrend(model.SeriesDiscriptionId).ToList();
            if (_rules == null)
            {
                throw new Exception("Не удалось получить правила для тенденций: " + rulesTrend.Error);
            }
            if (_rules.Count() == 0)
            {
                throw new Exception("Нет правил для тенденций");
            }

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
            return flag;
        }
        /// <summary>
        /// Загрузка точек из файла и внесение статистики по каждой точке, через вызов метода AddNewPoint
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="elements"></param>
        /// <param name="seriesId"></param>
        /// <returns></returns>
        private bool LoadFromExcel(string fileName, List<TypeDataInFile> elements, int seriesId)
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

                    if (!AddNewPoint(point, seriesId))
                        return false;

                    excelcell = excelcell.get_Offset(1, 0);
                }
            }
            catch (Exception ex)
            {
                _error = ex.Message;
                return false;
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
        private bool LoadFromTxt(string fileName, List<TypeDataInFile> elements, int seriesId)
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

                    if (!AddNewPoint(point, seriesId))
                        throw new Exception(_error);

                    read = stream.ReadLine();
                }
            }
            catch (Exception ex)
            {
                _error = ex.Message;
                return false;
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
        private bool AddNewPoint(PointInfo point, int seriesId)
        {
            using (var _context = new DissertationDbContext())
            {
                try
                {
                    if (_points.Count > 0)
                    {//если уже есть точки, получить тенденцию
                        point = ModelCalculator.CalcFUX(point, seriesId);
                        var rule = _rules.SingleOrDefault(r => r.FuzzyLabelFromId == _points[_points.Count - 1].FuzzyLabelId && r.FuzzyLabelToId == point.FuzzyLabelId);
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
                            var pointTrend = _context.PointTrends.FirstOrDefault(p => p.StartPoint == beforePoint && p.FinishPoint == nextPoint);
                            if (pointTrend == null)
                            {
                                pointTrend = new PointTrend
                                {
                                    StartPoint = beforePoint,
                                    FinishPoint = nextPoint,
                                    Count = 1,
                                    Weight = 0,
                                    SeriesDiscriptionId = seriesId
                                };
                                _context.PointTrends.Add(pointTrend);
                            }
                            else
                            {
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
                catch (Exception ex)
                {
                    _error = "AddNewPoint: " + ex.Message;
                    return false;
                }
            }
        }
    }
}
