using System.Net;
using System.Net.Sockets;

const string CLIENT_ADDRESS = "0.0.0.0";
const int CLIENT_PORT = 1500;

var multicastAddress = IPAddress.Parse("224.1.2.3");
var source = new IPEndPoint(multicastAddress, 2000);
UdpClient receiverUdp = new(new IPEndPoint(IPAddress.Parse(CLIENT_ADDRESS), CLIENT_PORT));

receiverUdp.JoinMulticastGroup(multicastAddress);

while (true)
{
    var result = receiverUdp.Receive(ref source);

    foreach (var data in result)
    {
        System.Console.WriteLine(data);
    }
    System.Console.WriteLine($"{DateTime.Now} ----");
}