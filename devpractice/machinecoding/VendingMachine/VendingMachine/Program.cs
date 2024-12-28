// See https://aka.ms/new-console-template for more information
using VendingMachine;

Console.WriteLine("Hello, World!");

var products = new List<KeyValuePair<Product, int>>
        {
            new KeyValuePair<Product, int>(new Product(1, "Soda", 25), 10),
            new KeyValuePair<Product, int>(new Product(2, "Chips", 15), 5),
            new KeyValuePair<Product, int>(new Product(3, "Candy", 10), 20),
        };

var vendingMachine = new vendingMachine(products);
var paymentService = new PaymentService();
var customerService = new CustomerService(vendingMachine, paymentService);

customerService.seeAvailableProducts();
var tasks = new List<Task>
{
    Task.Run(async ()=>
    {
        var notes = new List<Note> { Note.Hundred };
        var coins = new List<Coin> { Coin.One, Coin.Two };

        await customerService.buyProduct(new Product(1, "Soda", 25), 2, notes, coins);
    }),
    Task.Run(async ()=>
    {
        var notes = new List<Note> { Note.Fifty };
        var coins = new List<Coin> { Coin.One, Coin.Two };

        await customerService.buyProduct(new Product(2, "Chips", 15), 2, notes, coins);
    }),
};


customerService.seeAvailableProducts();


