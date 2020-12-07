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
    /// Interaction logic for Consoles.xaml
    /// </summary>
    public partial class Consoles : Page
    {
        CRUDManager _crudManager = new CRUDManager();
        public Consoles()
        {
            InitializeComponent();
            PopulateListBox();
        }

        private void PopulateListBox() {
            ListBoxConsoles.ItemsSource = _crudManager.RetrieveAllConsoles();
        }

        private void PopulateConsoleFields() {
            if (_crudManager.SelectedConsole != null) {
                Text_ConsoleId.Text = _crudManager.SelectedConsole.ConsoleId.ToString();
                Text_ConsoleName.Text = _crudManager.SelectedConsole.ConsoleName;
                Text_Manufacturer.Text = _crudManager.SelectedConsole.Manufacturer;
                Text_OnlineCompatible.Text = _crudManager.SelectedConsole.OnlineCompatible;
            }
        }

        private void ClearAll() {
            Text_ConsoleId.Clear();
            Text_ConsoleName.Clear();
            Text_Manufacturer.Clear();
            Text_OnlineCompatible.Clear();
        }

        private void ListBoxConsole_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (ListBoxConsoles.SelectedItem != null)
            {
                _crudManager.SetSelectedConsole(ListBoxConsoles.SelectedItem);
                PopulateConsoleFields();
            }
        }

        public void ClearButtonClicked(object sender, RoutedEventArgs e)
        {
            ListBoxConsoles.SelectedItem = null;
            ClearAll();
        }

        private void UpdateButtonClicked(object sender, RoutedEventArgs e)
        {
            if (Text_ConsoleName.Text.Length > 30)
            {
                MessageBox.Show("Console Name is too long");
            }
            else if (Text_ConsoleName.Text.Length < 1)
            {
                MessageBox.Show("Console Name cannot be empty");
            }
            else if (Text_Manufacturer.Text.Length > 30) {
                MessageBox.Show("Manufacturer is too many characters");
            }
            else if (Text_Manufacturer.Text.Length < 1) {
                MessageBox.Show("Manufacturer cannot be empty");
            }
            else if (Text_OnlineCompatible.Text != "Y" && Text_OnlineCompatible.Text != "N") {
                MessageBox.Show("Online compatibility must be either a Y for Yes or N for No");
            }
            else {
                _crudManager.UpdateConsole(int.Parse(Text_ConsoleId.Text), Text_ConsoleName.Text, Text_Manufacturer.Text, Text_OnlineCompatible.Text);
                ListBoxConsoles.ItemsSource = null;
                PopulateListBox();
                ListBoxConsoles.SelectedItem = _crudManager.SelectedConsole;
                PopulateConsoleFields();
            }
            
        }

        private void CreateButtonClicked(object sender, RoutedEventArgs e)
        {
            if (ListBoxConsoles.SelectedItem == null)
            {
                if (Text_ConsoleName.Text.Length > 30)
                {
                    MessageBox.Show("Console Name is too long");
                }
                else if (Text_ConsoleName.Text.Length < 1)
                {
                    MessageBox.Show("Console Name cannot be empty");
                }
                else if (Text_Manufacturer.Text.Length > 30)
                {
                    MessageBox.Show("Manufacturer is too many characters");
                }
                else if (Text_Manufacturer.Text.Length < 1)
                {
                    MessageBox.Show("Manufacturer cannot be empty");
                }
                else if (Text_OnlineCompatible.Text != "Y" && Text_OnlineCompatible.Text != "N")
                {
                    MessageBox.Show("Online compatibility must be either a Y for Yes or N for No");
                }
                else {
                    _crudManager.CreateConsole(Text_ConsoleName.Text, Text_Manufacturer.Text, Text_OnlineCompatible.Text);
                    ListBoxConsoles.ItemsSource = null;
                    PopulateListBox();
                    ListBoxConsoles.SelectedItem = _crudManager.SelectedConsole;
                    PopulateConsoleFields();
                    ClearAll();
                }                
            }
        }

        private void DeleteButtonClicked(object sender, RoutedEventArgs e)
        {
            if (ListBoxConsoles.SelectedItem != null)
            {
                _crudManager.DeleteConsole(int.Parse(Text_ConsoleId.Text));
                ListBoxConsoles.ItemsSource = null;
                PopulateListBox();
                PopulateConsoleFields();
            }
            else
            {
                MessageBox.Show("Select a console to delete");
            }
            ClearAll();
        }
    }
}
