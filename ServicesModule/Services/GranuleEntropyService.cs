using DatabaseModule;
using ServicesModule.BindingModels;
using ServicesModule.Interfaces;
using ServicesModule.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServicesModule
{
	public class GranuleEntropyService : ISeriesDescriptionModel<GranuleEntropyViewModel, GranuleEntropyBindingModel>
	{
		public IEnumerable<GranuleEntropyViewModel> GetElements(int parentId)
		{
			using (var _context = new DissertationDbContext())
			{
				return _context.GranuleEntropys
									.Where(ge => ge.DiagnosticTestId == parentId)
									.ToList()
									.Select(ge => ModelConvector.ToGranuleEntropy(ge));
			}
		}

		public GranuleEntropyViewModel GetElement(int id)
		{
			using (var _context = new DissertationDbContext())
			{
				return ModelConvector.ToGranuleEntropy(_context.GranuleEntropys.SingleOrDefault(ge => ge.Id == id));
			}
		}

		public void InsertElement(GranuleEntropyBindingModel model)
		{
			throw new NotImplementedException();
		}

		public void UpdateElement(GranuleEntropyBindingModel model)
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
