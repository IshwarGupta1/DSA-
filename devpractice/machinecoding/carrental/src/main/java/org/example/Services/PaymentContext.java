package org.example.Services;

public class PaymentContext {
    private IPaymentStrategy paymentStrategy;
    public PaymentContext(IPaymentStrategy paymentStrategy)
    {
        this.paymentStrategy = paymentStrategy;
    }

    public void payment(double amounttobePaid) {
        paymentStrategy.payment(amounttobePaid);
    }
}
