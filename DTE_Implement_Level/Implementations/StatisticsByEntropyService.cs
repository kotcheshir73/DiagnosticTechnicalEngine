using DTE_Interface_Level.BindingModels;
using DTE_Interface_Level.Interfaces;
using DTE_Interface_Level.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DTE_Implement_Level.Implementations
{
    public class StatisticsByEntropyService : ISeriesDescriptionModel<StatisticsByEntropyViewModel, StatisticsByEntropyBindingModel>
	{
		public IEnumerable<StatisticsByEntropyViewModel> GetElements(int parentId)
		{
			using (var _context = new DissertationDbContext())
			{
				return _context.StatisticsByEntropys
									.Where(sbe => sbe.SeriesDiscriptionId == parentId)
									.ToList()
									.Select(sbe => ModelConvector.ToStatisticsByEntropy(sbe));
			}
		}

		public StatisticsByEntropyViewModel GetElement(int id)
		{
			using (var _context = new DissertationDbContext())
			{
				return ModelConvector.ToStatisticsByEntropy(_context.StatisticsByEntropys.SingleOrDefault(sbe => sbe.Id == id));
			}
		}

		public void InsertElement(StatisticsByEntropyBindingModel model)
		{
			throw new NotImplementedException();
		}

		public void UpdateElement(StatisticsByEntropyBindingModel model)
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