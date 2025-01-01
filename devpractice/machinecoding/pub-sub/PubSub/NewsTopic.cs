namespace PubSub
{
    public class NewsTopic : ITopic
    {
        public void update(string message)
        {
            Console.WriteLine($"news is {message}.");
        }
    }
}
