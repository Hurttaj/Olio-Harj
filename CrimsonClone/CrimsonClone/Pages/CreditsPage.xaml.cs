/*
 * This is a part of a student project made in JAMK University of Applied Sciences
 * Link to this project's GitHub:
 * https://github.com/Hurttaj/Olio-Harj
 * 
 * Authors and their GitHub names:
 * Borhan Amini (bhnamn)
 * Hurtta Jussi (Hurttaj)
 * Minkkilä Juuso (SlightHeadahce)
 *
 * Date: Spring 2016
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    /// This page contains credits information
    /// </summary>
    public sealed partial class CreditsPage : Page
    {
        public CreditsPage()
        {
            this.InitializeComponent();
        }

        private void MainMenuButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}
