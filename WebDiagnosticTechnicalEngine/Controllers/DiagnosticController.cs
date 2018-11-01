using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Script.Serialization;
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
            //string ip = "https://212.8.234.87/";

            string ip = "https://ois.ustu:8443/";
            int versionId = 3;
            int unitId = 4;
            HttpClient client = new HttpClient();
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.BaseAddress = new Uri(ip);
            //dataSeries.InitSeries(new InitSeriesDto
            //{
            //    SeriesName = "balance-employees-koef",
            //    Url = string.Format("{0}api/1.0/balance/balance-employees?versionId={1}&unitId={2}&workTypeId=&toolGroupId=", ip, versionId, unitId),
            //    VersionId = versionId
            //}, false, "Коэффициент загрузки по ОПР. %");
            //dataSeries.InitSeries(new InitSeriesDto
            //{
            //    SeriesName = "balance-employees-total",
            //    Url = string.Format("{0}api/1.0/balance/balance-employees?versionId={1}&unitId={2}&workTypeId=&toolGroupId=", ip, versionId, unitId),
            //    VersionId = versionId
            //}, false, "Профицит/дефицит, чел.");


            Task<HttpResponseMessage> response = client.GetAsync(string.Format("{0}api/1.0/balance/balance-employees?versionId={1}&unitId={2}&workTypeId=&toolGroupId=", ip, versionId, unitId));
            if (response.Result.IsSuccessStatusCode)
            {
                var stringd = response.Result.Content.ReadAsStringAsync();
                JavaScriptSerializer ser = new JavaScriptSerializer();
                var res = ser.Deserialize< ResponseDiagnosticDto >(stringd.Result);

                ResponseDiagnosticDto list = JsonConvert.DeserializeObject<ResponseDiagnosticDto>(stringd.Result);
                if (list != null)
                {
                    var result = dataSeries.Diagnostic(new DiagnosticDto
                    {
                        SeriesName = "balance-employees-koef",
                        VersionId = versionId,
                        UnitId = unitId,
                        Url = string.Format("{0}api/1.0/balance/balance-employees?versionId={1}&unitId={2}&workTypeId=&toolGroupId=", ip, versionId, unitId),
                        Key = "Коэффициент загрузки по ОПР. %"
                    });
                    dataSeries.Diagnostic(new DiagnosticDto
                    {
                        SeriesName = "balance-employees-total",
                        VersionId = versionId,
                        UnitId = unitId,
                        Url = string.Format("{0}api/1.0/balance/balance-employees?versionId={1}&unitId={2}&workTypeId=&toolGroupId=", ip, versionId, unitId),
                        Key = "Профицит/дефицит, чел."
                    });
                    return new JsonResult { Data = result };
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
