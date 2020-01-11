using System;
using System.Collections.Generic;
using System.Text;

namespace Section09_DelegatesLINQ.SticksGame
{
    public class Sticks
    {
        private Random _random;
        public Sticks(int initialSticksNumber, PlayerEnum firstPlayer)
        {
            if (initialSticksNumber < 7 || initialSticksNumber > 29)
                throw new ArgumentException("Invalid Initial sticks number");

            InitialSticksNumber = initialSticksNumber;
            RemainingSticks = InitialSticksNumber;
            GameStatus = GameStatusEnum.NotStarted;
            CurrentPlayer = firstPlayer;
            _random = new Random();
        }

        public int InitialSticksNumber { get; }
        public PlayerEnum CurrentPlayer { get; private set; }
        public int RemainingSticks { get; private set; }
        public GameStatusEnum GameStatus { get; private set; }

        public event Action<int> ComputerPlayedEvent;
        public event EventHandler<int> HumanPlayedEvent;
        public event Action<PlayerEnum> EndOfGameEvent;

        public void StartGame()
        {
            if (GameStatus == GameStatusEnum.GameIsOver)
                RemainingSticks = InitialSticksNumber;
            if (GameStatus == GameStatusEnum.InProgress)
                throw new InvalidOperationException("Can't start game that is already in progress");

            GameStatus = GameStatusEnum.InProgress;

            while (GameStatus == GameStatusEnum.InProgress)
            {
                if (CurrentPlayer == PlayerEnum.Computer)
                {
                    ComputerMakesMove();
                }
                else
                {
                    HumanMakesMove();
                }

                FireEndOfGameIfRequired();

                CurrentPlayer = CurrentPlayer == PlayerEnum.Computer ? PlayerEnum.Human : PlayerEnum.Computer;
            }

        }

        public void HumanTakes(int sticks) 
        {
            if (sticks < 1 || sticks > 3)
                throw new ArgumentException("You can take from 1 to 3 sticks on a single move");

            if (sticks > RemainingSticks)
                throw new ArgumentException($"You can't take more than remaining. Currently there are {RemainingSticks} sticks vailable");

            TakeSticks(sticks);
        }

        private void FireEndOfGameIfRequired()
        {
            if (RemainingSticks == 0)
            {
                GameStatus = GameStatusEnum.GameIsOver;
                if (EndOfGameEvent != null)
                    EndOfGameEvent(CurrentPlayer = CurrentPlayer == PlayerEnum.Computer ? PlayerEnum.Human : PlayerEnum.Computer);
            }
        }

        private void HumanMakesMove()
        {
            if (HumanPlayedEvent != null)
                HumanPlayedEvent(this, RemainingSticks);
        }

        private void ComputerMakesMove()
        {
            int r = _random.Next(1, 3);
            int sticksCount;

            switch (RemainingSticks)
            {
                case 3:
                    sticksCount = 2;
                    break;
                case 2:
                    sticksCount = 1;
                    break;
                case 1:
                    sticksCount = 1;
                    break;
                default:
                    sticksCount = r;
                    break;
            }
            
            TakeSticks(sticksCount);

            if (ComputerPlayedEvent != null)
                ComputerPlayedEvent(sticksCount);

        }

        private void TakeSticks(int sticksCount)
        {
            RemainingSticks -= sticksCount;
        }
    }
}
