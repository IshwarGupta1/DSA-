namespace Observer
{
    public class Client
    {
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public Client(int ClientId, string ClientName)
        {
            this.ClientId = ClientId;
            this.ClientName = ClientName;
        }

        public void Updates(string dir, int point)
        {
            Console.WriteLine(ClientId + ":" + ClientName);
            switch (dir)
            {
                case "up":
                    Console.WriteLine("the stock went " + dir + " by "+ point.ToString()); 
                    break;
                case "down":
                    Console.WriteLine("the stock went " + dir + " by " + point.ToString());
                    break;
                case "neutral":
                    Console.WriteLine("the stock remain " + dir + " with " + point.ToString());
                    break;
                default:
                    throw new Exception();
            }
        }
    }
}
