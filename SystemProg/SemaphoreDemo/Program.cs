// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
var  pool = new Semaphore(3, 3);
for (int i= 0;i< 20; i++)
{
    int a = i;
    Task.Run(()=>{
        pool.WaitOne();
        Console.WriteLine($"Task {a} startted");
        Thread.Sleep(1000);
        pool.Release();
    });
}




Thread.Sleep(10000);