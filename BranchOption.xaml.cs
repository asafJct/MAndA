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
    /// Interaction logic for BranchOption.xaml
    /// </summary>
    public partial class BranchOption : Window
    {
        public BranchOption()
        {
            InitializeComponent();
        }

        private void AddBranch_Click(object sender, RoutedEventArgs e)
        {
            new AddBranch().ShowDialog();
        }

        private void DeleteBranch_Click(object sender, RoutedEventArgs e)
        {
            new DeleteBranch().ShowDialog();
        }

        private void UpdateBranch_Click(object sender, RoutedEventArgs e)
        {
            new UpdateBranch().ShowDialog();
        }

      
    }
}
