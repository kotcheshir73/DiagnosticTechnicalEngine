using DatabaseModule;
using ServicesModule.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServicesModule
{
    public class BLClassGranuleUX
	{
		private string _error;

		public string Error { get { return _error; } }

		public IEnumerable<GranuleUXViewModel> GetListGranuleUX(int parentId)
		{
			try
			{
				using (var _context = new DissertationDbContext())
				{
					return _context.GranuleUXs.Where(rec => rec.DiagnosticTestId == parentId).ToList().Select(rec => ModelConvector.ToGranuleUX(rec));
				}
			}
			catch (Exception ex)
			{
				_error = ex.Message;
				return null;
			}
		}

		public GranuleUXViewModel GetElemGranuleUX(int id)
		{
			try
			{
				using (var _context = new DissertationDbContext())
				{
					return ModelConvector.ToGranuleUX(_context.GranuleUXs.SingleOrDefault(rec => rec.Id == id));
				}
			}
			catch (Exception ex)
			{
				_error = ex.Message;
				return null;
			}
		}

		public bool DelGranuleUXFromSeries(int seriesId)
		{
			using (var _context = new DissertationDbContext())
			{
				_context.GranuleUXs.RemoveRange(_context.GranuleUXs.Where(rec => rec.DiagnosticTestId == seriesId));
				_context.SaveChanges();
				return true;
			}
		}
	}
}
