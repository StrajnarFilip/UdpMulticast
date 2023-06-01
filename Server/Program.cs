using System.Net;
using System.Net.Sockets;

const string SERVER_ADDRESS = "0.0.0.0";
const int SERVER_PORT = 2000;

var multicastAddress = IPAddress.Parse("224.1.2.3");
var destination = new IPEndPoint(multicastAddress, 1000);
var multicastOption = new MulticastOption(multicastAddress);
System.Console.WriteLine($"{multicastOption.InterfaceIndex} {multicastOption.LocalAddress} {multicastOption.Group}");
UdpClient senderUdp = new(new IPEndPoint(IPAddress.Parse(SERVER_ADDRESS), SERVER_PORT));

senderUdp.JoinMulticastGroup(multicastAddress);

while (true)
{
    senderUdp.Send(new byte[] { 1, 2, 3 }, destination);
    Thread.Sleep(5000);
}