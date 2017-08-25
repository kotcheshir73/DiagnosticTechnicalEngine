using DatabaseModule;
using ServicesModule.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServicesModule
{
    public class BLClassGranuleFuzzy
	{
		private string _error;

		public string Error { get { return _error; } }

		public IEnumerable<GranuleFuzzyViewModel> GetListGranuleFuzzy(int parentId)
		{
			try
			{
				using (var _context = new DissertationDbContext())
				{
					return _context.GranuleFuzzys.Where(rec => rec.DiagnosticTestId == parentId).ToList().Select(rec => ModelConvector.ToGranuleFuzzy(rec));
				}
			}
			catch (Exception ex)
			{
				_error = ex.Message;
				return null;
			}
		}

		public GranuleFuzzyViewModel GetElemGranuleFuzzy(int id)
		{
			try
			{
				using (var _context = new DissertationDbContext())
				{
					return ModelConvector.ToGranuleFuzzy(_context.GranuleFuzzys.SingleOrDefault(rec => rec.Id == id));
				}
			}
			catch (Exception ex)
			{
				_error = ex.Message;
				return null;
			}
		}

		public bool DelGranuleFuzzyFromSeries(int seriesId)
		{
			using (var _context = new DissertationDbContext())
			{
				_context.GranuleFuzzys.RemoveRange(_context.GranuleFuzzys.Where(rec => rec.DiagnosticTestId == seriesId));
				_context.SaveChanges();
				return true;
			}
		}
	}
}
