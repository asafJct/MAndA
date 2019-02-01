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
    /// Interaction logic for UpdateBranch.xaml
    /// </summary>
    public partial class UpdateBranch : Window
    {
        BE.Branch branch;
        BL.IBL bl;
        public UpdateBranch()
        {
            InitializeComponent();
            branch = new BE.Branch();
            this.DataContext = branch;
            bl = BL.FactoryBL.getBL();
            branchNumberComboBox.ItemsSource = from item in bl.getAllBranch()
                                               select item.branchNumber;
            this.hechsherComboBox.ItemsSource = Enum.GetValues(typeof(BE.kosherLevel));
        }
        private void UpdateBranchButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.updateBranch(branch);
                branch = new BE.Branch();
                MessageBox.Show("the branch " + branch.branchName + " update ", "");
                this.DataContext = branch;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void branchNumberComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            branch = bl.getAllBranch(b => b.branchNumber == branch.branchNumber).FirstOrDefault();
            this.DataContext = branch;
        }
    }
}
