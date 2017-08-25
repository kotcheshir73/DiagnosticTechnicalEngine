using DatabaseModule;
using ServicesModule.BindingModels;
using ServicesModule.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ServicesModule
{
    public class RuleTrendsService
    {
        private string _error;

        public string Error { get { return _error; } }

        public IEnumerable<RuleTrendViewModel> GetListRuleTrend(int parentId)
        {
            try
            {
                using (var _context = new DissertationDbContext())
                {
                    return _context.RuleTrends
                                .Include(rt => rt.FuzzyTrend)
                                .Include(rt => rt.FuzzyLabelFrom)
                                .Include(rt => rt.FuzzyLabelTo)
                                .Where(rt => rt.SeriesDiscriptionId == parentId)
                                .ToList()
                                .Select(rt => ModelConvector.ToRuleTrend(rt));
                }
            }
            catch (Exception ex)
            {
                _error = ex.Message;
                return null;
            }
        }

        public RuleTrendViewModel GetElemRuleTrend(int id)
        {
            try
            {
                using (var _context = new DissertationDbContext())
                {
                    return ModelConvector.ToRuleTrend(_context.RuleTrends
                                .Include(rt => rt.FuzzyTrend)
                                .Include(rt => rt.FuzzyLabelFrom)
                                .Include(rt => rt.FuzzyLabelTo)
                                .SingleOrDefault(rt => rt.Id == id));
                }
            }
            catch (Exception ex)
            {
                _error = ex.Message;
                return null;
            }
        }

        public bool AddRuleTrend(RuleTrendBindingModel model)
        {
            using (var _context = new DissertationDbContext())
            {
                try
                {
                    var list = _context.RuleTrends.Where(rt => rt.SeriesDiscriptionId == model.SeriesId);
                    if (list.FirstOrDefault(rt => rt.FuzzyLabelFromId == model.FuzzyLabelFromId &&
                                                    rt.FuzzyLabelToId == model.FuzzyLabelToId) != null)
                    {
                        _error = "Уже есть такое правило!";
                        return false;
                    }
                    if (!model.FuzzyTrendId.HasValue || model.FuzzyTrendId.Value == 0)
                    {
                        model.FuzzyTrendId = _context.FuzzyTrends.FirstOrDefault(t => t.TrendName == model.FuzzyTrendName).Id;
                    }
                    _context.RuleTrends.Add(ModelConvector.ToRuleTrend(model));
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

        public bool UpdRuleTrend(RuleTrendBindingModel model)
        {
            using (var _context = new DissertationDbContext())
            {
                try
                {
                    var list = _context.RuleTrends.Where(rt => rt.SeriesDiscriptionId == model.SeriesId);
                    var elem = _context.RuleTrends.SingleOrDefault(rt => rt.Id == model.Id);
                    if (list.FirstOrDefault(rt => rt.Id != model.Id &&
                                                    rt.FuzzyLabelFromId == model.FuzzyLabelFromId &&
                                                    rt.FuzzyLabelToId == model.FuzzyLabelToId) != null)
                    {
                        _error = "Уже есть такое правило!";
                        return false;
                    }
                    elem = ModelConvector.ToRuleTrend(model, elem);

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

        public bool DelRuleTrend(int id)
        {
            using (var _context = new DissertationDbContext())
            {
                _context.RuleTrends.Remove(_context.RuleTrends.Single(rt => rt.Id == id));
                _context.SaveChanges();
                return true;
            }
        }

        public bool DelRuleTrendFromSeries(int seriesId)
        {
            using (var _context = new DissertationDbContext())
            {
                _context.RuleTrends.RemoveRange(_context.RuleTrends.Where(rt => rt.SeriesDiscriptionId == seriesId));
                _context.SaveChanges();
                return true;
            }
        }

        public List<RuleTrendViewModel> MakeRules(int seriesId)
        {
            var logicFL = new FuzzyLabelService();
            var logicFT = new FuzzyTrendService();
            var labels = logicFL.GetListFuzzyLabel(seriesId);
            if (labels == null)
            {
                return null;
            }
            var trends = logicFT.GetListFuzzyTrend(seriesId);
            // формируем правила нечетких тенденций
            List<RuleTrendViewModel> rules = new List<RuleTrendViewModel>();
            // проходимся по всем нечетким меткам ряда
            foreach (var labFrom in labels)
            {
                foreach (var labTo in labels)
                {
                    var trend = trends.FirstOrDefault(t => t.Weight == labTo.FuzzyLabelWeight - labFrom.FuzzyLabelWeight);
                    if (trend != null)
                    {
                        rules.Add(new RuleTrendViewModel
                        {
                            SeriesDiscriptionId = seriesId,
                            FuzzyTrendId = trend.Id,
                            FuzzyTrendName = trend.TrendName,
                            FuzzyTrendWeight = trend.Weight,
                            FuzzyLabelFromId = labFrom.Id,
                            FuzzyLabelFromName = labFrom.FuzzyLabelName,
                            FuzzyLabelToId = labTo.Id,
                            FuzzyLabelToName = labTo.FuzzyLabelName
                        });
                    }
                    else
                    {
                        rules.Add(new RuleTrendViewModel
                        {
                            SeriesDiscriptionId = seriesId,
                            FuzzyTrendName = FuzzyTrendLabel.Неопределено.ToString(),
                            FuzzyTrendWeight = labTo.FuzzyLabelWeight - labFrom.FuzzyLabelWeight,
                            FuzzyLabelFromId = labFrom.Id,
                            FuzzyLabelFromName = labFrom.FuzzyLabelName,
                            FuzzyLabelToId = labTo.Id,
                            FuzzyLabelToName = labTo.FuzzyLabelName
                        });
                    }
                }
            }

            return rules;
        }
    }
}
