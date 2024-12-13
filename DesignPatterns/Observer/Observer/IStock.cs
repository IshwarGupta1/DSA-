using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    public interface IStock
    {
        public void addClient(Client client);
        public void removeClient(Client client);
        public void update(int newPoints, string dir);
    }
}
