using System;

namespace Section08_Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            GuessNumbersGame();
            //ComplexNumbers()
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


