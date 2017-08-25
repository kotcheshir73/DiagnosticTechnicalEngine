using DatabaseModule;
using ServicesModule.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ServicesModule
{
    public class GranuleFuzzyService
    {
		private string _error;

		public string Error { get { return _error; } }

		public IEnumerable<GranuleFuzzyViewModel> GetListGranuleFuzzy(int parentId)
		{
			try
			{
				using (var _context = new DissertationDbContext())
				{
					return _context.GranuleFuzzys
                                        .Include(gf => gf.FuzzyLabel)
                                        .Include(gf => gf.FuzzyTrend)
                                        .Where(gf => gf.DiagnosticTestId == parentId)
                                        .ToList()
                                        .Select(gf => ModelConvector.ToGranuleFuzzy(gf));
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
					return ModelConvector.ToGranuleFuzzy(_context.GranuleFuzzys.SingleOrDefault(gf => gf.Id == id));
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
