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

namespace GamingWPFGUI2
{
    /// <summary>
    /// Interaction logic for CustomerMenu.xaml
    /// </summary>
    public partial class CustomerMenu : Page
    {
        public CustomerMenu()
        {
            InitializeComponent();
        }

        private void OrdersButtonClicked(object sender, RoutedEventArgs e)
        {
            Orders orders = new Orders();
            this.NavigationService.Navigate(orders);
        }

        private void CustomersButtonClicked(object sender, RoutedEventArgs e)
        {
            Customers customers = new Customers();
            this.NavigationService.Navigate(customers);
        }
    }
}
