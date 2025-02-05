package org.example.Services;

import org.example.models.Car;

public class CashPaymentStrategy implements IPaymentStrategy{
    @Override
    public void payment(double amounttobePaid) {
        System.out.println(amounttobePaid + " INR paid in cash");
    }
}
