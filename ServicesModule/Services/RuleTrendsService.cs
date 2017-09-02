using DatabaseModule;
using ServicesModule.BindingModels;
using ServicesModule.Interfaces;
using ServicesModule.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ServicesModule
{
	public class RuleTrendsService : ISeriesDescriptionModel<RuleTrendViewModel, RuleTrendBindingModel>
	{
		public IEnumerable<RuleTrendViewModel> GetElements(int parentId)
		{
			using (var _context = new DissertationDbContext())
			{
				return _context.RuleTrends
							.Include(rt => rt.FuzzyTrend)
							.Include(rt => rt.FuzzyLabelFrom)
							.Include(rt => rt.FuzzyLabelTo)
							.Where(rt => rt.SeriesDiscriptionId == parentId)
							.ToList()
							.Select(rt => ModelConvector.ToRuleTrend(rt));
			}
		}

		public RuleTrendViewModel GetElement(int id)
		{
			using (var _context = new DissertationDbContext())
			{
				return ModelConvector.ToRuleTrend(_context.RuleTrends
							.Include(rt => rt.FuzzyTrend)
							.Include(rt => rt.FuzzyLabelFrom)
							.Include(rt => rt.FuzzyLabelTo)
							.SingleOrDefault(rt => rt.Id == id));
			}
		}

		public void InsertElement(RuleTrendBindingModel model)
		{
			using (var _context = new DissertationDbContext())
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
				_context.SaveChanges();
			}
		}

		public void UpdateElement(RuleTrendBindingModel model)
		{
			using (var _context = new DissertationDbContext())
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

				_context.Entry(elem).State = EntityState.Modified;
				_context.SaveChanges();
			}
		}

		public void DeleteElement(int id)
		{
			using (var _context = new DissertationDbContext())
			{
				_context.RuleTrends.Remove(_context.RuleTrends.Single(rt => rt.Id == id));
				_context.SaveChanges();
			}
		}

		public void DeleteElements(int seriesId)
		{
			using (var _context = new DissertationDbContext())
			{
				_context.RuleTrends.RemoveRange(_context.RuleTrends.Where(rt => rt.SeriesDiscriptionId == seriesId));
				_context.SaveChanges();
			}
		}
	}
}
