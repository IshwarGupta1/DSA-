using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    internal class Product
    {
        public string productName { get; set; }
        public double price { get; set; }
        public Product(string productName, double price)
        {
            this.productName = productName;
            this.price = price;
        }
    }
}
