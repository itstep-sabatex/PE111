// See https://aka.ms/new-console-template for more information

int summ = 0;
foreach (var arg  in args)
{
    if (int.TryParse(arg, out int value))
    {
        summ += value;
    }
    
}
Console.WriteLine($"Summ = {summ}");
Environment.Exit(summ);