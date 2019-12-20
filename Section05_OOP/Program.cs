using System;

namespace Section05_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Struct types:");
            PointVal a; // same as PointVal a = new PointVal();
            a.X = 3;
            a.Y = 5;

            PointVal b = a;
            b.X = 7;
            b.Y = 10;

            a.LogValues();
            b.LogValues();

            Console.WriteLine("reference types:");
            ///
            PointRef c = new PointRef
            {
                X = 3,
                Y = 5
            };

            PointRef d = c;
            d.X = 7;
            d.Y = 10;

            c.LogValues();
            d.LogValues();


            //Console.WriteLine("Enter ab, ac, alpha");
            //double ab = double.Parse(Console.ReadLine());
            //double ac = double.Parse(Console.ReadLine());
            //int alpha = int.Parse(Console.ReadLine());

            //double square = Math.Round(Calculator.TriangleSquareCalc(ab, ac, alpha), 2);

            //Console.WriteLine($"Square is {square}");

            //Console.WriteLine($"Average2 is {Calculator.Avg2(1 ,2, 3, 4)}");

        }

    }
}
