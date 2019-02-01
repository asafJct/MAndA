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
    /// Interaction logic for UpdateOrderDish.xaml
    /// </summary>
    public partial class UpdateOrderDish : Window
    {
        BE.Ordered_Dish newOrderDish, oldOrderDish;
        BL.IBL bl;
        public UpdateOrderDish()
        {
            InitializeComponent();
            newOrderDish = new BE.Ordered_Dish();
            this.gridUpdateOrderDish.DataContext = newOrderDish;
            bl = BL.FactoryBL.getBL();
            orderNumberTextBox.ItemsSource = from item in bl.getAllOrder()
                                             select item.orderNumber;

            //dishNameComboBox.ItemsSource = from orderdish in bl.getAllOrdered_Dish()
            //                                from order in bl.getAllOrder()
            //                                where orderdish.orderNumber == order.orderNumber
            //                                select bl.convertDishIdToDishName(orderdish.dishNumber);
        }

        private void updateOrderDish_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.updateOrderDish(newOrderDish,oldOrderDish);
                newOrderDish = new BE.Ordered_Dish();
                this.gridUpdateOrderDish.DataContext = newOrderDish;
            }
            catch (Exception b)
            {
                MessageBox.Show(b.Message);
            }

        }

        private void orderNumberTextBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dishNameComboBox.ItemsSource = from item in bl.getAllOrdered_Dish(od => od.orderNumber == Convert.ToInt32(orderNumberTextBox.SelectedValue))
                                           select bl.convertDishIdToDishName(item.dishNumber);
        }
        int convertDishnameToDishId(string name)
        {
            return bl.getAllDish(d=>d.dishName==name).FirstOrDefault().dishId;


        }
        private void dishNameComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //newOrderDish = bl.getAllOrdered_Dish((Od => Od.orderNumber == newOrderDish.orderNumber) &&( Od.dishNumber == convertDishnameToDishId((dishNameComboBox.SelectedValue).ToString()).FirstOrDefault().dishId)).FirstOrDefault() ;
            //oldOrderDish = newOrderDish;
            //this.gridUpdateOrderDish.DataContext = newOrderDish;
        }
    }
}
