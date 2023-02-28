using EFCoreDemo.Models;
using ScoolJournal.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ScoolJournal
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public User[] Users { get; set; }
        public int UserId { get; set; }
        public Login()
        {
            InitializeComponent();

        }

        private void Button_CheckPassword(object sender, RoutedEventArgs e)
        {
            using (var context = new EFCoreDemoDbContext())
            {
                var user = context.Users.Find(UserId);
                if (user?.Password == passwordB.Password)
                {

                }
                else
                {
                    errorBlock.Visibility = Visibility.Visible;
                }
            }

        }
        private void Button_Cancel(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (var context = new EFCoreDemoDbContext())
            {
                var r = context.Users.Select(x => new { Id=x.Id,Name=x.Name}).ToList();
                usersBox.ItemsSource = r;
            }
            Enum.GetNames(typeof(UserLevel))
                Enum.GetValues()

            
        }

        private void passwordB_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void passwordB_GotFocus(object sender, RoutedEventArgs e)
        {
            errorBlock.Visibility= Visibility.Collapsed;
        }
    }
}
