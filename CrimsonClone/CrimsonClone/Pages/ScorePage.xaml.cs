﻿using System;
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
    public sealed partial class ScorePage : Page
    {
        private StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
        private StorageFile scoresFile;

        public ScorePage()
        {
            this.InitializeComponent();
            //ReadHS();
        }

        /*private async void ReadHS()
        {
            scoresFile = await storageFolder.CreateFileAsync("highscore.dat", CreationCollisionOption.OpenIfExists);
            IList<string> readLines = await FileIO.ReadLinesAsync(scoresFile);
            foreach (var line in readLines)
            {
                ScoresTextBlock.Text += line + Environment.NewLine;
                scores.Add(double.Parse(line));
            }
        }*/


        private void MainMenuButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}
