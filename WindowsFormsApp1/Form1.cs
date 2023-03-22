using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public delegate void WriteToConsoleDelegate(int count);

        private void SetProgressBar(int count)
        {
            progressBar1.Value = count;
        }
 
        public void WriteToConsole(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Action<int> d = SetProgressBar;
                this.Invoke(d,i);
                //progressBar1.Value = i;
                Console.WriteLine($"Delegate write to console {i}");
                Thread.Sleep(1000);
            }
        }
       private void buttonStartDelegate_Click(object sender, EventArgs e)
       {
            WriteToConsoleDelegate dl = WriteToConsole;
            dl.BeginInvoke(100,null,null);
            Console.WriteLine("Delegate started");

       }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            while (progressBar1.Value < 100)
            {
                progressBar1.Value++;
                Thread.Sleep(100);
            }
         }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < 100)
            {
                progressBar1.Value++;
            }
            else
                progressBar1.Value = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void buttonTimerStop_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

     }
}
