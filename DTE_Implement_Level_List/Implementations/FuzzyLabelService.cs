using DTE_Interface_Level.BindingModels;
using DTE_Interface_Level.Interfaces;
using DTE_Interface_Level.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DTE_Implement_Level_List.Implementations
{
    public class FuzzyLabelService : ISeriesDescriptionModel<FuzzyLabelViewModel, FuzzyLabelBindingModel>
	{
		public IEnumerable<FuzzyLabelViewModel> GetElements(int parentId)
		{
            var _context = DissertationDbList.getInstance();
			{
				return _context.FuzzyLabels
							.Where(fl => fl.SeriesDiscriptionId == parentId)
							.ToList()
							.Select(fl => ModelConvector.ToFuzzyLabel(fl));
			}
		}

		public FuzzyLabelViewModel GetElement(int id)
        {
            var _context = DissertationDbList.getInstance();
            {
				return ModelConvector.ToFuzzyLabel(_context.FuzzyLabels.SingleOrDefault(fl => fl.Id == id));
			}
		}

		public void InsertElement(FuzzyLabelBindingModel model)
        {
            var _context = DissertationDbList.getInstance();
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
			}
		}

		public void UpdateElement(FuzzyLabelBindingModel model)
        {
            var _context = DissertationDbList.getInstance();
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
			}
		}

		public void DeleteElement(int id)
        {
            var _context = DissertationDbList.getInstance();
            {
				_context.FuzzyLabels.Remove(_context.FuzzyLabels.SingleOrDefault(fl => fl.Id == id));
			}
		}

		public void DeleteElements(int seriesId)
        {
            var _context = DissertationDbList.getInstance();
            {
				_context.FuzzyLabels.RemoveAll(fl => fl.SeriesDiscriptionId == seriesId);
			}
		}
	}
}