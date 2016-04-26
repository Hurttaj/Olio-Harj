/*
 * This is a part of a student project made in JAMK University of Applied Sciences
 * Link to this project's GitHub:
 * https://github.com/Hurttaj/Olio-Harj
 * 
 * Authors and their GitHub names:
 * Borhan Amini (bhnamn)
 * Hurtta Jussi (Hurttaj)
 * Minkkilä Juuso (SlightHeadahce)
 *
 * Date: Spring 2016
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrimsonClone.Classes
{
    /// <summary>
    /// This is a class for enemy characters
    /// It inherits collision object
    /// </summary>
    public class Enemy : CollisionObject
    {
        /// <summary>
        /// In order of appearance:
        /// maxSpeed is overall maximum speed
        /// currentMaxSpeed is the maximum speed for each enemy
        /// accelerate is enemy's acceleration
        /// speed is enemy's current speed
        /// </summary>
        private readonly double maxSpeed = 50.0;
        private double currentMaxSpeed = 4.0;
        private readonly double accelerate = 0.5;
        private double speed = 0;

        /// <summary>
        /// Enemy's default constructor
        /// </summary>
        /// <param name="radius">required for collision checks</param>
        /// <param name="tickCount">increases maximum speed</param>
        public Enemy(double radius, int tickCount)
        {
            Radius = radius;
            currentMaxSpeed += tickCount / 1800.0;
            Debug.WriteLine("MaxSpeed" + currentMaxSpeed);
            /// safetyguard for enemy speed
            if (currentMaxSpeed > maxSpeed) currentMaxSpeed = maxSpeed;
        }

        /// <summary>
        /// this is a method for enemy movement
        /// </summary>
        /// <param name="dirX">player's X-position</param>
        /// <param name="dirY">player's Y-position</param>
        public void Move(float dirX, float dirY)
        {
            /// speed settings
            speed += accelerate;
            if (speed > currentMaxSpeed) speed = currentMaxSpeed;

            /// temporary variables for initial X and Y changes and for player location
            double deltaX = 0;
            double deltaY = 0;

            /// calculating the difference between player and enemy coordinates
            deltaX = dirX - PositionX;
            deltaY = dirY - PositionY;

            /// calculating the angle between the player and the enemy in radians
            double angle = Math.Atan(deltaY / deltaX);

            if (deltaX < 0) angle += Math.PI;

            /// actual X and Y coordinate calculations
            /// sign returns 1 if given number is positive, and -1 if it's negative
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
