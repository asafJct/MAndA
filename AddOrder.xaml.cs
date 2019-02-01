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
    /// Interaction logic for AddOrder.xaml
    /// </summary>
    public partial class AddOrder : Window
    {
        BE.Order order;
        BL.IBL bl;
        static public int oN = 10000000;
        public AddOrder()
        {
            InitializeComponent();
            order = new BE.Order();
            this.gridAddOrder.DataContext = order;
            bl = BL.FactoryBL.getBL();
            branchNumberComboBox.ItemsSource = from item in bl.getAllBranch()
                                               select item.branchNumber;
            //branchNumberComboBox.DisplayMemberPath = "branchNumber";
            this.hechsherComboBox.ItemsSource = Enum.GetValues(typeof(BE.kosherLevel));
           
            
        }

        private void addOrderButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ++oN;
                order.orderNumber = oN;
                bl.addOrder(order);
                MessageBox.Show(order.clientName + "!\n your invatation is added, the order number is " + oN, "Added successfully ! ");
                order = new BE.Order();
                this.gridAddOrder.DataContext = order;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
