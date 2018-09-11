using ServicesModule;
using ServicesModule.BindingModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WebDiagnosticTechnicalEngine.Models;

namespace WebDiagnosticTechnicalEngine.Services
{
    public class DatatSeries
    {
        /// <summary>
        /// Метод получения набора данных через запрос к webAPI
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private List<APIData> GetData(InitSeriesDto model)
        {
            List<APIData> data = new List<APIData>();

            string url = model.Url;

            var pattern = Regex.Match(url, @"versionId=[\d+]");
            if (pattern.Success)
            {
                url = url.Replace(pattern.Value, string.Format("versionId={0}", model.VersionId));
            }

            HttpClient client = new HttpClient();
            var byteArray = Encoding.ASCII.GetBytes("admin:admin");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            client.BaseAddress = new Uri("https://212.8.234.87/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            Task<HttpResponseMessage> response = client.GetAsync(url);
            if (response.Result.IsSuccessStatusCode)
            {
                List<APIData> list = response.Result.Content.ReadAsAsync<List<APIData>>().Result;
                if (list != null)
                {
                    return list;
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

        public void InitSeries(InitSeriesDto model)
        {
            APIService service = new APIService();
            service.InitSeries(new SeriesDescriptionBindingModel
            {
                SeriesName = model.SeriesName,
                SeriesDiscription = model.Url,
                NeedForecast = true
            }, GetData(model));
        }

        public double MakeForecast(ForecastDto model)
        {
            APIService service = new APIService();
            return
            service.MakeForecast(new SeriesDescriptionBindingModel
            {
                SeriesName = model.SeriesName,
                NeedForecast = true
            }, GetData(new InitSeriesDto
            {
                SeriesName = model.SeriesName,
                Url = service.GetSeriesUrl(new SeriesDescriptionBindingModel
                {
                    SeriesName = model.SeriesName
                }),
                VersionId = model.VersionId
            }));
        }
    }
}