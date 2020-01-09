using System;

namespace Section09_DelegatesLINQ
{
    public class Car
    {
        private int _speed = 0;

        public event Action<int> TooFastEvent;
        public event Action<int> AccelerateEvent;
        //public delegate void TooFast();

        //private TooFast _tooFast;

        public void Start()
        {
            Console.WriteLine("Starting car...");
            _speed = 10;
        }
        public void Accelerate()
        {
            _speed += 10;
            AccelerateEvent?.Invoke(_speed);  // Check Event for null and invoke

            if (_speed > 80)
            {
                if (TooFastEvent != null)
                    TooFastEvent(_speed);
            }
        }
        public void Stop()
        {
            _speed = 0;
            Console.WriteLine($"Stopping car! Speed = {_speed}");

        }

        //public void RegisterOnTooFast(TooFast tooFast)
        //{
        //    this._tooFast = tooFast;
        //}

    }
}