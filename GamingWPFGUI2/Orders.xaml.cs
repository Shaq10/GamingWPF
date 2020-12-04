using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GamingWPFBusiness;

namespace GamingWPFGUI2
{
    /// <summary>
    /// Interaction logic for Orders.xaml
    /// </summary>
    public partial class Orders : Page
    {
        CRUDManager _crudManager = new CRUDManager();
        public Orders()
        {
            InitializeComponent();
            PopulateListBox();
        }

        private void PopulateListBox()
        {
            ListBoxCustomers.ItemsSource = _crudManager.RetrieveAllCustomers();
            ListBoxGames.ItemsSource = _crudManager.RetrieveAllGames();
            ListBoxOrders.ItemsSource = _crudManager.RetrieveAllOrders();
        }
    }
}
