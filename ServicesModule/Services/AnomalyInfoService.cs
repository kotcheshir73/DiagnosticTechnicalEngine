using DatabaseModule;
using ServicesModule.BindingModels;
using ServicesModule.Interfaces;
using ServicesModule.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServicesModule
{
	public class AnomalyInfoService : ISeriesDescriptionModel<AnomalyInfoViewModel, AnomalyInfoBindingModel>
	{
		public IEnumerable<AnomalyInfoViewModel> GetElements(int parentId)
		{
			using (var _context = new DissertationDbContext())
			{
				return _context.AnomalyInfos
									.Where(ai => ai.SeriesDiscriptionId == parentId)
									.ToList()
									.Select(ai => ModelConvector.ToAnomalyInfo(ai));
			}
		}

		public AnomalyInfoViewModel GetElement(int id)
		{
			using (var _context = new DissertationDbContext())
			{
				return ModelConvector.ToAnomalyInfo(_context.AnomalyInfos.SingleOrDefault(ai => ai.Id == id));
			}
		}

		public void InsertElement(AnomalyInfoBindingModel model)
		{
			using (var _context = new DissertationDbContext())
			{
				var list = _context.AnomalyInfos.Where(ai => ai.SeriesDiscriptionId == model.SeriesDiscriptionId);
				if (list.FirstOrDefault(ai => ai.AnomalyName == model.AnomalyName && ai.TypeSituation ==
						 Converter.ToTypeSituation(model.TypeSituation)) != null)
				{
					throw new Exception("Уже есть аномалия с таким именем!");
				}
				if (list.FirstOrDefault(ai => ai.SetSituations == model.SetSituations && ai.TypeSituation ==
						Converter.ToTypeSituation(model.TypeSituation)) != null)
				{
					throw new Exception("Уже есть аномалия с такой последовательностью!");
				}
				_context.AnomalyInfos.Add(ModelConvector.ToAnomalyInfo(model));
				_context.SaveChanges();
			}
		}

		public void UpdateElement(AnomalyInfoBindingModel model)
		{
			using (var _context = new DissertationDbContext())
			{
				var list = _context.AnomalyInfos.Where(ai => ai.SeriesDiscriptionId == model.SeriesDiscriptionId);
				var elem = _context.AnomalyInfos.SingleOrDefault(ai => ai.Id == model.Id);
				if (list.Count() > 0)
				{
					if (list.FirstOrDefault(ai => ai.AnomalyName == model.AnomalyName && ai.TypeSituation ==
						 Converter.ToTypeSituation(model.TypeSituation) && ai.Id != model.Id) != null)
					{
						throw new Exception("Уже есть аномалия с таким именем!");
					}
					if (list.FirstOrDefault(ai => ai.SetSituations == model.SetSituations && ai.TypeSituation ==
						Converter.ToTypeSituation(model.TypeSituation) && ai.Id != model.Id) != null)
					{
						throw new Exception("Уже есть аномалия с такой последовательностью!");
					}
				}
				elem = ModelConvector.ToAnomalyInfo(model, elem);

				_context.Entry(elem).State = System.Data.Entity.EntityState.Modified;
				_context.SaveChanges();
			}
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
