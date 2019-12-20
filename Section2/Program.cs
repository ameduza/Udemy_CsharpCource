using System;

namespace Section2
{
    class Program
    {
        static void Main(string[] args)
        {
            // one();

            //two();

            //three();

            //triangleSquare();

            userProfile();

        }

        private static void userProfile()
        {
            /*
            Запросить у пользователя: фамилию, имя, возраст, вес, рост.
            Высчитать ИМТ(индекс массы тела) по формуле ИМТ = вес(кг) / (рост(м) * рост(м))
            Сформировать единую строку, в следующем формате:
            Your profile:
            Full Name: фамилия, имя
            Age: рост
            Weight: вес
            Height: рост
            Body Mass Index: ИМТ

            Вывести сформированную строку на консоль.
            */
            /*
                        Console.WriteLine("Enter your Lastname, Name");
                        string lastName = Console.ReadLine();
                        string name = Console.ReadLine();

                        Console.WriteLine("Enter your age, weight, height");
                        int age = int.Parse(Console.ReadLine());
                        double weight = double.Parse(Console.ReadLine());
                        double height = double.Parse(Console.ReadLine());

                        double heightMeters = height / 100;

                        double massIndex = weight / (heightMeters * heightMeters);

                        Console.WriteLine();
                        Console.WriteLine($"Your profile:\n" +
                            $"Full Name: {lastName}, {name}\n" +
                            $"Age: {age}\n" +
                            $"Weight: {weight}\n" +
                            $"Height: {height}\n" +
                            $"Body Mass Index: {Math.Round(massIndex, 2)}");
            */
            //UserProfile user = new UserProfile();
            //user.LastName = "M";
            //user.Name = "Name";


            //double heightMeters = height / 100;

            //double massIndex = weight / (heightMeters * heightMeters);

            //Console.WriteLine();
            //Console.WriteLine($"Your profile:\n" +
            //    $"Full Name: {lastName}, {name}\n" +
            //    $"Age: {age}\n" +
            //    $"Weight: {weight}\n" +
            //    $"Height: {height}\n" +
            //    $"Body Mass Index: {Math.Round(massIndex, 2)}");


        }

        private class UserProfile
        {
            //private string _lastName;
            //private string _name;
            //private int _age;
            private double _weight;
        private double _height;

        public string LastName { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public double MassIndex {
            get
            {
                return _weight / ((_height / 100) * (_height / 100));
            }
            set { }
        }
    } 
        private static void triangleSquare()
        {
            /*
            Запросить у пользователя длины трёх сторон треугольника.Длины могут быть представлены дробными значениями.
            После получения длин сторон -использовать формулу Герона для вычисления площади треугольника.
            Чтобы жизнь не казалась мёдом найдите формулу самостоятельно.
            S = SQRT(p * (p−a) * (p−b) * (p−c))
            p = 0.5*(a+b+c)
            После вычисления площади - вывести результат на консоль.
            */
            Console.WriteLine("Enter a, b, c");
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double c = double.Parse(Console.ReadLine());

            double p = (a + b + c) / 2;
            double pMinusA = p - a;
            double pMinusB = p - b;
            double pMinusC = p - c;

            double square = Math.Sqrt(p * pMinusA * pMinusB * pMinusC);

            Console.WriteLine($"Triangle square equals {square}");

        }
        private static void three()
        {
            Console.WriteLine("Enter number");
            string x = Console.ReadLine();
            
            Console.WriteLine($"Number length is {x.Length}");
        }

        private static void two()
        {
            Console.WriteLine("Enter x:");
            int x = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter y:");
            int y = int.Parse(Console.ReadLine());

            Console.WriteLine($"x = {x}, y = {y}");
            int m = x;
            x = y;
            y = m;
            Console.WriteLine($"now x = {x}, y = {y}");
        }

        private static void one()
        {
            Console.WriteLine("Please type your name: ");

            string name = Console.ReadLine();
            Console.WriteLine($"Hello, {name}");

        }

    }
}
