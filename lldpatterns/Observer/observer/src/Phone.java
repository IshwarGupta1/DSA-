public class Phone implements Observer{
    @Override
    public void update(String message) {
        System.out.println("phone updates");
        System.out.println(message);
    }
}
