// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using System.Runtime.InteropServices;

Console.WriteLine("Hello, World!");
[DllImport("user32.dll",CallingConvention = CallingConvention.StdCall)]
static extern void MessageBox(IntPtr hWnd, string text, string caption, uint uType = 0x02);
IntPtr intPtr = Process.GetCurrentProcess().MainWindowHandle;
MessageBox(intPtr,"Title dll window","Demo");
Thread.Sleep(5000);