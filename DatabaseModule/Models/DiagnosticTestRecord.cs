using DatabaseModule.BaseClassies;

namespace DatabaseModule
{
    public class DiagnosticTestRecord : BaseClassDiagnosticTest
	{
        public int AnomalyInfoId { get; set; }

        public AnomalyInfo AnomalyInfo { get; set; }

        public int? PointNumber { get; set; }

		public string Description { get; set; }
	}
}
