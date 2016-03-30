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
        // Creat game loop timer
        private DispatcherTimer timer;

        // Variables that express pressed key
        private bool UpPressed;
        private bool DownPressed;
        private bool LeftPressed;
        private bool RightPressed;


        public GamePage()
        {
            this.InitializeComponent();

            // Keyboard listeners
            Window.Current.CoreWindow.KeyDown += CoreWindow_KeyDown;
            Window.Current.CoreWindow.KeyUp += CoreWindow_KeyUp;

            // Creat game loop timer 
            timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 0, 0, 1000 / 60);
            timer.Start();


        }

        private void Timer_Tick(object sender, object e)
        {
            //if (UpPressed) Player.Move();
        }

        private void CoreWindow_KeyUp(CoreWindow sender, KeyEventArgs args)
        {
            switch (args.VirtualKey)
            {
                case VirtualKey.W:
                    UpPressed = false;
                    break;
                case VirtualKey.S:
                    UpPressed = false;
                    break;
                case VirtualKey.D:
                    LeftPressed = false;
                    break;
                case VirtualKey.A:
                    RightPressed = false;
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
                    UpPressed = true;
                    break;
                case VirtualKey.S:
                    DownPressed = true;
                    break;
                case VirtualKey.D:
                    LeftPressed = true;
                    break;
                case VirtualKey.A:
                    RightPressed = true;
                    break;
                default:
                    break;
            }
        }


    }
}
