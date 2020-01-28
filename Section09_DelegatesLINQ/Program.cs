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
            CheatGameUI();

            //PrintChessPlayers();

            //LinqDemo(@"ChessPlayer\Top100ChessPlayers.csv");

            //DisplayLargestFilesLinq(@"C:\Distribs");
            //Console.WriteLine("--------------------");
            //DisplayLargestFilesNoLinq(@"C:\Distribs");

            //SticksGameUI.SticksGame();

            //CarCall();
        }

        private static void CheatGameUI()
        {
            var game = new CheatGame(maxNumberOfMistakes: 2, questionsFile: @"CheatGame\Questions.csv");
            game.EndOfGameEvent += CheatGame_EndOfGameEvent;
            game.WrongAnswerEvent += (explanation) =>
                { 
                    Console.WriteLine($"Sorry, you wrong. Correct answer is: {explanation}");
                    Console.WriteLine();
                };

            game.Start();
            Console.WriteLine("Welcome to the Cheat Game");
            while (game.GameStatus == GameStatusEnum.InProgress)
            {
                Console.WriteLine($"Do you believe inthe next question? (Type y/n): {game.GetNextQuestion()}");
                game.ValidateAnswer(Console.ReadLine() == "y");
            };
        }

        private static void CheatGame_EndOfGameEvent(object sender, CheatGameEventArg e)
        {
            Console.WriteLine($"Game is over! Question asked count: {e.MessageCount}");
            Console.WriteLine(e.IsWin ? "You won!" : "You lost!");
        }

        private static void LinqDemo(string filepath)
        {
            IEnumerable<ChessPlayer> players = File.ReadAllLines(filepath)
                                                .Skip(1)
                                                .Select(x => ChessPlayer.ParseCsvLine(x))
                                                .Where(x => x.BirthYear > 1988)
                                                .Take(10)
                                                .ToList();  // Greedy operator that kick off real calculation right now!

            Console.WriteLine($"The lowest rating in top 10 is {players.Min(x => x.Rating)}");
            var playersList = players.ToList();


            Console.WriteLine($"First RUS player: {players.FirstOrDefault(x => x.Country == "RUS")}");
        }

        private static void PrintChessPlayers()
        {
            List<ChessPlayer> players = RusChessPlayersSorted(@"ChessPlayer\Top100ChessPlayers.csv");
            foreach (var player in players)
            {
                Console.WriteLine($"{player} BirthDate: {player.BirthYear}");
            }

        }
        private static List<ChessPlayer> RusChessPlayersSorted(string file)
        {
            //найти всех игроков из России и отсортировать их по году рождения по возрастанию.
            return File.ReadAllLines(file)
                .Skip(1)
                .Select(x => ChessPlayer.ParseCsvLine(x))
                .Where(x => x.Country == "RUS")
                .OrderBy(x => x.BirthYear)
                .ToList();
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
