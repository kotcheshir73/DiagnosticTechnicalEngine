using DatabaseModule;
using ServicesModule.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServicesModule
{
    public class BLClassGranuleFT
	{
		private string _error;

		public string Error { get { return _error; } }

		public IEnumerable<GranuleFTViewModel> GetListGranuleFT(int parentId)
		{
			try
			{
				using (var _context = new DissertationDbContext())
				{
					return _context.GranuleFTs.Where(rec => rec.DiagnosticTestId == parentId).ToList().Select(rec => ModelConvector.ToGranuleFT(rec));
				}
			}
			catch (Exception ex)
			{
				_error = ex.Message;
				return null;
			}
		}

		public GranuleFTViewModel GetElemGranuleFT(int id)
		{
			try
			{
				using (var _context = new DissertationDbContext())
				{
					return ModelConvector.ToGranuleFT(_context.GranuleFTs.SingleOrDefault(rec => rec.Id == id));
				}
			}
			catch (Exception ex)
			{
				_error = ex.Message;
				return null;
			}
		}

		public bool DelGranuleFTFromSeries(int seriesId)
		{
			using (var _context = new DissertationDbContext())
			{
				_context.GranuleFTs.RemoveRange(_context.GranuleFTs.Where(rec => rec.DiagnosticTestId == seriesId));
				_context.SaveChanges();
				return true;
			}
		}
	}
}
