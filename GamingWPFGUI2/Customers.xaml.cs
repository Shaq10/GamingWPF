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
    /// Interaction logic for Customers.xaml
    /// </summary>
    public partial class Customers : Page
    {
        CRUDManager _crudManager = new CRUDManager();
        public Customers()
        {
            InitializeComponent();
            PopulateListBox();
        }

        private void PopulateListBox() {
            ListBoxCustomers.ItemsSource = _crudManager.RetrieveAllCustomers();
        }

        private void PopulateCustomerFields() {
            if (_crudManager.SelectedCustomer != null) {
                Text_CustomerId.Text = _crudManager.SelectedCustomer.CustomerId;
                Text_FirstName.Text = _crudManager.SelectedCustomer.FirstName;
                Text_LastName.Text = _crudManager.SelectedCustomer.LastName;
                Text_Email.Text = _crudManager.SelectedCustomer.Email;
                Text_HouseNum.Text = _crudManager.SelectedCustomer.HouseNum.ToString();
                Text_FirstLineAddress.Text = _crudManager.SelectedCustomer.FirstLineAddress;
                Text_SecondLineAddress.Text = _crudManager.SelectedCustomer.SecondLineAddress;
                Text_City.Text = _crudManager.SelectedCustomer.City;
                Text_Postcode.Text = _crudManager.SelectedCustomer.Postcode;
                Text_Country.Text = _crudManager.SelectedCustomer.Country;
                Text_Mobile.Text = _crudManager.SelectedCustomer.Mobile;
                DP_Dob.SelectedDate = _crudManager.SelectedCustomer.Dob;
                Text_Gender.Text = _crudManager.SelectedCustomer.Gender;

            }
        }

        private void ClearAll() {
            Text_CustomerId.Clear() ;
            Text_FirstName.Clear();
            Text_LastName.Clear();
            Text_Email.Clear();
            Text_HouseNum.Clear();
            Text_FirstLineAddress.Clear();
            Text_SecondLineAddress.Clear();
            Text_City.Clear();
            Text_Postcode.Clear();
            Text_Country.Clear();
            Text_Mobile.Clear();
            Text_Gender.Clear();
        }

        private void ListBoxCustomer_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (ListBoxCustomers.SelectedItem != null)
            {
                _crudManager.SetSelectedCustomer(ListBoxCustomers.SelectedItem);
                PopulateCustomerFields();
            }
        }

        public void ClearButtonClicked(object sender, RoutedEventArgs e)
        {
            ListBoxCustomers.SelectedItem = null;
            ClearAll();
        }

        private void UpdateButtonClicked(object sender, RoutedEventArgs e)
        {
            _crudManager.UpdateCustomer(Text_CustomerId.Text, Text_FirstName.Text, Text_LastName.Text, Text_Email.Text, int.Parse(Text_HouseNum.Text), Text_FirstLineAddress.Text, 
                Text_SecondLineAddress.Text, Text_City.Text, Text_Postcode.Text, Text_Country.Text, Text_Mobile.Text,DP_Dob.SelectedDate.Value, char.Parse(Text_Gender.Text));
            ListBoxCustomers.ItemsSource = null;
            PopulateListBox();
            ListBoxCustomers.SelectedItem = _crudManager.SelectedCustomer;
            PopulateCustomerFields();
        }

        private void CreateButtonClicked(object sender, RoutedEventArgs e)
        {
            if (ListBoxCustomers.SelectedItem == null)
            {
                _crudManager.CreateCustomer(Text_CustomerId.Text, Text_FirstName.Text, Text_LastName.Text, Text_Email.Text, int.Parse(Text_HouseNum.Text), Text_FirstLineAddress.Text,
                Text_SecondLineAddress.Text, Text_City.Text, Text_Postcode.Text, Text_Country.Text, Text_Mobile.Text, DP_Dob.SelectedDate.Value, char.Parse(Text_Gender.Text));
                ListBoxCustomers.ItemsSource = null;
                PopulateListBox();
                ListBoxCustomers.SelectedItem = _crudManager.SelectedCustomer;
                PopulateCustomerFields();
            }
        }

        private void DeleteButtonClicked(object sender, RoutedEventArgs e)
        {
            if (ListBoxCustomers.SelectedItem != null)
            {
                _crudManager.DeleteGame(Text_CustomerId.Text);
                ListBoxCustomers.ItemsSource = null;
                PopulateListBox();
                PopulateCustomerFields();
            }
            else
            {
                MessageBox.Show("Select a customer to delete");
            }
            ClearAll();
        }
    }    
}
