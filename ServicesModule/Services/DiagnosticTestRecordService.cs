using DatabaseModule;
using ServicesModule.BindingModels;
using ServicesModule.Interfaces;
using ServicesModule.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ServicesModule
{
	public class DiagnosticTestRecordService : ISeriesDescriptionModel<DiagnosticTestRecordViewModel, DiagnosticTestRecordBindingModel>
	{
		public IEnumerable<DiagnosticTestRecordViewModel> GetElements(int parentId)
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

		public DiagnosticTestRecordViewModel GetElement(int id)
		{
			using (var _context = new DissertationDbContext())
			{
				return ModelConvector.ToDiagnosticTestRecord(_context.DiagnosticTestRecords
									.Include(dtr => dtr.AnomalyInfo)
									.SingleOrDefault(dtr => dtr.Id == id));
			}
		}

		public void InsertElement(DiagnosticTestRecordBindingModel model)
		{
			throw new NotImplementedException();
		}

		public void UpdateElement(DiagnosticTestRecordBindingModel model)
		{
			throw new NotImplementedException();
		}

		public void DeleteElement(int id)
		{
			throw new NotImplementedException();
		}

		public void DeleteElements(int seriesId)
		{
			throw new NotImplementedException();
		}
	}
}
