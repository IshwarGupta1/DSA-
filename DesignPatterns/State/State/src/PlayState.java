public class PlayState implements State{


    @Override
    public void playMusic(User user) {
        System.out.println("music is already playing");
    }

    @Override
    public void stopMusic(User user) {
        System.out.println("music is stopped");
        user.setState(new StopState());
    }
}
