using DTE_Interface_Level.BindingModels;
using DTE_Interface_Level.Interfaces;
using DTE_Interface_Level.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DTE_Implement_Level.Implementations
{
    public class GranuleFTService : ISeriesDescriptionModel<GranuleFTViewModel, GranuleFTBindingModel>
	{
		public IEnumerable<GranuleFTViewModel> GetElements(int parentId)
		{
			using (var _context = new DissertationDbContext())
			{
				return _context.GranuleFTs
									.Where(gft => gft.DiagnosticTestId == parentId)
									.ToList()
									.Select(gft => ModelConvector.ToGranuleFT(gft));
			}
		}

		public GranuleFTViewModel GetElement(int id)
		{
			using (var _context = new DissertationDbContext())
			{
				return ModelConvector.ToGranuleFT(_context.GranuleFTs.SingleOrDefault(gft => gft.Id == id));
			}
		}

		public void InsertElement(GranuleFTBindingModel model)
		{
			throw new NotImplementedException();
		}

		public void UpdateElement(GranuleFTBindingModel model)
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