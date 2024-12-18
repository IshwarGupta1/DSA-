using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events_Delegates
{
    public class Publisher
    {
        public delegate void Notify(string message);
        public event Notify OnNotify;
        public void AlertMessage(string message)
        {
            OnNotify(message);
        }
    }
}
