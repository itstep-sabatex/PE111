// See https://aka.ms/new-console-template for more information
using System.Net.Security;
using System.Net.Sockets;

Console.WriteLine("Hello, World!");

int Counter=0;
Mutex mutex = new Mutex(true,"MyMutex",);

void Increment(string taskName)
{
    if (mutex.WaitOne())
    {
        Counter++;
        Console.WriteLine($"{ taskName} {Counter}");
        mutex.ReleaseMutex();
    }
}


var t1 =Task.Run(() =>
{
    for (int i = 0; i < 10; i++)
    {
        Increment("Task 1");
    }
});
var t2 =Task.Run(() =>
{
    for (int i = 0; i < 10; i++)
    {
        Increment("Task 2");
    }
});
t1.Wait();
t2.Wait();


