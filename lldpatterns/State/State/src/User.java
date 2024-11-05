public class User {
    public State state;
    public User()
    {
        this.state = new StopState();
    }
    public void setState(State state)
    {
        this.state = state;
    }

    public void playMusic()
    {
        state.playMusic(this);
    }

    public void stopMusic()
    {
        state.stopMusic(this);
    }
}
