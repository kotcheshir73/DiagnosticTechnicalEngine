using DatabaseModule;
using ServicesModule.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServicesModule
{
    public class StatisticsByEntropyService
    {
		private string _error;

		public string Error { get { return _error; } }

		public IEnumerable<StatisticsByEntropyViewModel> GetListStatisticsByEntropy(int parentId)
		{
			try
			{
				using (var _context = new DissertationDbContext())
				{
					return _context.StatisticsByEntropys
                                        .Where(sbe => sbe.SeriesDiscriptionId == parentId)
                                        .ToList()
                                        .Select(sbe => ModelConvector.ToStatisticsByEntropy(sbe));
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
					return ModelConvector.ToStatisticsByEntropy(_context.StatisticsByEntropys.SingleOrDefault(sbe => sbe.Id == id));
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
