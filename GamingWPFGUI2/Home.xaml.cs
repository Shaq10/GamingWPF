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
    /// Interaction logic for Home.xaml
    /// </summary>

    
    public partial class Home : Page
    {
        CRUDManager _crudManager = new CRUDManager();
        public Home()
        {
            InitializeComponent();
            PopulateListBox();
        }

        private void PopulateListBox()
        {
            ListBoxGames.ItemsSource = _crudManager.RetrieveAllGames();
        }

        private void PopulateGameFields() {
            if (_crudManager.SelectedGame != null) {
                Text_GameId.Text = _crudManager.SelectedGame.GameId;
                Text_GenreId.Text = _crudManager.SelectedGame.GenreId.ToString();
                Text_ConsoleId.Text = _crudManager.SelectedGame.ConsoleId.ToString();
                Text_Title.Text = _crudManager.SelectedGame.Title;
                Text_AgeRating.Text = _crudManager.SelectedGame.AgeRating.ToString();
                Text_Price.Text = _crudManager.SelectedGame.Price.ToString();
                Text_Publisher.Text = _crudManager.SelectedGame.Publisher;
                Text_ReleaseDate.Text = _crudManager.SelectedGame.ReleaseDate.ToString("dd-mm-yyyy");
                Text_Multiplayers.Text = _crudManager.SelectedGame.Multiplayers.ToString();
            }
        }

        private void ListBoxGame_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (ListBoxGames.SelectedItem != null)
            {
                _crudManager.SetSelectedGame(ListBoxGames.SelectedItem);
                PopulateGameFields();
            }
        }
    }
}
