using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesModule
{
    public class ExperimentByForecast
    {
        private int countCenters = 5;

        public void RunExperiment(string path)
        {
            if(Directory.Exists(path))
            {
                var info = new DirectoryInfo(path);
                var files = info.GetFiles();
                foreach(var file in files)
                {
                    List<double> values = LoadFromTxt(file.FullName);
                    var clust = new ModelClustering(file.FullName, 1, countCenters);
                }
            }
        }
        /// <summary>
        /// Загрузка точек из файла
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private List<double> LoadFromTxt(string fileName)
        {
            StreamReader stream = null;
            List<double> values = new List<double>();
            try
            {
                stream = new StreamReader(fileName);
                string read = stream.ReadLine();
                while (read != null)
                {
                    read = read.Replace(" ", "");
                    if (double.TryParse(read.Replace('.', ','), out double val))
                    {
                        values.Add(val);
                    }
                    else if (double.TryParse(read.Replace(',', '.'), out val))
                    {
                        values.Add(val);
                    }
                    else
                    {
                        values.Add(Convert.ToDouble(read));
                    }

                    read = stream.ReadLine();
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
            }

            return values;
        }
    }
}
