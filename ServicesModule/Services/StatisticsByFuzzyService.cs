using DatabaseModule;
using ServicesModule.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ServicesModule
{
    public class StatisticsByFuzzyService
    {
		private string _error;

		public string Error { get { return _error; } }

		public IEnumerable<StatisticsByFuzzyViewModel> GetListStatisticsByFuzzy(int parentId)
		{
			try
			{
				using (var _context = new DissertationDbContext())
				{
					return _context.StatisticsByFuzzys
                                .Include(sbf => sbf.EndStateFuzzyLabel)
                                .Include(sbf => sbf.EndStateFuzzyTrend)
                                .Include(sbf => sbf.StartStateFuzzyLabel)
                                .Include(sbf => sbf.StartStateFuzzyTrend)
                                .Where(sbf => sbf.DiagnosticTestId == parentId)
                                .ToList()
                                .Select(sbf => ModelConvector.ToStatisticsByFuzzy(sbf));
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
					return ModelConvector.ToStatisticsByFuzzy(_context.StatisticsByFuzzys
                                .Include(sbf => sbf.EndStateFuzzyLabel)
                                .Include(sbf => sbf.EndStateFuzzyTrend)
                                .Include(sbf => sbf.StartStateFuzzyLabel)
                                .Include(sbf => sbf.StartStateFuzzyTrend)
                                .SingleOrDefault(sbf => sbf.Id == id));
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
