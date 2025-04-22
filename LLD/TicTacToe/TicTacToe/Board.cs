using System;
using System.Collections.Generic;

namespace TicTacToe
{
    internal class Board
    {
        private int moves;
        private readonly List<List<char>> board = new List<List<char>>();

        public Board(int m)
        {
            InitializeBoard(m);
            moves = 0;
        }

        private void InitializeBoard(int m)
        {
            for (int i = 0; i < m; i++)
            {
                List<char> row = new List<char>();
                for (int j = 0; j < m; j++)
                {
                    row.Add('.');
                }
                board.Add(row);
            }
        }

        public void makeMove(int r, int c, Character ch)
        {
            if (moves == board.Count * board[0].Count)
            {
                throw new Exception("Board is full");
            }
            if (!isValid(r, c) || board[r][c] != '.')
            {
                throw new Exception("Invalid Move");
            }
            board[r][c] = ch.getValue();
            moves++;
        }

        public bool HasWinner()
        {
            int n = board.Count;

            // Check rows
            for (int i = 0; i < n; i++)
            {
                char first = board[i][0];
                if (first == '.') continue;
                bool allSame = true;
                for (int j = 1; j < n; j++)
                {
                    if (board[i][j] != first)
                    {
                        allSame = false;
                        break;
                    }
                }
                if (allSame) return true;
            }

            // Check columns
            for (int j = 0; j < n; j++)
            {
                char first = board[0][j];
                if (first == '.') continue;
                bool allSame = true;
                for (int i = 1; i < n; i++)
                {
                    if (board[i][j] != first)
                    {
                        allSame = false;
                        break;
                    }
                }
                if (allSame) return true;
            }

            // Check main diagonal
            char diag1 = board[0][0];
            if (diag1 != '.')
            {
                bool allSame = true;
                for (int i = 1; i < n; i++)
                {
                    if (board[i][i] != diag1)
                    {
                        allSame = false;
                        break;
                    }
                }
                if (allSame) return true;
            }

            // Check anti-diagonal
            char diag2 = board[0][n - 1];
            if (diag2 != '.')
            {
                bool allSame = true;
                for (int i = 1; i < n; i++)
                {
                    if (board[i][n - 1 - i] != diag2)
                    {
                        allSame = false;
                        break;
                    }
                }
                if (allSame) return true;
            }

            return false;
        }

        private bool isValid(int r, int c)
        {
            return r >= 0 && c >= 0 && r < board.Count && c < board[0].Count;
        }
    }
}
