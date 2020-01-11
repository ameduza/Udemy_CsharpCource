using System;
using System.Collections.Generic;
using System.Text;

namespace Section09_DelegatesLINQ.SticksGame
{
    public static class SticksGameUI
    {
        public static void SticksGame()
        {
            Sticks game = new Sticks(10, PlayerEnum.Human);
            game.ComputerPlayedEvent += SticksGame_ComputerPlayedEvent;
            game.HumanPlayedEvent += SticksGame_HumanPlayedEvent;
            game.EndOfGameEvent += SticksGame_EndOfGameEvent;

            game.StartGame();
        }

        private static void SticksGame_EndOfGameEvent(PlayerEnum winner)
        {
            Console.WriteLine($"Game is over! Winner is {winner}");
        }

        private static void SticksGame_HumanPlayedEvent(object sender, int remainingSticks)
        {
            Console.WriteLine($"Remaining sticks: {remainingSticks}");
            Console.WriteLine("Take some ticks...");

            bool isTakenCorrectly = false;
            while (!isTakenCorrectly)
            {
                if (int.TryParse(Console.ReadLine(), out int takenSticks))
                {
                    var game = (Sticks)sender;

                    try
                    {
                        game.HumanTakes(takenSticks);
                        isTakenCorrectly = true;
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.WriteLine(" ...try number from 1 to 3");
                        isTakenCorrectly = false;
                    }
                }
                else
                {
                    Console.WriteLine("Wrong input, try number from 1 to 3");
                }
            }
        }

        private static void SticksGame_ComputerPlayedEvent(int sticksTaken)
        {
            Console.WriteLine($"Machine took: {sticksTaken}");
        }
    }
}
