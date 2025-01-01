namespace PubSub
{
    public interface IService
    {
        public void subscribe(User user);
        public void unsubscribe(User user);
        public void update(string message);
    }
}
