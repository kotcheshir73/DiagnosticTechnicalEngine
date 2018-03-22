using NLog;
using ServicesModule;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
