using DTE_Interface_Level.BindingModels;
using System;
using System.Collections.Generic;
using System.IO;

namespace DTE_Implement_Level
{
    /// <summary>
    /// 
    /// </summary>
    public class ModelClustering
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly double fuzzyness;
        /// <summary>
        /// 
        /// </summary>
        private readonly double accuracy;

        public List<ClusterCenter> Centers { set; get; }

        public List<ClusterPoint> Points { set; get; }

        public double[,] U2 { get; private set; }
        /// <summary>
        /// Кластеризация ряда
        /// </summary>
        /// <param name="data">данные</param>
        /// <param name="_accuracy">точность</param>
        public ModelClustering(string path, int type, int countCenters, List<APIData> data = null)
        {
            Centers = new List<ClusterCenter>();
            for (int i = 0; i < countCenters; ++i)
                Centers.Add(new ClusterCenter(0));
            switch(type)
            {
                case 0: LoadFromExcel(path); break;
                case 1: LoadFromTXT(path); break;
                case 2: LoadFromAPI(data); break;
            }
            accuracy = Math.Pow(10, -5);
            fuzzyness = 2;
        }

        private void LoadFromExcel(string path)
        {
   //         var excel = new Microsoft.Office.Interop.Excel.Application();
   //         try
   //         {
   //             var workbook = excel.Workbooks.Open(path, Type.Missing, Type.Missing, Type.Missing, Type.Missing, 
   //                 Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, 
   //                 Type.Missing, Type.Missing, Type.Missing);
   //             var excelworksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets.get_Item(1);//Получаем ссылку на лист 1
   //             var excelcell = excelworksheet.get_Range("A2", "A2");
   //             Points = new List<ClusterPoint>();
   //             while (excelcell.Value2 != null)
   //             { 
   //                 double val = 0;
   //                 if (double.TryParse(excelcell.get_Offset(0, 1).Value2.ToString(), out val))
   //                     Points.Add(new ClusterPoint(val));
   //                 else
   //                     break;
   //                 excelcell = excelcell.get_Offset(1, 0);
   //             }
   //             workbook.Close(false, Type.Missing, Type.Missing);
   //             excel.Quit();
   //         }
   //         catch (Exception)
			//{
			//	throw;
			//}
        }

        private void LoadFromTXT(string path)
        {
            try
            {
                var reading = new StreamReader(path);
                string read = reading.ReadLine();
                Points = new List<ClusterPoint>();
                while (read != null)
                {
                    if (double.TryParse(read.Replace('.', ','), out double val))
                        Points.Add(new ClusterPoint(val));
                    else if (double.TryParse(read.Replace(',', '.'), out val))
                        Points.Add(new ClusterPoint(val));
                    else
                        break;
                    read = reading.ReadLine();
                }
                reading.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void LoadFromAPI(List<APIData> data)
        {
            try
            {
                Points = new List<ClusterPoint>();
                foreach (var dat in data)
                {
                    Points.Add(new ClusterPoint(dat.Value));
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Расчет 
        /// </summary>
        public bool Calc()
        {
            if (Points != null && Points.Count > 0 && Centers != null && Centers.Count > 0)
                U2 = new double[Points.Count, Centers.Count];
            else 
                return false;
            Random rand = new Random();
            for (int i = 0; i < Points.Count; i++)//формируем матрицу U
                for (int j = 0; j < Centers.Count; j++)
                    U2[i, j] = (double)rand.Next(1, 1000) / 1000;
            CalcClusterCenters();
            RecalcClusterPointIndex();
            int maxSteps = 100;
            for (int i = 0; i < maxSteps; i++)
            {
                double jfirst = CalcObjectiveFunction();
                CalcClusterCenters();
                Step();
                double jsecond = CalcObjectiveFunction();
                if (Math.Abs(jfirst - jsecond) < accuracy) return true;
            }
            return false;
        }
        /// <summary>
        /// Перерасчет кластерных центров
        /// </summary>
        private void CalcClusterCenters()
        {
            for (int j = 0; j < Centers.Count; j++)
            {
                double newX = 0.0;
                double l = 0.0;
                for (int i = 0; i < Points.Count; i++)
                {
                    double temp = Math.Pow(U2[i, j], fuzzyness);
                    newX += temp * Points[i].X;
                    l += temp;
                }
                Centers[j].X = newX / l;
            }
        }
        /// <summary>
        /// Рачет/перерасчет принадлежности точек к центрам кластеров
        /// </summary>
        private void RecalcClusterPointIndex()
        {
            for (int i = 0; i < Points.Count; i++)
            {
                double max = -1.0;
                for (int j = 0; j < Centers.Count; j++)
                {
                    if (max < U2[i, j])
                    {
                        max = U2[i, j];
                        Points[i].ClusterIndex = (max == 0.5) ? 0.5 : j;
                    }
                }
            }
        }
        /// <summary>
        /// Что-то считаем )))))
        /// </summary>
        /// <returns></returns>
        private double CalcObjectiveFunction()
        {
            double J = 0;
            for (int i = 0; i < Points.Count; i++)
            {
                for (int j = 0; j < Centers.Count; j++)
                {
                    J += Math.Pow(U2[i, j], fuzzyness) * Math.Pow(CalcDistanse(Points[i].X, Centers[j]), 2);
                }
            }
            return J;
        }
        /// <summary>
        /// Расчет расстояния между точкой и центром
        /// </summary>
        /// <param name="value">значение точки</param>
        /// <param name="center">центр кластеризации</param>
        /// <returns>расстояние</returns>
        private double CalcDistanse(double value, ClusterCenter center)
        {
            return Math.Sqrt(Math.Pow(value - center.X, 2));
        }
        /// <summary>
        /// Шаг клатсеризации
        /// </summary>
        private void Step()
        {
            for (int j = 0; j < Centers.Count; j++)
            {
                for (int i = 0; i < Points.Count; i++)
                {
                    double top = CalcDistanse(Points[i].X, Centers[j]);
                    if (top < 1.0) top = Math.Pow(10, -5);
                    double sum = 0.0;
                    for (int k = 0; k < Centers.Count; k++)
                    {
                        double distance = CalcDistanse(Points[i].X, Centers[k]);
                        if (distance < 1.0) distance = Math.Pow(10, -5);
                        sum += Math.Pow(top / distance, 2.0 / (fuzzyness - 1.0));
                    }
                    U2[i, j] = 1.0 / sum;
                }
            }
            RecalcClusterPointIndex();
        }
    }
}