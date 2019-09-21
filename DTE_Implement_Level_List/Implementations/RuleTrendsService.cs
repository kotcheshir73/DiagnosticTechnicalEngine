using DTE_Interface_Level.BindingModels;
using DTE_Interface_Level.Interfaces;
using DTE_Interface_Level.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DTE_Implement_Level_List.Implementations
{
    public class RuleTrendsService : ISeriesDescriptionModel<RuleTrendViewModel, RuleTrendBindingModel>
	{
		public IEnumerable<RuleTrendViewModel> GetElements(int parentId)
        {
            var _context = DissertationDbList.getInstance();
            {
				return _context.RuleTrends
							//.Include(rt => rt.FuzzyTrend)
							//.Include(rt => rt.FuzzyLabelFrom)
							//.Include(rt => rt.FuzzyLabelTo)
							.Where(rt => rt.SeriesDiscriptionId == parentId)
							.ToList()
							.Select(rt => ModelConvector.ToRuleTrend(rt));
			}
		}

		public RuleTrendViewModel GetElement(int id)
        {
            var _context = DissertationDbList.getInstance();
            {
				return ModelConvector.ToRuleTrend(_context.RuleTrends
							//.Include(rt => rt.FuzzyTrend)
							//.Include(rt => rt.FuzzyLabelFrom)
							//.Include(rt => rt.FuzzyLabelTo)
							.SingleOrDefault(rt => rt.Id == id));
			}
		}

		public void InsertElement(RuleTrendBindingModel model)
        {
            var _context = DissertationDbList.getInstance();
            {
				var list = _context.RuleTrends.Where(rt => rt.SeriesDiscriptionId == model.SeriesId);
				if (list.FirstOrDefault(rt => rt.FuzzyLabelFromId == model.FuzzyLabelFromId &&
												rt.FuzzyLabelToId == model.FuzzyLabelToId) != null)
				{
					throw new Exception("Уже есть такое правило!");
				}
				if (!model.FuzzyTrendId.HasValue || model.FuzzyTrendId.Value == 0)
				{
					model.FuzzyTrendId = _context.FuzzyTrends.FirstOrDefault(t => t.TrendName == model.FuzzyTrendName).Id;
				}
				_context.RuleTrends.Add(ModelConvector.ToRuleTrend(model));
			}
		}

		public void UpdateElement(RuleTrendBindingModel model)
        {
            var _context = DissertationDbList.getInstance();
            {
				var list = _context.RuleTrends.Where(rt => rt.SeriesDiscriptionId == model.SeriesId);
				var elem = _context.RuleTrends.SingleOrDefault(rt => rt.Id == model.Id);
				if (list.FirstOrDefault(rt => rt.Id != model.Id &&
												rt.FuzzyLabelFromId == model.FuzzyLabelFromId &&
												rt.FuzzyLabelToId == model.FuzzyLabelToId) != null)
				{
					throw new Exception("Уже есть такое правило!");
				}
				elem = ModelConvector.ToRuleTrend(model, elem);
			}
		}

		public void DeleteElement(int id)
        {
            var _context = DissertationDbList.getInstance();
            {
				_context.RuleTrends.Remove(_context.RuleTrends.Single(rt => rt.Id == id));
			}
		}

		public void DeleteElements(int seriesId)
        {
            var _context = DissertationDbList.getInstance();
            {
				_context.RuleTrends.RemoveAll(rt => rt.SeriesDiscriptionId == seriesId);
			}
		}
	}
}