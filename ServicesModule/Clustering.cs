using System;
using System.Collections.Generic;
using System.IO;

namespace ServicesModule
{
	/// <summary>
	/// 
	/// </summary>
    public class Clustering
    {
        /// <summary>
        /// список центров кластеров
        /// </summary>
        private List<ClusterCenter> centers;
        /// <summary>
        /// список точек
        /// </summary>
        private List<ClusterPoint> points;
        /// <summary>
        /// матрица нечеткого разбиения
        /// </summary>
        private double[,] U;
        /// <summary>
        /// 
        /// </summary>
        private double fuzzyness;
        /// <summary>
        /// 
        /// </summary>
        private double accuracy;

        public List<ClusterCenter> Centers
        {
            set { centers = value; }
            get { return centers; }
        }

        public List<ClusterPoint> Points
        {
            set { points = value; }
            get { return points; }
        }

        public double[,] U2
        {
            get { return U; }
        }
        /// <summary>
        /// Кластеризация ряда
        /// </summary>
        /// <param name="data">данные</param>
        /// <param name="_accuracy">точность</param>
        public Clustering(string path, int type, int countCenters)
        {
            centers = new List<ClusterCenter>();
            for (int i = 0; i < countCenters; ++i)
                centers.Add(new ClusterCenter(0));
            switch(type)
            {
                case 0: LoadFromExcel(path); break;
                case 1: LoadFromTXT(path); break;
            }
            accuracy = Math.Pow(10, -5);
            fuzzyness = 2;
        }

        private void LoadFromExcel(string path)
        {
            var excel = new Microsoft.Office.Interop.Excel.Application();
            try
            {
                var workbook = excel.Workbooks.Open(path, Type.Missing, Type.Missing, Type.Missing, Type.Missing, 
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, 
                    Type.Missing, Type.Missing, Type.Missing);
                var excelworksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets.get_Item(1);//Получаем ссылку на лист 1
                var excelcell = excelworksheet.get_Range("A2", "A2");
                points = new List<ClusterPoint>();
                while (excelcell.Value2 != null)
                { 
                    double val = 0;
                    if (double.TryParse(excelcell.get_Offset(0, 1).Value2.ToString(), out val))
                        points.Add(new ClusterPoint(val));
                    else
                        break;
                    excelcell = excelcell.get_Offset(1, 0);
                }
                workbook.Close(false, Type.Missing, Type.Missing);
                excel.Quit();
            }
            catch (Exception)
			{
				throw;
			}
        }

        private void LoadFromTXT(string path)
        {
            try
            {
                var reading = new StreamReader(path);
                string read = reading.ReadLine();
                points = new List<ClusterPoint>();
                while (read != null)
                {
                    double val = 0;
                    if (double.TryParse(read.Replace('.', ','), out val))
                        points.Add(new ClusterPoint(val));
                    else if (double.TryParse(read.Replace(',', '.'), out val))
                        points.Add(new ClusterPoint(val));
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
        /// <summary>
        /// Расчет 
        /// </summary>
        public bool Calc()
        {
            if (points != null && points.Count > 0 && centers != null && centers.Count > 0)
                U = new double[points.Count, centers.Count];
            else 
                return false;
            Random rand = new Random();
            for (int i = 0; i < points.Count; i++)//формируем матрицу U
                for (int j = 0; j < centers.Count; j++)
                    U[i, j] = (double)rand.Next(1, 1000) / 1000;
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
            for (int j = 0; j < centers.Count; j++)
            {
                double newX = 0.0;
                double l = 0.0;
                for (int i = 0; i < points.Count; i++)
                {
                    double temp = Math.Pow(U[i, j], fuzzyness);
                    newX += temp * points[i].x;
                    l += temp;
                }
                centers[j].x = newX / l;
            }
        }
        /// <summary>
        /// Рачет/перерасчет принадлежности точек к центрам кластеров
        /// </summary>
        private void RecalcClusterPointIndex()
        {
            for (int i = 0; i < points.Count; i++)
            {
                double max = -1.0;
                for (int j = 0; j < centers.Count; j++)
                {
                    if (max < U[i, j])
                    {
                        max = U[i, j];
                        points[i].clusterIndex = (max == 0.5) ? 0.5 : j;
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
            for (int i = 0; i < points.Count; i++)
            {
                for (int j = 0; j < centers.Count; j++)
                {
                    J += Math.Pow(U[i, j], fuzzyness) * Math.Pow(CalcDistanse(points[i].x, centers[j]), 2);
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
            return Math.Sqrt(Math.Pow(value - center.x, 2));
        }
        /// <summary>
        /// Шаг клатсеризации
        /// </summary>
        private void Step()
        {
            for (int j = 0; j < centers.Count; j++)
            {
                for (int i = 0; i < points.Count; i++)
                {
                    double top = CalcDistanse(points[i].x, centers[j]);
                    if (top < 1.0) top = Math.Pow(10, -5);
                    double sum = 0.0;
                    for (int k = 0; k < centers.Count; k++)
                    {
                        double distance = CalcDistanse(points[i].x, centers[k]);
                        if (distance < 1.0) distance = Math.Pow(10, -5);
                        sum += Math.Pow(top / distance, 2.0 / (fuzzyness - 1.0));
                    }
                    U[i, j] = 1.0 / sum;
                }
            }
            RecalcClusterPointIndex();
        }
    }
}
