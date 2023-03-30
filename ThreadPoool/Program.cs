// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
ThreadPool.GetMaxThreads(out int wokerThread, out int comletionPortThread);

Console.WriteLine($"Max thread ={wokerThread}, compl = {comletionPortThread}");

var tasks = new List<Task>();
for  (int i = 0; i < 100; i++)
{
    int a = i;
    tasks.Add(Task.Run(() => 
    { 
        Console.WriteLine($"Task {a}");
        Thread.Sleep( 1000 );
    }));
}
while (tasks.Where(a=>!a.IsCompleted).Count() > 0) Thread.Sleep(1000);

