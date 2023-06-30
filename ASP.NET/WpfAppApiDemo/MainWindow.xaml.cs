using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
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
using WebApplicationApiDemo.Models;

namespace WpfAppApiDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private HttpClient httpClient;
        public MainWindow()
        {
            InitializeComponent();
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:7274");
            httpClient.DefaultRequestHeaders.Add("username", "dgshd");
            httpClient.DefaultRequestHeaders.Add("password", "*********");
        }

        private void UpdateGrid()
        {
            var r = httpClient.GetAsync("api/Students");
            r.Wait();
            var response = r.Result;
            if (response.IsSuccessStatusCode)
            {
                var r1 = response.Content.ReadFromJsonAsync<IEnumerable<Student>>();
                r1.Wait();
                dg.ItemsSource = r1.Result;
            }
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateGrid();
             
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var student = new Student { Name="Peter",Surname="Pizec"};
            var r = httpClient.PostAsJsonAsync("api/Students",student);
            r.Wait();
            var response = r.Result;
            if (response.IsSuccessStatusCode)
            {
                UpdateGrid();
            }

        }
    }
}
