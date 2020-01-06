using System;
using System.Text;

namespace Section08_Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            HangmanGame();
            //CrossAndZerosGame();
            //GuessNumbersGame();
            //ComplexNumbers()
        }

        private static void HangmanGame()
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.UTF8;
            Hangman game = new Hangman();
            HangmanGameDrawCurrentState(game);
            while (game.Attempt > 0 && !game.IsUserGuessedWord)
            {
                Console.WriteLine("Введите следующую букву или слово целиком если готовы попробовать...");
                try
                {
                    game.UserAttempt(Console.ReadLine());
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Вы уже пробовали эту букву. Для продолжения нажмите любую клавишу...");
                    Console.ReadKey();
                }
                    
                HangmanGameDrawCurrentState(game);
            }
            
            if (game.IsUserGuessedWord)
            {
                HangmanGameDrawCurrentState(game);
                Console.WriteLine("Поздравляем! Угадали!");
            }
            else
            {
                string word = new string(game.CharsGuessed);
                Console.WriteLine($"Извините, неверное слово. Было загадано слово: {word}");
            }
        }

        private static void HangmanGameDrawCurrentState(Hangman game)
        {

            Console.Clear();

            foreach (var c in game.CharsGuessed)
            {
                Console.Write($"{c} ");
            }
            Console.WriteLine();

            Console.WriteLine($"Количество попыток: {game.Attempt}");

            if (game.CharsTriedList.Count > 0)
            {
                string list = new string(game.CharsTriedList.ToArray());
                Console.WriteLine($"Использованные буквы: {list}");
            }
        }
        public static void CrossAndZerosGame()
        {
            CrossAndZero game = new CrossAndZero();
            game.StartGame();
            
        }

        public static void GuessNumbersGame()
        {
            GuessNumber game = new GuessNumber(maxNumber: 100, maxTries: 7);
            
            Console.WriteLine("Please select game mode: 1 - human guess, 2 - computer guess");
            GameMode player = Enum.Parse<GameMode>(Console.ReadLine());

            int proposedNumber;
            if (player == GameMode.HumanGuess)
            {
                proposedNumber = GuessNumber.GetRundomNumber(0, 100);
            }
            else
            {
                Console.WriteLine("Please enter number to guess by computer:");
                proposedNumber = int.Parse(Console.ReadLine());
            }

            game.StartGame(player, proposedNumber);
        }

        public static void ComplexNumbers()
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


