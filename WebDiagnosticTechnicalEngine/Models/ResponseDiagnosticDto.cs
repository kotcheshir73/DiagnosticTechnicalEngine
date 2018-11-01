using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WebDiagnosticTechnicalEngine.Models
{
    public class ResponseDiagnosticDto
    {
        public List<ResponseDiagnosticRecordDto> Data { get; set; }
    }
}