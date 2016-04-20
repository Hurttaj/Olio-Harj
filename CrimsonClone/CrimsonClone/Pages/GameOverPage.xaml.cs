using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
        // Score Storing
        private List<int> scores = new List<int>();
        private StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
        private StorageFile scoresFile;

        public int Score { get; set; }
        public int Time { get; set; }

        public GameOverPage()
        {
            this.InitializeComponent();
            ReadHS();
        }

        // Creating highscore.dat for storing scores
        private async void ReadHS()
        {
            scoresFile = await storageFolder.CreateFileAsync("highscore.dat", CreationCollisionOption.OpenIfExists);
            IList<string> readLines = await FileIO.ReadLinesAsync(scoresFile);
            foreach (var line in readLines)
            {
                scores.Add(int.Parse(line));
            }
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ScorePage));
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
