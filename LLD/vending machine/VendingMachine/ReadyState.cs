using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    internal class ReadyState : IVendingMachineState
    {
        private readonly VendingMachine vendingMachine;
        public ReadyState(VendingMachine vendingMachine)
        {
            this.vendingMachine = vendingMachine;
        }
        public void DispenseProduct()
        {
            throw new NotImplementedException();
        }

        public void InsertCoin(Coin coin)
        {
            vendingMachine.AddCoin(coin);
            Console.WriteLine("Coin inserted: " + coin);
            CheckPaymentStatus();
        }

        public void InsertNote(Note note)
        {
            vendingMachine.AddNote(note);
            Console.WriteLine("Coin inserted: " + note);
            CheckPaymentStatus();
        }

        public void ReturnChange()
        {
            double change = vendingMachine.TotalPayment - vendingMachine.SelectedProduct.price;
            if (change > 0)
            {
                Console.WriteLine("Change returned: $" + change);
                vendingMachine.ResetPayment();
            }
            else
            {
                Console.WriteLine("No change to return.");
            }
            vendingMachine.SetState(vendingMachine.GetIdleState());
        }

        public void SelectProduct(Product product)
        {
            Console.WriteLine("Product already selected. Please make payment.");
        }

        private void CheckPaymentStatus()
        {
            if (vendingMachine.TotalPayment >= vendingMachine.SelectedProduct.price)
            {
                vendingMachine.SetState(vendingMachine.GetDispenseState());
            }
        }
    }
}
