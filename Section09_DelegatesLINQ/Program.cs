using Section09_DelegatesLINQ.SticksGame;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Section09_DelegatesLINQ
{
    public static class LinqExt
    {
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (var file in source)
            {
                action(file);
            }
        }
    }
    class Program
    {
        static Car car;

        static void Main(string[] args)
        {
            DisplayLargestFilesLinq(@"C:\Distribs");
            Console.WriteLine("--------------------");
            DisplayLargestFilesNoLinq(@"C:\Distribs");
            
            //SticksGameUI.SticksGame();

            //CarCall();
        }

        private static void DisplayLargestFilesLinq(string pathToDir) 
        {
            IEnumerable<FileInfo> topFivefiles = new DirectoryInfo(pathToDir)
                .GetFiles()
                .OrderByDescending(x => x.Length)
                .Take(5);

            foreach (var file in topFivefiles)
            {
                Console.WriteLine($"{file.Name} size is {file.Length} bytes");
            }
            Console.WriteLine("-------------------- Extention:");
            
            topFivefiles
                .ForEach(file => Console.WriteLine($"{file.Name} size is {file.Length} bytes"));
        }
        private static void DisplayLargestFilesNoLinq(string pathToDir)
        {
            var dirInfo = new DirectoryInfo(pathToDir);
            FileInfo[] files = dirInfo.GetFiles();

            Array.Sort(files, FilesSortLengthDesc);

            for (int i = 0; i < 5; i++)
            {
                FileInfo file = files[i];
                Console.WriteLine($"{file.Name} size is {file.Length} bytes");
            }
        }

        private static int FilesSortLengthDesc(FileInfo x, FileInfo y)
        {
            if (x.Length == y.Length) return 0;
            if (x.Length < y.Length) return 1;
            return -1;
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
