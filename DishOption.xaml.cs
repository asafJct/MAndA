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
    /// Interaction logic for Dish.xaml
    /// </summary>
    public partial class DishOption : Window
    {
        public DishOption()
        {
            InitializeComponent();
        }

        private void AddDish_Click(object sender, RoutedEventArgs e)
        {
            new AddDish().ShowDialog();
        }

        private void DeleteDish_Click(object sender, RoutedEventArgs e)
        {
            new DeleteDish().ShowDialog();
        }

        private void UpdateDish_Click(object sender, RoutedEventArgs e)
        {
            new UpdateDish().ShowDialog();
        }

        private void allDishes_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
