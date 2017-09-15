using System.Windows.Forms;

namespace DiagnosticTechnicalEngine.Forms
{
	public partial class FormDiagnosticTest : Form
	{
		public FormDiagnosticTest(int? diagnosticTestId, int? seriesId)
		{
			InitializeComponent();
            if (seriesId.HasValue)
            {
                userControlAnalysisSeries.SeriesId = seriesId;
            }
            else
            {
                tabControl.TabPages.Remove(tabPageLoadSeries);
            }
			if(diagnosticTestId.HasValue)
			{
                userControlDiagnosticTestRecord.DiagnosticTestId = diagnosticTestId.Value;
				userControlGranuleUX.DiagnosticTestId = diagnosticTestId.Value;
				userControlGranuleFT.DiagnosticTestId = diagnosticTestId.Value;
				userControlGranuleEntropy.DiagnosticTestId = diagnosticTestId.Value;
				userControlGranuleFuzzy.DiagnosticTestId = diagnosticTestId.Value;
			}
		}
	}
}
