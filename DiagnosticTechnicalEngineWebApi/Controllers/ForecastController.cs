using DiagnosticTechnicalEngineWebApi.Models;
using DTE_Implement_Level_List;
using DTE_Interface_Level.BindingModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DiagnosticTechnicalEngineWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForecastController : ControllerBase
    {
        [HttpPost]
        public List<double> MakeForecast([FromBody] ForecastDto model)
        {
            APIService service = new APIService();

            var sdModel = new SeriesDescriptionBindingModel
            {
                SeriesName = model.SeriesName,
                NeedForecast = model.NeedForecast
            };

            var res = service.InitSeries(sdModel, model.DiagnosticList.Select(x => new APIData { timestamp = x.DataSeriesDate, Value = x.DataSeriesValue }).ToList());
            if (!res)
            {
                throw new Exception("Невозможно сформировать данные по ряду");
            }

            var list = model.DiagnosticList.Select(x => new APIData { timestamp = x.DataSeriesDate, Value = x.DataSeriesValue }).ToList();

            var diff = (list[list.Count - 1].timestamp - list[list.Count - 2].timestamp).Ticks;

            var resultList = new List<double>();

            for (int i = 0; i < model.CountPoints; ++i)
            {
                var result = service.MakeForecast(sdModel, list, model.NotSaveStatistic);

                list.Add(new APIData { timestamp = list[list.Count - 1].timestamp.AddTicks(diff), Value = result });

                resultList.Add(result);
            }

            return resultList;
        }
    }
}