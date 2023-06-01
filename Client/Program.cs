using System.Net;
using System.Net.Sockets;

const string CLIENT_ADDRESS = "0.0.0.0";
const int CLIENT_PORT = 1500;

const string SOURCE_ADDRESS = "224.1.2.3";
const int SOURCE_PORT = 2000;

var multicastAddress = IPAddress.Parse(SOURCE_ADDRESS);
var source = new IPEndPoint(multicastAddress, SOURCE_PORT);
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