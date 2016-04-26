using CrimsonClone.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
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

namespace CrimsonClone
{
    /// <summary>
    /// visual representation of a player character
    /// </summary>
    public sealed partial class DrawPlayerCharacter : UserControl
    {
        /// <summary>
        /// actual, logical player character
        /// </summary>
        public PlayerCharacter playerCharacter;

        /// <summary>
        /// default constructor
        /// </summary>
        /// <param name="positionX">player character's X position</param>
        /// <param name="positionY">player character's Y position</param>
        public DrawPlayerCharacter(float positionX, float positionY)
        {
            this.InitializeComponent();

            /// visual width and height
            Width = 20;
            Height = 20;
            
            /// creates a player character
            playerCharacter = new PlayerCharacter(Width / 2);
            /// player character's settings
            playerCharacter.PositionX = positionX;
            playerCharacter.PositionY = positionY;
        }

        /// <summary>
        /// updates the location on canvas
        /// </summary>
        public void UpdatePosition()
        {
            SetValue(Canvas.LeftProperty, playerCharacter.PositionX);
            SetValue(Canvas.TopProperty, playerCharacter.PositionY);
        }
    }
}
