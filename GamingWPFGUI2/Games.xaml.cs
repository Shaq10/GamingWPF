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
    /// Interaction logic for Games.xaml
    /// </summary>
    public partial class Games : Page
    {
        CRUDManager _crudManager = new CRUDManager();
        public Games()
        {
            InitializeComponent();
            PopulateListBox();
        }

        private void PopulateListBox()
        {
            ListBoxGames.ItemsSource = _crudManager.RetrieveAllGames();
        }

        private void PopulateGameFields()
        {
            if (_crudManager.SelectedGame != null)
            {
                Text_GameId.Text = _crudManager.SelectedGame.GameId;
                Text_GenreId.Text = _crudManager.SelectedGame.GenreId.ToString();
                Text_ConsoleId.Text = _crudManager.SelectedGame.ConsoleId.ToString();
                Text_Title.Text = _crudManager.SelectedGame.Title;
                Text_AgeRating.Text = _crudManager.SelectedGame.AgeRating.ToString();
                Text_Price.Text = _crudManager.SelectedGame.Price.ToString();
                Text_Publisher.Text = _crudManager.SelectedGame.Publisher;
                DP_ReleaseDate.SelectedDate = _crudManager.SelectedGame.ReleaseDate;
                Text_Multiplayers.Text = _crudManager.SelectedGame.Multiplayers.ToString();
            }
        }

        private void ClearAll()
        {
            Text_GameId.Clear();
            Text_GenreId.Clear();
            Text_ConsoleId.Clear();
            Text_Title.Clear();
            Text_AgeRating.Clear();
            Text_Price.Clear();
            Text_Publisher.Clear();
            Text_Multiplayers.Clear();
        }

        private void ListBoxGame_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (ListBoxGames.SelectedItem != null)
            {
                _crudManager.SetSelectedGame(ListBoxGames.SelectedItem);
                PopulateGameFields();
            }
        }

        public void ClearButtonClicked(object sender, RoutedEventArgs e)
        {
            ListBoxGames.SelectedItem = null;
            ClearAll();

        }

        private void UpdateButtonClicked(object sender, RoutedEventArgs e)
        {
            _crudManager.UpdateGame(Text_GameId.Text, int.Parse(Text_GenreId.Text), int.Parse(Text_ConsoleId.Text), Text_Title.Text, int.Parse(Text_AgeRating.Text), decimal.Parse(Text_Price.Text), Text_Publisher.Text, DP_ReleaseDate.SelectedDate.Value, int.Parse(Text_Multiplayers.Text));
            ListBoxGames.ItemsSource = null;
            PopulateListBox();
            ListBoxGames.SelectedItem = _crudManager.SelectedGame;
            PopulateGameFields();
        }

        private void CreateButtonClicked(object sender, RoutedEventArgs e)
        {
            if (ListBoxGames.SelectedItem == null)
            {
                _crudManager.CreateGame(Text_GameId.Text, int.Parse(Text_GenreId.Text), int.Parse(Text_ConsoleId.Text), Text_Title.Text, int.Parse(Text_AgeRating.Text), decimal.Parse(Text_Price.Text), Text_Publisher.Text, DP_ReleaseDate.SelectedDate.Value, int.Parse(Text_Multiplayers.Text));
                ListBoxGames.ItemsSource = null;
                PopulateListBox();
                ListBoxGames.SelectedItem = _crudManager.SelectedGame;
                PopulateGameFields();
            }

        }

        private void DeleteButtonClicked(object sender, RoutedEventArgs e)
        {
            if (ListBoxGames.SelectedItem != null)
            {
                _crudManager.DeleteGame(Text_GameId.Text);
                ListBoxGames.ItemsSource = null;
                PopulateListBox();
                PopulateGameFields();
            }
            else
            {
                MessageBox.Show("Select a game to delete");
            }
            ClearAll();

        }
    }
}
