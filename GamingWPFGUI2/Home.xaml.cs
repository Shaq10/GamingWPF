﻿using System;
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
    /// Interaction logic for Home.xaml
    /// </summary>

    
    public partial class Home : Page
    {
        public Home()
        {
            InitializeComponent();
        }

        private void ManagerButtonClicked(object sender, RoutedEventArgs e) {
            ManagerMenu menu = new ManagerMenu();
            this.NavigationService.Navigate(menu);
        }

        private void CustomerButtonClicked(object sender, RoutedEventArgs e)
        {
            CustomerMenu cust = new CustomerMenu();
            this.NavigationService.Navigate(cust);
        }
    }
}
