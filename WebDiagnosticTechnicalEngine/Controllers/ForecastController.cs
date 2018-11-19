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
        public void Check()
        {
            //string ip = "https://212.8.234.87/";

            //string ip = "https://ois.ustu:8443/";
            //int versionId = 3;
            //HttpClient client = new HttpClient();
            //ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            //client.DefaultRequestHeaders.Accept.Clear();
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //client.BaseAddress = new Uri(ip);

            Dictionary<string, List<APIData>> datas = new Dictionary<string, List<APIData>>();
            datas.Add("employee-test-1", new List<APIData> {
                new APIData { Value=382.6302751, timestamp = new DateTime(2018, 1, 1) },
                new APIData { Value=313.8986417, timestamp = new DateTime(2018, 1, 2) },
                new APIData { Value=16.80342435, timestamp = new DateTime(2018, 1, 3) },
                new APIData { Value=86.68324348, timestamp = new DateTime(2018, 1, 4) },
                new APIData { Value=85.6927287, timestamp = new DateTime(2018, 1, 5) },
                new APIData { Value=28.26744174, timestamp = new DateTime(2018, 1, 6) },
                new APIData { Value=134.73912, timestamp = new DateTime(2018, 1, 7) },
                new APIData { Value=79.19606783, timestamp = new DateTime(2018, 1, 8) },
                new APIData { Value=95.1819865, timestamp = new DateTime(2018, 1, 9) }//,
                //new APIData { Value=208.78212, timestamp = new DateTime(2018, 1, 10) },
                //new APIData { Value=316.7589, timestamp = new DateTime(2018, 1, 11) },
                //new APIData { Value=508.78212, timestamp = new DateTime(2018, 1, 12) },
            });

            datas.Add("equipment-test-1", new List<APIData> {
                new APIData { Value=27.41282497, timestamp = new DateTime(2018, 1, 1) },
                new APIData { Value=25.98715001, timestamp = new DateTime(2018, 1, 2) },
                new APIData { Value=23.42815815, timestamp = new DateTime(2018, 1, 3) },
                new APIData { Value=27.27796036, timestamp = new DateTime(2018, 1, 4) },
                new APIData { Value=27.22512584, timestamp = new DateTime(2018, 1, 5) },
                new APIData { Value=27.71489084, timestamp = new DateTime(2018, 1, 6) },
                new APIData { Value=27.17638709, timestamp = new DateTime(2018, 1, 7) },
                new APIData { Value=27.10292234, timestamp = new DateTime(2018, 1, 8) },
                new APIData { Value=27.13002584, timestamp = new DateTime(2018, 1, 9) }
            });

            datas.Add("area-test-1", new List<APIData> {
                new APIData { Value=472, timestamp = new DateTime(2018, 1, 1) },
                new APIData { Value=880, timestamp = new DateTime(2018, 1, 2) },
                new APIData { Value=1976, timestamp = new DateTime(2018, 1, 3) },
                new APIData { Value=1896, timestamp = new DateTime(2018, 1, 4) },
                new APIData { Value=1968, timestamp = new DateTime(2018, 1, 5) },
                new APIData { Value=2584, timestamp = new DateTime(2018, 1, 6) },
                new APIData { Value=1952, timestamp = new DateTime(2018, 1, 7) },
                new APIData { Value=2264, timestamp = new DateTime(2018, 1, 8) },
                new APIData { Value=2216, timestamp = new DateTime(2018, 1, 9) }
            });

            List<double> result = new List<double>();
            Dictionary<string, List<double>> resultYear = new Dictionary<string, List<double>>();


            foreach (var elem in datas)
            {
                dataSeries.Flush(new SeriesDescriptionBindingModel
                {
                    SeriesName = elem.Key
                });
                dataSeries.InitSeries(new InitSeriesDto
                {
                    SeriesName = elem.Key
                }, true, elem.Value);

                var res = dataSeries.MakeForecast(new ForecastDto
                {
                    SeriesName = elem.Key
                }, elem.Value);

                result.Add(res);

                resultYear.Add(elem.Key, new List<double> { res });

                for (int i = 0; i < 5; ++i)
                {
                    dataSeries.Flush(new SeriesDescriptionBindingModel
                    {
                        SeriesName = elem.Key
                    });
                    elem.Value.Add(new APIData { Value = res, timestamp = new DateTime() });
                    res = dataSeries.MakeForecast(new ForecastDto
                    {
                        SeriesName = elem.Key
                    }, elem.Value, false);

                    resultYear[elem.Key].Add(res);
                }
            }

            string f = "";

            //Task<HttpResponseMessage> response = client.GetAsync(string.Format("{0}api/1.0/timeseries/employee?versionId={1}", ip, versionId));
            //if (response.Result.IsSuccessStatusCode)
            //{
            //    var stringd = response.Result.Content.ReadAsStringAsync();
            //    ResponseForecastDto list = JsonConvert.DeserializeObject<ResponseForecastDto>(stringd.Result);
            //    if (list != null)
            //    {
            //        var res = dataSeries.MakeForecast(new ForecastDto
            //        {
            //            SeriesName = "employee",
            //            VersionId = versionId
            //        });
            //        return new JsonResult { Data = res };
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
