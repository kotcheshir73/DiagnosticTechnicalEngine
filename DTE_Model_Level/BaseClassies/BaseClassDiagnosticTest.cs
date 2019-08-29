using DTE_Model_Level.Models;

namespace DTE_Model_Level.BaseClassies
{
	public class BaseClassDiagnosticTest : BaseClass
	{
		public int DiagnosticTestId { get; set; }

		public virtual DiagnosticTest DiagnosticTest { get; set; }
	}
}