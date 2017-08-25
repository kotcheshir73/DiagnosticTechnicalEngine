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
    public class BLClassDiagnosticTest
	{
		private string _error;

		private event Action<string> _evMessage;

		private event Action<string> _evMessageCountPoints;

		private List<PointInfo> _points;

		private List<KeyValuePair<AnomalyInfo, int>> _anomalyDetected;

		private int _countPoints;

		private int _countAddedPoints;

		private int _countPointsForMemmory;

		private List<GranuleFuzzy> _granuleFuzzy;

		private List<GranuleEntropy> _granuleEntropy;

		private List<GranuleFT> _granuleFT;

		private List<GranuleUX> _granuleUX;

		public string Error { get { return _error; } }

		public IEnumerable<DiagnosticTestViewModel> GetListDiagnosticTest(int parentId)
		{
			try
			{
				using (var _context = new DissertationDbContext())
				{
					return _context.DiagnosticTests.
					  Where(rec => rec.SeriesDiscriptionId == parentId).ToList().Select(rec => ModelConvector.ToDiagnosticTest(rec));
				}
			}
			catch (Exception ex)
			{
				_error = ex.Message;
				return null;
			}
		}

		public DiagnosticTestViewModel GetElemDiagnosticTest(int id)
		{
			try
			{
				using (var _context = new DissertationDbContext())
				{
					return ModelConvector.ToDiagnosticTest(_context.DiagnosticTests.SingleOrDefault(rec => rec.Id == id));
				}
			}
			catch (Exception ex)
			{
				_error = ex.Message;
				return null;
			}
		}

		public bool DelDiagnosticTest(int id)
		{
			using (var _context = new DissertationDbContext())
			{
				_context.DiagnosticTests.Remove(_context.DiagnosticTests.Single(rec => rec.Id == id));
				_context.SaveChanges();
				return true;
			}
		}

		public bool DelDiagnosticTestFromSeries(int seriesId)
		{
			using (var _context = new DissertationDbContext())
			{
				_context.DiagnosticTests.RemoveRange(_context.DiagnosticTests.Where(rec => rec.SeriesDiscriptionId == seriesId));
				_context.SaveChanges();
				return true;
			}
		}

		public bool MakeDiagnosticTest(DiagnosticTestBindingModel model)
		{
			using (var _context = new DissertationDbContext())
			using (var transaction = _context.Database.BeginTransaction())
			{
				var test = ModelConvector.ToDiagnosticTest(model);
				test.DateTest = DateTime.Now;
				test.Count = 0;
				_context.DiagnosticTests.Add(test);
				_context.SaveChanges();

				_evMessage += model.MessagerEvent;
				_evMessageCountPoints += model.MessageCountPoint;
				_countPointsForMemmory = model.CountPointsForMemmory;

				if (model.MakeGranuleUX.HasValue && model.MakeGranuleUX.Value)
				{
					_granuleUX = new List<GranuleUX>();
				}
				if (model.MakeGranuleFT.HasValue && model.MakeGranuleFT.Value)
				{
					_granuleFT = new List<GranuleFT>();
				}
				if (model.MakeGranuleEntropy.HasValue && model.MakeGranuleEntropy.Value)
				{
					_granuleEntropy = new List<GranuleEntropy>();
				}
				if (model.MakeGranuleFuzzy.HasValue && model.MakeGranuleFuzzy.Value)
				{
					_granuleFuzzy = new List<GranuleFuzzy>();
				}

				var elem = _context.SeriesDescriptions.SingleOrDefault(sd => sd.Id == model.SeriesDiscriptionId);
				if (elem == null)
				{
					_error = "Не удалось получить информацию по ряду";
					return false;
				}

				_points = new List<PointInfo>();
				_anomalyDetected = new List<KeyValuePair<AnomalyInfo, int>>();			

				bool flag = true;
				switch (model.TypeFile)
				{
					case TypeFile.Excel:
						flag = LoadFromExcel(model.FileName, model.DatasInFile, test);
						break;
					case TypeFile.Текстовый:
						flag = LoadFromTxt(model.FileName, model.DatasInFile, test);
						break;
				}
				SaveGranules();
				if (flag)
				{
					test.Count = _countPoints;
					_context.SaveChanges();
				}
				_evMessage?.Invoke("Обработка завершена. Всего точек: " + _countPoints + ". Добавлено новых: " + _countAddedPoints);
				return flag;
			}
		}
		/// <summary>
		/// Загрузка точек из файла и внесение статистики по каждой точке, через вызов метода AddNewPoint
		/// </summary>
		/// <param name="fileName"></param>
		/// <param name="elements"></param>
		/// <param name="seriesId"></param>
		/// <returns></returns>
		private bool LoadFromExcel(string fileName, List<TypeDataInFile> elements, DiagnosticTest diagnosticTest)
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
					point.DiagnosticTest = diagnosticTest;
					point.DiagnosticTestId = diagnosticTest.Id;
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

					if (!AddNewPoint(point))
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
		private bool LoadFromTxt(string fileName, List<TypeDataInFile> elements, DiagnosticTest diagnosticTest)
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
					point.DiagnosticTest = diagnosticTest;
					point.DiagnosticTestId = diagnosticTest.Id;
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

					if (!AddNewPoint(point))
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
		/// <returns></returns>
		private bool AddNewPoint(PointInfo point)
		{
			using (var _context = new DissertationDbContext())
			{
				try
				{
					// увеличиваем общее количество обработанных точек
					_countPoints++;
					// увеличиваем количество обрабатывааемых точек при текущем вызове метода обработки ряда
					_countAddedPoints++;

					if (!point.Fux.HasValue)
					{//вычисляем функцию принадлежности и меру энтропии по функции принадлежности
						point = ModelCalculator.CalcFUX(point);
						if (point == null)
						{
							throw new Exception("Не удалось получить функцию принадлежности");
						}
						point.EntropuUX = ModelCalculator.CalcEntropyByUX(point.Fux.Value);
					}

					if (_points.Count > 0)
					{//если уже есть точки, получить тенденцию
						var rule = _context.RuleTrends.SingleOrDefault(r => r.FuzzyLabelFromId == _points[_points.Count - 1].FuzzyLabelId && r.FuzzyLabelToId == point.FuzzyLabelId &&
						r.SeriesDiscriptionId == point.DiagnosticTest.SeriesDiscriptionId);
						if (rule == null)
						{
							throw new Exception(string.Format("Нет правила для такого сочитания нечетких меток: {0} и {1}",
								  _points[_points.Count - 1].FuzzyLabel.FuzzyLabelName, point.FuzzyLabel.FuzzyLabelName));
						}
						point.FuzzyTrendId = rule.FuzzyTrendId;
						point.FuzzyTrend = _context.FuzzyTrends.Single(ft => ft.Id == rule.FuzzyTrendId);

						if (_points.Count > 3)
						{
							point.EntropyFT = ModelCalculator.CalcEntropyByFT(_points[_points.Count - 1].FuzzyTrend.TrendName, _points[_points.Count - 2].FuzzyTrend.TrendName,
								_points[_points.Count - 3].FuzzyTrend.TrendName, point.DiagnosticTest.SeriesDiscriptionId);
						}

						if (_points.Count > 1)
						{//получить состояния
							var stateFuzzy = GetStateFuzzy(point);
							if (stateFuzzy == null)
							{
								throw new Exception("Не определили номер ситуации по нечеткости: " + _error);
							}
							point.StatisticsByFuzzyId = stateFuzzy.Id;
							if (_points.Count > 4)
							{
								var stateEntropy = GetStateEntropy(point);
								if (stateEntropy == null)
								{
									throw new Exception("Не определили номер ситуации по энтропии: " + _error);
								}
								point.StatisticsByEntropyId = stateEntropy.Id;
							}
							// определения возможного наступления аномалии
							if (!AnomalyDetected(point))
							{
								throw new Exception(_error);
							}
							// поиск новых аномалий
							if (!CheckNewState(point))
							{
								throw new Exception(_error);
							}
						}
					}
					if (_points.Count == _countPointsForMemmory)
					{//Храним не более _countPointsForMemmory точек
						_points.RemoveAt(0);
					}
					_points.Add(point);//занести точку

					_evMessageCountPoints?.Invoke(_countAddedPoints.ToString());

					Granules(point);

					return true;
				}
				catch (Exception ex)
				{
					_error = "AddNewPoint: " + ex.Message;
					return false;
				}
			}
		}
		#region
		/// <summary>
		/// Определяем, нужно ли формировать гранулы по каким-то данным
		/// </summary>
		/// <param name="point"></param>
		/// <param name="seriesId"></param>
		private void Granules(PointInfo point)
		{
			if (_granuleUX != null)
			{
				GranulesUX(point);
			}
			if (_granuleFT != null)
			{
				GranulesFT(point);
			}
			if (_granuleEntropy != null)
			{
				GranulesEntropy(point);
			}
			if (_granuleFuzzy != null)
			{
				GranulesFuzzy(point);
			}
		}

		private void SaveGranules()
		{
			using (var _context = new DissertationDbContext())
			using (var transaction = _context.Database.BeginTransaction())
			{
				if (_granuleUX != null)
				{
					foreach (var gr in _granuleUX)
					{
						_context.GranuleUXs.Add(new GranuleUX
						{
							DiagnosticTestId = gr.DiagnosticTestId,
							GranulePosition = gr.GranulePosition,
							LingvistUX = gr.LingvistUX,
							Count = gr.Count
						});
					}
				}
				if (_granuleFT != null)
				{
					foreach (var gr in _granuleFT)
					{
						_context.GranuleFTs.Add(new GranuleFT
						{
							DiagnosticTestId = gr.DiagnosticTestId,
							GranulePosition = gr.GranulePosition,
							LingvistFT = gr.LingvistFT,
							Count = gr.Count
						});
					}
				}
				if (_granuleEntropy != null)
				{
					foreach (var gr in _granuleEntropy)
					{
						_context.GranuleEntropys.Add(new GranuleEntropy
						{
							DiagnosticTestId = gr.DiagnosticTestId,
							GranulePosition = gr.GranulePosition,
							LingvistUX = gr.LingvistUX,
							LingvistFT = gr.LingvistFT,
							Count = gr.Count
						});
					}
				}
				if (_granuleFuzzy != null)
				{
					foreach (var gr in _granuleFuzzy)
					{
						_context.GranuleFuzzys.Add(new GranuleFuzzy
						{
							DiagnosticTestId = gr.DiagnosticTestId,
							GranulePosition = gr.GranulePosition,
							FuzzyLabel = gr.FuzzyLabel,
							FuzzyTrend = gr.FuzzyTrend,
							Count = gr.Count
						});
					}
				}
				transaction.Commit();
			}
		}

		private void GranulesFT(PointInfo point)
		{
			// для анализа делаем гранулы по мере энтропии по нечеткой тенденции
			if (_granuleFT != null)
			{
				// если еще нет записей в гранулах, создаем первую
				if (_granuleFT.Count == 0)
				{
					_granuleFT.Add(new GranuleFT
					{
						Count = 1,
						DiagnosticTestId = point.DiagnosticTestId,
						GranulePosition = 0,
						LingvistFT = Converter.ToLingvistFT(point.EntropyFT)
					});
				}
				// иначе 
				else
				{
					var entropy = Converter.ToLingvistFT(point.EntropyFT);
					// если энтропии совпадают, то просто увеличиваем кол-во
					if (_granuleFT[_granuleFT.Count - 1].LingvistFT == entropy)
					{
						_granuleFT[_granuleFT.Count - 1].Count++;
					}
					// иначе, новый элемент в гранулированном ряду
					else
					{
						_granuleFT.Add(new GranuleFT
						{
							Count = 1,
							DiagnosticTestId = point.DiagnosticTestId,
							GranulePosition = _granuleFT[_granuleFT.Count - 1].GranulePosition + 1,
							LingvistFT = Converter.ToLingvistFT(point.EntropyFT)
						});
					}
				}
			}
		}

		private void GranulesUX(PointInfo point)
		{
			// для анализа делаем гранулы по мере энтропии по функции принадлежности
			if (_granuleUX != null)
			{
				// если еще нет записей в гранулах, создаем первую
				if (_granuleUX.Count == 0)
				{
					_granuleUX.Add(new GranuleUX
					{
						Count = 1,
						DiagnosticTestId = point.DiagnosticTestId,
						GranulePosition = 0,
						LingvistUX = Converter.ToLingvistUX(point.EntropuUX, point.PositionFUX)
					});
				}
				// иначе 
				else
				{
					var entropy = Converter.ToLingvistUX(point.EntropuUX, point.PositionFUX);
					// если энтропии совпадают, то просто увеличиваем кол-во
					if (_granuleUX[_granuleUX.Count - 1].LingvistUX == entropy)
					{
						_granuleUX[_granuleUX.Count - 1].Count++;
					}
					// иначе, новый элемент в гранулированном ряду
					else
					{
						_granuleUX.Add(new GranuleUX
						{
							Count = 1,
							DiagnosticTestId = point.DiagnosticTestId,
							GranulePosition = _granuleUX[_granuleUX.Count - 1].GranulePosition + 1,
							LingvistUX = Converter.ToLingvistUX(point.EntropuUX, point.PositionFUX)
						});
					}
				}
			}
		}

		private void GranulesEntropy(PointInfo point)
		{
			// для анализа делаем гранулы по мере энтропии по нечеткости
			if (_granuleEntropy != null)
			{
				// если еще нет записей в гранулах, создаем первую
				if (_granuleEntropy.Count == 0)
				{
					_granuleEntropy.Add(new GranuleEntropy
					{
						Count = 1,
						DiagnosticTestId = point.DiagnosticTestId,
						GranulePosition = 0,
						LingvistUX = Converter.ToLingvistUX(point.EntropuUX, point.PositionFUX),
						LingvistFT = Converter.ToLingvistFT(point.EntropyFT)
					});
				}
				// иначе 
				else
				{
					var entropyUX = Converter.ToLingvistUX(point.EntropuUX, point.PositionFUX);
					var entropyFT = Converter.ToLingvistFT(point.EntropyFT);
					// если энтропии совпадают, то просто увеличиваем кол-во
					if (_granuleEntropy[_granuleEntropy.Count - 1].LingvistUX == entropyUX &&
						_granuleEntropy[_granuleEntropy.Count - 1].LingvistFT == entropyFT)
					{
						_granuleEntropy[_granuleEntropy.Count - 1].Count++;
					}
					// иначе, новый элемент в гранулированном ряду
					else
					{
						_granuleEntropy.Add(new GranuleEntropy
						{
							Count = 1,
							DiagnosticTestId = point.DiagnosticTestId,
							GranulePosition = _granuleEntropy[_granuleEntropy.Count - 1].GranulePosition + 1,
							LingvistUX = Converter.ToLingvistUX(point.EntropuUX, point.PositionFUX),
							LingvistFT = Converter.ToLingvistFT(point.EntropyFT)
						});
					}
				}
			}
		}

		private void GranulesFuzzy(PointInfo point)
		{
			// для анализа делаем гранулы по мере энтропии по нечеткости
			if (_granuleFuzzy != null)
			{
				// если еще нет записей в гранулах, создаем первую
				if (_granuleFuzzy.Count == 0)
				{
					_granuleFuzzy.Add(new GranuleFuzzy
					{
						Count = 1,
						DiagnosticTestId = point.DiagnosticTestId,
						GranulePosition = 0,
						FuzzyLabel = point.FuzzyLabel.FuzzyLabelName,
						FuzzyTrend = point.FuzzyTrend.TrendName.ToString()
					});
				}
				// иначе 
				else
				{
					var fuzzyValue = point.FuzzyLabel.FuzzyLabelName;
					var fuzzyTrend = point.FuzzyTrend.TrendName.ToString();
					// если энтропии совпадают, то просто увеличиваем кол-во
					if (_granuleFuzzy[_granuleFuzzy.Count - 1].FuzzyLabel == fuzzyValue &&
						_granuleFuzzy[_granuleFuzzy.Count - 1].FuzzyTrend == fuzzyTrend)
					{
						_granuleFuzzy[_granuleFuzzy.Count - 1].Count++;
					}
					// иначе, новый элемент в гранулированном ряду
					else
					{
						_granuleFuzzy.Add(new GranuleFuzzy
						{
							Count = 1,
							DiagnosticTestId = point.DiagnosticTestId,
							GranulePosition = _granuleFuzzy[_granuleFuzzy.Count - 1].GranulePosition + 1,
							FuzzyLabel = fuzzyValue,
							FuzzyTrend = fuzzyTrend
						});
					}
				}
			}
		}
		#endregion

		/// <summary>
		/// Определение ситуации по энтропиям, увеличение статистики по этой ситуации
		/// </summary>
		/// <param name="point"></param>
		/// <returns></returns>
		private StatisticsByEntropy GetStateEntropy(PointInfo point)
		{
			using (var _context = new DissertationDbContext())
			{
				try
				{
					var stateEntropy = _context.StatisticsByEntropys.SingleOrDefault(r =>
						r.StartStateLingvistUX == Converter.ToLingvistUX(_points[_points.Count - 1].EntropuUX, _points[_points.Count - 1].PositionFUX) &&
						r.StartStateLingvistFT == Converter.ToLingvistFT(_points[_points.Count - 1].EntropyFT) &&
						r.EndStateLingvistUX == Converter.ToLingvistUX(point.EntropuUX, point.PositionFUX) &&
						r.EndStateLingvistFT == Converter.ToLingvistFT(point.EntropyFT));
					if (stateEntropy == null)
					{
						stateEntropy = new StatisticsByEntropy
						{
							DiagnosticTestId = point.DiagnosticTestId,
							StartStateLingvistUX = Converter.ToLingvistUX(_points[_points.Count - 1].EntropuUX, _points[_points.Count - 1].PositionFUX),
							StartStateLingvistFT = Converter.ToLingvistFT(_points[_points.Count - 1].EntropyFT),
							EndStateLingvistUX = Converter.ToLingvistUX(point.EntropuUX, point.PositionFUX),
							EndStateLingvistFT = Converter.ToLingvistFT(point.EntropyFT),
							NumberSituation = _context.StatisticsByEntropys.Where(sbe => sbe.DiagnosticTestId == point.DiagnosticTestId).Select(sbe => sbe.NumberSituation).Max() + 1,
							CountMeet = 1
						};
						_context.StatisticsByEntropys.Add(stateEntropy);
					}
					else
					{
						stateEntropy.CountMeet++;
						_context.SaveChanges();
					}
					return stateEntropy;
				}
				catch (Exception ex)
				{
					_error = "GetStateEntropy: " + ex.Message;
					return null;
				}
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
				try
				{
					var stateFuzzy = _context.StatisticsByFuzzys.SingleOrDefault(r =>
											r.StartStateFuzzyLabelId == _points[_points.Count - 1].FuzzyLabelId &&
											r.StartStateFuzzyTrendId == _points[_points.Count - 1].FuzzyTrendId &&
											r.EndStateFuzzyLabelId == point.FuzzyLabelId &&
											r.EndStateFuzzyTrendId == point.FuzzyTrendId);
					if (stateFuzzy == null)
					{
						stateFuzzy = new StatisticsByFuzzy
						{
							DiagnosticTestId = point.DiagnosticTestId,
							StartStateFuzzyLabelId = _points[_points.Count - 1].FuzzyLabelId.Value,
							StartStateFuzzyTrendId = _points[_points.Count - 1].FuzzyTrendId.Value,
							EndStateFuzzyLabelId = point.FuzzyLabelId.Value,
							EndStateFuzzyTrendId = point.FuzzyTrendId.Value,
							NumberSituation = _context.StatisticsByFuzzys.Where(sbf => sbf.DiagnosticTestId == point.DiagnosticTestId).Select(sbf => sbf.NumberSituation).Max() + 1,
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
				catch (Exception ex)
				{
					_error = "GetStateFuzzy: " + ex.Message;
					return null;
				}
			}
		}

		private bool AnomalyDetected(PointInfo point)
		{
			try
			{
				if (point.StatisticsByEntropy != null)
				{
					AnomalyDetectedByElem(point.StatisticsByEntropy, TypeSituation.ПоЭнтропии);
				}
				if (point.StatisticsByFuzzy != null)
				{
					AnomalyDetectedByElem(point.StatisticsByFuzzy, TypeSituation.ПоНечеткости);
				}
				return true;
			}
			catch (Exception ex)
			{
				_error = "AnomalyDetected: " + ex.Message;
				return false;
			}
		}

		private void AnomalyDetectedByElem(StatisticBy statistic, TypeSituation type)
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
								var anomaly = _context.AnomalyInfos.SingleOrDefault(a => a.Id == _anomalyDetected[i].Key.Id);
								anomaly.CountMeet++;

								_evMessage("Точка №" + _countAddedPoints + ". Возникла аномалия: " + _anomalyDetected[i].Key.AnomalyName + " (" +
													Math.Round((((double)statistic.CountMeet) / _countPoints) * 100, 2) + "%)");

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
				var listAnomaly = _context.AnomalyInfos.Where(ai => ai.TypeSituation == type).ToList();
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

		private bool CheckNewState(PointInfo point)
		{//список самых вероятных исходов
			_error = "";
			try
			{
				if (point.StatisticsByFuzzy != null)
				{
					CheckNewStateByElem(point.StatisticsByFuzzy, TypeSituation.ПоНечеткости, point);
				}

				if (point.StatisticsByEntropy != null)
				{
					CheckNewStateByElem(point.StatisticsByEntropy, TypeSituation.ПоЭнтропии, point);
				}
				return true;
			}
			catch (Exception ex)
			{
				_error = "CheckNewState: " + ex.Message;
				return false;
			}
		}

		private void CheckNewStateByElem(StatisticBy statistic, TypeSituation type, PointInfo point)
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
														_points[i].StatisticsByFuzzy as StatisticBy :
														_points[i].StatisticsByEntropy as StatisticBy;
						if (tempEntropy != null)
						{
							setSituations += tempEntropy.NumberSituation;
							if (i < _points.Count - 1)
							{
								setSituations += ",";
							}
							setValues += ((_points[i].Value.HasValue) ? _points[i].Value.Value : _points[i].Fux.Value) + ";";
							if (i > 0)
							{
								var temp2Entropy = type == TypeSituation.ПоНечеткости ?
														_points[i - 1].StatisticsByFuzzy as StatisticBy :
														_points[i - 1].StatisticsByEntropy as StatisticBy;
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
					setValues += ((point.Value.HasValue) ? point.Value.Value : point.Fux.Value);

					if (setSituations.Split(',').Length < 6)
					{
						_evMessage?.Invoke("Точка №" + _countAddedPoints + ". Зафиксирована новая аномалия по энтропии, но имеется менее 5 точек для ее идентифкации: " + setSituations);
					}
					else
					{//ищем среди аномалий аномалию с такой последовательностью
						var elem = _context.AnomalyInfos.SingleOrDefault(r => r.TypeSituation == type && r.SetSituations == setSituations);
						if (elem == null)
						{
							string typeString = (type == TypeSituation.ПоНечеткости ? "нечеткости" : "энтропии");
							string name = string.Format("Аномалия по {0}: {1} -> {2}", typeString, setSituations, statistic.NumberSituation);
							_context.AnomalyInfos.Add(new AnomalyInfo
							{
								DiagnosticTestId = point.DiagnosticTestId,
								AnomalyName = name,
								TypeSituation = type,
								TypeMemoryValue = typeMemory,
								AnomalySituation = statistic.NumberSituation,
								CountMeet = 1,
								NotAnomaly = false,
								NotDetected = notDetected,
								SetSituations = setSituations,
								SetValues = setValues
							});

							_evMessage("Точка №" + _countAddedPoints + ". Обнаружена новая аномалия по " + typeString + ": " + setSituations + " (" +
														Math.Round((((double)statistic.CountMeet) / _countPoints) * 100, 2) + "%)");
						}
					}

				}
			}
		}

		private bool AnalysAnomaly(AnomalyInfo anomaly)
		{//список самых вероятных исходов
			using (var _context = new DissertationDbContext())
			{
				try
				{
					if (anomaly.TypeSituation == TypeSituation.ПоЭнтропии)
					{//
						var stateEntropy = _context.StatisticsByEntropys.SingleOrDefault(r => r.NumberSituation == anomaly.AnomalySituation);
						if (stateEntropy == null)
						{
							if (_evMessage != null)
							{
								_evMessage("Точка №" + _countAddedPoints + ". Анализ частоты встречи аномалии по энтропии. Неизвестное состояние №" +
									anomaly.AnomalySituation);
								return false;
							}
						}
						if ((((double)stateEntropy.CountMeet) / _countPoints) * 100 > 5)
						{
							if (_evMessage != null)
							{
								_evMessage("Точка №" + _countAddedPoints + ". Аномалия " + anomaly.AnomalyName +
									" встречается очень часто, значит это не аномалия.");
								return true;
							}
						}
					}
					if (anomaly.TypeSituation == TypeSituation.ПоНечеткости)
					{//
						var stateFuzzy = _context.StatisticsByFuzzys.SingleOrDefault(r => r.NumberSituation == anomaly.AnomalySituation);
						if (stateFuzzy == null)
						{
							if (_evMessage != null)
							{
								_evMessage("Точка №" + _countAddedPoints + ". Анализ частоты встречи аномалии по нечеткости. Неизвестное состояние №" +
									anomaly.AnomalySituation);
								return false;
							}
						}
						if ((((double)stateFuzzy.CountMeet) / _countPoints) * 100 > 5)
						{
							if (_evMessage != null)
							{
								_evMessage("Точка №" + _countAddedPoints + ". Аномалия " + anomaly.AnomalyName +
									" встречается очень часто, значит это не аномалия.");
								return true;
							}
						}
					}

					return false;
				}
				catch (Exception ex)
				{
					_error = "AnalysAnomaly: " + ex.Message;
					return false;
				}
			}
		}

		public double GetForecast(int id)
		{
			using (var _context = new DissertationDbContext())
			{   // 0 - находиим диагностический тест
				var diagTest = _context.DiagnosticTests
				.Include(rec => rec.SeriesDescription)
				.Include(rec => rec.FirstPoint)
				.Include(rec => rec.SecondPoint)
				.SingleOrDefault(rec => rec.Id == id);
				// 0- проверяем, что для этого ряда возможно вычислить прогноз
				var canMakeForecast = diagTest.NeedForecast;
				if (!canMakeForecast)
				{
					throw new Exception("Для этого ряда не заложено прогнозирование следующего значения");
				}
				// результат - прогнозное значение
				double result = 0;
				// пока что - эот будет значение в последней точке
				result = diagTest.FirstPoint.Value.Value;
				// определяем ситуации по энтропии и по неопределенности
				var entropy = ModelConvector.ToStatisticsByEntropy(_context.StatisticsByEntropys.Single(rec => rec.Id == diagTest.FirstPoint.StatisticsByEntropyId));
				var fuzzy = ModelConvector.ToStatisticsByFuzzy(_context.StatisticsByFuzzys.Single(rec => rec.Id == diagTest.FirstPoint.StatisticsByFuzzyId));

				// 1 - отбираем ситуации из двух наборов
				var listStatEntropyOrdered = _context.StatisticsByEntropys.Where(r => r.StartState ==
						entropy.EndState).OrderByDescending(r => r.CountMeet).ToList();
				var listStatFuzzyOrdered = _context.StatisticsByFuzzys.Where(r => r.StartState ==
						fuzzy.EndState).OrderByDescending(r => r.CountMeet).ToList();

				int indexEntropy = -1;

				int indexFuzzy = -1;

				bool fuzzyLabelEqFuzzyTrend = false;

				bool fuzzyTrendEqEntropyTrend = false;

				#region ищем оптимальное сочетание
				while (!fuzzyLabelEqFuzzyTrend && !fuzzyTrendEqEntropyTrend)
				{
					StatisticsByFuzzy tempStateFuzzy = null;
					fuzzyLabelEqFuzzyTrend = false;
					// сбрасываем счетчик по энтропии
					indexEntropy = -1;
					// получаем ситуацию по нечеткости
					while (!fuzzyLabelEqFuzzyTrend && indexFuzzy < listStatFuzzyOrdered.Count)
					{
						indexFuzzy++;
						tempStateFuzzy = listStatFuzzyOrdered[indexFuzzy];
						// находим правило для нечеткой тенденции и нечетких меток
						var rule = _context.RuleTrends.SingleOrDefault(r =>
									r.FuzzyLabelFromId == tempStateFuzzy.StartStateFuzzyLabelId &&
									r.FuzzyLabelToId == tempStateFuzzy.EndStateFuzzyLabelId &&
									r.FuzzyTrendId == tempStateFuzzy.EndStateFuzzyTrendId);
						// убеждаемся, что есть такое правило 
						fuzzyLabelEqFuzzyTrend = rule != null;
					}
					// получаем ситуацию по энтропии (ищем с первой ситуации, пока не найдем нужную или не дойдем до конца), (если нашли ситуацию по нечеткости)
					while (!fuzzyTrendEqEntropyTrend && indexEntropy < listStatEntropyOrdered.Count && fuzzyLabelEqFuzzyTrend)
					{
						indexEntropy++;
						var tempStateEntropy = listStatEntropyOrdered[indexEntropy];

						// получаем тенденцию в прогнозной точки
						int newPointPhasePlane = ModelCalculator.CalcPointFromFFT(diagTest.FirstPoint.FuzzyTrend.TrendName, diagTest.SecondPoint.FuzzyTrend.TrendName, tempStateEntropy);
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
					}
					// если дошли до конца по нечеткости, но так и не получили сочетания, просто берем первые по выпадению
					if (indexFuzzy == listStatFuzzyOrdered.Count && !fuzzyLabelEqFuzzyTrend)
					{
						indexEntropy = 0;
						indexFuzzy = 0;
						break;
					}
				}
				#endregion

				var stateFuzzy = listStatFuzzyOrdered[indexFuzzy];
				var fuzzyLabel = (new BLClassFuzzyLabel()).GetListFuzzyLabel(diagTest.SeriesDiscriptionId)
						.SingleOrDefault(r => r.Id == stateFuzzy.EndStateFuzzyLabelId);
				var newEntropyPUX = listStatEntropyOrdered[indexEntropy].EndStateLingvistUX;

				if (listStatFuzzyOrdered[indexFuzzy].StartStateFuzzyTrendId == fuzzy.EndStateFuzzyTrendId)
				{// тенденция неизменна
					if (listStatEntropyOrdered[indexEntropy].EndStateLingvistUX == entropy.EndStateLingvistUX)
					// если значение меры энтропии по функции принадлежности в предыдущей точке 
					// равно значению меры энтропии в текущей, то берем значение в предыдущей в качестве прогнозного
					{
						var trendName = _context.FuzzyTrends.Single(rec => rec.Id == fuzzy.EndStateFuzzyTrendId).TrendName;
						switch (trendName)
						{
							case FuzzyTrendLabel.СтабильностьСредняя:
								return diagTest.FirstPoint.Value.Value;
							case FuzzyTrendLabel.РостСильный:
							case FuzzyTrendLabel.РостСлабый:
							case FuzzyTrendLabel.РостСредний:
							case FuzzyTrendLabel.ПадениеСильное:
							case FuzzyTrendLabel.ПадениеСлабое:
							case FuzzyTrendLabel.ПадениеСреднее:
								//получить прирост по последним точкам
								return diagTest.FirstPoint.Value.Value * 2 - diagTest.SecondPoint.Value.Value;
						}
						return diagTest.FirstPoint.Value.Value;
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
