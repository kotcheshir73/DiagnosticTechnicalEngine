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
            dataSeries.InitSeries(model);
        }

        public double MakeForecast(ForecastDto model)
        {
            return 0;
        }


        /// <summary>
        /// /api/Forecast/Check
        /// </summary>
        /// <returns></returns>
        [System.Web.Http.HttpGet]
        public ActionResult Check()
        {
            CookieContainer cookies = new CookieContainer();
            HttpClientHandler handler = new HttpClientHandler
            {
                CookieContainer = cookies
            };
            HttpClient client = new HttpClient(handler);
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.BaseAddress = new Uri("https://212.8.234.87/");

            Task<HttpResponseMessage> responseAuth = client.PostAsJsonAsync("https://212.8.234.87/login", new { username = "admin", password = "admin" });

            if (responseAuth.Result.IsSuccessStatusCode)
            {
                Uri uri = new Uri("https://212.8.234.87/login");
                IEnumerable<Cookie> responseCookies = cookies.GetCookies(uri).Cast<Cookie>();

                var cookieGet = new CookieContainer();
                HttpClientHandler handlerGet = new HttpClientHandler
                {
                    CookieContainer = cookieGet
                };
                HttpClient clientGet = new HttpClient(handler)
                {
                    BaseAddress = new Uri("https://212.8.234.87/api/1.0/timeseries/employee?versionId=1")
                };
                Uri uriGet = new Uri("https://212.8.234.87/api/1.0/timeseries/employee?versionId=1");

                foreach (Cookie cookie in responseCookies)
                {
                    cookieGet.Add(uriGet, cookie);
                }

                Task<HttpResponseMessage> response = clientGet.GetAsync("https://212.8.234.87/api/1.0/timeseries/employee?versionId=1");
                if (response.Result.IsSuccessStatusCode)
                {
                    var stringd = response.Result.Content.ReadAsStringAsync();
                    List<APIData> list = response.Result.Content.ReadAsAsync<List<APIData>>().Result;
                    if (list != null)
                    {
                        return new JsonResult { Data = list };
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
            else
            {
                throw new Exception(responseAuth.Result.Content.ReadAsStringAsync().Result);
            }
        }
    }
}
