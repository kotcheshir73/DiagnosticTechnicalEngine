using DTE_Interface_Level.BindingModels;
using DTE_Interface_Level.Interfaces;
using DTE_Interface_Level.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DTE_Implement_Level.Implementations
{
    public class DiagnosticTestService : ISeriesDescriptionModel<DiagnosticTestViewModel, DiagnosticTestBindingModel>
	{
		public IEnumerable<DiagnosticTestViewModel> GetElements(int parentId)
		{
			using (var _context = new DissertationDbContext())
			{
				return _context.DiagnosticTests
									.Where(dt => dt.SeriesDiscriptionId == parentId)
									.ToList()
									.Select(dt => ModelConvector.ToDiagnosticTest(dt));
			}
		}

		public DiagnosticTestViewModel GetElement(int id)
		{
			using (var _context = new DissertationDbContext())
			{
				return ModelConvector.ToDiagnosticTest(_context.DiagnosticTests.SingleOrDefault(dt => dt.Id == id));
			}
		}

		public void InsertElement(DiagnosticTestBindingModel model)
		{
			throw new NotImplementedException();
		}

		public void UpdateElement(DiagnosticTestBindingModel model)
		{
			throw new NotImplementedException();
		}

		public void DeleteElement(int id)
		{
			using (var _context = new DissertationDbContext())
			{
				_context.DiagnosticTests.Remove(_context.DiagnosticTests.Single(dt => dt.Id == id));
				_context.SaveChanges();
			}
		}

		public void DeleteElements(int seriesId)
		{
			using (var _context = new DissertationDbContext())
			{
				_context.DiagnosticTests.RemoveRange(_context.DiagnosticTests.Where(dt => dt.SeriesDiscriptionId == seriesId));
				_context.SaveChanges();
			}
		}
	}
}