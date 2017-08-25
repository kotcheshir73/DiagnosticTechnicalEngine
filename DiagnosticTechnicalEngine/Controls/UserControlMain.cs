using System.Windows.Forms;

namespace DiagnosticTechnicalEngine.Controls
{
    public partial class UserControlMain : UserControl
    {
        public UserControlMain()
        {
            InitializeComponent();

            userControlSeriesDescription.LoadData();
            userControlSeriesDescription.AddEvent(LoadSeries);
        }

        public void LoadSeries(int id)
        {
            userControlSeriesInfo.SeriesId = id;
        }
	}
}
