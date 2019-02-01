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
    /// Interaction logic for UpdateDish.xaml
    /// </summary>
    public partial class UpdateDish : Window
    {
        BE.Dish dish;
        BL.IBL bl;
        public UpdateDish()
        {
            InitializeComponent();
            dish = new BE.Dish();
            this.gridUpdateDish.DataContext = dish;
            bl = BL.FactoryBL.getBL();
            dishIdComboBox.ItemsSource = from item in bl.getAllDish()
                                         select item.dishId;
            hechsherComboBox.ItemsSource = Enum.GetValues(typeof(BE.kosherLevel));
            dishSizeComboBox.ItemsSource = Enum.GetValues(typeof(BE.Size));

        }


        private void UpdatDishButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.updateDish(dish);
                MessageBox.Show("the dish \"" + dish.dishName + "\" updated  ", " Successfully updated! ");
                dish = new BE.Dish();
                this.gridUpdateDish.DataContext = dish;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void dishIdComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dish=bl.getAllDish(d => d.dishId == dish.dishId).FirstOrDefault();
            this.gridUpdateDish.DataContext = dish;
        }
    }
}
