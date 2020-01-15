using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Section09_DelegatesLINQ
{
    public class ChessPlayer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public int GamesCount { get; set; }
        public int BirthYear { get; set; }
        public int Rating { get; set; }

        public override string ToString()
        {
            return $"Full name: {FirstName} {LastName}";
        }
        public static ChessPlayer ParseCsvLine(string line)
        {
            string[] parts = line.Split(";");
            return new ChessPlayer()
            {
                LastName = parts[1].Split("	 ")[0].Trim(),
                FirstName = parts[1].Split("	 ")[1].Trim(),
                Country = parts[3].Trim(),
                GamesCount = int.Parse(parts[4]),
                BirthYear = int.Parse(parts[6]),
                Rating = int.Parse(parts[4])
            };
        }
    }
}
