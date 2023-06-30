// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
Parallel.For(0, 100, iterator =>
{
    for (int i = 0; i < 100; i++)
    {
        Console.WriteLine($"Thread {iterator} count={i}");
    }

});

var cl = new string[] { "Ivan", "Jone", "Steve" };


//[x,y]   

Parallel.ForEach(cl, iterator => { Console.WriteLine($"Thread for {iterator}"); });
