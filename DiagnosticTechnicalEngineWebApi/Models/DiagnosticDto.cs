﻿using System.Collections.Generic;

namespace DiagnosticTechnicalEngineWebApi.Models
{
    public class DiagnosticDto
    {
        /// <summary>
        /// Название серии (чтобы искать в базе)
        /// </summary>
        public string SeriesName { get; set; }

        /// <summary>
        /// Времянной ряд
        /// </summary>
        public List<DataSeriesDto> DiagnosticList { get; set; }

        /// <summary>
        /// Требуется ли прогнозирование по ряду
        /// </summary>
        public bool NeedForecast { get; set; }
    }
}