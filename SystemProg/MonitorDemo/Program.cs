// See https://aka.ms/new-console-template for more information
using System.Threading;

Console.WriteLine("Hello, World!");
int a = 0;
Object locked = new object();

void Increment(string threadName)
{
    lock (locked)
    {
        a++;
        //Console.WriteLine($"Thread {threadName} Value a ={a}");
    }
}


Task.Run(() => 
{
    for (int i = 0; i < 10; i++)
    {
        if (Monitor.TryEnter(locked,1000))
        {
///

        }
        else
        {


        }
        Interlocked.Increment(ref a);
        Increment("1");
    }
});
Task.Run(() =>
{
    for (int i = 0; i < 10; i++)
    {
        Increment("2");
    }
});
Task.Run(() =>
{
    for (int i = 0; i < 10; i++)
    {
        Increment("3");
     }
});

Thread.Sleep(2000);