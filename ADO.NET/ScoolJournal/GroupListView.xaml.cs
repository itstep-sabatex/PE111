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
    /// Interaction logic for GroupListView.xaml
    /// </summary>
    public partial class GroupListView : Window
    {
        public GroupListView()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (var context = new EFCoreDemoDbContext())
            {
                dg.ItemsSource = context.StudentGroups.ToArray();
            }

        }
    }
}
