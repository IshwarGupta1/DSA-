using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    internal interface IVendingMachineState
    {
        void SelectProduct(Product product);
        void InsertCoin(Coin coin);
        void InsertNote(Note note);
        void DispenseProduct();
        void ReturnChange();
    }
}
