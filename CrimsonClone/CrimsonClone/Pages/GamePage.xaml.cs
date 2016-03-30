using System;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace CrimsonClone
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GamePage : Page
    {
        // player character drawer
        private DrawPlayerCharacter player;

        // Creat game loop timer
        private DispatcherTimer timer;

        // Variables that express pressed key
        private bool UpPressed;
        private bool DownPressed;
        private bool LeftPressed;
        private bool RightPressed;
        private bool LMBPressed;

        // canvas sizes
        private float CanvasWidth;
        private float CanvasHeight;

        public GamePage()
        {
            this.InitializeComponent();

            // Keyboard listeners
            Window.Current.CoreWindow.KeyDown += CoreWindow_KeyDown;
            Window.Current.CoreWindow.KeyUp += CoreWindow_KeyUp;

            // initializing canwas size data
            CanvasWidth = (float)GameCanvas.Width;
            CanvasHeight = (float)GameCanvas.Height;

            // create player
            player = new DrawPlayerCharacter(CanvasWidth / 2, CanvasHeight / 2);
            GameCanvas.Children.Add(player);
            player.UpdatePosition(); 

            // Creat game loop timer 
            timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 0, 0, 1000 / 60);
            timer.Start();
        }

        private void Timer_Tick(object sender, object e)
        {
            //if (UpPressed) Player.Move();
            player.UpdatePosition();
        }

        private void CoreWindow_KeyUp(CoreWindow sender, KeyEventArgs args)
        {
            switch (args.VirtualKey)
            {
                case VirtualKey.W:
                    player.playerCharacter.UpPressed = false;
                    break;
                case VirtualKey.S:
                    player.playerCharacter.UpPressed = false;
                    break;
                case VirtualKey.D:
                    player.playerCharacter.LeftPressed = false;
                    break;
                case VirtualKey.A:
                    player.playerCharacter.RightPressed = false;
                    break;
                case VirtualKey.LeftButton:
                    player.playerCharacter.LMBPressed = false;
                    break;
                default:
                    break;
            }
        }

        // W,S,A,D keys difinitions
        // And checking if they are pressed
        private void CoreWindow_KeyDown(CoreWindow sender, KeyEventArgs args)
        {
            switch (args.VirtualKey)
            {
                case VirtualKey.W:
                    player.playerCharacter.UpPressed = true;
                    break;
                case VirtualKey.S:
                    player.playerCharacter.DownPressed = true;
                    break;
                case VirtualKey.D:
                    player.playerCharacter.LeftPressed = true;
                    break;
                case VirtualKey.A:
                    player.playerCharacter.RightPressed = true;
                    break;
                case VirtualKey.LeftButton:
                    player.playerCharacter.LMBPressed = true;
                    break;
                default:
                    break;
            }
        }


    }
}
