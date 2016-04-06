﻿using System;
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
        // USEFLUU AGAIN
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

            /*// Keyboard listeners
            Window.Current.CoreWindow.KeyDown += CoreWindow_KeyDown;
            Window.Current.CoreWindow.KeyUp += CoreWindow_KeyUp;

            // initializing canwas size data
            CanvasWidth = (float)GameCanvas.Width;
            CanvasHeight = (float)GameCanvas.Height;

            // create player
            player = new DrawPlayerCharacter(CanvasWidth / 2, CanvasHeight / 2);
            GameCanvas.Children.Add(player);
            player.UpdatePosition();

            // create enemy list
            enemies = new List<DrawEnemyCharacter>();

            for (int i = 1; i <= 4; i++)
                enemies.Add(new DrawEnemyCharacter());

            foreach (DrawEnemyCharacter enemy in enemies)
            {
                GameCanvas.Children.Add(enemy);
            }

            // create projectile list
            projectiles = new List<DrawProjectile>();

            // Creat game loop timer 
            timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 0, 0, 1000 / 60);
            timer.Start();*/

            game = new Game(GameCanvas);
            game.StartGame();
        }

        // game loop
        /*private void Timer_Tick(object sender, object e)
        {
            // player movement
            float dirX = 0;
            float dirY = 0;

            // these dictate the direction in wich the player moves
            if (UpPressed) dirY -= 1;
            if (DownPressed) dirY += 1;
            if (LeftPressed) dirX -= 1;
            if (RightPressed) dirX += 1;

            // player movement method is called
            player.playerCharacter.Move(dirX, dirY);
            player.UpdatePosition();

            // moving enemies
            foreach(DrawEnemyCharacter enemy in enemies)
            {
                enemy.enemyCharacter.Move(player.playerCharacter.PositionX, player.playerCharacter.PositionY);
                enemy.UpdatePosition();
            }

            // moving projectiles
            foreach(DrawProjectile projectile in projectiles)
            {
                projectile.bullet.Move();
                projectile.UpdatePosition();
            }

            if (LMBPressed) player.playerCharacter.FireWeapon();
        }

        private void CoreWindow_KeyUp(CoreWindow sender, KeyEventArgs args)
        {
            switch (args.VirtualKey)
            {
                case VirtualKey.W:
                    UpPressed = false;
                    break;
                case VirtualKey.S:
                    DownPressed = false;
                    break;
                case VirtualKey.D:
                    RightPressed = false;
                    break;
                case VirtualKey.A:
                    LeftPressed = false;
                    break;
                case VirtualKey.LeftButton:
                    LMBPressed = false;
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
                    RightPressed = true;
                    break;
                case VirtualKey.A:
                    LeftPressed = true;
                    break;
                case VirtualKey.LeftButton:
                    LMBPressed = true;
                    break;
                default:
                    break;
            }
        }


     

        /*public void FireWeapon()
        {
            new DrawProjectile(player.playerCharacter.PositionX, player.playerCharacter.PositionY, CursorX, CursorY);
        }*/

        // Saves the positions of the cursor in the PlayerCharacter class. This is so we can use them as parameters
        // for the DrawProjectile method from the PlayerCharacter class.
        // Spaghetti.
        private void MyCanvas_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            PointerPoint pointerPoint = e.GetCurrentPoint(this);
            game.player.playerCharacter.CursorX = (float)pointerPoint.Position.X;
            game.player.playerCharacter.CursorY = (float)pointerPoint.Position.Y;
        }


    }
}
