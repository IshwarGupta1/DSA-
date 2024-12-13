namespace Observer
{
    public class Stock1 : IStock
    {
        public int points { get; set; }
        public string name = "Stock1";
        List<Client> clients = new List<Client>();
        public Stock1(int points)
        {
            this.points = points;
        }
        public void addClient(Client client)
        {
            clients.Add(client);
        }

        public void removeClient(Client client)
        {
            clients.Remove(client);
        }

        public void update(int newPoints, string dir)
        {
            switch (dir)
            {
                case "up":
                    points += newPoints;
                    break;
                case "down":
                    points -= newPoints; 
                    break;
                case "neutral":
                    points = points;
                    break;
                default:
                    throw new Exception();
            }
            Console.WriteLine("Stock1 new points are " + points);
            foreach(var client in clients)
            {
                client.Updates(dir, newPoints);
            }
        }
    }
}
