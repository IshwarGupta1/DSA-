using System;
using System.Collections.Generic;

namespace TicTacToe
{
    internal class Game
    {
        private readonly Board board;
        private readonly List<Player> players = new List<Player>();
        private int currentPlayerIndex = 0;
        private readonly int size;

        public Game(int size, List<Player> playerList)
        {
            this.size = size;
            board = new Board(size);
            players.AddRange(playerList);
        }

        public void Start()
        {
            while (true)
            {
                Console.Clear();
                PrintBoard();

                var currentPlayer = players[currentPlayerIndex];
                Console.WriteLine($"{currentPlayer.playerName}'s turn ({currentPlayer.character.getValue()}):");
                Console.Write("Enter row: ");
                int row = int.Parse(Console.ReadLine());
                Console.Write("Enter column: ");
                int col = int.Parse(Console.ReadLine());

                try
                {
                    board.makeMove(row, col, currentPlayer.character);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadKey();
                    continue;
                }

                if (board.HasWinner())
                {
                    Console.Clear();
                    PrintBoard();
                    Console.WriteLine($"{currentPlayer.playerName} wins!");
                    break;
                }

                if (board.IsFull())
                {
                    Console.Clear();
                    PrintBoard();
                    Console.WriteLine("It's a draw!");
                    break;
                }

                currentPlayerIndex = (currentPlayerIndex + 1) % players.Count;
            }
        }

        private void PrintBoard()
        {
            for (var i = 0; i < size; i++)
            {
                for (var j = 0; j < size; j++)
                {
                    Console.Write(board[i][j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
