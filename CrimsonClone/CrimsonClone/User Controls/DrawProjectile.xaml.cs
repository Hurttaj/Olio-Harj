using CrimsonClone.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Input;
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
    /// visual representation of a projectile
    /// </summary>
    public sealed partial class DrawProjectile : UserControl
    {
        /// <summary>
        /// actual, logical projectile
        /// </summary>
        public Projectile bullet;

        /// <summary>
        /// default constructor
        /// </summary>
        /// <param name="PositionX">initial X position</param>
        /// <param name="PositionY">initial Y position</param>
        /// <param name="CursorX">X direction</param>
        /// <param name="CursorY">Y direction</param>
        public DrawProjectile(float PositionX, float PositionY, float CursorX, float CursorY)
        {
            this.InitializeComponent();

            /// width and height settings
            Width = 6;
            Height = 6;

            /// creates a new projectile
            bullet = new Projectile(Width / 2, PositionX, PositionY, CursorX, CursorY);
            UpdatePosition();
            SetValue(Canvas.ZIndexProperty, -5);
        }

        /// <summary>
        /// updates the location on canvas
        /// </summary>
        public void UpdatePosition()
        {
            SetValue(Canvas.LeftProperty, bullet.PositionX);
            SetValue(Canvas.TopProperty, bullet.PositionY);
        }
    }
}
