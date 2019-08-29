using DTE_Interface_Level.BindingModels;
using DTE_Interface_Level.Interfaces;
using DTE_Interface_Level.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DTE_Implement_Level.Implementations
{
    public class GranuleFuzzyService : ISeriesDescriptionModel<GranuleFuzzyViewModel, GranuleFuzzyBindingModel>
	{
		public IEnumerable<GranuleFuzzyViewModel> GetElements(int parentId)
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

		public GranuleFuzzyViewModel GetElement(int id)
		{
			using (var _context = new DissertationDbContext())
			{
				return ModelConvector.ToGranuleFuzzy(_context.GranuleFuzzys.SingleOrDefault(gf => gf.Id == id));
			}
		}

		public void InsertElement(GranuleFuzzyBindingModel model)
		{
			throw new NotImplementedException();
		}

		public void UpdateElement(GranuleFuzzyBindingModel model)
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