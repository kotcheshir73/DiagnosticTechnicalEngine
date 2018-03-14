namespace DatabaseModule.BaseClassies
{
	public class BaseClassDiagnosticTest : BaseClass
	{
		public int DiagnosticTestId { get; set; }

		public virtual DiagnosticTest DiagnosticTest { get; set; }
	}
}
