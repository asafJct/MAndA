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
namespace PLForms
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BL.IBL bl;//***********************
        public MainWindow()//****************************
        {
            InitializeComponent();
            bl= FactoryBL.getBL();    
        }
        private void Order_Click(object sender, RoutedEventArgs e)
        {
            new OrderOption().ShowDialog(); 
        }

        private void Branch_Click(object sender, RoutedEventArgs e)
        {
            new BranchOption().ShowDialog(); 
        }

        private void Dish_Click(object sender, RoutedEventArgs e)
        {
            new DishOption().ShowDialog();
                
        }

        private void OrderDish_Click(object sender, RoutedEventArgs e)
        {
            new OrderDishOption().ShowDialog();
        }

        private void exit_Click(object sender, RoutedEventArgs e)//******************************
        {
            //blXml.SaveDishesListLinq(bl.getAllDish().ToList());
            this.Close();
        }

        private void profits_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void TotalPayment_Click(object sender, RoutedEventArgs e)
        {
            new payments().ShowDialog();
        }

      
        
    }
}
