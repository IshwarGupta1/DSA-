package org.example;

public class bank {
    int amount = 10000;
    public synchronized void withdraw(int amnt)
    {
        System.out.println(amount + " current balance");
        if(amount<amnt)
            System.out.println("low balance");
        amount = amount -amnt;
        System.out.println(amnt + " withdrawn, and new amount is "+ (amount));
    }
}
