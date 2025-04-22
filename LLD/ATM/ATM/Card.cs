using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    internal class Card
    {
        private string CardID { get; set; }
        private string CardPIN { get; set; }
        public Card(string CardID, string CardPIN) 
        {
            this.CardID = CardID;
            this.CardPIN = CardPIN;
        }

        public string getCardID()
        {
            return CardID;
        }

        public string getCardPin()
        {
            return CardPIN;
        }
    }
}
