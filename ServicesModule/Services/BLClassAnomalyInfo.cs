using DatabaseModule;
using ServicesModule.BindingModels;
using ServicesModule.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServicesModule
{
    public class BLClassAnomalyInfo
	{
		private string _error;

		public string Error { get { return _error; } }

		public IEnumerable<AnomalyInfoViewModel> GetListAnomalyInfo(int parentId)
		{
			try
			{
				using (var _context = new DissertationDbContext())
				{
					return _context.AnomalyInfos.Where(rec => rec.DiagnosticTestId == parentId).ToList().Select(rec => ModelConvector.ToAnomalyInfo(rec));
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
					return ModelConvector.ToAnomalyInfo(_context.AnomalyInfos.SingleOrDefault(rec => rec.Id == id));
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
					var list = _context.AnomalyInfos.Where(rec => rec.DiagnosticTestId == model.DiagnosticTestId);
					var elem = _context.AnomalyInfos.SingleOrDefault(rec => rec.Id == model.Id);
					if (list.Count() > 0)
					{
						if (list.Where(rec => rec.AnomalyName == model.AnomalyName && rec.TypeSituation ==
							 Converter.ToTypeSituation(model.TypeSituation) && rec.Id != model.Id).Count() > 0)
						{
							_error = "Уже есть аномалия с таким именем!";
							return false;
						}
						if (list.Where(rec => rec.SetSituations == model.SetSituations && rec.TypeSituation ==
							Converter.ToTypeSituation(model.TypeSituation) && rec.Id != model.Id).Count() > 0)
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

		public bool DelAnomalyInfo(int id)
		{
			using (var _context = new DissertationDbContext())
			{
				_context.AnomalyInfos.Remove(_context.AnomalyInfos.SingleOrDefault(rec => rec.Id == id));
				_context.SaveChanges();
				return true;
			}
		}

		public bool DelAnomalyInfoFromSeries(int seriesId)
		{
			using (var _context = new DissertationDbContext())
			{
				_context.AnomalyInfos.RemoveRange(_context.AnomalyInfos.Where(rec => rec.DiagnosticTestId == seriesId));
				_context.SaveChanges();
				return true;
			}
		}

		public bool ResetStatistic(int seriesId)
		{
			using (var _context = new DissertationDbContext())
			using (var transaction = _context.Database.BeginTransaction())
			{
				try
				{
					var list = _context.AnomalyInfos.Where(rec => rec.DiagnosticTestId == seriesId).ToList();
					foreach (var elem in list)
					{
						elem.CountMeet = 0;
						_context.SaveChanges();
					}
					transaction.Commit();
					return true;
				}
				catch (Exception ex)
				{
					transaction.Rollback();
					_error = ex.Message;
					return false;
				}
			}
		}
	}
}
