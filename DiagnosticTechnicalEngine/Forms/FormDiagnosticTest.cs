using System.Windows.Forms;

namespace DiagnosticTechnicalEngine.Forms
{
	public partial class FormDiagnosticTest : Form
	{
		private int _diagnosticTestId;

		public FormDiagnosticTest(int? diagnosticTestId, int? seriesId)
		{
			InitializeComponent();
			userControlAnalysisSeries.DiagnosticTestId = diagnosticTestId;
			userControlAnalysisSeries.SeriesId = seriesId;
			if(diagnosticTestId.HasValue)
			{
				userControlStatisticEntropy.DiagnosticTestId = diagnosticTestId.Value;
				userControlStatisticFuzzy.DiagnosticTestId = diagnosticTestId.Value;
				userControlAnomalyInfo.DiagnosticTestId = diagnosticTestId.Value;
				userControlGranuleUX.DiagnosticTestId = diagnosticTestId.Value;
				userControlGranuleFT.DiagnosticTestId = diagnosticTestId.Value;
				userControlGranuleEntropy.DiagnosticTestId = diagnosticTestId.Value;
				userControlGranuleFuzzy.DiagnosticTestId = diagnosticTestId.Value;
			}
		}
	}
}
