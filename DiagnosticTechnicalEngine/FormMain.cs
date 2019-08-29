using DTE_Implement_Level;
using System;
using System.Windows.Forms;

namespace DiagnosticTechnicalEngine
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void runExperimentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if(fbd.ShowDialog() == DialogResult.OK)
            {
                ExperimentByForecast exp = new ExperimentByForecast();
                exp.RunExperiment(fbd.SelectedPath);
            }
        }

        private void результатыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.FormExperimentByForecast form = new Forms.FormExperimentByForecast();
            form.Show();
        }
    }
}
