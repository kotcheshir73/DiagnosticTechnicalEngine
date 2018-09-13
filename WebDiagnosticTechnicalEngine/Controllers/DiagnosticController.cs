using System.Web.Http;
using WebDiagnosticTechnicalEngine.Models;
using WebDiagnosticTechnicalEngine.Services;

namespace WebDiagnosticTechnicalEngine.Controllers
{
    public class DiagnosticController : ApiController
    {
        private readonly DatatSeries dataSeries;

        public DiagnosticController()
        {
            dataSeries = new DatatSeries();
        }

        public void InitSeries(InitSeriesDto model)
        {
            dataSeries.InitSeries(model);
        }

        public void MakeDiagnostic(DiagnosticDto model)
        {
        }
    }
}
