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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BL;
using BE;

namespace PLForms
{
    /// <summary>
    /// Interaction logic for ProfitByDish.xaml
    /// </summary>
    public partial class ProfitByDish : UserControl
    {
        BL.IBL bl;
        BE.Order order;
        public ProfitByDish()
        {
            InitializeComponent();
            bl = BL.FactoryBL.getBL();
            order = new BE.Order();
            //profitsDetails.ItemsSource = bl.groupingBydish();

        }
    }
}
