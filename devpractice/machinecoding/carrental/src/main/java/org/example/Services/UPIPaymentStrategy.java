package org.example.Services;

import org.example.models.Car;

public class UPIPaymentStrategy implements IPaymentStrategy{
    private String upiId;

    public UPIPaymentStrategy(String upiId) {
        this.upiId = upiId;
    }

    @Override
    public void payment(double amounttobePaid) {
        System.out.println(amounttobePaid + " INR paid from UPI Id " + upiId);
    }
}
