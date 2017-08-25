using DatabaseModule;
using ServicesModule.BindingModels;
using ServicesModule.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ServicesModule
{
    public class SeriesDescriptionService
    {
		private string _error;

		public string Error { get { return _error; } }

		public IEnumerable<SeriesDescriptionViewModel> GetListSeriesDescrip()
		{
			try
			{
				using (var _context = new DissertationDbContext())
				{
					return _context.SeriesDescriptions
                                        .ToList()
                                        .Select(sd => ModelConvector.ToSeriesDescription(sd));
				}
			}
			catch (Exception ex)
			{
				_error = ex.Message;
				return null;
			}
		}

		public SeriesDescriptionViewModel GetElemSeriesDescrip(int id)
		{
			try
			{
				using (var _context = new DissertationDbContext())
				{
					return ModelConvector.ToSeriesDescription(_context.SeriesDescriptions.SingleOrDefault(sd => sd.Id == id));
				}
			}
			catch (Exception ex)
			{
				_error = ex.Message;
				return null;
			}
		}

		public bool AddSeriesDescrip(SeriesDescriptionBindingModel model)
		{
			using (var _context = new DissertationDbContext())
			{
				try
				{
					var list = _context.SeriesDescriptions;
					if (list.SingleOrDefault(sd => sd.SeriesName == model.SeriesName) != null)
					{
						_error = "Уже есть ряд с таким именем!";
						return false;
					}
					_context.SeriesDescriptions.Add(ModelConvector.ToSeriesDescription(model));
					_context.SaveChanges();
					return true;
				}
				catch (Exception ex)
				{
					_error = ex.Message;
					return false;
				}
			}
		}

		public bool UpdSeriesDescrip(SeriesDescriptionBindingModel model)
		{
			using (var _context = new DissertationDbContext())
			{
				try
				{
					var list = _context.SeriesDescriptions;
					var elem = _context.SeriesDescriptions.SingleOrDefault(sd => sd.Id == model.Id);
					if (list.SingleOrDefault(sd => sd.SeriesName == model.SeriesName && sd.Id != model.Id) != null)
					{
						_error = "Уже есть ряд с таким именем!";
						return false;
					}
					elem = ModelConvector.ToSeriesDescription(model, elem);

					_context.Entry(elem).State = EntityState.Modified;
					_context.SaveChanges();
					return true;
				}
				catch (Exception ex)
				{
					_error = ex.Message;
					return false;
				}
			}
		}

		public bool DelSeriesDescrip(int id)
		{
			using (var _context = new DissertationDbContext())
			{
				_context.SeriesDescriptions.Remove(_context.SeriesDescriptions.SingleOrDefault(sd => sd.Id == id));
				_context.SaveChanges();
				return true;
			}
		}
	}
}
