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

        public CrossAndZero()
        {
            _player = Player.Cross;
            //_field = new byte?[3, 3] { { null, null, null }, { null, null, null }, { null, null, null } };
            //_field = new byte?[3, 3] { { 0, null, null }, { 0, 1, 1 }, { 0, null, null } };
            //_field = new byte?[3, 3] { { 0, null, null }, { 1, 1, 1 }, { 0, null, null } };
            _field = new byte?[3, 3] { { 0, 1, null }, { 1, 0, 1 }, { 0, null, 0 } };
        }

        public void StartGame()
        {
            DrawCurrentState();
            while (_isGameOver == false)
            {
                // request move
                DrawCurrentState();

                WinnerCalc();
            }
            Player winnerName = (Player)_winner;
            string winnerNameString = winnerName.ToString();

            Console.WriteLine($"Game is over! Winner is: {winnerNameString}");
        }

        private void DrawCurrentState()
        {
            Player playerName = (Player)_player;
            string playerNameString = playerName.ToString();

            Console.Clear();
            Console.WriteLine($"Current move is: {playerNameString}");
            Console.WriteLine();

            string cell;

            for (int i = 0; i < _field.GetLength(0); i++)
            {
                for (int j = 0; j < _field.GetLength(1); j++)
                {
                    switch (_field[i, j])
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
                    if (j < 2)
                        Console.Write("|");
                }
                Console.WriteLine();
            }

        }

        private void WinnerCalc()
        {
            int fieldRowLength = _field.GetLength(0);
            int fieldColumnLength = _field.GetLength(1);

            // Rows calc
            for (int r = 0; r < fieldRowLength; r++)
            {
                byte?[] row = new byte?[fieldRowLength];

                for (int c = 0; c < fieldColumnLength; c++)
                {
                    row[c] = _field[r, c];
                }

                byte? rowSum = row[0];
                for (int i = 0; i < row.Length - 1; i++)
                {
                    rowSum += row[i];
                }

                if (rowSum == fieldRowLength)
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
            for (int r = 0; r < fieldRowLength; r++)
            {
                byte?[] column = new byte?[fieldRowLength];

                for (int c = 0; c < fieldColumnLength; c++)
                {
                    column[c] = _field[c, r];
                }

                byte? columnSum = column[0];
                for (int i = 0; i < column.Length - 1; i++)
                {
                    columnSum += column[i];
                }

                if (columnSum == fieldColumnLength)
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
            var slashSum = _field[2, 0] + _field[1, 1] + _field[0, 2];
            var backSlashSum = _field[0, 0] + _field[1, 1] + _field[2, 2];

            if (slashSum == fieldColumnLength || backSlashSum == fieldColumnLength)
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


        }
    }

    enum Player
    {
        Zero = 0,
        Cross
    }

}
