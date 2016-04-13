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
    public sealed partial class DrawEnemyCharacter : UserControl
    {
        public Enemy enemyCharacter;
        
        public DrawEnemyCharacter(float positionX, float positionY)
        {
            this.InitializeComponent();

            Width = 12;
            Height = 12;

            enemyCharacter = new Enemy(Width / 2);
            enemyCharacter.PositionX = positionX;
            enemyCharacter.PositionY = positionY;
            SetValue(Canvas.ZIndexProperty, -10);

        }

        public void UpdatePosition()
        {
            SetValue(Canvas.LeftProperty, enemyCharacter.PositionX);
            SetValue(Canvas.TopProperty, enemyCharacter.PositionY);
        }
    }
}
