using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BL
{
    public class Circle
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double R { get; set; }
    }
    public class CircleUtility
    {
        public List<Circle> Circles;
        public CircleUtility(double[,] arr)
        {
            Circles = ArrToCircleList(arr);
        }

        public List<Circle> aloneCircles = new List<Circle>();
        public List<Circle> FindAllAloneCircles() // заполняет лист непересекающихся кругов
        {
            aloneCircles.Clear();
            for (int i = 0; i < Circles.Count; i++)
            {
                if (IsCircleAlone(i))
                    aloneCircles.Add(Circles[i]);
            }
            return aloneCircles;
        }
        public bool IsCircleAlone(int i) // проверяем i-тый круг на пересечение с другими кругами
        {
            for (int n = 0; n < Circles.Count; n++)
            {
                if (n != i)
                {
                    if (DistanceBetweenPoints(Circles[i].X, Circles[i].Y, Circles[n].X, Circles[n].Y) < (Circles[i].R + Circles[n].R))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public double DistanceBetweenPoints(double x1, double y1, double x2, double y2) // расстояние между двумя точками
        {
            return Math.Sqrt((x1 - x2)*(x1 - x2) + (y1 - y2)*(y1 - y2));
        } 
        public void Init()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        }
        public bool CheckingThatRadiusMoreThan0 (List<Circle> list1)
        {
            for(int k = 0; k < list1.Count; k++)
            {
                if (list1[k].R <= 0)
                    return false;
            }
            return true;
        }
        public double[,] CircleListToArr(List<Circle> list)
        {
            double[,] arr = new double[list.Count, 3];
            for (int i = 0; i < list.Count; i ++)
            {
                arr[i, 0] = list[i].X;
                arr[i, 1] = list[i].Y;
                arr[i, 2] = list[i].R;
            }
            return arr;
        }
        public List<Circle> ArrToCircleList(double[,] circles)
        {
            List < Circle > list = new List<Circle>();
            for ( int i = 0; i < circles.GetLength(0); i ++ )
            {
                list.Add(ArrayToCircle(circles[i, 0], circles[i, 1], circles[i, 2]));
            }
            return list;
        }
        private Circle ArrayToCircle(double x , double y , double r)
        {
            Circle circle = new Circle();
            circle.X = x;
            circle.Y = y;
            circle.R = r;
            return circle;
        }
    }
}
