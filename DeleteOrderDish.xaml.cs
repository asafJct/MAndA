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
    /// Interaction logic for DeleteOrderDish.xaml
    /// </summary>
    public partial class DeleteOrderDish : Window
    {
        BE.Ordered_Dish orderDish;
        BL.IBL bl;
        public DeleteOrderDish()
        {
            InitializeComponent();
            orderDish = new BE.Ordered_Dish();
            this.DataContext = orderDish;
            bl = BL.FactoryBL.getBL();
            orderNumberComboBox.ItemsSource = from item in bl.getAllOrder()
                                              select item.orderNumber;
        }

        private void deleteOrderDish_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                orderDish.dishNumber = bl.getAllDish(d => d.dishName == dishNameComboBox.SelectedValue).FirstOrDefault().dishId;
                bl.deleteOrderDish(orderDish);
                MessageBox.Show("The dish \"" + dishNameComboBox.SelectedValue+"\"was deleted from the order number \""+orderDish.orderNumber);
                orderDish = new BE.Ordered_Dish();
                this.DataContext = orderDish;
                orderNumberComboBox.ItemsSource = from item in bl.getAllOrder()
                                                  select item.orderNumber; //מחדש orderNumberComboBox-עדכון ה
                dishNameComboBox.ItemsSource = from item in bl.getAllOrdered_Dish(od => od.orderNumber == Convert.ToInt32(orderNumberComboBox.SelectedValue))
                                               select bl.convertDishIdToDishName(item.dishNumber);//מחדש dishNameComboBox-עדכון ה


            }
            catch (Exception b)
            {
                MessageBox.Show(b.Message);
            }
        }

        private void orderNumberComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)//מחזיר את כל המנות של הזמנה ספציפית
        {
            dishNameComboBox.ItemsSource = from item in bl.getAllOrdered_Dish(od => od.orderNumber == Convert.ToInt32(orderNumberComboBox.SelectedValue))
                                           select bl.convertDishIdToDishName(item.dishNumber);

        }
    }
}
