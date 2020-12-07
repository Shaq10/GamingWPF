using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
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
            int result;
            Regex regex = new Regex(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z");
            if (Text_CustomerId.Text.Length > 10)
            {
                MessageBox.Show("Customer ID cannot be longer than 10 characters");
            }
            else if (Text_CustomerId.Text.Length < 1)
            {
                MessageBox.Show("Customer ID cannot be empty");
            }
            else if (Text_FirstName.Text.Length > 30)
            {
                MessageBox.Show("First Name cannot be longer than 30 characters");
            }
            else if (Text_FirstName.Text.Length < 1)
            {
                MessageBox.Show("First Name cannot be empty");
            }
            else if (Text_LastName.Text.Length > 30)
            {
                MessageBox.Show("Last Name cannot be longer than 30 characters");
            }
            else if (Text_LastName.Text.Length < 1)
            {
                MessageBox.Show("Last Name cannot be empty");
            }
            else if (Text_Email.Text.Length < 1)
            {
                MessageBox.Show("Email cannot be empty");
            }
            else if (regex.Match(Text_Email.Text).Success == false)
            {
                MessageBox.Show("Email is not in the correct format");
            }
            else if (int.TryParse(Text_HouseNum.Text.ToString(), out result) == false)
            {
                MessageBox.Show("House number must be an integer");
            }
            else if (Text_HouseNum.Text.Length < 1)
            {
                MessageBox.Show("House number cannot be empty");
            }
            else if (Text_FirstLineAddress.Text.Length < 1)
            {
                MessageBox.Show("First line of address cannot be empty");
            }
            else if (Text_City.Text.Length > 30)
            {
                MessageBox.Show("City cannot be more than 30 characters");
            }
            else if (Text_City.Text.Length < 1)
            {
                MessageBox.Show("City cannot be empty");
            }
            else if (Text_Postcode.Text.Length > 10)
            {
                MessageBox.Show("Postcode is too long");
            }
            else if (Text_Postcode.Text.Length < 1)
            {
                MessageBox.Show("Postcode cannot be empty");
            }
            else if (Text_Country.Text.Length > 30)
            {
                MessageBox.Show("Country cannot be greater than 30 characters");
            }
            else if (Text_Country.Text.Length < 1)
            {
                MessageBox.Show("Country cannot be empty");
            }
            else if (Text_Mobile.Text.Length > 18)
            {
                MessageBox.Show("Mobile number is too long");
            }
            else if (Text_Mobile.Text.Length < 1)
            {
                MessageBox.Show("Mobile number cannot be empty");
            }
            else if (Text_Gender.Text.Length != 1) {
                MessageBox.Show("Gender must be one character");
            }
            else
            {
                _crudManager.UpdateCustomer(Text_CustomerId.Text, Text_FirstName.Text, Text_LastName.Text, Text_Email.Text, int.Parse(Text_HouseNum.Text), Text_FirstLineAddress.Text,
                Text_SecondLineAddress.Text, Text_City.Text, Text_Postcode.Text, Text_Country.Text, Text_Mobile.Text, DP_Dob.SelectedDate.Value, char.Parse(Text_Gender.Text));
                ListBoxCustomers.ItemsSource = null;
                PopulateListBox();
                ListBoxCustomers.SelectedItem = _crudManager.SelectedCustomer;
                PopulateCustomerFields();
            }
            
        }

        private void CreateButtonClicked(object sender, RoutedEventArgs e)
        {
            if (ListBoxCustomers.SelectedItem == null)
            {
                int result;
                Regex regex = new Regex(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z");
                if (Text_CustomerId.Text.Length > 10)
                {
                    MessageBox.Show("Customer ID cannot be longer than 10 characters");
                }
                else if (Text_CustomerId.Text.Length < 1)
                {
                    MessageBox.Show("Customer ID cannot be empty");
                }
                else if (Text_FirstName.Text.Length > 30)
                {
                    MessageBox.Show("First Name cannot be longer than 30 characters");
                }
                else if (Text_FirstName.Text.Length < 1)
                {
                    MessageBox.Show("First Name cannot be empty");
                }
                else if (Text_LastName.Text.Length > 30)
                {
                    MessageBox.Show("Last Name cannot be longer than 30 characters");
                }
                else if (Text_LastName.Text.Length < 1)
                {
                    MessageBox.Show("Last Name cannot be empty");
                }
                else if (Text_Email.Text.Length < 1)
                {
                    MessageBox.Show("Email cannot be empty");
                }
                else if (regex.Match(Text_Email.Text).Success == false)
                {
                    MessageBox.Show("Email is not in the correct format");
                }
                else if (int.TryParse(Text_HouseNum.Text.ToString(), out result) == false)
                {
                    MessageBox.Show("House number must be an integer");
                }
                else if (Text_HouseNum.Text.Length < 1)
                {
                    MessageBox.Show("House number cannot be empty");
                }
                else if (Text_FirstLineAddress.Text.Length < 1)
                {
                    MessageBox.Show("First line of address cannot be empty");
                }
                else if (Text_City.Text.Length > 30)
                {
                    MessageBox.Show("City cannot be more than 30 characters");
                }
                else if (Text_City.Text.Length < 1)
                {
                    MessageBox.Show("City cannot be empty");
                }
                else if (Text_Postcode.Text.Length > 10)
                {
                    MessageBox.Show("Postcode is too long");
                }
                else if (Text_Postcode.Text.Length < 1)
                {
                    MessageBox.Show("Postcode cannot be empty");
                }
                else if (Text_Country.Text.Length > 30)
                {
                    MessageBox.Show("Country cannot be greater than 30 characters");
                }
                else if (Text_Country.Text.Length < 1)
                {
                    MessageBox.Show("Country cannot be empty");
                }
                else if (Text_Mobile.Text.Length > 18)
                {
                    MessageBox.Show("Mobile number is too long");
                }
                else if (Text_Mobile.Text.Length < 1)
                {
                    MessageBox.Show("Mobile number cannot be empty");
                }
                else if (DP_Dob.SelectedDate == null)
                {
                    MessageBox.Show("D.O.B must be selected");
                }
                else if (Text_Gender.Text.Length != 1)
                {
                    MessageBox.Show("Gender must be one character");
                }
                else {
                    _crudManager.CreateCustomer(Text_CustomerId.Text, Text_FirstName.Text, Text_LastName.Text, Text_Email.Text, int.Parse(Text_HouseNum.Text), Text_FirstLineAddress.Text,
                Text_SecondLineAddress.Text, Text_City.Text, Text_Postcode.Text, Text_Country.Text, Text_Mobile.Text, DP_Dob.SelectedDate.Value, char.Parse(Text_Gender.Text));
                    ListBoxCustomers.ItemsSource = null;
                    PopulateListBox();
                    ListBoxCustomers.SelectedItem = _crudManager.SelectedCustomer;
                    PopulateCustomerFields();
                    ClearAll();
                }
                
            }
        }

        private void DeleteButtonClicked(object sender, RoutedEventArgs e)
        {
            if (ListBoxCustomers.SelectedItem != null)
            {
                _crudManager.DeleteCustomer(Text_CustomerId.Text);
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
