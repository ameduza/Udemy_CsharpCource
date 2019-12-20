using System;
using System.Collections.Generic;

namespace Section03
{
    class Section03
    {
        static void Main(string[] args)
        {
            //Maximum();

            //Fibonacci();

            //Average();

            Factorial();
        }

        private static void Factorial()
        {/*
            Факториалом числа является произведение этого числа на все предшествующие этому числу числа(кроме 0). 
            Факториал в математике записывается через восклицательный знак.Например 5! = 5 * 4 * 3 * 2 * 1 = 120.Особые случаи: 0! = 1. 1! = 1.
            
            Задача: запросить у пользователя число, факториал которого необходимо вычислить и произвести вычисление. 
            Затем вывести результат вычисления. Восклицательный знак запрашивать не надо, кроме того, в C# такой операции нет. 
            Для вычисления факториала надо производить перемножение.  */

            Console.WriteLine("Enter n:");
            int n = int.Parse(Console.ReadLine());

            int factorial = 1;
            for (int j = 1; j <= n; j++)
            {
                factorial *= j;
            }

            Console.WriteLine($"Factorial value is: {factorial}");
        }
        private static void Average()
        { /*
            Запросить у пользователя не более 10 целых положительных чисел, кратных трём. 
            Пользователь может прекратить приём чисел, введя 0.
            После прекращения приёма целых чисел(это происходит в случае если было введено 10 чисел, 
            либо пользователь ввёл 0, чтобы не вводить все 10) подсчитать среднее значение введённых 
            целых чисел и вывести на консоль. */

            Console.WriteLine("Enter ten positive int numbers multiplied to 3. Type 0 to force finish.");
            int inputCount = 5;
            int[] inputArray = new int[inputCount];
            int input = 0;
            int inputArrayRealLenght = 0;

            for (int i = 0; i < inputCount; i++)
            {
                input = int.Parse(Console.ReadLine());
                while (input < 0 || input %3 !=0 || (input == 0 && i < 1))
                {
                    Console.WriteLine("value is not correct");
                    input = int.Parse(Console.ReadLine());
                }
                if (input == 0 && i > 1)
                    break;
                inputArray[i] = input;
                inputArrayRealLenght++;
            }

            int sum = 0;

            for (int j = 0; j < inputArrayRealLenght; j++)
            {
                sum += inputArray[j];
            }

            double avg = (double)sum / inputArrayRealLenght;

            Console.WriteLine();
            Console.WriteLine("Final array list: ");
            foreach (var item in inputArray)
            {
                if (item != 0)
                    Console.Write($"{item.ToString()} ,");
            }

            Console.WriteLine();
            Console.WriteLine($"Array average: {avg.ToString()}, array final lenght: {inputArrayRealLenght.ToString()}");
        }
        private static void Fibonacci()
        {
            //Числа фибоначчи описываются следующей последовательностью: 1, 1, 2, 3, 5, 8, 13, 21...
            //Первые два числа - единицы.Все последующие числа вычисляются как сумма двух предыдущих.
            //Задание: запросить у пользователя кол-во чисел Фибоначчи, которое он хотел бы сгенерировать(вычислить), 
            //и, собственно, произвести генерацию(вычисление). В процессе генерации записывать числа в массив.
            //После генерации вывести вычисленные числа.

            Console.WriteLine("Enter Fibonacci list count:");
            int listCount = int.Parse(Console.ReadLine());

            int[] fibonacciArray = new int[listCount];
            fibonacciArray[0] = 0;
            fibonacciArray[1] = 1;

            for (int i = 2; i < listCount ; i++)
            {
                fibonacciArray[i] = fibonacciArray[i - 2] + fibonacciArray[i - 1];
            }

            string listString = string.Empty;

            for (int i = 0; i < fibonacciArray.Length; i++)
            {
                listString = string.Join(", ", listString, fibonacciArray[i].ToString());
            }

            listString = listString.Remove(0, 2);

            Console.WriteLine();
            Console.WriteLine($"Fibonacci list: {listString}");
        }
        private static void Maximum()
        {
            //Запросить у пользователя два целочисленных значения и найти максимальное.

            Console.WriteLine("Enter two int numbers");
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());

            string resultString;

            if (x > y)
            { resultString = $"X ({x}) bigger then Y ({y})"; }
            else if (x == y)
            {
                resultString = "X equals Y";
            }
            else
            {
                resultString = $"Y ({y}) bigger then X ({x})";
            }

            Console.WriteLine(resultString);


        }
    }
}
