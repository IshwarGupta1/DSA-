// Delegate Declaration
public delegate void NotifyEventHandler(string message);

// Publisher Class
class Publisher
{
    public event NotifyEventHandler OnNotify;

    public void Notify(string message)
    {
        if (OnNotify != null)
            OnNotify(message); // Trigger event
    }
}

// Subscriber Class
class Subscriber
{
    public void HandleNotification(string message)
    {
        Console.WriteLine($"Received: {message}");
    }
}

// Usage
class Program
{
    static void Main()
    {
        Publisher publisher = new Publisher();
        Subscriber subscriber = new Subscriber();

        publisher.OnNotify += subscriber.HandleNotification;
        publisher.Notify("Event triggered!");
    }
}
