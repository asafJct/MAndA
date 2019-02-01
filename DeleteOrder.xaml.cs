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
    /// Interaction logic for DeleteOrder.xaml
    /// </summary>
    public partial class DeleteOrder : Window
    {
        BE.Order order;
        BL.IBL bl;
        public DeleteOrder()
        {
            InitializeComponent();
            bl = BL.FactoryBL.getBL();
            order = new BE.Order();
            this.DataContext = order;
            orderNameComboBox.ItemsSource = from item in bl.getAllOrder()
                                            select item.orderNumber;
        }

        private void DeleteOrderButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                bl.deleteOrder(order);
                BE.Order or = new BE.Order();
                MessageBox.Show(order.clientName + "'s \n" + "is Deleted, the number invitation is " + order.orderNumber, "");
                orderNameComboBox.ItemsSource = from item in bl.getAllOrder()
                                                select item.orderNumber;
                this.DataContext = order;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
