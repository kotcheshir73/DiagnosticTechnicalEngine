using DTE_Interface_Level.BindingModels;
using DTE_Interface_Level.Interfaces;
using DTE_Interface_Level.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DTE_Implement_Level.Implementations
{
    public class StatisticsByFuzzyService : ISeriesDescriptionModel<StatisticsByFuzzyViewModel, StatisticsByFuzzyBindingModel>
	{
		public IEnumerable<StatisticsByFuzzyViewModel> GetElements(int parentId)
		{
			using (var _context = new DissertationDbContext())
			{
				return _context.StatisticsByFuzzys
							.Include(sbf => sbf.EndStateFuzzyLabel)
							.Include(sbf => sbf.EndStateFuzzyTrend)
							.Include(sbf => sbf.StartStateFuzzyLabel)
							.Include(sbf => sbf.StartStateFuzzyTrend)
							.Where(sbf => sbf.SeriesDiscriptionId == parentId)
							.ToList()
							.Select(sbf => ModelConvector.ToStatisticsByFuzzy(sbf));
			}
		}

		public StatisticsByFuzzyViewModel GetElement(int id)
		{
			using (var _context = new DissertationDbContext())
			{
				return ModelConvector.ToStatisticsByFuzzy(_context.StatisticsByFuzzys
							.Include(sbf => sbf.EndStateFuzzyLabel)
							.Include(sbf => sbf.EndStateFuzzyTrend)
							.Include(sbf => sbf.StartStateFuzzyLabel)
							.Include(sbf => sbf.StartStateFuzzyTrend)
							.SingleOrDefault(sbf => sbf.Id == id));
			}
		}

		public void InsertElement(StatisticsByFuzzyBindingModel model)
		{
			throw new NotImplementedException();
		}

		public void UpdateElement(StatisticsByFuzzyBindingModel model)
		{
			throw new NotImplementedException();
		}

		public void DeleteElement(int id)
		{
			throw new NotImplementedException();
		}

		public void DeleteElements(int seriesId)
		{
			throw new NotImplementedException();
		}
	}
}