namespace VendingMachine
{
    public class CustomerService
    {
        private readonly vendingMachine machine;
        private readonly PaymentService paymentService;
        public CustomerService(vendingMachine machine, PaymentService paymentService)
        {
            this.machine = machine;
            this.paymentService = paymentService;
        }

        public void seeAvailableProducts()
        {
            machine.ListAllProducts();
        }

        public async Task buyProduct(Product product, int quantity, List<Note> notes, List<Coin> coins)
        { 
            var productList = await machine.ProductAvailibility(product);
            var productQuantity = productList.Value;
            if (productQuantity < quantity)
                Console.WriteLine("Sorry not much left in stock");
            var totalAmount = product.Amount * quantity;
            
            if(paymentService.PayAmount(totalAmount, notes, coins, out int change))
            {
                Console.WriteLine($"product purchased by customer and change to be returned is {change}");
                machine.UpdateProductStock(productList.Key, quantity);
            }
        }
    }
}
