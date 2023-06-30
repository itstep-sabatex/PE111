// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
ThreadPool.GetMaxThreads(out int wokerThread, out int comletionPortThread);

Console.WriteLine($"Max thread ={wokerThread}, compl = {comletionPortThread}");
Task<string> DemoTask(int a)
{
    string message = $"Task {a}";
    Console.WriteLine(message);
    Thread.Sleep(1000);
    return Task.FromResult(message);
}

async Task<string> DemoTaskAsync(int a)
{
    var b = await DemoTask(a);
    string message = $"Task {a} {b}";

    Console.WriteLine(message);
    Thread.Sleep(1000);
    return message;
}

var aa = await DemoTask(1);
var b = await DemoTaskAsync(2);

var tasks = new List<Task<string>>();
for  (int i = 0; i < 100; i++)
{
    int a = i;
    tasks.Add(Task<string>.Run(() => 
    {
        string message = $"Task {a}";
        Console.WriteLine(message);
        Thread.Sleep( 1000 );
        return message;
    }));
}
do
{   Thread.Sleep( 1000 );
    string result = tasks[0].Result;
    tasks = tasks.Where(a => !a.IsCompleted).ToList();
}while(tasks.Count > 0);

Task<int>.Run(() => { });

