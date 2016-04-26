using CrimsonClone.Classes;
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
    /// Score page shows high scores
    /// </summary>
    public sealed partial class ScorePage : Page
    {
        /// <summary>
        /// List for high scores
        /// </summary>
        private List<Player> players;

        /// This method reads data from an exist file
        private async void ReaderMethod()
        {

            try
            {
                /// Finding the file
                StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
                Stream stream = await storageFolder.OpenStreamForReadAsync("highscores2.dat");

                /// Is the file empty?
                if (stream == null) players = new List<Player>();

                /// Reading data
                DataContractSerializer serializer = new DataContractSerializer(typeof(List<Player>));
                players = (List<Player>)serializer.ReadObject(stream);
                ScoreBoardWriter();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Following exception has happend (reading): " + ex.ToString());
            }
        }

        /// <summary>
        /// Writes data into high-score text box
        /// </summary>
        private void ScoreBoardWriter()
        {
            foreach (Player player in players)
            {
                ScoresTextBlock.Text += player.Points + " " + player.Name + Environment.NewLine;
                Debug.WriteLine("player & score:" + player.Points + " " + player.Name);
            }
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public ScorePage()
        {
            this.InitializeComponent();
            //ReaderMethod();
        }

        /// <summary>
        /// This method is called when this page is navigated to
        /// It calls for the file reader
        /// </summary>
        /// <param name="e"></param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //base.OnNavigatedTo(e);
            ReaderMethod();
        }

        /// <summary>
        /// This method is called when "MainMenuButton" is clicked
        /// It changes the page to main menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainMenuButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}
