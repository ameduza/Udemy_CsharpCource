using System;
using System.Collections.Generic;
using System.Text;

namespace Section05_OOP
{
    public struct PointVal 
    {
        public int X;
        public int Y;

        public void LogValues() {
            Console.WriteLine($"X={X}, Y={Y}");
        }
    }

    public class PointRef
    {
        public int X;
        public int Y;

        public void LogValues()
        {
            Console.WriteLine($"X={X}, Y={Y}");
        }
    }

}
