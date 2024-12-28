namespace VendingMachine
{
    public class PaymentService
    {
        public bool PayAmount(int amount, List<Note> notes, List<Coin> coins, out int change)
        {
            int totalPayment = notes.Sum(n => (int)n) + coins.Sum(c => (int)c);

            if (totalPayment < amount)
            {
                Console.WriteLine("Insufficient funds. Please add more money.");
                change = 0;
                return false;
            }

            change = totalPayment - amount;

            if (change > 0)
            {
                Console.WriteLine($"Payment successful! Returning change: {change}");
                Console.WriteLine(GetChangeBreakdown(change));
            }
            else
            {
                Console.WriteLine("Payment successful! No change to return.");
            }

            return true;
        }

        private string GetChangeBreakdown(int change)
        {
            var denominations = new[] { 100, 50, 20, 10, 5, 2, 1 };
            var breakdown = new Dictionary<int, int>();

            foreach (var denom in denominations)
            {
                if (change == 0) break;

                int count = change / denom;
                if (count > 0)
                {
                    breakdown[denom] = count;
                    change %= denom;
                }
            }

            return string.Join(", ", breakdown.Select(kvp => $"{kvp.Value} x {kvp.Key}"));
        }
    }
}
