using ConsoleApp1.Interface;

namespace ConsoleApp1.Strategies
{
    public class UPIPay : IPay
    {
        public void Pay(int amount)
        {
            Console.WriteLine($"UPI Paid--{amount}");
        }
    }
}
