using ServicesModule;
using ServicesModule.BindingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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


            return data;
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
            //return
            //service.MakeForecast(new SeriesDescriptionBindingModel
            //{
            //    SeriesName = model.SeriesName,
            //    NeedForecast = true
            //}, GetData(model));

            return 0;
        }
    }
}