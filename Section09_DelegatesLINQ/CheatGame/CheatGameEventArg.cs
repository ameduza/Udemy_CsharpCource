using System;

namespace Section09_DelegatesLINQ
{
    public class CheatGameEventArg : EventArgs
    {
        public CheatGameEventArg(int messageCount, bool isWin)
        {
            MessageCount = messageCount;
            IsWin = isWin;
        }

        public int MessageCount { get; }
        public bool IsWin { get; }
    }
}