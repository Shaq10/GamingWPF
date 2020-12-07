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

        private void ListBoxOrder_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (ListBoxOrders.SelectedItem != null)
            {
                _crudManager.SetSelectedOrder(ListBoxOrders.SelectedItem);
            }
        }

        private void ListBoxCustomer_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (ListBoxCustomers.SelectedItem != null)
            {
                _crudManager.SetSelectedCustomer(ListBoxCustomers.SelectedItem);
            }
        }

        private void ListBoxGame_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (ListBoxGames.SelectedItem != null)
            {
                _crudManager.SetSelectedGame(ListBoxGames.SelectedItem);
            }
        }

        private void DPSelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e) {
            if (DP_Delivery.SelectedDate.Value < _crudManager.SelectedOrder.OrderDate.AddDays(3))
            {
                MessageBox.Show("Delivery date should be at least 3 days after order date!");
                DP_Delivery.SelectedDate = _crudManager.SelectedOrder.DeliveryDate;
            }
        }

        private int AgeAt(DateTime dob, DateTime date) {
            if (date > dob)
            {
                var age = date - dob;
                return (int)(age.Days / 365.25);
            }
            else {
                throw new System.ArgumentException("Error - birthDate is in the future");
            }
        }

        private void UpdateButtonClicked(object sender, RoutedEventArgs e)
        {
            _crudManager.UpdateOrder(_crudManager.SelectedOrder.OrderId, DP_Delivery.SelectedDate.Value);
            ListBoxOrders.ItemsSource = null;
            PopulateListBox();
        }

        private void CreateButtonClicked(object sender, RoutedEventArgs e)
        {
            if (ListBoxCustomers.SelectedItem != null && ListBoxGames.SelectedItem != null)
            {
                if ( AgeAt(_crudManager.SelectedCustomer.Dob.Value , System.DateTime.Now) < _crudManager.SelectedGame.AgeRating) {
                    MessageBox.Show("Customer is too young to place order for this game");
                }
                else {
                    _crudManager.CreateOrder(_crudManager.SelectedCustomer.CustomerId, _crudManager.SelectedGame.GameId, System.DateTime.Now, System.DateTime.Now.AddDays(3), _crudManager.SelectedGame.Price);
                    ListBoxOrders.ItemsSource = null;
                    PopulateListBox();
                }
                
            }
            else {
                MessageBox.Show("Select both a Customer AND Game to complete order!");
            }
        }

        private void DeleteButtonClicked(object sender, RoutedEventArgs e)
        {
            if (ListBoxOrders.SelectedItem != null)
            {
                _crudManager.DeleteOrder(_crudManager.SelectedOrder.OrderId);
                ListBoxOrders.ItemsSource = null;
                PopulateListBox();
            }
            else
            {
                MessageBox.Show("Select an order to delete");
            }
        }
    }
}
