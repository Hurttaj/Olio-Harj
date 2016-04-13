using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrimsonClone.Classes
{
    public class Enemy : CollisionObject
    {
        // maxSpeed is overall maximum speed
        private readonly double maxSpeed = 50.0;
        // currentMaxSpeed is the maximum speed for each enemy
        private double currentMaxSpeed = 4.0;
        private readonly double accelerate = 0.5;
        private double speed = 0;

        // constructor
        public Enemy(double radius /*, int time*/)
        {
            Radius = radius;
            /*currentMaxSpeed += time/1000 */
            // safetyguard for enemy speed
            if (currentMaxSpeed > maxSpeed) currentMaxSpeed = maxSpeed;
        }

        // this is a method for enemy movement
        public void Move(float dirX, float dirY)
        {
            // speed settings
            speed += accelerate;
            if (speed > currentMaxSpeed) speed = currentMaxSpeed;

            // temporary variables for initial X and Y changes and for player location
            double deltaX = 0;
            double deltaY = 0;

            // calculating the difference between player and enemy coordinates
            deltaX = dirX - PositionX;
            deltaY = dirY - PositionY;

            // calculating the angle between the player and the enemy in radians
            double angle = Math.Atan(deltaY / deltaX);

            if (deltaX < 0) angle += Math.PI;

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
                PositionX += (float)(Math.Cos(angle)) * (float)speed /* Math.Sign(deltaX)*/;
                PositionY += (float)(Math.Sin(angle)) * (float)speed /* Math.Sign(deltaY)*/;
            }
        }

        /*public override void Move(int dirX, int dirY)
        {
            throw new NotImplementedException();
        }*/

       


    }
}
