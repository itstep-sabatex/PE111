using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TimerThreadDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Timer? timer;
        public MainWindow()
        {
            InitializeComponent();
            "sdds".Split("")
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           timer = new Timer(TimerHandle,null,1000,1000);
        }

        private void TimerHandle(object? state)
        {
            Thread.Sleep(1000);
            var c = DateTime.Now;
            timerText.Dispatcher.Invoke(() => { timerText.Text = c.ToString(); });


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            timerText.Text = "button click";
            //Thread.Sleep(20000);
        }
    }
}
