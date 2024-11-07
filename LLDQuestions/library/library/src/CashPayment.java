public class CashPayment implements Payment{

    @Override
    public void payAmount(double amount) {
        System.out.println("Amount "+ amount + " paid by Cash");
    }
}
