namespace VendingMachine
{
    public class vendingMachine
    {
        public IList<KeyValuePair<Product,int>> products { get; set; }
        private readonly SemaphoreSlim semaphore = new SemaphoreSlim(1,1);
        public vendingMachine(IList<KeyValuePair<Product, int>> products)
        {
            this.products = products;
        }

        public async Task ListAllProducts()
        {
            await semaphore.WaitAsync();
            try
            {
                foreach (var product in products)
                {
                    Console.WriteLine($"Product: {product.Key.Name} with Price {product.Key.Amount} and  Quantity available is {product.Value}");
                }
            }
            finally { semaphore.Release(); }
            
        }

        public async Task<KeyValuePair<Product, int>> ProductAvailibility(Product product)
        {
            await semaphore.WaitAsync();
            try
            {
                var resultProducts = products.Where(p => p.Key.Id == product.Id).FirstOrDefault();
                return resultProducts;
            }
            finally
            {
                semaphore.Release();
            }
            
        }

        public async Task UpdateProductStock(Product product, int quantity)
        {
            await semaphore.WaitAsync();
            try
            {
                for (int i = 0; i < products.Count; i++)
                {
                    if (products[i].Key.Id == product.Id)
                    {
                        products[i] = new KeyValuePair<Product, int>(product, products[i].Value - quantity);
                        break;
                    }
                }
            }
            finally { semaphore.Release(); }
            
        }
    }
}
