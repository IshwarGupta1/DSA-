using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    internal class Stock
    {
        private ConcurrentDictionary<Product, int> _productStock;
        public Stock()
        {
            _productStock = new ConcurrentDictionary<Product, int>();
        }
        
        public void AddProduct(Product product, int quantity)
        {
            _productStock[product] = quantity;
        }

        public bool CheckAvailability(Product product)
        {
            if(!_productStock.ContainsKey(product))
                throw new ArgumentOutOfRangeException(nameof(product));
            return _productStock[product] > 0;
        }

        public int GetQuantity(Product product)
        {
            if (!_productStock.ContainsKey(product))
                throw new ArgumentOutOfRangeException(nameof(product));
            return _productStock[product];
        }

        public void UpdateQuantity(Product product, int quantity) {
            _productStock[product] = quantity;
        }
    }
}
