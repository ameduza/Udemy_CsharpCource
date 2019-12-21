using System;

namespace Section05_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            CallMyStack();


            #region Structs and references
            /*
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
            */
            #endregion

            //Console.WriteLine("Enter ab, ac, alpha");
            //double ab = double.Parse(Console.ReadLine());
            //double ac = double.Parse(Console.ReadLine());
            //int alpha = int.Parse(Console.ReadLine());

            //double square = Math.Round(Calculator.TriangleSquareCalc(ab, ac, alpha), 2);

            //Console.WriteLine($"Square is {square}");

            //Console.WriteLine($"Average2 is {Calculator.Avg2(1 ,2, 3, 4)}");

        }

        private static void CallMyStack()
        {
            var ms = new MyStack<int>();
            for (int i = 0; i < 4; i++)
            {
                ms.Push(i * 10);
            }
            

            ms.Peek();
            ms.Pop();
            ms.Peek();
            Console.Clear();
            Console.WriteLine("Popping all array");
            for (int i = ms.Count; i > 0; i--)
            {
                ms.Pop();
            }
        }
    }
}
