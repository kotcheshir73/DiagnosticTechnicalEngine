using DTE_Interface_Level.BindingModels;
using System;
using System.Collections.Generic;
using System.Web.Http;
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
            #region Avia 1
            //datas.Add("employee-test-1", new List<APIData> {
            //    new APIData { Value=382.6302751, timestamp = new DateTime(2018, 1, 1) },
            //    new APIData { Value=313.8986417, timestamp = new DateTime(2018, 1, 2) },
            //    new APIData { Value=16.80342435, timestamp = new DateTime(2018, 1, 3) },
            //    new APIData { Value=86.68324348, timestamp = new DateTime(2018, 1, 4) },
            //    new APIData { Value=85.6927287, timestamp = new DateTime(2018, 1, 5) },
            //    new APIData { Value=28.26744174, timestamp = new DateTime(2018, 1, 6) },
            //    new APIData { Value=134.73912, timestamp = new DateTime(2018, 1, 7) },
            //    new APIData { Value=79.19606783, timestamp = new DateTime(2018, 1, 8) },
            //    new APIData { Value=95.1819865, timestamp = new DateTime(2018, 1, 9) }//,
            //    //new APIData { Value=208.78212, timestamp = new DateTime(2018, 1, 10) },
            //    //new APIData { Value=316.7589, timestamp = new DateTime(2018, 1, 11) },
            //    //new APIData { Value=508.78212, timestamp = new DateTime(2018, 1, 12) },
            //});

            //datas.Add("equipment-test-1", new List<APIData> {
            //    new APIData { Value=27.41282497, timestamp = new DateTime(2018, 1, 1) },
            //    new APIData { Value=25.98715001, timestamp = new DateTime(2018, 1, 2) },
            //    new APIData { Value=23.42815815, timestamp = new DateTime(2018, 1, 3) },
            //    new APIData { Value=27.27796036, timestamp = new DateTime(2018, 1, 4) },
            //    new APIData { Value=27.22512584, timestamp = new DateTime(2018, 1, 5) },
            //    new APIData { Value=27.71489084, timestamp = new DateTime(2018, 1, 6) },
            //    new APIData { Value=27.17638709, timestamp = new DateTime(2018, 1, 7) },
            //    new APIData { Value=27.10292234, timestamp = new DateTime(2018, 1, 8) },
            //    new APIData { Value=27.13002584, timestamp = new DateTime(2018, 1, 9) }
            //});

            //datas.Add("area-test-1", new List<APIData> {
            //    new APIData { Value=472, timestamp = new DateTime(2018, 1, 1) },
            //    new APIData { Value=880, timestamp = new DateTime(2018, 1, 2) },
            //    new APIData { Value=1976, timestamp = new DateTime(2018, 1, 3) },
            //    new APIData { Value=1896, timestamp = new DateTime(2018, 1, 4) },
            //    new APIData { Value=1968, timestamp = new DateTime(2018, 1, 5) },
            //    new APIData { Value=2584, timestamp = new DateTime(2018, 1, 6) },
            //    new APIData { Value=1952, timestamp = new DateTime(2018, 1, 7) },
            //    new APIData { Value=2264, timestamp = new DateTime(2018, 1, 8) },
            //    new APIData { Value=2216, timestamp = new DateTime(2018, 1, 9) }
            //});
            #endregion
            #region Avia 2 stanok off
            //datas.Add("Mazak VCN 410A", new List<APIData> {
            //    new APIData { Value=17.6418595679012, timestamp = new DateTime(2018, 1, 1) },
            //    new APIData { Value=9.77031063321386, timestamp = new DateTime(2018, 1, 2) },
            //    new APIData { Value=15.5857638888889, timestamp = new DateTime(2018, 1, 3) },
            //    new APIData { Value=17.9848790322581, timestamp = new DateTime(2018, 1, 4) },
            //    new APIData { Value=26.067278972521, timestamp = new DateTime(2018, 1, 5) },
            //    new APIData { Value=14.0590663580247, timestamp = new DateTime(2018, 1, 6) },
            //    new APIData { Value=8.07750896057348, timestamp = new DateTime(2018, 1, 7) },
            //    new APIData { Value=14.1573302469136, timestamp = new DateTime(2018, 1, 8) },
            //    new APIData { Value=25.3443538647342, timestamp = new DateTime(2018, 1, 9) }
            //});

            //datas.Add("Mazak VRX 630-5X", new List<APIData> {
            //    new APIData { Value=0, timestamp = new DateTime(2018, 1, 1) },
            //    new APIData { Value=0, timestamp = new DateTime(2018, 1, 2) },
            //    new APIData { Value=0, timestamp = new DateTime(2018, 1, 3) },
            //    new APIData { Value=21.9992906212664, timestamp = new DateTime(2018, 1, 4) },
            //    new APIData { Value=15.1317577658304, timestamp = new DateTime(2018, 1, 5) },
            //    new APIData { Value=24.2586805555556, timestamp = new DateTime(2018, 1, 6) },
            //    new APIData { Value=1.38541666666667, timestamp = new DateTime(2018, 1, 7) },
            //    new APIData { Value=2.65860339506172, timestamp = new DateTime(2018, 1, 8) },
            //    new APIData { Value=0.0522342995169082, timestamp = new DateTime(2018, 1, 9) }
            //});

            //datas.Add("Mazak VRX 630-5X 2", new List<APIData> {
            //    new APIData { Value=0.0265046296296296, timestamp = new DateTime(2018, 1, 1) },
            //    new APIData { Value=0.00190412186379929, timestamp = new DateTime(2018, 1, 2) },
            //    new APIData { Value=5.82689043209876, timestamp = new DateTime(2018, 1, 3) },
            //    new APIData { Value=0.529793906810036, timestamp = new DateTime(2018, 1, 4) },
            //    new APIData { Value=3.14691606929511, timestamp = new DateTime(2018, 1, 5) },
            //    new APIData { Value=1.36404320987654, timestamp = new DateTime(2018, 1, 6) },
            //    new APIData { Value=0.00896057347670251, timestamp = new DateTime(2018, 1, 7) },
            //    new APIData { Value=0.147916666666667, timestamp = new DateTime(2018, 1, 8) },
            //    new APIData { Value=0.00100644122383253, timestamp = new DateTime(2018, 1, 9) }
            //});

            //datas.Add("Mazak VCN 515C", new List<APIData> {
            //    new APIData { Value=1.61925154320988, timestamp = new DateTime(2018, 1, 1) },
            //    new APIData { Value=0.108236260454002, timestamp = new DateTime(2018, 1, 2) },
            //    new APIData { Value=1.58514660493828, timestamp = new DateTime(2018, 1, 3) },
            //    new APIData { Value=3.90901284348866, timestamp = new DateTime(2018, 1, 4) },
            //    new APIData { Value=4.39758811230586, timestamp = new DateTime(2018, 1, 5) },
            //    new APIData { Value=1.56813271604939, timestamp = new DateTime(2018, 1, 6) },
            //    new APIData { Value=4.42241636798089, timestamp = new DateTime(2018, 1, 7) },
            //    new APIData { Value=1.39510030864197, timestamp = new DateTime(2018, 1, 8) },
            //    new APIData { Value=0.00100644122383253, timestamp = new DateTime(2018, 1, 9) }
            //});

            //datas.Add("Mazak VCN 510C", new List<APIData> {
            //    new APIData { Value=10.1010802469136, timestamp = new DateTime(2018, 1, 1) },
            //    new APIData { Value=20.8652927120669, timestamp = new DateTime(2018, 1, 2) },
            //    new APIData { Value=9.34980709876543, timestamp = new DateTime(2018, 1, 3) },
            //    new APIData { Value=0.368652927120669, timestamp = new DateTime(2018, 1, 4) },
            //    new APIData { Value=9.55899044205496, timestamp = new DateTime(2018, 1, 5) },
            //    new APIData { Value=3.94375, timestamp = new DateTime(2018, 1, 6) },
            //    new APIData { Value=16.890531660693, timestamp = new DateTime(2018, 1, 7) },
            //    new APIData { Value=0.169328703703704, timestamp = new DateTime(2018, 1, 8) },
            //    new APIData { Value=3.977153784219, timestamp = new DateTime(2018, 1, 9) }
            //});
            #endregion
            #region Avai 2 stanok error
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
