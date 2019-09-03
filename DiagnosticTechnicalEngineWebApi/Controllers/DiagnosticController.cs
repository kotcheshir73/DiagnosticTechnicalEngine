using DiagnosticTechnicalEngineWebApi.Models;
using DTE_Implement_Level;
using DTE_Interface_Level.BindingModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace DiagnosticTechnicalEngineWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiagnosticController : ControllerBase
    {
        [HttpPost]
        public void MakeDiagnostic([FromBody] DiagnosticDto model)
        {
            APIService service = new APIService();

            var sdModel = new SeriesDescriptionBindingModel
            {
                SeriesName = model.SeriesName,
                NeedForecast = model.NeedForecast
            };

            if (service.CheckSeries(sdModel))
            {
                service.FlushStat(sdModel);
            }
            else
            {
                var res = service.InitSeries(sdModel, model.DiagnosticList.Select(x => new APIData { timestamp = x.DataSeriesDate, Value = x.DataSeriesValue }).ToList());
                if(!res)
                {
                    throw new Exception("Невозможно сформировать данные по ряду");
                }
            }

            var result = service.Diagnostic(sdModel, model.DiagnosticList.Select(x => new APIData { timestamp = x.DataSeriesDate, Value = x.DataSeriesValue }).ToList());
        }
    }
}