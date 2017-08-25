using DatabaseModule;
using ServicesModule.BindingModels;
using ServicesModule.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ServicesModule
{
    public class FuzzyLabelService
    {
		private string _error;

		public string Error { get { return _error; } }

		public IEnumerable<FuzzyLabelViewModel> GetListFuzzyLabel(int parentId)
		{
			try
			{
				using (var _context = new DissertationDbContext())
				{
					return _context.FuzzyLabels
                                .Where(fl => fl.SeriesDiscriptionId == parentId)
                                .ToList()
                                .Select(fl => ModelConvector.ToFuzzyLabel(fl));
				}
			}
			catch (Exception ex)
			{
				_error = ex.Message;
				return null;
			}
		}

		public FuzzyLabelViewModel GetElemFuzzyLabel(int id)
		{
			try
			{
				using (var _context = new DissertationDbContext())
				{
					return ModelConvector.ToFuzzyLabel(_context.FuzzyLabels.SingleOrDefault(fl => fl.Id == id));
				}
			}
			catch (Exception ex)
			{
				_error = ex.Message;
				return null;
			}
		}

		public bool AddFuzzyLabel(FuzzyLabelBindingModel model)
		{
			using (var _context = new DissertationDbContext())
			{
				try
				{
					var list = _context.FuzzyLabels.Where(fl => fl.SeriesDiscriptionId == model.SeriesId);
					if (list.FirstOrDefault(fl => fl.FuzzyLabelName == model.FuzzyLabelName) != null)
					{
						_error = "Уже есть нечеткая метка с таким именем!";
						return false;
					}
					if (list.FirstOrDefault(fl => fl.FuzzyLabelType == model.FuzzyLabelType) == null && list.Count() > 0)
					{
						_error = "Тип нечеткой метки должен совпадать с типами других нечетких меток!";
						return false;
					}
					_context.FuzzyLabels.Add(ModelConvector.ToFuzzyLabel(model));
					_context.SaveChanges();
					return true;
				}
				catch (Exception ex)
				{
					_error = ex.Message;
					return false;
				}
			}
		}

		public bool UpdFuzzyLabel(FuzzyLabelBindingModel model)
		{
			using (var _context = new DissertationDbContext())
			{
				try
				{
					var list = _context.FuzzyLabels.Where(fl => fl.SeriesDiscriptionId == model.SeriesId);
					var elem = _context.FuzzyLabels.SingleOrDefault(fl => fl.Id == model.Id);
					if (list.FirstOrDefault(fl => fl.FuzzyLabelName == model.FuzzyLabelName && fl.Id != model.Id) != null)
					{
						_error = "Уже есть нечеткая метка с таким именем!";
						return false;
					}
					if (list.FirstOrDefault(fl => fl.FuzzyLabelType == model.FuzzyLabelType) == null)
					{
						_error = "Тип нечеткой метки должен совпадать с типами других нечетких меток!";
						return false;
					}
					elem = ModelConvector.ToFuzzyLabel(model, elem);

					_context.Entry(elem).State = EntityState.Modified;
					_context.SaveChanges();
					return true;
				}
				catch (Exception ex)
				{
					_error = ex.Message;
					return false;
				}
			}
		}

		public bool DelFuzzyLabel(int id)
		{
			using (var _context = new DissertationDbContext())
			{
				_context.FuzzyLabels.Remove(_context.FuzzyLabels.SingleOrDefault(fl => fl.Id == id));
				_context.SaveChanges();
				return true;
			}
        }

        public bool DelFuzzyLabelFromSeries(int seriesId)
        {
            using (var _context = new DissertationDbContext())
            {
                _context.FuzzyLabels.RemoveRange(_context.FuzzyLabels.Where(fl => fl.SeriesDiscriptionId == seriesId));
                _context.SaveChanges();
                return true;
            }
        }
    }
}
