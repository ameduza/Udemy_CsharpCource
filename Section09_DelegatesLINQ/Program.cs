using System;

namespace Section09_DelegatesLINQ
{
    class Program
    {
        static Car car;
        static void Main(string[] args)
        {


            CarCall();

        }

        private static void CarCall()
        {
            car = new Car();
            //car.RegisterOnTooFast(HandleOnTooFast);
            car.AccelerateEvent += Car_AccelerateEvent;
            car.TooFastEvent += Car_TooFastEvent;


            car.Start();

            for (int i = 0; i < 10; i++)
            {
                car.Accelerate();
            }
        }

        private static void Car_AccelerateEvent(int speed)
        {
            Console.WriteLine($"Accelerating...Speed = {speed}");
        }

        private static void Car_TooFastEvent(int speed)
        {
            Console.WriteLine($"Your speed is {speed}");
            car.Stop();
        }

        //private static void HandleOnTooFast()
        //{
        //    Console.WriteLine("Too fast! Slow down!");
        //    car.Stop();
        //}
    }
}
