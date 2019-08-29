using DTE_Interface_Level.BindingModels;
using DTE_Interface_Level.Interfaces;
using DTE_Interface_Level.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DTE_Implement_Level.Implementations
{
    public class FuzzyTrendService : ISeriesDescriptionModel<FuzzyTrendViewModel, FuzzyTrendBindingModel>
	{
		public IEnumerable<FuzzyTrendViewModel> GetElements(int parentId)
		{
			using (var _context = new DissertationDbContext())
			{
				return _context.FuzzyTrends
							.Where(ft => ft.SeriesDiscriptionId == parentId)
							.ToList()
							.Select(ft => ModelConvector.ToFuzzyTrend(ft));
			}
		}

		public FuzzyTrendViewModel GetElement(int id)
		{
			using (var _context = new DissertationDbContext())
			{
				return ModelConvector.ToFuzzyTrend(_context.FuzzyTrends.SingleOrDefault(ft => ft.Id == id));
			}
		}

		public void InsertElement(FuzzyTrendBindingModel model)
		{
			using (var _context = new DissertationDbContext())
			{
				var list = _context.FuzzyTrends.Where(ft => ft.SeriesDiscriptionId == model.SeriesId);
				if (list.FirstOrDefault(ft => ft.TrendName == model.TrendName) != null)
				{
					throw new Exception("Уже есть нечеткая тенденция с таким названием!");
				}
				_context.FuzzyTrends.Add(ModelConvector.ToFuzzyTrend(model));
				_context.SaveChanges();
			}
		}

		public void UpdateElement(FuzzyTrendBindingModel model)
		{
			using (var _context = new DissertationDbContext())
			{
				var list = _context.FuzzyTrends.Where(ft => ft.SeriesDiscriptionId == model.SeriesId);
				var elem = _context.FuzzyTrends.SingleOrDefault(ft => ft.Id == model.Id);
				if (list.FirstOrDefault(ft => ft.TrendName == model.TrendName && ft.Id != model.Id) != null)
				{
					throw new Exception("Уже есть нечеткая тенденция с таким названием!");
				}
				elem = ModelConvector.ToFuzzyTrend(model, elem);

				_context.SaveChanges();
			}
		}

		public void DeleteElement(int id)
		{
			using (var _context = new DissertationDbContext())
			{
				_context.FuzzyTrends.Remove(_context.FuzzyTrends.SingleOrDefault(ft => ft.Id == id));
				_context.SaveChanges();
			}
		}

		public void DeleteElements(int seriesId)
		{
			using (var _context = new DissertationDbContext())
			{
				_context.FuzzyTrends.RemoveRange(_context.FuzzyTrends.Where(ft => ft.SeriesDiscriptionId == seriesId));
				_context.SaveChanges();
			}
		}
	}
}