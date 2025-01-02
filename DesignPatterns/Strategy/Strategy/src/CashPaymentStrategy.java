public class CashPaymentStrategy implements Strategy{
    @Override
    public void doPayment(int amount) {
        System.out.println(amount + " Rs paid via Cash");
    }
}
