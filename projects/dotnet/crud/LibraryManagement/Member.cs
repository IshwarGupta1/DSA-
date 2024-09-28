using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    public class Member
    {
        public string Name { get; set; }
        public LibraryCard Card { get; set; }
        public Double Fine { get; set; }
        public Member(string name, LibraryCard card, double fine)
        {
            name = Name;
            Card = card;
            Fine = fine;
        }
    }
}
