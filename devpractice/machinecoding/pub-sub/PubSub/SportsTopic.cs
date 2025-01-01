namespace PubSub
{
    public class SportsTopic : ITopic
    {
        public void update(string message)
        {
            Console.WriteLine($"new is {message}.");
        }
    }
}
