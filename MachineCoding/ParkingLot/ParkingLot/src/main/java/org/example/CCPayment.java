package org.example;

public class CCPayment implements PaymentStrategy{
    @Override
    public void pay(double amount) {
        System.out.println("Credit Card paid "+ amount);
    }
}
