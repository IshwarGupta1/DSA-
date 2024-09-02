using ConsoleApp1.Interface;

namespace ConsoleApp1.Strategies
{
    public class CreditCardPay : IPay
    {
        public void Pay(int amount)
        {
            Console.WriteLine($"Credit Card Paid--{amount}");
        }
    }
}
