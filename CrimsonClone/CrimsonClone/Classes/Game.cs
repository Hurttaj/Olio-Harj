using CrimsonClone.User_Controls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public DrawPlayerCharacter player;

        // list for enemy characters
        public List<DrawEnemyCharacter> enemies;
        // list for to-be-removed enemies
        public List<DrawEnemyCharacter> removeEnemies;

        // rng for enemy spawn
        private Random enemyX = new Random();
        private Random enemyY = new Random();

        // list for projectiles
        public List<DrawProjectile> projectiles;
        // list for to-be-removed projectiles
        public List<DrawProjectile> removeProjectiles;

        // Creat game loop timer
        private DispatcherTimer timer;

        // Variables that express pressed key
        // NOW REDUNDANT
        // USEFLUU AGAIN
        private bool UpPressed;
        private bool DownPressed;
        private bool LeftPressed;
        private bool RightPressed;

        // is LMB pressed, comes from GamePage
        public bool LMBPressed;

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
       
            // create projectile list
            projectiles = new List<DrawProjectile>();

            // creating four enemies
            SpawnEnemies(4);
            /*
            for (int i = 1; i <= 4; i++)
            {
                DrawEnemyCharacter tempEnemy = new DrawEnemyCharacter(enemyX.Next(1, (int)CanvasWidth), enemyY.Next(1, (int)CanvasHeight));
                enemies.Add(tempEnemy);
                canvas.Children.Add(tempEnemy);
                Debug.WriteLine("Enemy added");
            }
            */

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
            EnemyCollision();

            // initialize prjectile removal list
            removeProjectiles = new List<DrawProjectile>();

            // moving projectiles
            foreach (DrawProjectile projectile in projectiles)
            {
                projectile.bullet.Move();
                //Debug.WriteLine("Projectile moved logically");
                projectile.UpdatePosition();
                //Debug.WriteLine("Projectile moved on canvas");

                // POISTETTAVAT ALUKSI ERI LISTAAN!
                if (projectile.bullet.PositionX <= 0 ||
                    projectile.bullet.PositionX >= (CanvasWidth - projectile.bullet.Radius * 2) ||
                    projectile.bullet.PositionY <= 0 ||
                    projectile.bullet.PositionY >= (CanvasHeight - projectile.bullet.Radius * 2))
                {
                    removeProjectiles.Add(projectile);
                    //Debug.WriteLine("Projectile added to removal list");
                }   
            }

            // removing projectiles
            foreach (DrawProjectile projectile in removeProjectiles)
            {
                try
                { 
                    canvas.Children.Remove(projectile);
                    //Debug.WriteLine("Projectile removed from canvas");
                    projectiles.Remove(projectile);
                    //Debug.WriteLine("Projectile removed from list");
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }

            if (LMBPressed)
            {
                try
                {
                    DrawProjectile tempProjectile = player.playerCharacter.FireWeapon();
                    projectiles.Add(tempProjectile);
                    canvas.Children.Add(tempProjectile);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
        }

        public void EnemyCollision()
        {
            Debug.WriteLine("Enemy collision check");
            removeEnemies = new List<DrawEnemyCharacter>();
            removeProjectiles = new List<DrawProjectile>();

            foreach (DrawEnemyCharacter enemy in enemies)
            {
                bool breaker = false;

                if (enemy.enemyCharacter.Collision(player.playerCharacter))
                {
                    // Game over
                }

                foreach (DrawProjectile projectile in projectiles)
                {
                    if(enemy.enemyCharacter.Collision(projectile.bullet))
                    {
                        removeEnemies.Add(enemy);
                        removeProjectiles.Add(projectile);
                        Debug.WriteLine("Enemy added to remove list");
                        breaker = true;
                        break;
                    }
                }
                if (breaker == true) break;
            }
            foreach (DrawEnemyCharacter enemy in removeEnemies)
            {
                try
                {
                    enemies.Remove(enemy);
                    canvas.Children.Remove(enemy);
                    Debug.WriteLine("Enemy removed");
                    SpawnEnemies(2);
                }
                catch(Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }

            foreach (DrawProjectile projectile in removeProjectiles)
            {
                try
                {
                    projectiles.Remove(projectile);
                    canvas.Children.Remove(projectile);
                }
                catch(Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                } 
            }
        }

        // enemy spawn method
        private void SpawnEnemies(int count)
        {
            for (int i = 1; i <= count; i++)
            {
                DrawEnemyCharacter tempEnemy = new DrawEnemyCharacter(enemyX.Next(1, (int)CanvasWidth), enemyY.Next(1, (int)CanvasHeight));
                enemies.Add(tempEnemy);
                canvas.Children.Add(tempEnemy);
                Debug.WriteLine("Enemy added");
            }
            
        }

        // W,A,S,D keys difinitions
        // And checking if they are pressed
        private void CoreWindow_KeyDown(CoreWindow sender, KeyEventArgs args)
        {
            switch (args.VirtualKey)
            {
                case VirtualKey.W:
                    UpPressed = true;
                    //Debug.WriteLine("W = true");
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
                    //Debug.WriteLine("W = false");
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
                default:
                    break;
            }
        }
    }
}
