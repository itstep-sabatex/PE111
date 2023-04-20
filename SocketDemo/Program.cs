// See https://aka.ms/new-console-template for more information
using System.Net;
using System.Net.Sockets;
using System.Text;

Task.Run(() =>
{
    // Server
    //IPHostEntry iPHostEntry = Dns.GetHostEntry(Dns.GetHostName());
    //IPAddress iPAddress = iPHostEntry.AddressList[0];
    IPAddress ip = new IPAddress(new byte[] { 127, 0, 0, 1 });
    IPEndPoint localEndPoint = new IPEndPoint(ip, 10000);


    Socket listner = new Socket(localEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
    try
    {
        listner.Bind(localEndPoint);
        listner.Listen(1000);
        byte[] bytes = new Byte[1024];
        while (true)
        {
            Console.WriteLine("Waiting for a connection ...");
            Socket handler = listner.Accept(); // wait connection
            Console.WriteLine("Connected server side ...");
            string data = "";
            while (true)
            {
                int bytesRec = handler.Receive(bytes);
                data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                if (data.IndexOf("\r\n") > -1)
                {
                    break;
                }

            }
            Console.WriteLine("Text received: {0}", data);
        }
    
    
    }
    catch (Exception ex)
    {

    }




});

Task.Run(() => 
{
    // Client
    byte[] bytes = new byte[1024];
    IPAddress ip = new IPAddress(new byte[] { 127, 0, 0, 1 });
    IPEndPoint localEndPoint = new IPEndPoint(ip, 10000);

    Socket listner = new Socket(localEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
    try
    {
        listner.Connect(localEndPoint);
        Console.WriteLine("Client connected to {0}", listner.RemoteEndPoint.ToString());
        byte[] msg = Encoding.ASCII.GetBytes("Test message from client a test... \r\n");
        listner.Send(msg);
        listner.Shutdown(SocketShutdown.Both);
        listner.Close();

    }
    catch(Exception ex) 
    { 
    }



});

Console.ReadLine();