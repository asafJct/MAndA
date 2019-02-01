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
    /// Interaction logic for DeleteDish.xaml
    /// </summary>
    public partial class DeleteDish : Window
    {
        BE.Dish dish;
        BL.IBL bl;
        public DeleteDish()
        {
            InitializeComponent();
            bl = BL.FactoryBL.getBL();
            dish = new BE.Dish();
            dishNameComboBox.ItemsSource = from item in bl.getAllDish()
                                           select item.dishName;
            this.DataContext = dish;
        }

        private void DeleteDishButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BE.Dish di = new BE.Dish();
                di = bl.getAllDish().FirstOrDefault(d => d.dishName == dish.dishName);
                if (di == null)
                    throw new Exception("this dish doesn't exist");
                else
                    bl.deleteDish(di.dishId);
                MessageBox.Show("the dish \"" + dish.dishName + "\" Deleted from the list", "");
                this.DataContext = dish;
                dishNameComboBox.ItemsSource = from item in bl.getAllDish()
                                               select item.dishName;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }
}
