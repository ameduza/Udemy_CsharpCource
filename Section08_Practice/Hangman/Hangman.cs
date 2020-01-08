using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Section08_Practice
{
    public class Hangman
    {
        private char[] _charsProposed;
        private char[] _charsGuessed;
        private string _wordProposed;
        private List<char> _charsTriedList;

        public int Attempt { get; private set; }
        public bool IsUserGuessedWord { get; private set; }
        internal char[] CharsGuessed { get => _charsGuessed; private set => _charsGuessed = value; }
        public List<char> CharsTriedList { get => _charsTriedList; }

        public Hangman()
        {
            Attempt = 6;
            MakeUpWord();
        }

        internal string MakeUpWord()
        {
            string[] allWords = File.ReadAllLines("Hangman/WordsStockRus.txt", Encoding.UTF8);
            Random random = new Random();
            int r = random.Next(0, allWords.Length - 1);
            _wordProposed = allWords[r].ToUpper();
            _charsProposed = _wordProposed.ToCharArray();
            _charsGuessed = new char[_wordProposed.Length];
            for (int j = 0; j < _charsGuessed.Length; j++)
            {
                _charsGuessed[j] = char.Parse("_");
            }

            _charsTriedList = new List<char>();
            return _wordProposed;
        }

        internal void UserAttempt(string userInput)
        {
            bool isAttemptSucceeded = false;
            userInput = userInput.ToUpper();
            
            if (userInput.Length > 1)
            {
                if (userInput == _wordProposed)
                {
                    IsUserGuessedWord = true;
                    CharsGuessed = _charsProposed;
                    isAttemptSucceeded = true;
                }
                else
                    IsUserGuessedWord = false;
            }
            else
            { 
                char letter = char.Parse(userInput);

                if (_charsTriedList.Contains(letter))
                    throw new ArgumentException("Invalid argument, this letter was already tried.");
                else
                    _charsTriedList.Add(letter);

                for (int i = 0; i < _charsProposed.Length; i++)
                {
                    if (_charsProposed[i] == letter)
                    {
                        CharsGuessed[i] = letter;
                        isAttemptSucceeded = true;
                    }
                }

                int numberOfEmpty = CharsGuessed.Length;
                for (int i = CharsGuessed.Length-1; i > -1; i--)
                {
                    if (CharsGuessed[i] != char.Parse("_"))
                        numberOfEmpty--;
                }

                if (numberOfEmpty == 0)
                {
                    IsUserGuessedWord = true;
                    //CharsGuessed = _charsProposed;
                }
            }

            if (!isAttemptSucceeded)
                Attempt--;

            if (Attempt == 0)
                CharsGuessed = _charsProposed;
        }
    }
}
