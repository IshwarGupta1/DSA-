public class Main {
    public static void main(String[] args) {
        UserContext user = new UserContext();
        CashPaymentStrategy cash = new CashPaymentStrategy();
        UPIPaymentStrategy upi = new UPIPaymentStrategy();
        CreditCardPaymentStrategy creditCard = new CreditCardPaymentStrategy();
        user.payment(cash, 100);
        user.payment(upi, 150);
        user.payment(creditCard, 200);


    }
}