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
    /// Interaction logic for AddDish.xaml
    /// </summary>
    public partial class AddDish : Window
    {
        BE.Dish dish;
        BL.IBL bl;
        public AddDish()
        {
            InitializeComponent();

            dish = new BE.Dish();
            this.gridAddDish.DataContext = dish;
            bl = BL.FactoryBL.getBL();

            dishSizeComboBox.ItemsSource = Enum.GetValues(typeof(BE.Size));
            this.hechsherComboBox.ItemsSource = Enum.GetValues(typeof(BE.kosherLevel));
        }

        private void AddDishButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.addDish(dish);
                MessageBox.Show("the dish \"" + dish.dishName + "\" is added to the list", "");
                dish = new BE.Dish();
                this.gridAddDish.DataContext = dish;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
