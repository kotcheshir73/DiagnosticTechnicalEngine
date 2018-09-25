using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using WebDiagnosticTechnicalEngine.Models;
using WebDiagnosticTechnicalEngine.Services;

namespace WebDiagnosticTechnicalEngine.Controllers
{
    public class DiagnosticController : ApiController
    {
        private readonly DatatSeries dataSeries;

        public DiagnosticController()
        {
            dataSeries = new DatatSeries();
        }

        public void InitSeries(InitSeriesDto model)
        {
            dataSeries.InitSeries(model, false);
        }

        public void MakeDiagnostic(DiagnosticDto model)
        {
            dataSeries.Diagnostic(model);
        }


        /// <summary>
        /// /api/Diagnostic/Check
        /// </summary>
        /// <returns></returns>
        [System.Web.Http.HttpGet]
        public ActionResult Check()
        {
            HttpClient client = new HttpClient();
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.BaseAddress = new Uri("https://212.8.234.87/");


            Task<HttpResponseMessage> response = client.GetAsync("https://212.8.234.87/api/1.0/balance/balance-employees?versionId=1&unitId=17060&workTypeId=&toolGroupId=");
            if (response.Result.IsSuccessStatusCode)
            {
                var stringd = response.Result.Content.ReadAsStringAsync();
                ResponseDiagnosticDto list = JsonConvert.DeserializeObject<ResponseDiagnosticDto>(stringd.Result);
                if (list != null)
                {
                    return new JsonResult { Data = list.Data };
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
