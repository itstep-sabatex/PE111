// See https://aka.ms/new-console-template for more information


using ThreadDemo;

static void Method(object a)
{
    MatrixPar? param = a as MatrixPar;
    if (param != null )
    {
        param.result = MultiplreOneElement(param.dim, param.i, param.j, param.a, param.b);
    }

}



static double MultiplreOneElement(int dim, int i,int j,double[,] a, double[,] b)
{
    double result = 0;
    //var xDim = a.GetLength(0);
    //var yDim = a.GetLength(1);

    for (int mi = 0; mi < dim; mi++)
    {
        result =result + a[i,mi] * b[mi,j];
    }
    return result;
}

double[,] a = new double[10,10];
double[,] b = new double[10,10];

MatrixPar[,] threads = new MatrixPar[10,10];
for (int i = 0; i < 10; i++)
{
    for (int j = 0; j < 10; j++)
    {
        threads[i,j] = new MatrixPar(10, i, j, a, b, new Thread(Method));
        threads[i,j].thisThread.Start(threads[i,j]);
    }
}


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
