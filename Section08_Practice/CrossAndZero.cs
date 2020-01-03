using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Section08_Practice
{
    public class CrossAndZero
    {
        private Player _player;
        private byte?[,] _field;
        private Player _winner;
        private bool _isGameOver;
        private int _fieldRowLength;
        private int _fieldColumnLength;


        public CrossAndZero()
        {
            _player = Player.Cross;
            _field = new byte?[3, 3] { { null, null, null }, { null, null, null }, { null, null, null } };
            //_field = new byte?[3, 3] { { 0, null, null }, { 0, 1, 1 }, { 0, null, null } };
            //_field = new byte?[3, 3] { { 0, null, null }, { 1, 1, 1 }, { 0, null, null } };
            //_field = new byte?[3, 3] { { 1, 0, 1 }, { 1, 0, 0 }, { 0, null, 1 } };

            _fieldRowLength = _field.GetLength(0);
            _fieldColumnLength = _field.GetLength(1);
        }

        public void StartGame()
        {
            DrawCurrentState();
            while (_isGameOver == false)
            {
                Move();
                DrawCurrentState();

                WinnerCalc();
            }
            Player winnerName = (Player)_winner;
            string winnerNameString = winnerName.ToString();

            Console.WriteLine($"Game is over! Winner is: {winnerNameString}");
        }

        private void Move()
        {
            Player playerName = (Player)_player;
            string playerNameString = playerName.ToString();
            Console.WriteLine($"Current move is: {playerNameString}");
            Console.WriteLine();

            byte input = 255;
            bool isParsed = false, isCellBusy = true;
            byte r = 10, c = 10;
            while (!isParsed || input > 8 || isCellBusy)
            {
                isParsed = byte.TryParse(Console.ReadLine(), out input);
                if (!isParsed)
                    Console.WriteLine("Sorry, can't recognize your input. Please try again with a number between 0 and 8...");


                switch (input)
                {
                    case 0:
                        r = 0;
                        c = 0;
                        break;
                    case 1:
                        r = 0;
                        c = 1;
                        break;
                    case 2:
                        r = 0;
                        c = 2;
                        break;
                    case 3:
                        r = 1;
                        c = 0;
                        break;
                    case 4:
                        r = 1;
                        c = 1;
                        break;
                    case 5:
                        r = 1;
                        c = 2;
                        break;
                    case 6:
                        r = 2;
                        c = 0;
                        break;
                    case 7:
                        r = 2;
                        c = 1;
                        break;
                    case 8:
                        r = 2;
                        c = 2;
                        break;

                    default:
                        break;
                }

                if (input > 8)
                {
                    Console.WriteLine("The cell number can't be more than 8, please try another value");
                }

                if (input < 9 &&_field[r, c].HasValue)
                {
                    Console.WriteLine($"Cell already has a value. Try another one...");
                    isCellBusy = true;
                }
                else
                    isCellBusy = false;
            }

            if (_player == Player.Cross)
            {
                _field[r, c] = 1;
                _player = Player.Zero;
            }
            else
            {
                _field[r, c] = 0;
                _player = Player.Cross;
            }
        }

        private void DrawCurrentState()
        {
            Console.Clear();

            string cell;

            for (int row = 0; row < _fieldRowLength; row++)
            {
                for (int col = 0; col < _fieldColumnLength; col++)
                {
                    switch (_field[row, col])
                    {
                        case 0:
                            cell = "O";
                            break;
                        case 1:
                            cell = "X";
                            break;
                        default:
                            cell = "_";
                            break;
                    }
                    Console.Write($" {cell} ");
                    if (col < 2)
                        Console.Write("|");
                }
                Console.WriteLine();
            }
        }

        private void WinnerCalc()
        {
            // Rows calc
            for (int r = 0; r < _fieldRowLength; r++)
            {
                byte?[] row = new byte?[_fieldRowLength];

                for (int c = 0; c < _fieldColumnLength; c++)
                {
                    row[c] = _field[r, c];
                }

                byte? rowSum = row[0];
                for (int i = 1; i < row.Length; i++)
                {
                    rowSum += row[i];
                }

                if (rowSum == _fieldRowLength)
                {
                     _winner = Player.Cross;
                    _isGameOver = true;
                    return;
                }
                if (rowSum == 0)
                {
                    _winner = Player.Zero;
                    _isGameOver = true;
                    return;
                }
            }
            // Columns calc
            for (int r = 0; r < _fieldRowLength; r++)
            {
                byte?[] column = new byte?[_fieldRowLength];

                for (int c = 0; c < _fieldColumnLength; c++)
                {
                    column[c] = _field[c, r];
                }

                byte? columnSum = column[0];
                for (int i = 1; i < column.Length; i++)
                {
                    columnSum += column[i];
                }

                if (columnSum == _fieldColumnLength)
                {
                    _winner = Player.Cross;
                    _isGameOver = true;
                    return;
                }
                if (columnSum == 0)
                {
                    _winner = Player.Zero;
                    _isGameOver = true;
                    return;
                }
            }


            // Diagonals calc 
// TODO: implement universal logic
            var slashSum = _field[2, 0] + _field[1, 1] + _field[0, 2];
            var backSlashSum = _field[0, 0] + _field[1, 1] + _field[2, 2];

            if (slashSum == _fieldColumnLength || backSlashSum == _fieldColumnLength)
            {
                 _winner = Player.Cross;
                _isGameOver = true;
                return;
            }
            if (slashSum == 0 || backSlashSum == 0)
            {
                _winner = Player.Zero;
                _isGameOver = true;
                return;
            }


            //Check if no empty cells
            byte? fieldCellsSum = 0;
            for (int row = 0; row < _fieldRowLength; row++)
            {
                for (int col = 0; col < _fieldColumnLength; col++)
                {
                    fieldCellsSum += _field[row, col];
                }
            }

            if (fieldCellsSum != null) 
            {
                _isGameOver = true;
                Console.WriteLine("Game is over! No winner since no empty cells left :(");
            }
        }
    }

    enum Player
    {
        Zero = 0,
        Cross
    }

}
