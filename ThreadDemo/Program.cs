// See https://aka.ms/new-console-template for more information


static void Method(object a)
{
    Console.WriteLine($"Method argument a={a}");
}


static double MultiplreOneElement(int dim, int i,int j,double[,] a, double[,] b)
{
    double result = 0;
    //var xDim = a.GetLength(0);
    //var yDim = a.GetLength(1);

    for (int mi = 0; mi < dim; mi++)
    {
        result =result * a[i,mi] * b[mi,j];
    }
    return result;
}

var tr = new Thread(Method);
tr.Start(10);

Console.WriteLine($"Main thread number =  {Thread.CurrentThread.ManagedThreadId}");
var tr1 = new Thread(() =>
{
    for (int i = 0; i < 10; i++)
    {
        Console.WriteLine($"Thread 1 number = {Thread.CurrentThread.ManagedThreadId}");
        Thread.Sleep( 1000 );
    }
});
//tr1.IsBackground = true;
tr1.Priority = ThreadPriority.Highest;
tr1.Start();
var tr2 = new Thread(() =>
{
    for (int i = 0; i < 10; i++)
    {
        Console.WriteLine($"Thread 2 number = {Thread.CurrentThread.ManagedThreadId}");
        Thread.Sleep( 1000 );
    }
});
tr2.IsBackground = true;
tr2.Start();
var tr3 = new Thread(() =>
{
    for (int i = 0; i < 10; i++)
    {
        Console.WriteLine($"Thread 3 number = {Thread.CurrentThread.ManagedThreadId}");
        Thread.Sleep(1000);
    }
});
tr3.Priority = ThreadPriority.Normal;
tr3.IsBackground = true;
tr3.Start();




//Thread.Sleep(1000);
Console.WriteLine($"Main thread number =  {Thread.CurrentThread.ManagedThreadId}");


Thread.Sleep( 3000 );



Console.WriteLine("End main thread");
