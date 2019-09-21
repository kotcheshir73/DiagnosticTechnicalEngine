using DTE_Interface_Level.BindingModels;
using DTE_Interface_Level.Interfaces;
using DTE_Interface_Level.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DTE_Implement_Level_List.Implementations
{
    public class FuzzyTrendService : ISeriesDescriptionModel<FuzzyTrendViewModel, FuzzyTrendBindingModel>
	{
		public IEnumerable<FuzzyTrendViewModel> GetElements(int parentId)
        {
            var _context = DissertationDbList.getInstance();
            {
				return _context.FuzzyTrends
							.Where(ft => ft.SeriesDiscriptionId == parentId)
							.ToList()
							.Select(ft => ModelConvector.ToFuzzyTrend(ft));
			}
		}

		public FuzzyTrendViewModel GetElement(int id)
        {
            var _context = DissertationDbList.getInstance();
            {
				return ModelConvector.ToFuzzyTrend(_context.FuzzyTrends.SingleOrDefault(ft => ft.Id == id));
			}
		}

		public void InsertElement(FuzzyTrendBindingModel model)
        {
            var _context = DissertationDbList.getInstance();
            {
				var list = _context.FuzzyTrends.Where(ft => ft.SeriesDiscriptionId == model.SeriesId);
				if (list.FirstOrDefault(ft => ft.TrendName == model.TrendName) != null)
				{
					throw new Exception("Уже есть нечеткая тенденция с таким названием!");
				}
				_context.FuzzyTrends.Add(ModelConvector.ToFuzzyTrend(model));
			}
		}

		public void UpdateElement(FuzzyTrendBindingModel model)
        {
            var _context = DissertationDbList.getInstance();
            {
				var list = _context.FuzzyTrends.Where(ft => ft.SeriesDiscriptionId == model.SeriesId);
				var elem = _context.FuzzyTrends.SingleOrDefault(ft => ft.Id == model.Id);
				if (list.FirstOrDefault(ft => ft.TrendName == model.TrendName && ft.Id != model.Id) != null)
				{
					throw new Exception("Уже есть нечеткая тенденция с таким названием!");
				}
				elem = ModelConvector.ToFuzzyTrend(model, elem);
			}
		}

		public void DeleteElement(int id)
        {
            var _context = DissertationDbList.getInstance();
            {
				_context.FuzzyTrends.Remove(_context.FuzzyTrends.SingleOrDefault(ft => ft.Id == id));
			}
		}

		public void DeleteElements(int seriesId)
        {
            var _context = DissertationDbList.getInstance();
            {
				_context.FuzzyTrends.RemoveAll(ft => ft.SeriesDiscriptionId == seriesId);
			}
		}
	}
}