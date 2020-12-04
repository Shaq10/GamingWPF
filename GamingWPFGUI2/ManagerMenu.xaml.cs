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
    /// Interaction logic for ManagerMenu.xaml
    /// </summary>
    public partial class ManagerMenu : Page
    {
        public ManagerMenu()
        {
            InitializeComponent();
        }

        private void GamesButtonClicked(object sender, RoutedEventArgs e)
        {
            Games games = new Games();
            this.NavigationService.Navigate(games);
        }

        private void CustomersButtonClicked(object sender, RoutedEventArgs e)
        {
            Customers customers = new Customers();
            this.NavigationService.Navigate(customers);
        }

        private void ConsolesButtonClicked(object sender, RoutedEventArgs e)
        {
            Consoles consoles = new Consoles();
            this.NavigationService.Navigate(consoles);
        }

        private void GenresButtonClicked(object sender, RoutedEventArgs e)
        {
            Genres genres = new Genres();
            this.NavigationService.Navigate(genres);
        }

        private void OrdersButtonClicked(object sender, RoutedEventArgs e)
        {
            Orders orders = new Orders();
            this.NavigationService.Navigate(orders);
        }
    }
}
