package org.example.Services;

import org.example.models.Car;

public class CCPaymentStrategy implements IPaymentStrategy{
    private String creditCardNumber;
    private String creditCardHolder;

    public CCPaymentStrategy(String creditCardNumber, String creditCardHolder) {
        this.creditCardNumber = creditCardNumber;
        this.creditCardHolder = creditCardHolder;
    }

    @Override
    public void payment(double amounttobePaid) {

        System.out.println(amounttobePaid + " INR is paid from CreditCardHolder " + creditCardHolder + " having Credit Card number " + creditCardNumber);
    }
}
