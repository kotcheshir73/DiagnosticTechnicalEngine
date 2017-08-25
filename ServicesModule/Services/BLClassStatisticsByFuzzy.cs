using DatabaseModule;
using ServicesModule.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServicesModule
{
    public class BLClassStatisticsByFuzzy
	{
		private string _error;

		public string Error { get { return _error; } }

		public IEnumerable<StatisticsByFuzzyViewModel> GetListStatisticsByFuzzy(int parentId)
		{
			try
			{
				using (var _context = new DissertationDbContext())
				{
					return _context.StatisticsByFuzzys.Where(rec => rec.DiagnosticTestId == parentId).ToList().Select(rec => ModelConvector.ToStatisticsByFuzzy(rec));
				}
			}
			catch (Exception ex)
			{
				_error = ex.Message;
				return null;
			}
		}

		public StatisticsByFuzzyViewModel GetElemStatisticsByFuzzy(int id)
		{
			try
			{
				using (var _context = new DissertationDbContext())
				{
					return ModelConvector.ToStatisticsByFuzzy(_context.StatisticsByFuzzys.SingleOrDefault(rec => rec.Id == id));
				}
			}
			catch (Exception ex)
			{
				_error = ex.Message;
				return null;
			}
		}

		public bool DelStatisticsByFuzzyFromSeries(int seriesId)
		{
			using (var _context = new DissertationDbContext())
			{
				_context.StatisticsByFuzzys.RemoveRange(_context.StatisticsByFuzzys.Where(rec => rec.DiagnosticTestId == seriesId));
				_context.SaveChanges();
				return true;
			}
		}
	}
}
