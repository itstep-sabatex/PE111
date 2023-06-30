// See https://aka.ms/new-console-template for more information
using System.Net;
using System.Net.Sockets;

Console.WriteLine("Hello, World!");


Task.Run(() => 
{ 
    TcpListener listener = null;
    try
    {
        int port = 10000;
        IPAddress localaddr = new IPAddress(new byte[] { 127, 0, 0, 1 });
        listener = new TcpListener(localaddr, port);
        listener.Start();
        byte[] buffer = new byte[1024];
        string data = string.Empty;
        while (true)
        {
            Console.WriteLine("Waiting for a connection ...");
            TcpClient client = listener.AcceptTcpClient();
            Console.WriteLine("Client connected ...");
            data = null;
            NetworkStream stream = client.GetStream();
            int i;
            while ((i= stream.Read(buffer,0,buffer.Length)) !=0) 
            {
                data = System.Text.Encoding.UTF8.GetString(buffer,0,i);
                Console.WriteLine("Server Received: {0}", data);
                data = data.ToUpper();
                byte[] msg = System.Text.Encoding.UTF8.GetBytes(data);
                stream.Write(msg,0,msg.Length);
                Console.WriteLine("Server Sent:{0}", data);
            }
            client.Close();
            
        }

    }
    catch (Exception ex){
        Console.WriteLine("Error : {0}",ex);
    }
    finally 
    {
        listener?.Stop();
    }

});
Task.Run(() =>
{
    try
    {
        //int port = 10000;
        var client = new TcpClient("127.0.0.1", 10000);
        string message = "test message";
        byte[] data = System.Text.Encoding.UTF8.GetBytes(message);
        NetworkStream stream = client.GetStream();
        stream.Write(data, 0, data.Length);
        Console.WriteLine("Client Send: {0}", message);
        data = new byte[1024];
        var responseData = string.Empty;
        int bytes = stream.Read(data, 0, data.Length);
        responseData = System.Text.Encoding.UTF8.GetString(data, 0, bytes);
        Console.WriteLine("Client Received: {0}", responseData);
        stream.Close();
        client.Close();
    }
    catch (Exception ex) { Console.WriteLine("Error: {0}", ex); }

});

Console.ReadLine();