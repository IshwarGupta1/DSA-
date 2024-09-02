using ConsoleApp1;
using ConsoleApp1.Strategies;
using System;
public class Program
{
    public static void Main(string[] args)
    {
        int amount = 1000;
        var shoppingPay1 = new Context(new CashPay());
        shoppingPay1.doPayment(amount);
        var shoppingPay2 = new Context(new CreditCardPay());
        shoppingPay2.doPayment(amount);
        var shoppingPay3 = new Context(new UPIPay());
        shoppingPay3.doPayment(amount);
    }
}