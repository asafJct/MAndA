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
    /// Interaction logic for OrderDishOption.xaml
    /// </summary>
    public partial class OrderDishOption : Window
    {
        public OrderDishOption()
        {
            InitializeComponent();
        }

        private void AddOrderDish_Click(object sender, RoutedEventArgs e)
        {
            new AddOrderDish().ShowDialog();
        }

        private void DeleteOrderDish_Click(object sender, RoutedEventArgs e)
        {
            new DeleteOrderDish().ShowDialog();
        }

        private void UpdateOrderDish_Click(object sender, RoutedEventArgs e)
        {
            new UpdateOrderDish().ShowDialog();
        }

        private void ListOfOrderDishes_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
