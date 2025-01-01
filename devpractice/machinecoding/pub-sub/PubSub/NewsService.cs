namespace PubSub
{
    public class NewsService : IService
    {
        List<User> users;
        ITopic topic;
        public NewsService(List<User> users, ITopic topic)
        {
            this.users = users;
            this.topic = topic;
        }

        public void subscribe(User user)
        {
            users.Add(user);
        }   

        public void unsubscribe(User user)
        {
            users.Remove(user);
        }

        public void update(string message)
        {
            foreach(User user in users)
            {

            }
        }
    }
}
