public class StopState implements State{


    @Override
    public void playMusic(User user) {
        System.out.println("music is playing now");
        user.setState(new PlayState());
    }

    @Override
    public void stopMusic(User user) {
        System.out.println("music is already stopped");
    }
}
