﻿using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;

namespace MusicLibrary
{
    /// <summary>
    /// Interaction logic for MediaProperty.xaml
    /// </summary>
    public partial class MediaProperty : Window
    {
        private List<FileProperty> propertyList = new List<FileProperty>();
        private Database db;

        Song song;
        public MediaProperty(Song s)
        {
            InitializeComponent();
            propertyList.Add(new FileProperty { name = "Title", value = s.Title });
            db = new Database();
            song = s;
        }

        private void MediaProperty_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //var result = MessageBoxEx.Show("Do you want to save change?", "MusicPlayer", MessageBoxButton.YesNoCancel);
            //switch (result)
            //{
            //    case MessageBoxResult.Yes:
            //        //BtSave_Click(null, null);
            //        break;
            //    case MessageBoxResult.No:
            //        break;
            //    case MessageBoxResult.Cancel:
            //        e.Cancel = true;
            //        return;
            //}
        }

        private void BtPropertyCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void PropertyWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //song = (Song)ListMusicLibrary[lvLi];
            if (song == null)
            {
                MessageBoxEx.Show("PropertyWindow load Error media is null");
                return;
            }
            else
            {
                tbSongTitle.Text = song.Title;
                tbArtistName.Text = song.ArtistName;
                tbAlbumName.Text = song.AlbumId + "";
                tbAlbumId.Text = song.AlbumId + "";
                tbSequenceId.Text = song.SequenceId + "";
                tbPath.Text = song.PathToFile;
                string date = song.Year.ToString("yyyy");
                tbYear.Text = date;
                tbGenre.Text = song.Genre;
                tbRating.Text = song.Rating + "";
                tbDescription.Text = song.Description;
            }

        }
        
        private void BtPropertySave_Click(object sender, RoutedEventArgs e)
        {
            String title = tbSongTitle.Text;
            String artistName = tbArtistName.Text ;
            String albumName = tbAlbumName.Text;
            int sequenceId = Convert.ToInt32(tbSequenceId.Text);
            int AlbumId = Convert.ToInt32(tbAlbumId.Text);
            String pathToFile = tbPath.Text;
            //DateTime dt = Convert.ToDateTime(tbYear.Text);
            Regex regex = new Regex(@"\d+");
            String input_year = tbYear.Text;
            int yearInt = 1000;
            if (Regex.IsMatch(input_year, "^(19|20)[0-9][0-9]"))
            {
                yearInt = Convert.ToInt32(tbYear.Text);
            }
            else {
                MessageBoxEx.Show("Please input 4 digital year");
                return;
            }

            //To Do Format date and validation
            uint yearUint = (uint)(yearInt);
            String genre = tbGenre.Text;
            string date = song.Year.ToString("yyyy");
            int rating = Convert.ToInt32(tbRating.Text);
            String description = tbDescription.Text;

            Song new_song = new Song(title, artistName, sequenceId, (int)sequenceId, description, pathToFile, yearUint, genre, rating);
            db.UpdateSongByPath(new_song);
            MessageBoxEx.Show("Song of " + new_song.ArtistName + " is being saved");
            this.Close();
        }
    }
}
