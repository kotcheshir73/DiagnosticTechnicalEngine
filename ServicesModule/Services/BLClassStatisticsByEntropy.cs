using DatabaseModule;
using ServicesModule.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServicesModule
{
    public class BLClassStatisticsByEntropy
	{
		private string _error;

		public string Error { get { return _error; } }

		public IEnumerable<StatisticsByEntropyViewModel> GetListStatisticsByEntropy(int parentId)
		{
			try
			{
				using (var _context = new DissertationDbContext())
				{
					return _context.StatisticsByEntropys.Where(rec => rec.DiagnosticTestId == parentId).ToList().Select(rec => ModelConvector.ToStatisticsByEntropy(rec));
				}
			}
			catch (Exception ex)
			{
				_error = ex.Message;
				return null;
			}
		}

		public StatisticsByEntropyViewModel GetElemStatisticsByEntropy(int id)
		{
			try
			{
				using (var _context = new DissertationDbContext())
				{
					return ModelConvector.ToStatisticsByEntropy(_context.StatisticsByEntropys.SingleOrDefault(rec => rec.Id == id));
				}
			}
			catch (Exception ex)
			{
				_error = ex.Message;
				return null;
			}
		}

		public bool DelStatisticsByEntropyFromSeries(int seriesId)
		{
			using (var _context = new DissertationDbContext())
			{
				_context.StatisticsByEntropys.RemoveRange(_context.StatisticsByEntropys.Where(rec => rec.DiagnosticTestId == seriesId));
				_context.SaveChanges();
				return true;
			}
		}
	}
}
