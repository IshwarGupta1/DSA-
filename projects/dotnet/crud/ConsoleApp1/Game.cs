namespace ConsoleApp1
{
    public class Game
    {
        public int _boardSize; // boardSize given by user
        public List<Player> _players; // list of players
        public Game(int boardSize, List<Player> players)
        {
            _boardSize = boardSize;
            _players = players;
        }

        public void playGame()
        {
            var board = new List<List<string>>(); // game board

            // Initializing game board with empty values
            for (int i = 0; i < _boardSize; i++)
            {
                List<string> row = new List<string>();
                for (int j = 0; j < _boardSize; j++)
                {
                    row.Add("_"); // empty value
                }
                board.Add(row); // Add the row to the board
            }

            displayBoard(board);

            var random = new Random();
            var moves = 0;
            while (moves < _boardSize * _boardSize)
            {
                
                for (int i = 0; i < _players.Count; i++)
                {
                    // move by player
                    var mover = random.Next(0, _boardSize);
                    var movec = random.Next(0, _boardSize);

                    while (board[mover][movec] != "_")
                    {
                        mover = random.Next(0, _boardSize);
                        movec = random.Next(0, _boardSize);
                    }
                    board[mover][movec] = _players[i].symbol.ToString();
                    moves++;
                    displayBoard(board);
                    if (checkVictory(board, _players[i].symbol.ToString()))
                    {
                        
                        Console.WriteLine($"Winner of this game is {_players[i].name}");
                        displayBoard(board);
                        return;
                    }
                }
            }
            Console.WriteLine("Game is a Tie");
           
        }

        //Display Board
        private void displayBoard(List<List<string>> board)
        {
            for (int i = 0; i < _boardSize; i++)
            {
                for (int j = 0; j < _boardSize; j++)
                {
                    Console.Write(board[i][j]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }

        //check if there is victory or not
        private bool checkVictory(List<List<string>> board, string symbol)
        {
            // Check rows
            for (int i = 0; i < _boardSize; i++)
            {
                if (board[i].All(x => x == symbol)) return true; // Check if all elements in the row are the symbol
            }

            // Check columns
            for (int i = 0; i < _boardSize; i++)
            {
                if (board.Select(row => row[i]).All(x => x == symbol)) return true; // Check if all elements in the column are the symbol
            }

            // Check main diagonal
            if (Enumerable.Range(0, _boardSize).All(i => board[i][i] == symbol)) return true;

            // Check anti-diagonal
            if (Enumerable.Range(0, _boardSize).All(i => board[i][_boardSize - 1 - i] == symbol)) return true;

            return false;
        }
    }
}
