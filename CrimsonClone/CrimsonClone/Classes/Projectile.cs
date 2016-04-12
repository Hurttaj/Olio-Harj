using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrimsonClone.Classes
{
    public class Projectile : CollisionObject
    {
        // speed settings
        public readonly float speed = 30;
        private float dirX;
        private float dirY;

        // temporary variables for initial X and Y changes and for cursor location
        double deltaX = 0;
        double deltaY = 0;

        double angle;

        public Projectile(double radius, float positionX, float positionY, float cursorX, float cursorY)
        {
            Radius = radius;
            PositionX = positionX - (float)radius;
            PositionY = positionY - (float)radius;
            dirX = cursorX;
            dirY = cursorY;

            // calculating the difference between player and enemy coordinates
            deltaX = dirX - PositionX + Radius;
            deltaY = dirY - PositionY + Radius;

            // calculating the angle between the player and the cursor in radians
            angle = Math.Atan(deltaY / deltaX);

            if (deltaX < 0) angle += Math.PI;
        }

        public void Move(/*float dirX, float dirY*/)
        {
            // debug sentences
            Debug.WriteLine("Direction: " + dirX + "," + dirY);
            Debug.WriteLine("Position: " + PositionX + "," + PositionY);

            // actual X and Y coordinate calculations
            // sign returns 1 if given number is positive, and -1 if it's negative
            if (deltaX == 0 && deltaY != 0)
            {
                PositionY += speed * Math.Sign(deltaY);
            }

            else if (deltaX != 0 && deltaY == 0)
            {
                PositionX += speed * Math.Sign(deltaX);
            }

            else if (deltaX != 0 && deltaY != 0)
            {
                PositionX += (float)(Math.Cos(angle)) * speed /* Math.Sign(deltaX)*/;
                PositionY += (float)(Math.Sin(angle)) * speed /* Math.Sign(deltaY)*/;
            }
        }

        /*public override void Move(int dirX, int dirY)
        {
            throw new NotImplementedException();
        }*/
    }
}