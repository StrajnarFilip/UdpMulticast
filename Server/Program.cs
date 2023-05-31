using System.Net;
using System.Net.Sockets;

var multicastAddress = IPAddress.Parse("224.1.2.3");
var destination = new IPEndPoint(multicastAddress, 1000);
var multicastOption = new MulticastOption(multicastAddress);
System.Console.WriteLine($"{multicastOption.InterfaceIndex} {multicastOption.LocalAddress} {multicastOption.Group}");
UdpClient senderUdp = new(2000);

senderUdp.JoinMulticastGroup(multicastAddress);

senderUdp.Send(new byte[] { 1, 2, 3 }, destination);
