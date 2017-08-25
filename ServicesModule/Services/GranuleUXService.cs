using DatabaseModule;
using ServicesModule.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServicesModule
{
    public class GranuleUXService
    {
		private string _error;

		public string Error { get { return _error; } }

		public IEnumerable<GranuleUXViewModel> GetListGranuleUX(int parentId)
		{
			try
			{
				using (var _context = new DissertationDbContext())
				{
					return _context.GranuleUXs
                                        .Where(gux => gux.DiagnosticTestId == parentId)
                                        .ToList()
                                        .Select(gux => ModelConvector.ToGranuleUX(gux));
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
					return ModelConvector.ToGranuleUX(_context.GranuleUXs.SingleOrDefault(gux => gux.Id == id));
				}
			}
			catch (Exception ex)
			{
				_error = ex.Message;
				return null;
			}
		}
	}
}
