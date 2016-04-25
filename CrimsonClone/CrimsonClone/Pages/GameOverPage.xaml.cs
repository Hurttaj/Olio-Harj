﻿using CrimsonClone.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Serialization;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace CrimsonClone
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GameOverPage : Page
    {
        // Score Storing Variables
        private List<int> scores = new List<int>();
        List<Player> players = new List<Player>();
        Player player = new Player();
        public int Score { get; set; }
        public int Time { get; set; }
        public string playerName { get; set; }

        //private StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
        //private StorageFile scoresFile;

        

        public GameOverPage()
        {
            this.InitializeComponent();
            FileReader();


        }

        // Creating highscore.dat for storing scores
        /*private async void ReadHighScore()
        {
            scoresFile = await storageFolder.CreateFileAsync("highscore.dat", CreationCollisionOption.OpenIfExists);
            IList<string> readLines = await FileIO.ReadLinesAsync(scoresFile);
            foreach (var line in readLines)
            {
                scores.Add(int.Parse(line));
            }
        }*/

        private async void okButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ScorePage));

            // as the okButton pressed an object will be created
            Player player = new Player();
            player.name = nameTextBox.Text;
            player.points = Score;
            players.Add(player);
            players.Sort();
            players.Reverse();
            int i = 0;
            foreach (Player d in players)
            {
                i++;
                if (i >= 10) break; // only show 10 highest scores
            }

            try
            {
                // Creating highscore.dat for storing scores
                StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
                StorageFile scoresFile = await storageFolder.CreateFileAsync("highscore.dat", CreationCollisionOption.OpenIfExists);

                // save players to disk
                Stream stream = await scoresFile.OpenStreamForWriteAsync();
                DataContractSerializer serializer = new DataContractSerializer(typeof(List<Player>));
                serializer.WriteObject(stream, players);
                await stream.FlushAsync();
                stream.Dispose();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Following exception has happend (writing): " + ex.ToString());
            }
        }

        private async void FileReader()
        {
            try
            {
                // Finding the file
                StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
                Stream stream = await storageFolder.OpenStreamForReadAsync("highscore.dat");

                // Is the file empty?
                if(stream == null) players = new List<Player>();

                // Reading the file
                DataContractSerializer serializer = new DataContractSerializer(typeof(List<Player>));
                players = (List<Player>)serializer.ReadObject(stream);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Following exception has happend (reading): " + ex.ToString());
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //base.OnNavigatedTo(e);
            if (e.Parameter is GamePage)
            {
                GamePage gamePage = (GamePage)e.Parameter;
                scoreTextBlock.Text = gamePage.Score.ToString();
                timeTextBlock.Text = gamePage.Time.ToString();
                foreach (int score in scores)
                {
                    if(int.Parse(gamePage.Score.ToString()) > score)
                    {
                        scores.Add(int.Parse(gamePage.Score.ToString()));
                        break;
                    }

                }
                scores.Sort();
                scores.Reverse();
                int i = 0;
                foreach (double d in scores)
                {
                    i++;
                    if (i >= 10) break; // only show 10 highest scores
                }
            }
        }

        



    }
}
