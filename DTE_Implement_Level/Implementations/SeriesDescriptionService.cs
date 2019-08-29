using DTE_Interface_Level.BindingModels;
using DTE_Interface_Level.Interfaces;
using DTE_Interface_Level.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DTE_Implement_Level.Implementations
{
    public class SeriesDescriptionService : ISeriesDescriptionModel<SeriesDescriptionViewModel, SeriesDescriptionBindingModel>
	{
		public IEnumerable<SeriesDescriptionViewModel> GetElements(int parentId)
		{
			using (var _context = new DissertationDbContext())
			{
				return _context.SeriesDescriptions
									.ToList()
									.Select(sd => ModelConvector.ToSeriesDescription(sd));
			}
		}

		public SeriesDescriptionViewModel GetElement(int id)
		{
			using (var _context = new DissertationDbContext())
			{
				return ModelConvector.ToSeriesDescription(_context.SeriesDescriptions.SingleOrDefault(sd => sd.Id == id));
			}
		}

		public void InsertElement(SeriesDescriptionBindingModel model)
		{
			using (var _context = new DissertationDbContext())
			{
				var list = _context.SeriesDescriptions;
				if (list.SingleOrDefault(sd => sd.SeriesName == model.SeriesName) != null)
				{
					throw new Exception("Уже есть ряд с таким именем!");
				}
				_context.SeriesDescriptions.Add(ModelConvector.ToSeriesDescription(model));
				_context.SaveChanges();
			}
		}

		public void UpdateElement(SeriesDescriptionBindingModel model)
		{
			using (var _context = new DissertationDbContext())
			{
				var list = _context.SeriesDescriptions;
				var elem = _context.SeriesDescriptions.SingleOrDefault(sd => sd.Id == model.Id);
				if (list.SingleOrDefault(sd => sd.SeriesName == model.SeriesName && sd.Id != model.Id) != null)
				{
					throw new Exception("Уже есть ряд с таким именем!");
				}
				elem = ModelConvector.ToSeriesDescription(model, elem);

				_context.SaveChanges();
			}
		}

		public void DeleteElement(int id)
		{
			using (var _context = new DissertationDbContext())
			{
				_context.SeriesDescriptions.Remove(_context.SeriesDescriptions.SingleOrDefault(sd => sd.Id == id));
				_context.SaveChanges();
			}
		}

		public void DeleteElements(int seriesId)
		{
			throw new NotImplementedException();
		}
	}
}