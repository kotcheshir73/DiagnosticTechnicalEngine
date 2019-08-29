using Newtonsoft.Json;
using ServicesModule.BindingModels;
using ServicesModule.ViewModels;
using System;
using System.Collections.Generic;
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
        public void Check()
        {
            //string ip = "https://212.8.234.87/";

            //string ip = "https://ois.ustu:8443/";
            //int versionId = 3;
            //int unitId = 4;
            //HttpClient client = new HttpClient();
            //ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            //client.DefaultRequestHeaders.Accept.Clear();
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //client.BaseAddress = new Uri(ip);
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

            Dictionary<string, List<APIData>> datas = new Dictionary<string, List<APIData>>();
            #region Avia 2 sred
            //datas.Add("sred-prostoy", new List<APIData> {
            //    new APIData { Value=10.5419121773289, timestamp = new DateTime(2018, 1, 1) },
            //    new APIData { Value=8.38146247420442, timestamp = new DateTime(2018, 1, 2) },
            //    new APIData { Value=7.15909441638608, timestamp = new DateTime(2018, 1, 3) },
            //    new APIData { Value=8.04212827196698, timestamp = new DateTime(2018, 1, 4) },
            //    new APIData { Value=8.69942367220594, timestamp = new DateTime(2018, 1, 5) },
            //    new APIData { Value=5.52080176767677, timestamp = new DateTime(2018, 1, 6) },
            //    new APIData { Value=6.62678193222549, timestamp = new DateTime(2018, 1, 7) },
            //    new APIData { Value=3.08788930976431, timestamp = new DateTime(2018, 1, 8) },
            //    new APIData { Value=5.34246907480602, timestamp = new DateTime(2018, 1, 9) }
            //});
            #endregion
            #region Avia 2
            datas.Add("stanok1-off", new List<APIData> {
                new APIData { Value=17.6418, timestamp = new DateTime(2018, 1, 1) },
                new APIData { Value=9.77031, timestamp = new DateTime(2018, 1, 2) },
                new APIData { Value=15.5857, timestamp = new DateTime(2018, 1, 3) },
                new APIData { Value=17.9848, timestamp = new DateTime(2018, 1, 4) },
                new APIData { Value=26.0672, timestamp = new DateTime(2018, 1, 5) },
                new APIData { Value=14.0590, timestamp = new DateTime(2018, 1, 6) },
                new APIData { Value=8.07750, timestamp = new DateTime(2018, 1, 7) },
                new APIData { Value=14.1573, timestamp = new DateTime(2018, 1, 8) },
                new APIData { Value=25.3443, timestamp = new DateTime(2018, 1, 9) }
            });

            datas.Add("stanok1-stop", new List<APIData> {
                new APIData { Value=10.7662, timestamp = new DateTime(2018, 1, 1) },
                new APIData { Value=7.2479, timestamp = new DateTime(2018, 1, 2) },
                new APIData { Value=9.3409, timestamp = new DateTime(2018, 1, 3) },
                new APIData { Value=7.5832, timestamp = new DateTime(2018, 1, 4) },
                new APIData { Value=10.9485, timestamp = new DateTime(2018, 1, 5) },
                new APIData { Value=12.5266, timestamp = new DateTime(2018, 1, 6) },
                new APIData { Value=13.0858, timestamp = new DateTime(2018, 1, 7) },
                new APIData { Value=12.1050, timestamp = new DateTime(2018, 1, 8) },
                new APIData { Value=12.3985, timestamp = new DateTime(2018, 1, 9) }
            });

            datas.Add("stanok1-workout", new List<APIData> {
                new APIData { Value=0, timestamp = new DateTime(2018, 1, 1) },
                new APIData { Value=0, timestamp = new DateTime(2018, 1, 2) },
                new APIData { Value=0, timestamp = new DateTime(2018, 1, 3) },
                new APIData { Value=0, timestamp = new DateTime(2018, 1, 4) },
                new APIData { Value=0, timestamp = new DateTime(2018, 1, 5) },
                new APIData { Value=0, timestamp = new DateTime(2018, 1, 6) },
                new APIData { Value=0, timestamp = new DateTime(2018, 1, 7) },
                new APIData { Value=0, timestamp = new DateTime(2018, 1, 8) },
                new APIData { Value=3.31869, timestamp = new DateTime(2018, 1, 9) }
            });

            datas.Add("stanok1-wait", new List<APIData> {
                new APIData { Value=34.1687, timestamp = new DateTime(2018, 1, 1) },
                new APIData { Value=41.5333, timestamp = new DateTime(2018, 1, 2) },
                new APIData { Value=32.4259, timestamp = new DateTime(2018, 1, 3) },
                new APIData { Value=39.0403, timestamp = new DateTime(2018, 1, 4) },
                new APIData { Value=29.3931, timestamp = new DateTime(2018, 1, 5) },
                new APIData { Value=27.9956, timestamp = new DateTime(2018, 1, 6) },
                new APIData { Value=35.8979, timestamp = new DateTime(2018, 1, 7) },
                new APIData { Value=31.1385, timestamp = new DateTime(2018, 1, 8) },
                new APIData { Value=22.8676, timestamp = new DateTime(2018, 1, 9) }
            });

            datas.Add("stanok1-error", new List<APIData> {
                new APIData { Value=0.2969, timestamp = new DateTime(2018, 1, 1) },
                new APIData { Value=1.5624, timestamp = new DateTime(2018, 1, 2) },
                new APIData { Value=1.0497, timestamp = new DateTime(2018, 1, 3) },
                new APIData { Value=0.0002, timestamp = new DateTime(2018, 1, 4) },
                new APIData { Value=0.1309, timestamp = new DateTime(2018, 1, 5) },
                new APIData { Value=0, timestamp = new DateTime(2018, 1, 6) },
                new APIData { Value=0.9494, timestamp = new DateTime(2018, 1, 7) },
                new APIData { Value=1.6658, timestamp = new DateTime(2018, 1, 8) },
                new APIData { Value=0, timestamp = new DateTime(2018, 1, 9) }
            });

            datas.Add("stanok2-off", new List<APIData> {
                new APIData { Value=0, timestamp = new DateTime(2018, 1, 1) },
                new APIData { Value=0, timestamp = new DateTime(2018, 1, 2) },
                new APIData { Value=0, timestamp = new DateTime(2018, 1, 3) },
                new APIData { Value=21.9992, timestamp = new DateTime(2018, 1, 4) },
                new APIData { Value=15.1317, timestamp = new DateTime(2018, 1, 5) },
                new APIData { Value=24.2586, timestamp = new DateTime(2018, 1, 6) },
                new APIData { Value=1.3854, timestamp = new DateTime(2018, 1, 7) },
                new APIData { Value=2.6586, timestamp = new DateTime(2018, 1, 8) },
                new APIData { Value=0.0522, timestamp = new DateTime(2018, 1, 9) }
            });

            datas.Add("stanok2-stop", new List<APIData> {
                new APIData { Value=0, timestamp = new DateTime(2018, 1, 1) },
                new APIData { Value=0, timestamp = new DateTime(2018, 1, 2) },
                new APIData { Value=0.0837, timestamp = new DateTime(2018, 1, 3) },
                new APIData { Value=2.9554, timestamp = new DateTime(2018, 1, 4) },
                new APIData { Value=4.2414, timestamp = new DateTime(2018, 1, 5) },
                new APIData { Value=8.3470, timestamp = new DateTime(2018, 1, 6) },
                new APIData { Value=11.7465, timestamp = new DateTime(2018, 1, 7) },
                new APIData { Value=10.4745, timestamp = new DateTime(2018, 1, 8) },
                new APIData { Value=13.5445, timestamp = new DateTime(2018, 1, 9) }
            });

            datas.Add("stanok2-workout", new List<APIData> {
                new APIData { Value=0, timestamp = new DateTime(2018, 1, 1) },
                new APIData { Value=0, timestamp = new DateTime(2018, 1, 2) },
                new APIData { Value=0, timestamp = new DateTime(2018, 1, 3) },
                new APIData { Value=0, timestamp = new DateTime(2018, 1, 4) },
                new APIData { Value=0, timestamp = new DateTime(2018, 1, 5) },
                new APIData { Value=0, timestamp = new DateTime(2018, 1, 6) },
                new APIData { Value=0, timestamp = new DateTime(2018, 1, 7) },
                new APIData { Value=0, timestamp = new DateTime(2018, 1, 8) },
                new APIData { Value=4.7885, timestamp = new DateTime(2018, 1, 9) }
            });

            datas.Add("stanok2-wait", new List<APIData> {
                new APIData { Value=0, timestamp = new DateTime(2018, 1, 1) },
                new APIData { Value=0, timestamp = new DateTime(2018, 1, 2) },
                new APIData { Value=0.6622, timestamp = new DateTime(2018, 1, 3) },
                new APIData { Value=3.0546, timestamp = new DateTime(2018, 1, 4) },
                new APIData { Value=6.8960, timestamp = new DateTime(2018, 1, 5) },
                new APIData { Value=13.5732, timestamp = new DateTime(2018, 1, 6) },
                new APIData { Value=15.3340, timestamp = new DateTime(2018, 1, 7) },
                new APIData { Value=12.8607, timestamp = new DateTime(2018, 1, 8) },
                new APIData { Value=15.1390, timestamp = new DateTime(2018, 1, 9) }
            });

            datas.Add("stanok2-error", new List<APIData> {
                new APIData { Value=99.9988, timestamp = new DateTime(2018, 1, 1) },
                new APIData { Value=99.9988, timestamp = new DateTime(2018, 1, 2) },
                new APIData { Value=98.6437, timestamp = new DateTime(2018, 1, 3) },
                new APIData { Value=42.3702, timestamp = new DateTime(2018, 1, 4) },
                new APIData { Value=43.9383, timestamp = new DateTime(2018, 1, 5) },
                new APIData { Value=3.8668, timestamp = new DateTime(2018, 1, 6) },
                new APIData { Value=5.0134, timestamp = new DateTime(2018, 1, 7) },
                new APIData { Value=8.5473, timestamp = new DateTime(2018, 1, 8) },
                new APIData { Value=2.4099, timestamp = new DateTime(2018, 1, 9) }
            });

            #endregion
            #region Avia 1
            //datas.Add("employee-diagnostic-koef-test-1", new List<APIData> {
            //    new APIData { Value=50, timestamp = new DateTime(2018, 1, 1) },
            //    new APIData { Value=77, timestamp = new DateTime(2018, 1, 2) },
            //    new APIData { Value=193, timestamp = new DateTime(2018, 1, 3) },
            //    new APIData { Value=166, timestamp = new DateTime(2018, 1, 4) },
            //    new APIData { Value=166, timestamp = new DateTime(2018, 1, 5) },
            //    new APIData { Value=228, timestamp = new DateTime(2018, 1, 6) },
            //    new APIData { Value=147, timestamp = new DateTime(2018, 1, 7) },
            //    new APIData { Value=169, timestamp = new DateTime(2018, 1, 8) },
            //    new APIData { Value=163, timestamp = new DateTime(2018, 1, 9) }
            //});
            //datas.Add("employee-diagnostic-total-test-1", new List<APIData> {
            //    new APIData { Value=128.239, timestamp = new DateTime(2018, 1, 1) },
            //    new APIData { Value=59.508, timestamp = new DateTime(2018, 1, 2) },
            //    new APIData { Value=-237.588, timestamp = new DateTime(2018, 1, 3) },
            //    new APIData { Value=-167.708, timestamp = new DateTime(2018, 1, 4) },
            //    new APIData { Value=-168.698, timestamp = new DateTime(2018, 1, 5) },
            //    new APIData { Value=-326.124, timestamp = new DateTime(2018, 1, 6) },
            //    new APIData { Value=-119.652, timestamp = new DateTime(2018, 1, 7) },
            //    new APIData { Value=-175.195, timestamp = new DateTime(2018, 1, 8) },
            //    new APIData { Value=-159.209, timestamp = new DateTime(2018, 1, 9) }
            //});

            //datas.Add("equipment-diagnostic-koef-test-1", new List<APIData> {
            //    new APIData { Value=35, timestamp = new DateTime(2018, 1, 1) },
            //    new APIData { Value=44, timestamp = new DateTime(2018, 1, 2) },
            //    new APIData { Value=59, timestamp = new DateTime(2018, 1, 3) },
            //    new APIData { Value=36, timestamp = new DateTime(2018, 1, 4) },
            //    new APIData { Value=36, timestamp = new DateTime(2018, 1, 5) },
            //    new APIData { Value=33, timestamp = new DateTime(2018, 1, 6) },
            //    new APIData { Value=36, timestamp = new DateTime(2018, 1, 7) },
            //    new APIData { Value=37, timestamp = new DateTime(2018, 1, 8) },
            //    new APIData { Value=37, timestamp = new DateTime(2018, 1, 9) }
            //});

            //datas.Add("equipment-diagnostic-total-test-1", new List<APIData> {
            //    new APIData { Value=10.798, timestamp = new DateTime(2018, 1, 1) },
            //    new APIData { Value=9.372, timestamp = new DateTime(2018, 1, 2) },
            //    new APIData { Value=6.813, timestamp = new DateTime(2018, 1, 3) },
            //    new APIData { Value=10.663, timestamp = new DateTime(2018, 1, 4) },
            //    new APIData { Value=10.610, timestamp = new DateTime(2018, 1, 5) },
            //    new APIData { Value=11.100, timestamp = new DateTime(2018, 1, 6) },
            //    new APIData { Value=10.562, timestamp = new DateTime(2018, 1, 7) },
            //    new APIData { Value=10.488, timestamp = new DateTime(2018, 1, 8) },
            //    new APIData { Value=10.515, timestamp = new DateTime(2018, 1, 9) }
            //});

            //datas.Add("area-diagnostic-koef-test-1", new List<APIData> {
            //    new APIData { Value=8, timestamp = new DateTime(2018, 1, 1) },
            //    new APIData { Value=11, timestamp = new DateTime(2018, 1, 2) },
            //    new APIData { Value=26, timestamp = new DateTime(2018, 1, 3) },
            //    new APIData { Value=22, timestamp = new DateTime(2018, 1, 4) },
            //    new APIData { Value=22, timestamp = new DateTime(2018, 1, 5) },
            //    new APIData { Value=30, timestamp = new DateTime(2018, 1, 6) },
            //    new APIData { Value=20, timestamp = new DateTime(2018, 1, 7) },
            //    new APIData { Value=23, timestamp = new DateTime(2018, 1, 8) },
            //    new APIData { Value=22, timestamp = new DateTime(2018, 1, 9) }
            //});

            //datas.Add("area-diagnostic-total-test-1", new List<APIData> {
            //    new APIData { Value=3300, timestamp = new DateTime(2018, 1, 1) },
            //    new APIData { Value=4740, timestamp = new DateTime(2018, 1, 2) },
            //    new APIData { Value=11220, timestamp = new DateTime(2018, 1, 3) },
            //    new APIData { Value=9720, timestamp = new DateTime(2018, 1, 4) },
            //    new APIData { Value=9780, timestamp = new DateTime(2018, 1, 5) },
            //    new APIData { Value=13140, timestamp = new DateTime(2018, 1, 6) },
            //    new APIData { Value=8640, timestamp = new DateTime(2018, 1, 7) },
            //    new APIData { Value=9900, timestamp = new DateTime(2018, 1, 8) },
            //    new APIData { Value=9600, timestamp = new DateTime(2018, 1, 9) }
            //});
            #endregion
            Dictionary<string, List<GranuleViewModel>> resultYear = 
                new Dictionary<string, List<GranuleViewModel>>();
            foreach (var elem in datas)
            {
                dataSeries.InitSeries(new InitSeriesDto
                {
                    SeriesName = elem.Key
                }, false, elem.Value);

                var res = dataSeries.Diagnostic(new DiagnosticDto
                {
                    SeriesName = elem.Key
                }, elem.Value);

                resultYear.Add(elem.Key, res);
            }

            string f = "";

            //Task<HttpResponseMessage> response = client.GetAsync(string.Format("{0}api/1.0/balance/balance-employees?versionId={1}&unitId={2}&workTypeId=&toolGroupId=", ip, versionId, unitId));
            //if (response.Result.IsSuccessStatusCode)
            //{
            //    var stringd = response.Result.Content.ReadAsStringAsync();
            //    JavaScriptSerializer ser = new JavaScriptSerializer();
            //    var res = ser.Deserialize< ResponseDiagnosticDto >(stringd.Result);

            //    ResponseDiagnosticDto list = JsonConvert.DeserializeObject<ResponseDiagnosticDto>(stringd.Result);
            //    if (list != null)
            //    {
            //        var result = dataSeries.Diagnostic(new DiagnosticDto
            //        {
            //            SeriesName = "balance-employees-koef",
            //            VersionId = versionId,
            //            UnitId = unitId,
            //            Url = string.Format("{0}api/1.0/balance/balance-employees?versionId={1}&unitId={2}&workTypeId=&toolGroupId=", ip, versionId, unitId),
            //            Key = "Коэффициент загрузки по ОПР. %"
            //        });
            //        dataSeries.Diagnostic(new DiagnosticDto
            //        {
            //            SeriesName = "balance-employees-total",
            //            VersionId = versionId,
            //            UnitId = unitId,
            //            Url = string.Format("{0}api/1.0/balance/balance-employees?versionId={1}&unitId={2}&workTypeId=&toolGroupId=", ip, versionId, unitId),
            //            Key = "Профицит/дефицит, чел."
            //        });
            //        return new JsonResult { Data = result };
            //    }
            //    else
            //    {
            //        throw new Exception("Ряд не получен");
            //    }
            //}
            //else
            //{
            //    throw new Exception(response.Result.Content.ReadAsStringAsync().Result);
            //}
        }
    }
}
