using DatabaseModule;
using ServicesModule.BindingModels;
using ServicesModule.ViewModels;
using System;

namespace ServicesModule
{
    public static class ModelConvector
	{
		#region SeriesDescription
		public static SeriesDescriptionViewModel ToSeriesDescription(SeriesDescription elem)
		{
			return new SeriesDescriptionViewModel
			{
				Id = elem.Id,
				SeriesName = elem.SeriesName,
				SeriesDiscription = elem.SeriesDiscription,
				NeedForecast = elem.NeedForecast
			};
		}

		public static SeriesDescription ToSeriesDescription(SeriesDescriptionBindingModel model, SeriesDescription elem = null)
		{
			if (elem == null)
			{
				elem = new SeriesDescription();
			}
			elem.SeriesName = model.SeriesName;
			elem.SeriesDiscription = model.SeriesDiscription;
			elem.NeedForecast = model.NeedForecast;
			return elem;
		}


		public static FuzzyLabelViewModel ToFuzzyLabel(FuzzyLabel elem)
		{
			return new FuzzyLabelViewModel
			{
				Id = elem.Id,
				SeriesDiscriptionId = elem.SeriesDiscriptionId,
				FuzzyLabelType = elem.FuzzyLabelType.ToString(),
				FuzzyLabelName = elem.FuzzyLabelName,
				FuzzyLabelWeight = elem.FuzzyLabelWeight,
				FuzzyLabelMinVal = elem.FuzzyLabelMinVal,
				FuzzyLabelCenter = elem.FuzzyLabelCenter,
				FuzzyLabelMaxVal = elem.FuzzyLabelMaxVal,
			};
		}

		public static FuzzyLabel ToFuzzyLabel(FuzzyLabelBindingModel model, FuzzyLabel elem = null)
		{
			if (elem == null)
			{
				elem = new FuzzyLabel();
			}
			elem.SeriesDiscriptionId = model.SeriesId;
			elem.FuzzyLabelName = model.FuzzyLabelName;
			elem.FuzzyLabelType = model.FuzzyLabelType;
			elem.FuzzyLabelWeight = model.Weigth;
			elem.FuzzyLabelMinVal = model.MinVal;
			elem.FuzzyLabelCenter = model.Center;
			elem.FuzzyLabelMaxVal = model.MaxVal;
			return elem;
		}


		public static FuzzyTrendViewModel ToFuzzyTrend(FuzzyTrend elem)
		{
			return new FuzzyTrendViewModel
			{
				Id = elem.Id,
				SeriesDiscriptionId = elem.SeriesDiscriptionId,
				TrendName = elem.TrendName.ToString(),
				Weight = elem.Weight
			};
		}

		public static FuzzyTrend ToFuzzyTrend(FuzzyTrendBindingModel model, FuzzyTrend elem = null)
		{
			if (elem == null)
			{
				elem = new FuzzyTrend();
			}
			elem.SeriesDiscriptionId = model.SeriesId;
			elem.TrendName = model.TrendName;
			elem.Weight = model.Weight;
			return elem;
		}


		public static PointTrendViewModel ToPointTrend(PointTrend elem)
		{
			return new PointTrendViewModel
			{
				Id = elem.Id,
				SeriesDiscriptionId = elem.SeriesDiscriptionId,
				StartPoint = elem.StartPoint,
				FinishPoint = elem.FinishPoint,
				Count = elem.Count,
				Weight = elem.Weight,
                Trends = elem.Trends
			};
		}

		public static PointTrend ToPointTrend(PointTrendBindingModel model, PointTrend elem = null)
		{
			if (elem == null)
			{
				elem = new PointTrend();
			}
			elem.SeriesDiscriptionId = model.SeriesId;
			elem.StartPoint = model.StartPoint;
			elem.FinishPoint = model.FinishPoint;
			elem.Count = model.Count;
			elem.Weight = model.Weight;
			return elem;
		}


		public static RuleTrendViewModel ToRuleTrend(RuleTrend elem)
		{
			return new RuleTrendViewModel
			{
				Id = elem.Id,
				SeriesDiscriptionId = elem.SeriesDiscriptionId,
				FuzzyTrendId = elem.FuzzyTrendId,
				FuzzyTrendName = elem.FuzzyTrend.TrendName.ToString(),
				FuzzyTrendWeight = elem.FuzzyTrend.Weight,
				FuzzyLabelFromId = elem.FuzzyLabelFromId,
				FuzzyLabelFromName = elem.FuzzyLabelFrom.FuzzyLabelName,
				FuzzyLabelToId = elem.FuzzyLabelToId,
				FuzzyLabelToName = elem.FuzzyLabelTo.FuzzyLabelName,
			};
		}

		public static RuleTrend ToRuleTrend(RuleTrendBindingModel model, RuleTrend elem = null)
		{
			if (elem == null)
			{
				elem = new RuleTrend();
			}
			elem.SeriesDiscriptionId = model.SeriesId;
			elem.FuzzyTrendId = model.FuzzyTrendId.Value;
			elem.FuzzyLabelFromId = model.FuzzyLabelFromId;
			elem.FuzzyLabelToId = model.FuzzyLabelToId;
			return elem;
		}

		public static StatisticsByEntropyViewModel ToStatisticsByEntropy(StatisticsByEntropy elem)
		{
			return new StatisticsByEntropyViewModel
			{
				Id = elem.Id,
				SeriesDiscriptionId = elem.SeriesDiscriptionId,
				NumberSituation = elem.NumberSituation,
				Description = elem.Description,
				StartStateLingvistUX = elem.StartStateLingvistUX,
				StartStateLingvistFT = elem.StartStateLingvistFT,
				EndStateLingvistUX = elem.EndStateLingvistUX,
				EndStateLingvistFT = elem.EndStateLingvistFT,
				CountMeet = elem.CountMeet
			};
		}

		public static StatisticsByEntropy ToStatisticsByEntropy(StatisticsByEntropyBindingModel model, StatisticsByEntropy elem = null)
		{
			if (elem == null)
			{
				elem = new StatisticsByEntropy();
			}
			elem.SeriesDiscriptionId = model.SeriesDiscriptionId;
			elem.NumberSituation = model.NumberSituation;
			elem.Description = model.Description;
			elem.StartStateLingvistUX = (LingvistUX)Enum.Parse(typeof(LingvistUX), model.StartStateLingvistUX);
			elem.StartStateLingvistFT = (LingvistFT)Enum.Parse(typeof(LingvistFT), model.StartStateLingvistFT);
			elem.EndStateLingvistUX = (LingvistUX)Enum.Parse(typeof(LingvistUX), model.EndStateLingvistUX);
			elem.EndStateLingvistFT = (LingvistFT)Enum.Parse(typeof(LingvistFT), model.EndStateLingvistFT);
			return elem;
		}


		public static StatisticsByFuzzyViewModel ToStatisticsByFuzzy(StatisticsByFuzzy elem)
		{
			return new StatisticsByFuzzyViewModel
			{
				Id = elem.Id,
				SeriesDiscriptionId = elem.SeriesDiscriptionId,
				NumberSituation = elem.NumberSituation,
				Description = elem.Description,
				StartStateFuzzyLabelId = elem.StartStateFuzzyLabelId,
				StartStateFuzzyTrendId = elem.StartStateFuzzyTrendId,
				EndStateFuzzyLabelId = elem.EndStateFuzzyLabelId,
				EndStateFuzzyTrendId = elem.EndStateFuzzyTrendId,
				CountMeet = elem.CountMeet
			};
		}

		public static StatisticsByFuzzy ToStatisticsByFuzzy(StatisticsByFuzzyBindingModel model, StatisticsByFuzzy elem = null)
		{
			if (elem == null)
			{
				elem = new StatisticsByFuzzy();
			}
			elem.SeriesDiscriptionId = model.SeriesDiscriptionId;
			elem.NumberSituation = model.NumberSituation;
			elem.Description = model.Description;
			elem.StartStateFuzzyLabelId = model.StartStateFuzzyLabelId;
			elem.StartStateFuzzyTrendId = model.StartStateFuzzyTrendId;
			elem.EndStateFuzzyLabelId = model.EndStateFuzzyLabelId;
			elem.EndStateFuzzyTrendId = model.EndStateFuzzyTrendId;
			return elem;
		}


		public static AnomalyInfoViewModel ToAnomalyInfo(AnomalyInfo elem)
		{
			return new AnomalyInfoViewModel
			{
				Id = elem.Id,
				SeriesDiscriptionId = elem.SeriesDiscriptionId,
				TypeSituation = elem.TypeSituation,
				AnomalyName = elem.AnomalyName,
				AnomalySituation = elem.AnomalySituation,
				SetSituations = elem.SetSituations,
				TypeMemoryValue = elem.TypeMemoryValue,
				SetValues = elem.SetValues,
				Description = elem.Description,
				CountMeet = elem.CountMeet,
				NotAnomaly = elem.NotAnomaly,
				NotDetected = elem.NotDetected,
				Rashifrovka = elem.Rashfrovka
			};
		}

		public static AnomalyInfo ToAnomalyInfo(AnomalyInfoBindingModel model, AnomalyInfo elem = null)
		{
			if (elem == null)
			{
				elem = new AnomalyInfo();
			}
			elem.SeriesDiscriptionId = model.SeriesDiscriptionId;
			elem.AnomalyName = model.AnomalyName;
			elem.Description = model.Description;
			elem.AnomalySituation = model.AnomalySituation;
			elem.SetSituations = model.SetSituations;
			elem.SetValues = model.SetValues;
			elem.TypeMemoryValue = Converter.ToTypeMemoryValue(model.TypeMemoryValue);
			elem.TypeSituation = Converter.ToTypeSituation(model.TypeSituation);
			elem.NotAnomaly = model.NotAnomaly;
			elem.NotDetected = model.NotDetected;
			elem.CountMeet = model.CountMeet;
			return elem;
		}
		#endregion

		public static DiagnosticTestViewModel ToDiagnosticTest(DiagnosticTest elem)
		{
			return new DiagnosticTestViewModel
			{
				Id = elem.Id,
                TestNumber = elem.TestNumber,
				SeriesDiscriptionId = elem.SeriesDiscriptionId,
				DateTest = elem.DateTest,
				FileName = elem.FileName,
				Count = elem.Count
			};
		}

		public static DiagnosticTest ToDiagnosticTest(DiagnosticTestBindingModel model, DiagnosticTest elem = null)
		{
			if (elem == null)
			{
				elem = new DiagnosticTest();
			}
            elem.TestNumber = model.TestNumber;
			elem.SeriesDiscriptionId = model.SeriesDiscriptionId;
			elem.DateTest = model.DateTest;
			elem.FileName = model.FileName;
			elem.Count = model.Count;
			return elem;
		}

		public static DiagnosticTestRecordViewModel ToDiagnosticTestRecord(DiagnosticTestRecord elem)
		{
			return new DiagnosticTestRecordViewModel
			{
				Id = elem.Id,
				DiagnosticTestId = elem.DiagnosticTestId,
                AnomalyId = elem.AnomalyInfoId,
				Description = elem.Description,
				PointNumber = elem.PointNumber
			};
		}

		public static DiagnosticTestRecord ToDiagnosticTestRecord(DiagnosticTestRecordBindingModel model, DiagnosticTestRecord elem = null)
		{
			if (elem == null)
			{
				elem = new DiagnosticTestRecord();
			}
			elem.DiagnosticTestId = model.DiagnosticTestId;
			elem.Description = model.Description;
			elem.PointNumber = model.PointNumber;
			return elem;
		}



		public static GranuleUXViewModel ToGranuleUX(GranuleUX elem)
		{
			return new GranuleUXViewModel
			{
				Id = elem.Id,
				DiagnosticTestId = elem.DiagnosticTestId,
				GranulePosition = elem.GranulePosition,
				LingvistUX = elem.LingvistUX,
				Count = elem.Count
			};
		}

		public static GranuleUX ToGranuleUX(GranuleUXBindingModel model, GranuleUX elem = null)
		{
			if (elem == null)
			{
				elem = new GranuleUX();
			}
			elem.DiagnosticTestId = model.DiagnosticTestId;
			elem.GranulePosition = model.GranulePosition;
			elem.LingvistUX = Converter.ToLingvistUX(model.LingvistUX);
			elem.Count = model.Count;
			return elem;
		}


		public static GranuleFTViewModel ToGranuleFT(GranuleFT elem)
		{
			return new GranuleFTViewModel
			{
				Id = elem.Id,
				DiagnosticTestId = elem.DiagnosticTestId,
				GranulePosition = elem.GranulePosition,
				LingvistFT = elem.LingvistFT,
				Count = elem.Count
			};
		}

		public static GranuleFT ToGranuleFT(GranuleFTBindingModel model, GranuleFT elem = null)
		{
			if (elem == null)
			{
				elem = new GranuleFT();
			}
			elem.DiagnosticTestId = model.DiagnosticTestId;
			elem.GranulePosition = model.GranulePosition;
			elem.LingvistFT = Converter.ToLingvistFT(model.LingvistFT);
			elem.Count = model.Count;
			return elem;
		}


		public static GranuleEntropyViewModel ToGranuleEntropy(GranuleEntropy elem)
		{
			return new GranuleEntropyViewModel
			{
				Id = elem.Id,
				DiagnosticTestId = elem.DiagnosticTestId,
				GranulePosition = elem.GranulePosition,
				LingvistUX = elem.LingvistUX,
				LingvistFT = elem.LingvistFT,
				Count = elem.Count
			};
		}

		public static GranuleEntropy ToGranuleEntropy(GranuleEntropyBindingModel model, GranuleEntropy elem = null)
		{
			if (elem == null)
			{
				elem = new GranuleEntropy();
			}
			elem.DiagnosticTestId = model.DiagnosticTestId;
			elem.GranulePosition = model.GranulePosition;
			elem.LingvistUX = Converter.ToLingvistUX(model.LingvistUX);
			elem.LingvistFT = Converter.ToLingvistFT(model.LingvistFT);
			elem.Count = model.Count;
			return elem;
		}


		public static GranuleFuzzyViewModel ToGranuleFuzzy(GranuleFuzzy elem)
		{
			return new GranuleFuzzyViewModel
			{
				Id = elem.Id,
				DiagnosticTestId = elem.DiagnosticTestId,
				GranulePosition = elem.GranulePosition,
				FuzzyLabelName = elem.FuzzyLabel.FuzzyLabelName,
				FuzzyTrendName = elem.FuzzyTrend.TrendName.ToString(),
				Count = elem.Count
			};
		}

		public static GranuleFuzzy ToGranuleFuzzy(GranuleFuzzyBindingModel model, GranuleFuzzy elem = null)
		{
			if (elem == null)
			{
				elem = new GranuleFuzzy();
			}
			elem.DiagnosticTestId = model.DiagnosticTestId;
			elem.GranulePosition = model.GranulePosition;
			elem.FuzzyLabelId = model.FuzzyLabelId;
			elem.FuzzyTrendId = model.FuzzyTrendId;
			elem.Count = model.Count;
			return elem;
		}
	}
}
