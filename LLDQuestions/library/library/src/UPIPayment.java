public class UPIPayment implements Payment{

    @Override
    public void payAmount(double amount) {
        System.out.println("Amount "+ amount + " paid by UPI");
    }
}
