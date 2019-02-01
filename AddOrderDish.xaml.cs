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
    /// Interaction logic for AddOrderDish.xaml
    /// </summary>
    public partial class AddOrderDish : Window
    {
        BE.Ordered_Dish orderDish;
        BL.IBL bl;
        public AddOrderDish()
        {
            InitializeComponent();
            orderDish = new BE.Ordered_Dish();
            this.DataContext = orderDish;
            bl = BL.FactoryBL.getBL();
            //dishNameComboBox.ItemsSource = from item in bl.getAllDish()
            //                               select item.dishName;
            //dishNameComboBox.DisplayMemberPath = "dishName";
            //dishNameComboBox.SelectedValuePath = "dishId";

            orderNumberComboBox.ItemsSource = from item in bl.getAllOrder()
                                              select item.orderNumber;
        }

        private void addOrderDish_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //int n = int.Parse(this.dishNameComboBox.SelectedValuePath);
                //orderDish.dishNumber = n;
                orderDish.dishNumber = bl.getAllDish(d => d.dishName == dishNameComboBox.SelectedValue).FirstOrDefault().dishId;
                bl.addOrderedDish(orderDish);
                MessageBox.Show("the dish  \""+dishNameComboBox.SelectedValue +"\"is added to invatation number " + orderDish.orderNumber);
                orderDish = new BE.Ordered_Dish();
                this.gridAddOrderDish.DataContext = orderDish;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void orderNumberComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)//מחזיר את כל המנות שעונות על רמת ההכשר המבוקש בהזמנה
        {
            dishNameComboBox.ItemsSource = from item in bl.getAllDish(d=>d.hechsher==bl.getAllOrder(o=>orderDish.orderNumber==o.orderNumber).FirstOrDefault().hechsher)
                                           select item.dishName;
        }
    }
}
