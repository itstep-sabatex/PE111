using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UDPDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UdpClient udpClient = new UdpClient();
            udpClient.Client.Bind(new IPEndPoint(IPAddress.Any, 5000));

            Task.Run(() =>
            {
                var from = new IPEndPoint(0, 5000);
                while (true)
                {
                    Thread.Sleep(1000);
                    var recvBuffer = udpClient.Receive(ref from);

                    Console.WriteLine($"Recesive bytes: {recvBuffer.Length}");
                }
            
            
            
            });

            var data = Encoding.UTF8.GetBytes("Hello World");
            var ipAddress = new IPAddress(new byte[] {255,255,255,255});
            udpClient.Send(data,data.Length,"255.255.255.255",5000);



            Console.ReadLine();
        }
    }
}