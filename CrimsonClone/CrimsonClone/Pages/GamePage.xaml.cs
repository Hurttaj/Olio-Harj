using System;
using CrimsonClone.User_Controls;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Input;
using CrimsonClone.Classes;
using System.Diagnostics;
using Windows.Storage;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace CrimsonClone
{
    /// <summary>
    /// This page contains the actual game
    /// </summary>
    public sealed partial class GamePage : Page
    {
        /// <summary>
        /// Logical game
        /// </summary>
        private Game game;
        
        public int Score { get
            {
                return game.Score;
            }
        }
        public int Time { get
            {
                return game.TickCount;
            }
        }
        
        // Variables that express pressed key
        // NOW REDUNDANT
        // USEFUL AGAIN
        // REMOVED AGAIN  


        // Binding MyBinding = new Binding();  

        /// <summary>
        /// default constructor
        /// initializes a new game and starts its timer
        /// </summary>
        public GamePage()
        {
            this.InitializeComponent();

            game = new Game(GameCanvas, this);
            game.StartGame();
        }

        /// <summary>
        /// Is called when the game over requirement is reached within game
        /// </summary>
        public void GameOver()
        {
            //Debug.WriteLine("Test line");
            //(GamePage.Current as GamePage).Score = Score;
            Frame.Navigate(typeof(GameOverPage), this);
            

        }

        /// mouse movement detection
        private void MyCanvas_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            PointerPoint pointerPoint = e.GetCurrentPoint(this);
            game.player.playerCharacter.CursorX = (float)pointerPoint.Position.X;
            game.player.playerCharacter.CursorY = (float)pointerPoint.Position.Y;
        }


        /// mouse click detection 
        //13.4 Fixed to only work on left click
        private void GameCanvas_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            Windows.UI.Xaml.Input.Pointer ptr = e.Pointer;
            Windows.UI.Input.PointerPoint ptrPt = e.GetCurrentPoint(GameCanvas);

            if (ptrPt.Properties.IsLeftButtonPressed)
            {
                game.LMBPressed = true;
            }
            
        }
        
        /// is called if left mouse button is released
        private void GameCanvas_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            game.LMBPressed = false;
        }
    }
}
