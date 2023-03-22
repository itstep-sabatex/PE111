// See https://aka.ms/new-console-template for more information
using System.Diagnostics;


Console.WriteLine("Hello, World!");
using (Process process = new Process())
{
    //process.StartInfo.FileName = "C:\\Users\\serhi\\source\\repos\\itstep-sabatex\\ПВ111\\ADONet\\Calc\\bin\\Debug\\net6.0\\Calc.exe";
    process.StartInfo.FileName = "cmd.exe";
    var progName = Path.GetFileNameWithoutExtension(Environment.GetCommandLineArgs()[0]);
    var folder = Directory.GetCurrentDirectory();
    process.StartInfo.Arguments = $"/C tar -czvf {progName}.tar.gz {folder}";
    process.StartInfo.RedirectStandardOutput = true;
    process.StartInfo.RedirectStandardError = true;
    process.OutputDataReceived += (sender, args) => Console.WriteLine(args.Data);
    process.ErrorDataReceived += (sender, args) => Console.WriteLine(args.Data);
    process.Start();
    process.WaitForExit();
    
    var result = process.ExitCode;
    Console.WriteLine($"summ = {result}");
    Thread.Sleep( 5000 );
}
