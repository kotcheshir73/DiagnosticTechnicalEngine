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
	public class PointTrendService : ISeriesDescriptionModel<PointTrendViewModel, PointTrendBindingModel>
	{
		public IEnumerable<PointTrendViewModel> GetElements(int parentId)
		{
			using (var _context = new DissertationDbContext())
			{
				return _context.PointTrends
							.Where(pt => pt.SeriesDiscriptionId == parentId)
							.ToList()
							.OrderBy(pt => pt.StartPoint)
							.Select(pt => ModelConvector.ToPointTrend(pt));
			}
		}

		public PointTrendViewModel GetElement(int id)
		{
			using (var _context = new DissertationDbContext())
			{
				return ModelConvector.ToPointTrend(_context.PointTrends.SingleOrDefault(pt => pt.Id == id));
			}
		}

		public void InsertElement(PointTrendBindingModel model)
		{
			using (var _context = new DissertationDbContext())
			{
				var list = _context.PointTrends.Where(pt => pt.SeriesDiscriptionId == model.SeriesId);
				if (list.FirstOrDefault(pt => pt.StartPoint == model.StartPoint &&
												pt.FinishPoint == model.FinishPoint) != null)
				{
					throw new Exception("Уже есть Такое правило!");
				}
				_context.PointTrends.Add(ModelConvector.ToPointTrend(model));
				_context.SaveChanges();
			}
		}

		public void UpdateElement(PointTrendBindingModel model)
		{
			using (var _context = new DissertationDbContext())
			{
				var list = _context.PointTrends.Where(pt => pt.SeriesDiscriptionId == model.SeriesId);
				var elem = _context.PointTrends.SingleOrDefault(pt => pt.Id == model.Id);
				if (list.FirstOrDefault(pt => pt.Id != model.Id &&
												pt.StartPoint == model.StartPoint &&
												pt.FinishPoint == model.FinishPoint) != null)
				{
					throw new Exception("Уже есть такое правило!");
				}
				elem = ModelConvector.ToPointTrend(model, elem);

				_context.Entry(elem).State = EntityState.Modified;
				_context.SaveChanges();
			}
		}

		public void DeleteElement(int id)
		{
			using (var _context = new DissertationDbContext())
			{
				_context.PointTrends.Remove(_context.PointTrends.Single(pt => pt.Id == id));
				_context.SaveChanges();
			}
		}

		public void DeleteElements(int seriesId)
		{
			using (var _context = new DissertationDbContext())
			{
				_context.PointTrends.RemoveRange(_context.PointTrends.Where(pt => pt.SeriesDiscriptionId == seriesId));
				_context.SaveChanges();
			}
		}
	}
}
