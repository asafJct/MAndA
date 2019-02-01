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
using BE;
using BL;

namespace PLForms
{
    /// <summary>
    /// Interaction logic for payments.xaml
    /// </summary>
    public partial class payments : Window
    {
        BL.IBL bl;
        BE.Order order;
        private int id;
        public payments()
        {
            InitializeComponent();
            bl = BL.FactoryBL.getBL();
            order = new BE.Order();
            orderNumberComboBox.ItemsSource = bl.getAllOrder();
            orderNumberComboBox.SelectedValuePath = orderNumberComboBox.DisplayMemberPath = "orderNumber";
            AccountDetails.ItemsSource = bl.getListDishes();
        }
        //private int GetSelectedOrderNumber()
        //{
        //    object result = this.orderNumberComboBox.SelectedValue;
        //    if (result == null)
        //        throw new Exception("must select Student First");
        //    return (int)result;
        //}
        //private void refreshDataGrid(int Id)
        //{
        //    AccountDetails.ItemsSource = bl.getDishesToOrder(id);
        //        //from item1 in bl.getAllOrdered_Dish()
        //        //                         where item1.orderNumber == Id
        //        //                         from item2 in bl.getAllDish()
        //        //                         where item1.dishNumber == item2.dishId
        //        //                         select new { name = item2.dishName, amount = item1.amountDish, price = item1.amountDish * item2.dishPrice };

        //}
         private void orderNumbberComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox && ((ComboBox)sender).SelectedIndex > -1)
               AccountDetails.ItemsSource = bl.getDishesToOrder(id);
               // this.refreshDataGrid((int)orderNumberComboBox.SelectedValue);
        }
    }
}

