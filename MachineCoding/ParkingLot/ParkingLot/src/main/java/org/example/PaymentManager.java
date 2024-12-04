package org.example;

public class PaymentManager {
    PaymentContext paymentContext = new PaymentContext();
    public void payCharge(double totalCharge, String modeOfPayment)
    {
        switch (modeOfPayment){
            case "Credit Card" :
                paymentContext.setPaymentStrategy(new CCPayment());
                paymentContext.executePayment(totalCharge);
                return;
            case "Cash" :
                paymentContext.setPaymentStrategy(new CashPayment());
                paymentContext.executePayment(totalCharge);
                return;
            case "UPI" :
                paymentContext.setPaymentStrategy(new UPIPayment());
                paymentContext.executePayment(totalCharge);
                return;
            default :
                throw new RuntimeException("payment mode not accepted");
        }
    }
}
