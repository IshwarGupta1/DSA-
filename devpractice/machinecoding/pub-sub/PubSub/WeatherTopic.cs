namespace PubSub
{
    public class WeatherTopic : ITopic
    {
        public void update(string message)
        {
            Console.WriteLine($"weather is {message}.");
        }
    }
}
