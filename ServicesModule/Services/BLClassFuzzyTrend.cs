using DatabaseModule;
using ServicesModule.BindingModels;
using ServicesModule.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServicesModule
{
    public class BLClassFuzzyTrend
	{
		private string _error;

		public string Error { get { return _error; } }

		public IEnumerable<FuzzyTrendViewModel> GetListFuzzyTrend(int parentId)
		{
			try
			{
				using (var _context = new DissertationDbContext())
				{
					return _context.FuzzyTrends.Where(rec => rec.SeriesDiscriptionId == parentId).ToList().Select(rec => ModelConvector.ToFuzzyTrend(rec));
				}
			}
			catch (Exception ex)
			{
				_error = ex.Message;
				return null;
			}
		}

		public FuzzyTrendViewModel GetElemFuzzyTrend(int id)
		{
			try
			{
				using (var _context = new DissertationDbContext())
				{
					return ModelConvector.ToFuzzyTrend(_context.FuzzyTrends.SingleOrDefault(rec => rec.Id == id));
				}
			}
			catch (Exception ex)
			{
				_error = ex.Message;
				return null;
			}
		}

		public bool AddFuzzyTrend(FuzzyTrendBindingModel model)
		{
			using (var _context = new DissertationDbContext())
			{
				try
				{
					var list = _context.FuzzyTrends.Where(rec => rec.SeriesDiscriptionId == model.SeriesId);
					if (list.FirstOrDefault(rec => rec.TrendName == model.TrendName) != null)
					{
						_error = "Уже есть нечеткая тенденция с таким названием!";
						return false;
					}
					_context.FuzzyTrends.Add(ModelConvector.ToFuzzyTrend(model));
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

		public bool UpdFuzzyTrend(FuzzyTrendBindingModel model)
		{
			using (var _context = new DissertationDbContext())
			{
				try
				{
					var list = _context.FuzzyTrends.Where(rec => rec.SeriesDiscriptionId == model.SeriesId);
					var elem = _context.FuzzyTrends.SingleOrDefault(rec => rec.Id == model.Id);
					if (list.FirstOrDefault(rec => rec.TrendName == model.TrendName && rec.Id != model.Id) != null)
					{
						_error = "Уже есть нечеткая тенденция с таким названием!";
						return false;
					}
					elem = ModelConvector.ToFuzzyTrend(model, elem);

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

		public bool DelFuzzyTrend(int id)
		{
			using (var _context = new DissertationDbContext())
			{
				_context.FuzzyTrends.Remove(_context.FuzzyTrends.SingleOrDefault(rec => rec.Id == id));
				_context.SaveChanges();
				return true;
			}
		}

		public bool DelFuzzyTrendFromSeries(int seriesId)
		{
			using (var _context = new DissertationDbContext())
			{
				_context.FuzzyTrends.RemoveRange(_context.FuzzyTrends.Where(rec => rec.SeriesDiscriptionId == seriesId));
				_context.SaveChanges();
				return true;
			}
		}

		public bool Generate(int seriesId)
		{
			using (var _context = new DissertationDbContext())
			using (var transaction = _context.Database.BeginTransaction())
			{
				try
				{
					foreach (FuzzyTrendLabel elem in Enum.GetValues(typeof(FuzzyTrendLabel)))
					{
						_context.FuzzyTrends.Add(ModelConvector.ToFuzzyTrend(new FuzzyTrendBindingModel
						{
							SeriesId = seriesId,
							TrendName = elem,
							Weight = Converter.ToFuzzyTrendLabelWeight(elem)
						}));
						_context.SaveChanges();
					}
					transaction.Commit();
					return true;
				}
				catch (Exception ex)
				{
					_error = ex.Message;
					transaction.Rollback();
					return false;
				}
			}

		}
	}
}
