// See https://aka.ms/new-console-template for more information
using ConsoleApp1;

var player1 = new Player { name = "Player 1", symbol = Symbol.X };
var player2 = new Player { name = "Player 2", symbol = Symbol.O };

// Add players to a list
var players = new List<Player> { player1, player2 };

// Initialize game with a specific board size (e.g., 3 for a 3x3 Tic Tac Toe)
var game = new Game(3, players);

// Start the game
game.playGame();
