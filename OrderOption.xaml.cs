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

namespace PLForms
{
    /// <summary>
    /// Interaction logic for order.xaml
    /// </summary>
    public partial class OrderOption : Window
    {
        public OrderOption()
        {
            InitializeComponent();
        }

        private void AddOrder_Click(object sender, RoutedEventArgs e)
        {
            new AddOrder().ShowDialog();
        }

        private void DeleteOrder_Click(object sender, RoutedEventArgs e)
        {
            new DeleteOrder().ShowDialog();
        }

        private void UpdateOrder_Click(object sender, RoutedEventArgs e)
        {
            new UpdateOrder().ShowDialog();
        }

     
      
    }
}
             