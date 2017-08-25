using DatabaseModule;
using ServicesModule.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServicesModule
{
    public class BLClassDiagnosticTestRecord
	{
		private string _error;

		public string Error { get { return _error; } }

		public IEnumerable<DiagnosticTestRecordViewModel> GetListDiagnosticTestRecord(int parentId)
		{
			try
			{
				using (var _context = new DissertationDbContext())
				{
					return _context.DiagnosticTestRecords.Where(rec => rec.DiagnosticTestId == parentId).ToList().Select(rec => ModelConvector.ToDiagnosticTestRecord(rec));
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
					return ModelConvector.ToDiagnosticTestRecord(_context.DiagnosticTestRecords.SingleOrDefault(rec => rec.Id == id));
				}
			}
			catch (Exception ex)
			{
				_error = ex.Message;
				return null;
			}
		}

		public bool DelDiagnosticTestRecordFromSeries(int seriesId)
		{
			using (var _context = new DissertationDbContext())
			{
				_context.DiagnosticTestRecords.RemoveRange(_context.DiagnosticTestRecords.Where(rec => rec.DiagnosticTestId == seriesId));
				_context.SaveChanges();
				return true;
			}
		}
	}
}
