using Newtonsoft.Json;
using ServicesModule.BindingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using WebDiagnosticTechnicalEngine.Models;
using WebDiagnosticTechnicalEngine.Services;

namespace WebDiagnosticTechnicalEngine.Controllers
{
    public class ForecastController : ApiController
    {
        private readonly DatatSeries dataSeries;

        public ForecastController()
        {
            dataSeries = new DatatSeries();
        }

        public void InitSeries(InitSeriesDto model)
        {
            dataSeries.InitSeries(model, true);
        }

        public double MakeForecast(ForecastDto model)
        {
            return dataSeries.MakeForecast(model);
        }


        /// <summary>
        /// /api/Forecast/Check
        /// </summary>
        /// <returns></returns>
        [System.Web.Http.HttpGet]
        public ActionResult Check()
        {
            //string ip = "https://212.8.234.87/";

            string ip = "https://ois.ustu:8443/";
            int versionId = 3;
            HttpClient client = new HttpClient();
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.BaseAddress = new Uri(ip);
            //dataSeries.InitSeries(new InitSeriesDto
            //{
            //    SeriesName = "employee",
            //    Url = string.Format("{0}api/1.0/timeseries/employee?versionId={1}", ip, versionId),
            //    VersionId = versionId
            //}, true);

            Task<HttpResponseMessage> response = client.GetAsync(string.Format("{0}api/1.0/timeseries/employee?versionId={1}", ip, versionId));
            if (response.Result.IsSuccessStatusCode)
            {
                var stringd = response.Result.Content.ReadAsStringAsync();
                ResponseForecastDto list = JsonConvert.DeserializeObject<ResponseForecastDto>(stringd.Result);
                if (list != null)
                {
                    var res = dataSeries.MakeForecast(new ForecastDto
                    {
                        SeriesName = "employee",
                        VersionId = versionId
                    });
                    return new JsonResult { Data = res };
                }
                else
                {
                    throw new Exception("Ряд не получен");
                }
            }
            else
            {
                throw new Exception(response.Result.Content.ReadAsStringAsync().Result);
            }
        }
    }
}
