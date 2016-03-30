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
    public sealed partial class DrawProjectile : UserControl
    {
        public Projectile bullet;

        public DrawProjectile()
        {
            this.InitializeComponent();

            Width = 6;
            Height = 6;

            bullet = new Projectile(Width / 2, player.PositionX, player.PositionY);
        }
    }
}
