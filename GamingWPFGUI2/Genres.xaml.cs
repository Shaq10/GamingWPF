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
    /// Interaction logic for Genres.xaml
    /// </summary>
    public partial class Genres : Page
    {
        CRUDManager _crudManager = new CRUDManager();
        public Genres()
        {
            InitializeComponent();
            PopulateListBox();
        }

        private void PopulateListBox()
        {
            ListBoxGenres.ItemsSource = _crudManager.RetrieveAllGenres();
        }

        private void PopulateGenreFields()
        {
            if (_crudManager.SelectedGenre != null)
            {
                Text_GenreId.Text = _crudManager.SelectedGenre.GenreId.ToString();
                Text_GenreName.Text = _crudManager.SelectedGenre.GenreName;
            }
        }

        private void ClearAll() {
            Text_GenreId.Clear();
            Text_GenreName.Clear();
        }

        private void ListBoxGenre_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (ListBoxGenres.SelectedItem != null)
            {
                _crudManager.SetSelectedGenre(ListBoxGenres.SelectedItem);
                PopulateGenreFields();
            }
        }

        public void ClearButtonClicked(object sender, RoutedEventArgs e)
        {
            ListBoxGenres.SelectedItem = null;
            ClearAll();

        }

        private void UpdateButtonClicked(object sender, RoutedEventArgs e)
        {
            if (Text_GenreName.Text.Length > 30)
            {
                MessageBox.Show("Genre Name is too long");
            }
            else if (Text_GenreName.Text.Length < 1)
            {
                MessageBox.Show("Genre Name cannot be empty");
            }
            else {
                _crudManager.UpdateGenre(int.Parse(Text_GenreId.Text), Text_GenreName.Text);
                ListBoxGenres.ItemsSource = null;
                PopulateListBox();
                ListBoxGenres.SelectedItem = _crudManager.SelectedGenre;
                PopulateGenreFields();
            }            
        }

        private void CreateButtonClicked(object sender, RoutedEventArgs e)
        {
            if (ListBoxGenres.SelectedItem == null)
            {
                if (Text_GenreName.Text.Length > 30)
                {
                    MessageBox.Show("Genre Name is too long");
                }
                else if (Text_GenreName.Text.Length < 1)
                {
                    MessageBox.Show("Genre Name cannot be empty");
                }
                else {
                    _crudManager.CreateGenre(Text_GenreName.Text);
                    ListBoxGenres.ItemsSource = null;
                    PopulateListBox();
                    ListBoxGenres.SelectedItem = _crudManager.SelectedGenre;
                    PopulateGenreFields();
                    ClearAll();
                }                
            }
        }

        private void DeleteButtonClicked(object sender, RoutedEventArgs e) {
            if (ListBoxGenres.SelectedItem != null)
            {
                _crudManager.DeleteGenre(int.Parse(Text_GenreId.Text));
                ListBoxGenres.ItemsSource = null;
                PopulateListBox();
                PopulateGenreFields();
            }
            else {
                MessageBox.Show("Select a genre to delete");
            }
            ClearAll();
        }
    }
}
