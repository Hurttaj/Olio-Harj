using CrimsonClone.User_Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.System;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace CrimsonClone.Classes
{
    class Game : INotifyPropertyChanged
    {

        /// Audio from: https://www.freesound.org/people/D%20W/sounds/143610/ No changes were made.
        private MediaElement fireAudio;

        /// Audio from: https://www.freesound.org/people/yottasounds/sounds/232135/ No changes were made.
        private MediaElement deathAudio;

        private async void FireSound()
        {
            /// create media element
            fireAudio = new MediaElement();
            /// load audio from assets
            StorageFolder folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("Assets");
            StorageFile file = await folder.GetFileAsync("FireAudio.wav");
            var stream = await file.OpenAsync(FileAccessMode.Read);
            fireAudio.AutoPlay = false;
            fireAudio.SetSource(stream, file.ContentType);
        }

        private async void DeathSound()
        {
            /// create media element
            deathAudio = new MediaElement();
            /// load audio from assets
            StorageFolder folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("Assets");
            StorageFile file = await folder.GetFileAsync("DeathAudio.wav");
            var stream = await file.OpenAsync(FileAccessMode.Read);
            deathAudio.AutoPlay = false;
            deathAudio.SetSource(stream, file.ContentType);
        }

        /// player character drawer
        public DrawPlayerCharacter player;

        /// list for enemy characters
        public List<DrawEnemyCharacter> enemies;
        /// list for to-be-removed enemies
        public List<DrawEnemyCharacter> removeEnemies;

        /// rng for enemy spawn
        private Random spawnRand = new Random();
        private Random enemyRand = new Random();

        /// list for projectiles
        public List<DrawProjectile> projectiles;
        /// list for to-be-removed projectiles
        public List<DrawProjectile> removeProjectiles;

        /// Creat game loop timer
        private DispatcherTimer timer;

        /// firerate timer
        private DispatcherTimer fireRate;

        /// boolean determing wether or not you are allowed to shoot
        private bool fireTimer = true;

        /// Variables that express pressed key
        // NOW REDUNDANT
        // USEFLUU AGAIN
        private bool UpPressed;
        private bool DownPressed;
        private bool LeftPressed;
        private bool RightPressed;

        /// property changed interface thingy
        public event PropertyChangedEventHandler PropertyChanged;

        /// required for updating score and time on the screen
        protected void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        
        /// is LMB pressed, comes from GamePage
        public bool LMBPressed;

        
        /// TickCount is simply the amount of ticks palyed; how many times the game loop has been completed
        // Starts at 900 so that the random spawn of enemies starts increasing 15 seconds in.
        // Moved the 900 to the rand itself.
        private int tickCount = 0;
        public int TickCount
        {
            get
            {
                return tickCount;
                //return TickCount;
            }
            set
            {
                tickCount = value;
                //TickCount = value;
                RaisePropertyChanged();
            }
        }

        /// score counter; is increased when enemies are killed
        private int score = 0;
        public int Score
        {
            get
            {
                return score;
                //return Score;
            }
            set
            {
                score = value;
                //Score = value;

                /// notifies that the Score has been changed
                RaisePropertyChanged();
            }
        }

        /// canvas
        private Canvas canvas;

        /// canvas sizes
        private float CanvasWidth;
        private float CanvasHeight;

        /// required for game over stuff
        private GamePage gamePage;

        public Game(Canvas canvas, GamePage gamePage)
        {
            /// canvas and page initializing stuff for movement and whatnot
            this.canvas = canvas;
            this.gamePage = gamePage;

            FireSound();
            DeathSound();

            // IsGameOver = false;

            /// Keyboard listeners
            Window.Current.CoreWindow.KeyDown += CoreWindow_KeyDown;
            Window.Current.CoreWindow.KeyUp += CoreWindow_KeyUp;

            /// initializing canvas size data
            CanvasWidth = (float)canvas.Width;
            CanvasHeight = (float)canvas.Height;

            /// create player
            player = new DrawPlayerCharacter(CanvasWidth / 2, CanvasHeight / 2);
            canvas.Children.Add(player);
            /// updates players position on canvas
            player.UpdatePosition();

            /// create enemy list
            enemies = new List<DrawEnemyCharacter>();
       
            /// create projectile list
            projectiles = new List<DrawProjectile>();

            /// creating four enemies
            SpawnEnemies(4);

            /// initialize TickCount and Score to 0
            TickCount = 0;
            Score = 0;

            /// create game loop timer 
            timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 0, 0, (1000 / 60));

            /// create firerate dispatcher timer
            fireRate = new DispatcherTimer();
            fireRate.Tick += FireRate_Tick;
            fireRate.Interval = new TimeSpan(0, 0, 0, 0, (10000 / 25));
        }
        
        /// this method starts the game
        public void StartGame()
        {
            /// starts game- and firerate -timers
            timer.Start();
            fireRate.Start();
        }

        /// this method changes the firerate boolean, wether or not you are allowed to shoot
        private void FireRate_Tick(object sender, object e)
        { fireTimer = true; }

        /// game loop
        private void Timer_Tick(object sender, object e)
        {
            /// player movement initial directions
            float dirX = 0;
            float dirY = 0;

            /// these dictate the direction in wich the player moves
            if (UpPressed) dirY -= 1;
            if (DownPressed) dirY += 1;
            if (LeftPressed) dirX -= 1;
            if (RightPressed) dirX += 1;

            /// player movement method is called
            player.playerCharacter.Move(dirX, dirY);
            /// updates players position on canvas
            player.UpdatePosition();

            /// moving enemies
            foreach (DrawEnemyCharacter enemy in enemies)
            {
                enemy.enemyCharacter.Move(player.playerCharacter.PositionX, player.playerCharacter.PositionY);
                enemy.UpdatePosition();
            }

            /// calls enemy collision
            EnemyCollision();

            /// initialize projectile removal list
            removeProjectiles = new List<DrawProjectile>();

            /// moving projectiles
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

            /// removing projectiles
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


            /// calls fireWeapon if you are allowed to fire
            if (LMBPressed && fireTimer)
            {
                try
                {
                    DrawProjectile tempProjectile = player.playerCharacter.FireWeapon();
                    projectiles.Add(tempProjectile);
                    canvas.Children.Add(tempProjectile);
                    fireAudio.Play();
                    fireTimer = false;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }

            /// increases tick count
            TickCount++;
        }

        /// <summary>
        /// Enemy collision method
        /// Checks wether or not enemies collide with projectiles or the player
        /// </summary>
        public void EnemyCollision()
        {
            //Debug.WriteLine("Enemy collision check");

            /// initialize removal lists
            removeEnemies = new List<DrawEnemyCharacter>();
            removeProjectiles = new List<DrawProjectile>();

            /// collision checks
            foreach (DrawEnemyCharacter enemy in enemies)
            {
                /// used for break check; used for breaking the main collision check loop
                bool breaker = false;

                /// enemy-player collision checks
                if (enemy.enemyCharacter.Collision(player.playerCharacter))
                {
                    // Game over
                    // IsGameOver = true;
                    timer.Stop();
                    gamePage.GameOver();
                }

                /// enemy-projectile collision checks
                foreach (DrawProjectile projectile in projectiles)
                {
                    if(enemy.enemyCharacter.Collision(projectile.bullet))
                    {
                        /// if collision happens, enemy and projectile are both added to their removal list
                        removeEnemies.Add(enemy);
                        removeProjectiles.Add(projectile);
                        //Debug.WriteLine("Enemy added to remove list");
                        breaker = true;
                        break;
                    }
                }
                if (breaker == true) break;
            }

            /// removes enemies from canvas and enemy list, and also plays death sound for each
            foreach (DrawEnemyCharacter enemy in removeEnemies)
            {
                try
                {
                    enemies.Remove(enemy);
                    /// plays death sound
                    deathAudio.Play();
                    canvas.Children.Remove(enemy);
                    /// increases core by 100 per dead enemy
                    Score += 100;
                    //Debug.WriteLine("Enemy removed");
                    //Debug.WriteLine("Tick" + (int)(2 + (tickCount / 300)));
                    //Debug.WriteLine("Rand" + spawnRand.Next(1, (int)(2 + ((tickCount+900)/ 1800))));
                    /// spawns new enemy; amount of enemies spawned is partially determined by game time
                    SpawnEnemies(spawnRand.Next(1, (int)(2 + ((TickCount+900)/ 1800))));
                    // The tick counter works but for some reason the rand always returns 1.
                
                }
                catch(Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }

            /// removes projectiles from canvas and projectile list
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

        /// <summary>
        /// Enemy spawn method
        /// </summary>
        /// <param name="count">how many enemies are to be spawned</param>
        private void SpawnEnemies(int count)
        {
            for (int i = 1; i <= count; i++)
            {
                /// creates a new temporary enemy that is to be added to canvas and enemy list
                /// spawn location is determined randomly
                /// tick count increases speed
                DrawEnemyCharacter tempEnemy = new DrawEnemyCharacter(enemyRand.Next(1, (int)CanvasWidth), enemyRand.Next(1, (int)CanvasHeight), TickCount);
                enemies.Add(tempEnemy);
                canvas.Children.Add(tempEnemy);
                //Debug.WriteLine("Enemy added");
            }
            
        }
        
        /// <summary>
        /// W,A,S,D keys definitions
        /// And checking if they are pressed
        /// </summary>
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

        /// <summary>
        /// W,A,S,D keys definitions
        /// And checking if they are released
        /// </summary>
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
