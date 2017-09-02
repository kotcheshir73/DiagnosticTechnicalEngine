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
					var trend = trends.FirstOrDefault(t => t.Weight == labTo.FuzzyLabelWeight - labFrom.FuzzyLabelWeight);
					if (trend != null)
					{
						rules.Add(new RuleTrendViewModel
						{
							SeriesDiscriptionId = seriesId,
							FuzzyTrendId = trend.Id,
							FuzzyTrendName = trend.TrendName,
							FuzzyTrendWeight = trend.Weight,
							FuzzyLabelFromId = labFrom.Id,
							FuzzyLabelFromName = labFrom.FuzzyLabelName,
							FuzzyLabelToId = labTo.Id,
							FuzzyLabelToName = labTo.FuzzyLabelName
						});
					}
					else
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
			}

			return rules;
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
						var rule = _context.RuleTrends.SingleOrDefault(r => r.FuzzyLabelFromId == _points[_points.Count - 1].FuzzyLabelId && r.FuzzyLabelToId == point.FuzzyLabelId);
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
				catch (Exception)
				{
					throw;
				}
			}
		}
	}
}
