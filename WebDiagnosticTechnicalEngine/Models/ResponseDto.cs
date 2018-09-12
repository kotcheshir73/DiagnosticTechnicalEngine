using ServicesModule.BindingModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebDiagnosticTechnicalEngine.Models
{
    public class ResponseDto
    {
        public List<APIData> Data { get; set; }
    }
}