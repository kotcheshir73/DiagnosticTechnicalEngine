using ServicesModule.BindingModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebDiagnosticTechnicalEngine.Models
{
    public class ResponseForecastDto
    {
        public List<APIData> Data { get; set; }
    }
}