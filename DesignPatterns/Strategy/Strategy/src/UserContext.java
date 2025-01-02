public class UserContext {
    public void payment(Strategy strategy, int amount)
    {
        System.out.print("User has ");
        strategy.doPayment(amount);
    }
}
