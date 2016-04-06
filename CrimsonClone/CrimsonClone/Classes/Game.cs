﻿using CrimsonClone.User_Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace CrimsonClone.Classes
{
    class Game
    {
        // player character drawer
        private DrawPlayerCharacter player;

        // list for enemy characters
        public List<DrawEnemyCharacter> enemies;

        // list for projectiles
        public List<DrawProjectile> projectiles;

        // Creat game loop timer
        private DispatcherTimer timer;

        // Variables that express pressed key
        // NOW REDUNDANT
        // USEFLUU AGAIN
        private bool UpPressed;
        private bool DownPressed;
        private bool LeftPressed;
        private bool RightPressed;
        private bool LMBPressed;

        // canvas
        private Canvas canvas;

        // canvas sizes
        private float CanvasWidth;
        private float CanvasHeight;
        
        public Game(Canvas canvas)
        {
            this.canvas = canvas;

            // Keyboard listeners
            Window.Current.CoreWindow.KeyDown += CoreWindow_KeyDown;
            Window.Current.CoreWindow.KeyUp += CoreWindow_KeyUp;

            // initializing canwas size data
            CanvasWidth = (float)canvas.Width;
            CanvasHeight = (float)canvas.Height;

            // create player
            player = new DrawPlayerCharacter(CanvasWidth / 2, CanvasHeight / 2);
            canvas.Children.Add(player);
            player.UpdatePosition();

            // create enemy list
            enemies = new List<DrawEnemyCharacter>();
            /*
            for (int i = 1; i <= 4; i++)
                enemies.Add(new DrawEnemyCharacter());

            foreach (DrawEnemyCharacter enemy in enemies)
            {
                canvas.Children.Add(enemy);
            }
            */
            // create projectile list
            projectiles = new List<DrawProjectile>();

            // Creat game loop timer 
            timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 0, 0, 1000 / 60);
        }
        
        // this method starts the game
        public void StartGame()
        {
            timer.Start();
        }

        // game loop
        private void Timer_Tick(object sender, object e)
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
            foreach (DrawEnemyCharacter enemy in enemies)
            {
                enemy.enemyCharacter.Move(player.playerCharacter.PositionX, player.playerCharacter.PositionY);
                enemy.UpdatePosition();
            }

            // moving projectiles
            foreach (DrawProjectile projectile in projectiles)
            {
                projectile.bullet.Move();
                projectile.UpdatePosition();
            }

            if (LMBPressed) player.playerCharacter.FireWeapon();
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
    }
}
