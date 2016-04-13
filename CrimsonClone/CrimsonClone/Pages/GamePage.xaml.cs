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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace CrimsonClone
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GamePage : Page
    {

        private Game game;

        // Variables that express pressed key
        // NOW REDUNDANT
        // USEFUL AGAIN
        // REMOVED AGAIN    

        public GamePage()
        {

            this.InitializeComponent();

          

            game = new Game(GameCanvas);
            game.StartGame();
        }

        // mouce movement
        private void MyCanvas_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            PointerPoint pointerPoint = e.GetCurrentPoint(this);
            game.player.playerCharacter.CursorX = (float)pointerPoint.Position.X;
            game.player.playerCharacter.CursorY = (float)pointerPoint.Position.Y;
        }


        // mouse click. 13.4 Fixed to only work on left click
        private void GameCanvas_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            Windows.UI.Xaml.Input.Pointer ptr = e.Pointer;
            Windows.UI.Input.PointerPoint ptrPt = e.GetCurrentPoint(GameCanvas);

            if (ptrPt.Properties.IsLeftButtonPressed)
            {
                game.LMBPressed = true;
            }
            
        }

        private void GameCanvas_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            game.LMBPressed = false;
        }
    }
}
