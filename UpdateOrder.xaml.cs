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
    /// Interaction logic for UpdateOrder.xaml
    /// </summary>
    public partial class UpdateOrder : Window
    {
        BE.Order order;
        BL.IBL bl;
        public UpdateOrder()
        {
            InitializeComponent();
            order = new BE.Order();
            this.gridUpdateOrder.DataContext = order;
            bl = BL.FactoryBL.getBL();
            branchNumberComboBox.ItemsSource = from item in bl.getAllBranch()
                                               select item.branchNumber;
            hechsherComboBox.ItemsSource = Enum.GetValues(typeof(BE.kosherLevel));
            orderNameComboBox.ItemsSource = from item in bl.getAllOrder()
                                            select item.orderNumber;

        }

        private void UpdateOrderButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.updateOrder(order);
                //order = new BE.Order();
                MessageBox.Show("the order " + order.orderNumber + " updated  ", " Successfully updated! ");
                this.gridUpdateOrder.DataContext = order;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void orderNameComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            order = bl.getAllOrder(O => O.orderNumber == order.orderNumber).FirstOrDefault();
            this.gridUpdateOrder.DataContext = order;
        }
    }
}