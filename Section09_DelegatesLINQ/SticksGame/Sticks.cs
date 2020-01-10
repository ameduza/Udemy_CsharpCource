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
            GameStatus = GameStatusEnum.InProgress;
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

                CurrentPlayer = CurrentPlayer == PlayerEnum.Computer ? PlayerEnum.Human : PlayerEnum.Human;
            }

        }

        private void FireEndOfGameIfRequired()
        {
            if (RemainingSticks == 0)
            {
                GameStatus = GameStatusEnum.GameIsOver;
                if (EndOfGameEvent != null)
                    EndOfGameEvent(CurrentPlayer = CurrentPlayer == PlayerEnum.Computer ? PlayerEnum.Human : PlayerEnum.Human;);
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
            int sticksNumber = RemainingSticks > 3 ? 3 : r;

            RemainingSticks -= sticksNumber;
        }
    }
}
