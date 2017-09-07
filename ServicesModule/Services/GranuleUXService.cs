using DatabaseModule;
using ServicesModule.BindingModels;
using ServicesModule.Interfaces;
using ServicesModule.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServicesModule
{
	public class GranuleUXService : ISeriesDescriptionModel<GranuleUXViewModel, GranuleUXBindingModel>
	{
		public IEnumerable<GranuleUXViewModel> GetElements(int parentId)
		{
			using (var _context = new DissertationDbContext())
			{
				return _context.GranuleUXs
									.Where(gux => gux.DiagnosticTestId == parentId)
									.ToList()
									.Select(gux => ModelConvector.ToGranuleUX(gux));
			}
		}

		public GranuleUXViewModel GetElement(int id)
		{
			using (var _context = new DissertationDbContext())
			{
				return ModelConvector.ToGranuleUX(_context.GranuleUXs.SingleOrDefault(gux => gux.Id == id));
			}
		}

		public void InsertElement(GranuleUXBindingModel model)
		{
			throw new NotImplementedException();
		}

		public void UpdateElement(GranuleUXBindingModel model)
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
