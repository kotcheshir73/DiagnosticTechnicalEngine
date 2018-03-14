using DatabaseModule;
using DatabaseModule.BaseClassies;
using ServicesModule.BindingModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;

namespace ServicesModule
{
	public class ModelDiagnosticTest
	{
		private event Action<string> _evMessage;

		private event Action<string> _evMessageCountPoints;

		private List<PointInfo> _points;

		private List<KeyValuePair<AnomalyInfo, int>> _anomalyDetected;

		private int _countPoints;

		private int _countPointsForMemmory;

		private List<GranuleFuzzy> _granuleFuzzy;

		private List<GranuleEntropy> _granuleEntropy;

		private List<GranuleFT> _granuleFT;

		private List<GranuleUX> _granuleUX;

		public void MakeDiagnosticTest(DiagnosticTestBindingModel model)
		{
			using (var _context = new DissertationDbContext())
			{
				if (_context.DiagnosticTests.FirstOrDefault(dt => dt.TestNumber == model.TestNumber && dt.SeriesDiscriptionId == model.SeriesDiscriptionId) != null)
				{
					throw new Exception("Уже есть диагностический тест с таким номером!");
				}

				var elem = _context.SeriesDescriptions.SingleOrDefault(sd => sd.Id == model.SeriesDiscriptionId);
				if (elem == null)
				{
					throw new Exception("Не удалось получить информацию по ряду");
				}

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

				_points = new List<PointInfo>();
				_anomalyDetected = new List<KeyValuePair<AnomalyInfo, int>>();

				switch (model.TypeFile)
				{
					case TypeFile.Excel:
						LoadFromExcel(model.FileName, model.DatasInFile, test);
						break;
					case TypeFile.Текстовый:
						LoadFromTxt(model.FileName, model.DatasInFile, test);
						break;
				}
				SaveGranules();
				using (var transaction = _context.Database.BeginTransaction())
				{
					test.Count = _countPoints;
					var lastPoint = _points[_points.Count - 1];
					lastPoint.IsLast = true;
                    FillPoint(lastPoint);
					_context.PointInfos.Add(lastPoint);
					_context.SaveChanges();
					var preLastPoint = _points[_points.Count - 2];
                    FillPoint(preLastPoint);
                    _context.PointInfos.Add(preLastPoint);
					_context.SaveChanges();
					transaction.Commit();
				}
				_evMessage?.Invoke("Обработка завершена. Добавлено новых точек: " + _countPoints);
			}
		}
		/// <summary>
		/// Загрузка точек из файла и внесение статистики по каждой точке, через вызов метода AddNewPoint
		/// </summary>
		/// <param name="fileName"></param>
		/// <param name="elements"></param>
		/// <param name="seriesId"></param>
		/// <returns></returns>
		private void LoadFromExcel(string fileName, List<TypeDataInFile> elements, DiagnosticTest diagnosticTest)
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
					PointInfo point = new PointInfo
					{
						SeriesDiscriptionId = diagnosticTest.SeriesDiscriptionId,
						DiagnosticTest = diagnosticTest,
						DiagnosticTestId = diagnosticTest.Id
					};
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
						throw new Exception("LoadFromExcel: Недостаточно данных для расчетов, нужна или нечеткая метка или числовое значение");
					}
					AddNewPoint(point);

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
		}
		/// <summary>
		/// Загрузка точек из файла и внесение статистики по каждой точке, через вызов метода AddNewPoint
		/// </summary>
		/// <param name="fileName"></param>
		/// <param name="elements"></param>
		/// <param name="seriesId"></param>
		/// <returns></returns>
		private void LoadFromTxt(string fileName, List<TypeDataInFile> elements, DiagnosticTest diagnosticTest)
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
						throw new Exception("LoadFromTxt: Не совпадают данные из файла и ожидаемые");
					}
					PointInfo point = new PointInfo
					{
						SeriesDiscriptionId = diagnosticTest.SeriesDiscriptionId,
						DiagnosticTest = diagnosticTest,
						DiagnosticTestId = diagnosticTest.Id
					};
					for (int i = 0; i < elements.Count; ++i)
					{
						switch (elements[i])
						{
							case TypeDataInFile.ЧисловоеЗначение:
								double val = 0;
								if (double.TryParse(read.Replace('.', ','), out val))
								{
									point.Value = val;
								}
								else if (double.TryParse(read.Replace(',', '.'), out val))
								{
									point.Value = val;
								}
								else
								{
									point.Value = Convert.ToDouble(elems[i]);
								}
								break;
							case TypeDataInFile.Дата:
								point.Date = DateTime.FromOADate(Convert.ToDouble(elems[i]));
								break;
						}
					}
					if (!point.Value.HasValue)
					{
						throw new Exception("LoadFromTxt: Недостаточно данных для расчетов, нужна или нечеткая метка или числовое значение");
					}
					AddNewPoint(point);

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
		/// <summary>
		/// Обработка новой точки
		/// </summary>
		/// <param name="point"></param>
		/// <returns></returns>
		private void AddNewPoint(PointInfo point)
		{
			using (var _context = new DissertationDbContext())
			{
				// увеличиваем общее количество обработанных точек
				_countPoints++;

				if (!point.Fux.HasValue)
				{//вычисляем функцию принадлежности и меру энтропии по функции принадлежности
					point = ModelCalculator.CalcFUX(point);
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

					if (_points.Count > 3)
					{
						point.EntropyFT = ModelCalculator.CalcEntropyByFT(_points[_points.Count - 1].FuzzyTrend.TrendName,
																			_points[_points.Count - 2].FuzzyTrend.TrendName,
																			_points[_points.Count - 3].FuzzyTrend.TrendName,
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
						// определения возможного наступления аномалии
						AnomalyDetected(point);
						// поиск новых аномалий
						CheckNewState(point);
					}
				}
				if (_points.Count == _countPointsForMemmory)
				{//Храним не более _countPointsForMemmory точек
					_points.RemoveAt(0);
				}
				_points.Add(point);//занести точку

				_evMessageCountPoints?.Invoke(_countPoints.ToString());

				Granules(point);
			}
		}
		#region Granules
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
						_context.SaveChanges();
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
						_context.SaveChanges();
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
						_context.SaveChanges();
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
							FuzzyLabelId = gr.FuzzyLabelId,
							FuzzyTrend = gr.FuzzyTrend,
							FuzzyTrendId = gr.FuzzyTrendId,
							Count = gr.Count
						});
						_context.SaveChanges();
					}
				}
				transaction.Commit();
			}
		}

		private void GranulesFT(PointInfo point)
		{
			// для анализа делаем гранулы по мере энтропии по нечеткой тенденции
			if (_granuleFT != null && _points.Count > 5)
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
			if (_granuleUX != null && _points.Count > 0)
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
			if (_granuleEntropy != null && _points.Count > 5)
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
			if (_granuleFuzzy != null && _points.Count > 1)
			{
				// если еще нет записей в гранулах, создаем первую
				if (_granuleFuzzy.Count == 0)
				{
					_granuleFuzzy.Add(new GranuleFuzzy
					{
						Count = 1,
						DiagnosticTestId = point.DiagnosticTestId,
						GranulePosition = 0,
						FuzzyLabelId = point.FuzzyLabelId.Value,
						FuzzyTrendId = point.FuzzyTrendId.Value
					});
				}
				// иначе 
				else
				{
					// если энтропии совпадают, то просто увеличиваем кол-во
					if (_granuleFuzzy[_granuleFuzzy.Count - 1].FuzzyLabelId == point.FuzzyLabelId &&
						_granuleFuzzy[_granuleFuzzy.Count - 1].FuzzyTrendId == point.FuzzyTrendId)
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
							FuzzyLabelId = point.FuzzyLabelId.Value,
							FuzzyTrendId = point.FuzzyTrendId.Value
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

								_evMessage(message);

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
						_evMessage?.Invoke("Точка №" + _countPoints + ". Зафиксирована аномалия по энтропии, но имеется менее 5 точек для ее идентифкации: " + setSituations);
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
							_evMessage(message);

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
						if (_evMessage != null)
						{
							_evMessage("Точка №" + _countPoints + ". Анализ частоты встречи аномалии по энтропии. Неизвестное состояние №" +
								anomaly.AnomalySituation);
							return false;
						}
					}
					if ((((double)stateEntropy.CountMeet) / _countPoints) * 100 > 5)
					{
						if (_evMessage != null)
						{
							_evMessage("Точка №" + _countPoints + ". Аномалия " + anomaly.AnomalyName +
								" встречается очень часто, значит это не аномалия.");
							return true;
						}
					}
				}
				if (anomaly.TypeSituation == TypeSituation.ПоНечеткости)
				{//
					var stateFuzzy = _context.StatisticsByFuzzys.SingleOrDefault(r => r.NumberSituation == anomaly.AnomalySituation &&
												r.SeriesDiscriptionId == anomaly.SeriesDiscriptionId);
					if (stateFuzzy == null)
					{
						if (_evMessage != null)
						{
							_evMessage("Точка №" + _countPoints + ". Анализ частоты встречи аномалии по нечеткости. Неизвестное состояние №" +
								anomaly.AnomalySituation);
							return false;
						}
					}
					if ((((double)stateFuzzy.CountMeet) / _countPoints) * 100 > 5)
					{
						if (_evMessage != null)
						{
							_evMessage("Точка №" + _countPoints + ". Аномалия " + anomaly.AnomalyName +
								" встречается очень часто, значит это не аномалия.");
							return true;
						}
					}
				}

				return false;
			}
		}

		public double GetForecast(int id)
		{
			using (var _context = new DissertationDbContext())
			{   // 0 - находиим диагностический тест
				var diagTest = _context.DiagnosticTests
				.Include(dt => dt.SeriesDescription)
				.SingleOrDefault(dt => dt.Id == id);
				// 0- проверяем, что для этого ряда возможно вычислить прогноз
				var canMakeForecast = diagTest.SeriesDescription.NeedForecast;
				if (!canMakeForecast)
				{
					throw new Exception("Для этого ряда не заложено прогнозирование следующего значения");
				}
				// результат - прогнозное значение
				double result = 0;
				var LastPoint = _context.PointInfos.FirstOrDefault(pi => pi.DiagnosticTestId == diagTest.Id && pi.IsLast);
				var PreLastPoint = _context.PointInfos.FirstOrDefault(pi => pi.DiagnosticTestId == diagTest.Id && !pi.IsLast);
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
						int newPointPhasePlane = ModelCalculator.CalcPointFromFFT(LastPoint.FuzzyTrend.TrendName, PreLastPoint.FuzzyTrend.TrendName, tempStateEntropy);
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
				#endregion

				var stateFuzzy = listStatFuzzyOrdered[indexFuzzy];
				var fuzzyLabel = _context.FuzzyLabels
						.SingleOrDefault(r => r.Id == stateFuzzy.EndStateFuzzyLabelId && r.SeriesDiscriptionId == diagTest.SeriesDiscriptionId);
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

        private void FillPoint(PointInfo point)
        {
            point.FuzzyLabel = null;
            point.FuzzyTrend = null;
            point.DiagnosticTest = null;
            point.StatisticsByEntropy = null;
            point.StatisticsByFuzzy = null;
        }
	}
}
