using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrimsonClone.Classes
{
    /// <summary>
    /// This is a class for projectiles
    /// </summary>
    public class Projectile : CollisionObject
    {
        /// speed settings
        public readonly float speed = 20;
        /// <summary>
        /// dirX and dirY are for cursor's X and Y locations on the time of projectile's creation
        /// </summary>
        private float dirX;
        private float dirY;

        /// temporary variables for initial X and Y changes 
        /// used with cursor location
        double deltaX = 0;
        double deltaY = 0;

        /// <summary>
        /// field for movement angle
        /// determined by deltaX and Y
        /// </summary>
        double angle;

        /// <summary>
        /// Default constuctor
        /// </summary>
        /// <param name="radius">required for collision checks</param>
        /// <param name="positionX">player's X position; the initial X position of a spawning projectile</param>
        /// <param name="positionY">player's Y position; the initial Y position of a spawning projectile</param>
        /// <param name="cursorX">cursor's X position</param>
        /// <param name="cursorY">cursor's Y position</param>
        public Projectile(double radius, float positionX, float positionY, float cursorX, float cursorY)
        {
            /// setting stuff up
            Radius = radius;
            PositionX = positionX - (float)radius;
            PositionY = positionY - (float)radius;
            dirX = cursorX;
            dirY = cursorY;

            /// calculating the difference between player and enemy coordinates
            deltaX = dirX - PositionX + Radius;
            deltaY = dirY - PositionY + Radius;

            /// calculating the angle between the player and the cursor in radians
            angle = Math.Atan(deltaY / deltaX);

            /// required because of tangent's symmetry
            if (deltaX < 0) angle += Math.PI;
        }

        /// <summary>
        /// Moves the projectile
        /// </summary>
        public void Move(/*float dirX, float dirY*/)
        {
            // debug sentences
            /*
            Debug.WriteLine("Direction: " + dirX + "," + dirY);
            Debug.WriteLine("Position: " + PositionX + "," + PositionY);
            */

            /// actual X and Y coordinate calculations
            /// sign returns 1 if given number is positive, and -1 if it's negative
            if (deltaX == 0 && deltaY != 0)
            {
                PositionY += speed * Math.Sign(deltaY);
            }

            else if (deltaX != 0 && deltaY == 0)
            {
                PositionX += speed * Math.Sign(deltaX);
            }

            /// if both X and Y positions have to change, angle has to be used
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