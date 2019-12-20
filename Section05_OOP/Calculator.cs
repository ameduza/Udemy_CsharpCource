using System;
using System.Collections.Generic;
using System.Text;

namespace Section05_OOP
{
    public class Calculator
    {
        public static double Avg(int[] numbers)
        {
            double sum = 0;
            foreach (var n in numbers)
            {
                sum += n;
            }
            return sum / numbers.Length;
        }

        public static double Avg2(params int[] numbers)
        {
            double sum = 0;
            foreach (var n in numbers)
            {
                sum += n;
            }
            return sum / numbers.Length;
        }

        public static double TriangleSquareCalc(double ab, double bc, double ac)
        {
            double p = (ab + bc + ac) / 2;
            return Math.Sqrt(p * (p - ab) * (p - bc) * (p - ac));
        }

        /*Добавить перегрузку, которая принимает длины двух смежных сторон (double) и величину угла между ними. Величину угла принимать как int.
        Метод должен рассчитывать площадь по формуле:
        0.5 * ab * ac * sin(alpha) */
        public static double TriangleSquareCalc(double ab, double ac, int alpha)
        {
            double rads = alpha * Math.PI / 100;
            return 0.5 * ab * ac * Math.Sin(rads);
        }

        public static double TriangleSquareCalc(double ab, double ac, int alpha, bool isInRadians = false) 
        {
            if (isInRadians)
            {
                return 0.5 * ab * ac * Math.Sin(alpha);
            }
            else
            {
                double rads = alpha * Math.PI / 100;
                return 0.5 * ab * ac * Math.Sin(rads);
            }
        }

    }
}
