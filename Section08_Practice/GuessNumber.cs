using System;
using System.Collections.Generic;
using System.Text;

namespace Section08_Practice
{
    public enum GameMode
    {
        HumanGuess = 1,
        ComputerGuess
    }
    public class GuessNumber
    {
        private readonly int _maxtries;
        private readonly int _maxNumber;

        public GuessNumber(int maxNumber = 100, int maxTries = 5)
        {
            _maxNumber = maxNumber;
            _maxtries = maxTries;
        }
        public static int GetRundomNumber(int from, int to)
        {
            Random randomNumber = new Random();
            return randomNumber.Next(from, to);
        }

        public void StartGame(GameMode player, int proposedNumber)
        {
            int currentTry = _maxtries;
            int from = 0;
            int to = _maxNumber;
            int guessedNumber;

            if (player == GameMode.ComputerGuess)
            {
                while (currentTry > 0)
                {
                    Console.WriteLine($"Round {currentTry}, current range is {from} - {to}");
                    guessedNumber = (int)Math.Round((from + to) * 0.5, 0);
                    Console.WriteLine($"Computer tries with number {guessedNumber}");
                    if (proposedNumber == guessedNumber)
                    {
                        Console.WriteLine("Computer Wins!");
                        return;
                    }

                    if (proposedNumber > guessedNumber)
                    {
                        from = guessedNumber;
                    }
                    else
                    {
                        to = guessedNumber;
                    }
                    
                    currentTry--;
                }
                Console.WriteLine("Computer lost :(");
            }
            else
            {
                while (currentTry > 0)
                {
                    Console.WriteLine($"Round {currentTry}, please enter  your number:");
                    guessedNumber = int.Parse(Console.ReadLine());

                    if (proposedNumber == guessedNumber)
                    {
                        Console.WriteLine("You Wins!");
                        return;
                    }

                    if (proposedNumber > guessedNumber)
                    {
                        Console.WriteLine("Proposed numer is Higher than yours");
                    }
                    else
                    {
                        Console.WriteLine("Proposed numer is Lower than yours");
                    }

                    currentTry--;
                }

                Console.WriteLine($"You lost, sorry. Proposed number was {proposedNumber}");
            }
        }
    }
}