using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WebDiagnosticTechnicalEngine.Models
{
    public class ResponseDiagnosticRecordDto
    {
        public string Key { get; set; }
        
        public List<double> Values { get; set; }
    }
}