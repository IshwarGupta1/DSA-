public class Computer implements Observer{
    @Override
    public void update(String message) {
        System.out.println("computer updates");
        System.out.println(message);
    }
}
