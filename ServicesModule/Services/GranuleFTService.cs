using DatabaseModule;
using ServicesModule.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServicesModule
{
    public class GranuleFTService
    {
		private string _error;

		public string Error { get { return _error; } }

		public IEnumerable<GranuleFTViewModel> GetListGranuleFT(int parentId)
		{
			try
			{
				using (var _context = new DissertationDbContext())
				{
					return _context.GranuleFTs
                                        .Where(gft => gft.DiagnosticTestId == parentId)
                                        .ToList()
                                        .Select(gft => ModelConvector.ToGranuleFT(gft));
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
					return ModelConvector.ToGranuleFT(_context.GranuleFTs.SingleOrDefault(gft => gft.Id == id));
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
