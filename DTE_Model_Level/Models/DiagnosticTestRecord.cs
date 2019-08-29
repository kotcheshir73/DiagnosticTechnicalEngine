using DTE_Model_Level.BaseClassies;

namespace DTE_Model_Level.Models
{
    public class DiagnosticTestRecord : BaseClassDiagnosticTest
	{
        public int AnomalyInfoId { get; set; }

        public virtual AnomalyInfo AnomalyInfo { get; set; }

        public int? PointNumber { get; set; }

		public string Description { get; set; }
	}
}