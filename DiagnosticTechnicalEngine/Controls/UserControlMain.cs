using DTE_Implement_Level.Implementations;
using System.Windows.Forms;

namespace DiagnosticTechnicalEngine.Controls
{
    public partial class UserControlMain : UserControl
	{
		private UserControlSeriesDescription controlSeriesDescription;

		public UserControlMain()
		{
			InitializeComponent();
			controlSeriesDescription = new UserControlSeriesDescription
			{
				BackColor = System.Drawing.Color.Transparent,
				Location = new System.Drawing.Point(0, 0),
				MinimumSize = new System.Drawing.Size(450, 400),
				Name = "userControlSeriesDescription",
				Size = new System.Drawing.Size(350, 730),
				Dock = DockStyle.Left,
				TabIndex = 1
			};
			controlSeriesDescription.Initialize(new SeriesDescriptionService());
			controlSeriesDescription.AddEvent(LoadSeries);
			controlSeriesDescription.ParentId = 1;

			Controls.Add(controlSeriesDescription);
		}

		public void LoadSeries(int id)
		{
			userControlSeriesInfo.SeriesId = id;
		}
	}
}
