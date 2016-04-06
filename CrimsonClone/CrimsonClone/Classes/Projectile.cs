using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrimsonClone.Classes
{
    public class Projectile : CollisionObject
    {
        // speed settings
        public readonly float speed = 30;

        public Projectile(double radius, float positionX, float positionY, float CursorX, float CursorY)
        {
            Radius = radius;
            PositionX = positionX;
            PositionY = positionY;
        }

        public void Move(float dirX, float dirY)
        {
            // temporary variables for initial X and Y changes and for cursor location
            double deltaX = 0;
            double deltaY = 0;

            // calculating the difference between player and enemy coordinates
            deltaX = dirX - PositionX;
            deltaY = dirY - PositionY;

            // calculating the angle between the player and the cursor in radians
            double Angle = Math.Atan(deltaY / deltaX);

            // actual X and Y coordinate calculations
            // sign returns 1 if given number is positive, and -1 if it's negative
            if (deltaX == 0 && deltaY != 0)
            {
                PositionY += (float)speed * Math.Sign(deltaY);
            }

            else if (deltaX != 0 && deltaY == 0)
            {
                PositionX += (float)speed * Math.Sign(deltaX);
            }

            else if (deltaX != 0 && deltaY != 0)
            {
                PositionX += (float)(Math.Cos(Angle)) * (float)speed * Math.Sign(deltaX);
                PositionY += (float)(Math.Sin(Angle)) * (float)speed * Math.Sign(deltaY);
            }
        }

        /*public override void Move(int dirX, int dirY)
        {
            throw new NotImplementedException();
        }*/
    }
}