using CrimsonClone.Classes;
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

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace CrimsonClone.User_Controls
{
    /// <summary>
    /// Visual elemnt of enemy character
    /// </summary>
    public sealed partial class DrawEnemyCharacter : UserControl
    {
        /// <summary>
        /// The actual logical enemy character
        /// </summary>
        public Enemy enemyCharacter;
        
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="positionX">spawn location</param>
        /// <param name="positionY">spawn location</param>
        /// <param name="tickCount">used for enemy charafter's speed</param>
        public DrawEnemyCharacter(float positionX, float positionY, int tickCount)
        {
            this.InitializeComponent();

            /// visaul size
            Width = 18;
            Height = 18;

            /// creating an enemy character
            enemyCharacter = new Enemy(Width / 2, tickCount);

            /// settings for enemy character
            enemyCharacter.PositionX = positionX;
            enemyCharacter.PositionY = positionY;
            SetValue(Canvas.ZIndexProperty, -10);
            UpdatePosition();
        }

        /// <summary>
        /// updates the location on canvas
        /// </summary>
        public void UpdatePosition()
        {
            SetValue(Canvas.LeftProperty, enemyCharacter.PositionX);
            SetValue(Canvas.TopProperty, enemyCharacter.PositionY);
        }
    }
}
