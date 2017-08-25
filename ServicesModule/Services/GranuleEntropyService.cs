using DatabaseModule;
using ServicesModule.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServicesModule
{
    public class GranuleEntropyService
    {
		private string _error;

		public string Error { get { return _error; } }

		public IEnumerable<GranuleEntropyViewModel> GetListGranuleEntropy(int parentId)
		{
			try
			{
				using (var _context = new DissertationDbContext())
				{
					return _context.GranuleEntropys
                                        .Where(ge => ge.DiagnosticTestId == parentId)
                                        .ToList()
                                        .Select(ge => ModelConvector.ToGranuleEntropy(ge));
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
					return ModelConvector.ToGranuleEntropy(_context.GranuleEntropys.SingleOrDefault(ge => ge.Id == id));
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
