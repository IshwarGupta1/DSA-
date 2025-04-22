using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class Player
    {
        public int playerId { get; set; }
        public string playerName { get; set; }
        public Character character { get; set; }
        public Player(int playerId, string playerName, Character character)
        {
            this.playerId = playerId;
            this.playerName = playerName;
            this.character = character;
        }
    }
}
