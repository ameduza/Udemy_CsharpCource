using System;

namespace Section08_Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            ComplexNumber c1 = new ComplexNumber(5, 3);
            ComplexNumber c2 = new ComplexNumber(1, 2);


            ComplexNumber sumResult = c1.Plus(c2);
            ComplexNumber substResult = c1.Minus(c2);

            Console.WriteLine($"SumResult = {sumResult.RealPart} + {sumResult.ImaginaryPart}i");
            Console.WriteLine($"SubstResult = {substResult.RealPart} + {substResult.ImaginaryPart}i");

        }
    }
}


