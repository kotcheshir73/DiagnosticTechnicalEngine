using System.Collections.Generic;

namespace WebDiagnosticTechnicalEngine.Models
{
    public class DiagnosticDto
    {
        public string SeriesName { get; set; }

        public int VersionId { get; set; }

        public int UnitId { get; set; }

        public int? WorkTypeId { get; set; }

        public int? ToolGroupId { get; set; }

        public string Url { get; set; }

        public string Key { get; set; }
    }
}