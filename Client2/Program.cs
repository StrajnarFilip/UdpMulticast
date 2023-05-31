using System.Net;
using System.Net.Sockets;

var multicastAddress = IPAddress.Parse("224.1.2.3");
var source = new IPEndPoint(multicastAddress, 2000);
UdpClient receiverUdp = new(1001);

receiverUdp.JoinMulticastGroup(multicastAddress);

while (true)
{
    var result = receiverUdp.Receive(ref source);

    foreach (var data in result)
    {
        System.Console.WriteLine(data);
    }
    System.Console.WriteLine("OK ----");
}