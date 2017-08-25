using DatabaseModule;
using ServicesModule.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ServicesModule
{
    public class DiagnosticTestRecordService
    {
		private string _error;

		public string Error { get { return _error; } }

		public IEnumerable<DiagnosticTestRecordViewModel> GetListDiagnosticTestRecord(int parentId)
		{
			try
			{
				using (var _context = new DissertationDbContext())
				{
					return _context.DiagnosticTestRecords
                                        .Include(dtr => dtr.AnomalyInfo)
                                        .Where(dtr => dtr.DiagnosticTestId == parentId)
                                        .ToList()
                                        .Select(dtr => ModelConvector.ToDiagnosticTestRecord(dtr));
				}
			}
			catch (Exception ex)
			{
				_error = ex.Message;
				return null;
			}
		}

		public DiagnosticTestRecordViewModel GetElemDiagnosticTestRecord(int id)
		{
			try
			{
				using (var _context = new DissertationDbContext())
				{
					return ModelConvector.ToDiagnosticTestRecord(_context.DiagnosticTestRecords
                                        .Include(dtr => dtr.AnomalyInfo)
                                        .SingleOrDefault(dtr => dtr.Id == id));
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
