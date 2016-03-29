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
    public sealed partial class DrawPlayerCharacter : UserControl
    {
        private PlayerCharacter player;
        Vector2 myVector = new Vector2(1, 1);

        public DrawPlayerCharacter()
        {
            this.InitializeComponent();

            Width = 16;
            Height = 16;
            
            player = new PlayerCharacter(myVector, Width / 2);
        }

        public void UpdatePosition()
        {
            SetValue(Canvas.LeftProperty, myVector);
            SetValue(Canvas.TopProperty, myVector);
        }

        public void FireWeapon()
        {

        }
    }
}
