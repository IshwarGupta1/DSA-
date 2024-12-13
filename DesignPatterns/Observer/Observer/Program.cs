// See https://aka.ms/new-console-template for more information
using Observer;

var clientList = new List<Client>();
for(int i=0;i<100;i++)
{
    var client = new Client(i, "client" + i);
    clientList.Add(client);
}
var stock1 = new Stock1(100);
var stock2 = new Stock2(200);
for(int i=0;i<50;i++)
{
    stock1.addClient(clientList[i]);
}
for (int i = 50; i < 100; i++)
{
    stock2.addClient(clientList[i-50]);
}

stock1.update(200, "up");
stock2.update(300, "down");
stock1.update(500, "down");
stock2.update(600, "up");

