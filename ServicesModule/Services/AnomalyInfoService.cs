using DatabaseModule;
using ServicesModule.BindingModels;
using ServicesModule.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServicesModule
{
    public class AnomalyInfoService
    {
		private string _error;

		public string Error { get { return _error; } }

		public IEnumerable<AnomalyInfoViewModel> GetListAnomalyInfo(int parentId)
		{
			try
			{
				using (var _context = new DissertationDbContext())
				{
					return _context.AnomalyInfos
                                        .Where(ai => ai.DiagnosticTestId == parentId)
                                        .ToList()
                                        .Select(ai => ModelConvector.ToAnomalyInfo(ai));
				}
			}
			catch (Exception ex)
			{
				_error = ex.Message;
				return null;
			}
		}

		public AnomalyInfoViewModel GetElemAnomalyInfo(int id)
		{
			try
			{
				using (var _context = new DissertationDbContext())
				{
					return ModelConvector.ToAnomalyInfo(_context.AnomalyInfos.SingleOrDefault(ai => ai.Id == id));
				}
			}
			catch (Exception ex)
			{
				_error = ex.Message;
				return null;
			}
		}

		public bool UpdAnomalyInfo(AnomalyInfoBindingModel model)
		{
			using (var _context = new DissertationDbContext())
			{
				try
				{
					var list = _context.AnomalyInfos.Where(ai => ai.DiagnosticTestId == model.DiagnosticTestId);
					var elem = _context.AnomalyInfos.SingleOrDefault(ai => ai.Id == model.Id);
					if (list.Count() > 0)
					{
						if (list.Where(ai => ai.AnomalyName == model.AnomalyName && ai.TypeSituation ==
							 Converter.ToTypeSituation(model.TypeSituation) && ai.Id != model.Id).Count() > 0)
						{
							_error = "Уже есть аномалия с таким именем!";
							return false;
						}
						if (list.Where(ai => ai.SetSituations == model.SetSituations && ai.TypeSituation ==
							Converter.ToTypeSituation(model.TypeSituation) && ai.Id != model.Id).Count() > 0)
						{
							_error = "Уже есть аномалия с такой последовательностью!";
							return false;
						}
					}
					elem = ModelConvector.ToAnomalyInfo(model, elem);

					_context.Entry(elem).State = System.Data.Entity.EntityState.Modified;
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
	}
}
