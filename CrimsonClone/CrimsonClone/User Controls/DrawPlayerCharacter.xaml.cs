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
        public PlayerCharacter playerCharacter;

        public DrawPlayerCharacter(float positionX, float positionY)
        {
            this.InitializeComponent();

            Width = 20;
            Height = 20;
            
            playerCharacter = new PlayerCharacter(Width / 2);
            playerCharacter.PositionX = positionX;
            playerCharacter.PositionY = positionY;
        }

        public void UpdatePosition()
        {
            SetValue(Canvas.LeftProperty, playerCharacter.PositionX);
            SetValue(Canvas.TopProperty, playerCharacter.PositionY);
        }
    }
}
