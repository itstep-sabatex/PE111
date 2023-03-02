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
    /// Interaction logic for StudentListWindow.xaml
    /// </summary>
    public partial class StudentListWindow : Window
    {
        public StudentListWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (var context = new EFCoreDemoDbContext())
            {
                dgStudents.ItemsSource = context.Students.ToArray();
            }
        }
    }
}
