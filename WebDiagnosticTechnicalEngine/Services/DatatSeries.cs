using DTE_Implement_Level;
using DTE_Interface_Level.BindingModels;
using DTE_Interface_Level.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
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
        private List<APIData> GetData(InitSeriesDto model, string key = null)
        {
            string url = model.Url;

            var pattern = Regex.Match(url, @"versionId=[\d+]");
            if (pattern.Success)
            {
                url = url.Replace(pattern.Value, string.Format("versionId={0}", model.VersionId));
            }

            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri("https://212.8.234.87/")
            };
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            Task<HttpResponseMessage> response = client.GetAsync(url);
            if (response.Result.IsSuccessStatusCode)
            {
                if (!string.IsNullOrEmpty(key))
                {
                    var stringResult = response.Result.Content.ReadAsStringAsync();
                    ResponseDiagnosticDto list = JsonConvert.DeserializeObject<ResponseDiagnosticDto>(stringResult.Result);
                    if (list != null)
                    {
                        var resList = list.Data.FirstOrDefault(x => x.Key == key).Values.Select(x => new APIData
                        {
                            timestamp = DateTime.Now,
                            Value = x
                        }).ToList();
                        return resList;
                    }
                    else
                    {
                        throw new Exception("Ряд не получен");
                    }
                }
                else
                {
                    var stringResult = response.Result.Content.ReadAsStringAsync();
                    ResponseForecastDto list = JsonConvert.DeserializeObject<ResponseForecastDto>(stringResult.Result);
                    if (list != null)
                    {
                        return list.Data;
                    }
                    else
                    {
                        throw new Exception("Ряд не получен");
                    }
                }
            }
            else
            {
                throw new Exception(response.Result.Content.ReadAsStringAsync().Result);
            }
        }

        private List<ResponseDiagnosticRecordDto> GetData(DiagnosticDto model)
        {
            string url = model.Url;

            var pattern = Regex.Match(url, @"versionId=[\d+]");
            if (pattern.Success)
            {
                url = url.Replace(pattern.Value, string.Format("versionId={0}", model.VersionId));
            }

            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri("https://212.8.234.87/")
            };
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            Task<HttpResponseMessage> response = client.GetAsync(url);
            if (response.Result.IsSuccessStatusCode)
            {
                var stringResult = response.Result.Content.ReadAsStringAsync();
                ResponseDiagnosticDto list = JsonConvert.DeserializeObject<ResponseDiagnosticDto>(stringResult.Result);
                if (list != null)
                {
                    return list.Data;
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

        public void InitSeries(InitSeriesDto model, bool needForecast, string key = null)
        {
            APIService service = new APIService();
            service.InitSeries(new SeriesDescriptionBindingModel
            {
                SeriesName = model.SeriesName,
                SeriesDiscription = model.Url,
                NeedForecast = needForecast
            }, GetData(model, key));
        }

        public void InitSeries(InitSeriesDto model, bool needForecast, List<APIData> data)
        {
            APIService service = new APIService();
            service.InitSeries(new SeriesDescriptionBindingModel
            {
                SeriesName = model.SeriesName,
                SeriesDiscription = model.Url,
                NeedForecast = needForecast
            }, data);
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

        public void Flush(SeriesDescriptionBindingModel model)
        {
            APIService service = new APIService();
            service.FlushStat(model);
        }

        public double MakeForecast(ForecastDto model, List<APIData> data, bool notchangestat = false)
        {
            APIService service = new APIService();
            return
            service.MakeForecast(new SeriesDescriptionBindingModel
            {
                SeriesName = model.SeriesName,
                NeedForecast = true
            }, data, notchangestat);
        }

        public List<GranuleViewModel> Diagnostic(DiagnosticDto model)
        {
            APIService service = new APIService();
            return
            service.Diagnostic(new SeriesDescriptionBindingModel
            {
                SeriesName = model.SeriesName,
                NeedForecast = false
            }, GetData(new InitSeriesDto
            {
                SeriesName = model.SeriesName,
                Url = service.GetSeriesUrl(new SeriesDescriptionBindingModel
                {
                    SeriesName = model.SeriesName
                }),
                VersionId = model.VersionId
            }, model.Key));
        }

        public List<GranuleViewModel> Diagnostic(DiagnosticDto model, List<APIData> data)
        {
            APIService service = new APIService();
            return
            service.Diagnostic(new SeriesDescriptionBindingModel
            {
                SeriesName = model.SeriesName,
                NeedForecast = false
            }, data);
        }
    }
}