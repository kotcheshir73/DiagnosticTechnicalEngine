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
	public class FuzzyLabelService : ISeriesDescriptionModel<FuzzyLabelViewModel, FuzzyLabelBindingModel>
	{
		public IEnumerable<FuzzyLabelViewModel> GetElements(int parentId)
		{
			using (var _context = new DissertationDbContext())
			{
				return _context.FuzzyLabels
							.Where(fl => fl.SeriesDiscriptionId == parentId)
							.ToList()
							.Select(fl => ModelConvector.ToFuzzyLabel(fl));
			}
		}

		public FuzzyLabelViewModel GetElement(int id)
		{
			using (var _context = new DissertationDbContext())
			{
				return ModelConvector.ToFuzzyLabel(_context.FuzzyLabels.SingleOrDefault(fl => fl.Id == id));
			}
		}

		public void InsertElement(FuzzyLabelBindingModel model)
		{
			using (var _context = new DissertationDbContext())
			{
				var list = _context.FuzzyLabels.Where(fl => fl.SeriesDiscriptionId == model.SeriesId);
				if (list.FirstOrDefault(fl => fl.FuzzyLabelName == model.FuzzyLabelName) != null)
				{
					throw new Exception("Уже есть нечеткая метка с таким именем!");
				}
				if (list.FirstOrDefault(fl => fl.FuzzyLabelType == model.FuzzyLabelType) == null && list.Count() > 0)
				{
					throw new Exception("Тип нечеткой метки должен совпадать с типами других нечетких меток!");
				}
				_context.FuzzyLabels.Add(ModelConvector.ToFuzzyLabel(model));
				_context.SaveChanges();
			}
		}

		public void UpdateElement(FuzzyLabelBindingModel model)
		{
			using (var _context = new DissertationDbContext())
			{
				var list = _context.FuzzyLabels.Where(fl => fl.SeriesDiscriptionId == model.SeriesId);
				var elem = _context.FuzzyLabels.SingleOrDefault(fl => fl.Id == model.Id);
				if (list.FirstOrDefault(fl => fl.FuzzyLabelName == model.FuzzyLabelName && fl.Id != model.Id) != null)
				{
					throw new Exception("Уже есть нечеткая метка с таким именем!");
				}
				if (list.FirstOrDefault(fl => fl.FuzzyLabelType == model.FuzzyLabelType) == null)
				{
					throw new Exception("Тип нечеткой метки должен совпадать с типами других нечетких меток!");
				}
				elem = ModelConvector.ToFuzzyLabel(model, elem);

				_context.Entry(elem).State = EntityState.Modified;
				_context.SaveChanges();
			}
		}

		public void DeleteElement(int id)
		{
			using (var _context = new DissertationDbContext())
			{
				_context.FuzzyLabels.Remove(_context.FuzzyLabels.SingleOrDefault(fl => fl.Id == id));
				_context.SaveChanges();
			}
		}

		public void DeleteElements(int seriesId)
		{
			using (var _context = new DissertationDbContext())
			{
				_context.FuzzyLabels.RemoveRange(_context.FuzzyLabels.Where(fl => fl.SeriesDiscriptionId == seriesId));
				_context.SaveChanges();
			}
		}
	}
}
