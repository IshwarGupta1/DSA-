using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    internal class IdleState : IVendingMachineState
    {
        private readonly VendingMachine vendingMachine;
        public IdleState(VendingMachine vendingMachine)
        {
            this.vendingMachine = vendingMachine;
        }
        public void DispenseProduct()
        {
            Console.WriteLine("Please select a product first");
        }

        public void InsertCoin(Coin coin)
        {
            Console.WriteLine("Please select product first and then insert currency");
        }

        public void InsertNote(Note note)
        {
            Console.WriteLine("Please select product first and then insert currency");
        }

        public void ReturnChange()
        {
            Console.WriteLine("Please select product first and then do payment");
        }

        public void SelectProduct(Product product)
        {
           if(vendingMachine.Inventory.CheckAvailability(product))
            {
                vendingMachine.SelectProduct(product);
                vendingMachine.SetState(vendingMachine.GetReadyState());
            }
        }
    }
}
