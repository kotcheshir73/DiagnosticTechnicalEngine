using System;

namespace DatabaseModule.Models
{
    public class ExperimentFileResult
    {
        public int Id { get; set; }

        public string FileName { get; set; }

        public DateTime DateExperiment { get; set; }

        public double Forecast { get; set; }

        public double RealValue { get; set; }

        public string ForecastsByPoint { get; set; }
    }
}
