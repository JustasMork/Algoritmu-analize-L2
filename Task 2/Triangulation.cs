using System;
using System.Collections.Generic;
using System.Linq;

namespace L2
{
    class Triangulation
    {
        protected List<Point> polygon;
        protected Random random;
        protected int counter;

        public virtual double getMinPerimeter(int start, int end) { throw new NotImplementedException(); }
        

        public void GeneratePolygon(int numberOfPoints)
        {

            while (polygon.Count != numberOfPoints)
            {
                Point point = new Point(random.Next(10), random.Next(10));
                if (polygon.Count == 0 || polygon.Any(item => point.isDifferent(item)))
                {
                    polygon.Add(point);
                    counter++;
                    Console.WriteLine(point);
                }
            }
        }
        public Triangulation()
        {
            random = new Random();
            polygon = new List<Point>();
        }

        public int getNumPoints()
        {
            return counter;
        }

        public void addPoint(Point point)
        {
            if (polygon.Count == 0 || polygon.Any(item => point.isDifferent(item)))
            {
                polygon.Add(point);
                counter++;
            }

        }

        protected double getMinFromArray(double[] array)
        {
            double min = Double.MaxValue;
            foreach (double i in array)
            {
                if (min.CompareTo(i) == 1)
                    min = i;
            }
            return min;
        }



        public double getPerimeter(int a, int b, int c)
        {
            double firstPair = Math.Sqrt(Math.Pow((polygon[a].getX() - polygon[b].getX()), 2) + Math.Pow(polygon[a].getY() - polygon[b].getY(), 2));
            double secondPair = Math.Sqrt(Math.Pow((polygon[b].getX() - polygon[c].getX()), 2) + Math.Pow(polygon[b].getY() - polygon[c].getY(), 2));
            double thirdPair = Math.Sqrt(Math.Pow((polygon[c].getX() - polygon[a].getX()), 2) + Math.Pow(polygon[c].getY() - polygon[a].getY(), 2));

            return firstPair + secondPair + thirdPair;
        }

    }
}
