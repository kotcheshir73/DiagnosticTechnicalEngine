using DatabaseModule;
using ServicesModule.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServicesModule
{
    public class BLClassGranuleEntropy
	{
		private string _error;

		public string Error { get { return _error; } }

		public IEnumerable<GranuleEntropyViewModel> GetListGranuleEntropy(int parentId)
		{
			try
			{
				using (var _context = new DissertationDbContext())
				{
					return _context.GranuleEntropys.Where(rec => rec.DiagnosticTestId == parentId).ToList().Select(rec => ModelConvector.ToGranuleEntropy(rec));
				}
			}
			catch (Exception ex)
			{
				_error = ex.Message;
				return null;
			}
		}

		public GranuleEntropyViewModel GetElemGranuleEntropy(int id)
		{
			try
			{
				using (var _context = new DissertationDbContext())
				{
					return ModelConvector.ToGranuleEntropy(_context.GranuleEntropys.SingleOrDefault(rec => rec.Id == id));
				}
			}
			catch (Exception ex)
			{
				_error = ex.Message;
				return null;
			}
		}

		public bool DelGranuleEntropyFromSeries(int seriesId)
		{
			using (var _context = new DissertationDbContext())
			{
				_context.GranuleEntropys.RemoveRange(_context.GranuleEntropys.Where(rec => rec.DiagnosticTestId == seriesId));
				_context.SaveChanges();
				return true;
			}
		}
	}
}
