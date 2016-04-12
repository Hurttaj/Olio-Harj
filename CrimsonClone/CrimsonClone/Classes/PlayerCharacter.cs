using CrimsonClone.User_Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CrimsonClone.Classes
{
    public class PlayerCharacter : CollisionObject
    {
        // speed settings
        private readonly double maxSpeed = 15.0;
        private readonly double accelerate = 0.7;
        private double speed = 0;
        public float CursorX;
        public float CursorY;

        /*
        // Variables that express pressed key
        public bool UpPressed;
        public bool DownPressed;
        public bool LeftPressed;
        public bool RightPressed;
        public bool LMBPressed;
        */

        // Constructor. Vector2 is a property that marks the centerpoint as a coordinate. 
        public PlayerCharacter(double radius)
        {
            Radius = radius;
        }

        /*public override void Move (int dirX, int dirY)
        {
            // speed settings; speed and acceleration are defined in class's private fields
            speed += accelerate;
            if (speed > maxSpeed) speed = maxSpeed;
            
            // if X or Y change is 0, there's no need for further calculation
            if (dirX == 0 || dirY == 0)
            {
                PositionX += (float)speed * dirX;
                PositionY += (float)speed * dirY;
            }
            
            // if both X and Y change, the actual amount of movement has to be re-evaluated so that the movement area is not a square but rather a stop-sign
            // this way speed stays the same regardless of the direction of the movement
            else
            {
                // (Math.PI/4) is 45 degrees in radians
                PositionX += (float)Math.Cos(Math.PI/4) * dirX * (float)speed;
                PositionY += (float)Math.Sin(Math.PI/4) * dirY * (float)speed;
            } 
        }*/

        public void Move(float dirX, float dirY)
        {
            /*
            dirX = 0;
            dirY = 0;

            if (UpPressed) dirY -= 1;
            if (DownPressed) dirY += 1;
            if (LeftPressed) dirX -= 1;
            if (RightPressed) dirX += 1;
            */

            // speed settings; speed and acceleration are defined in class's private fields
            speed += accelerate;
            if (speed > maxSpeed) speed = maxSpeed;

            // if X or Y change is 0, there's no need for further calculation
            if (dirX == 0 || dirY == 0)
            {
                PositionX += (float)speed * dirX;
                PositionY += (float)speed * dirY;
            }

            // if both X and Y change, the actual amount of movement has to be re-evaluated so that the movement area is not a square but rather a stop-sign
            // this way speed stays the same regardless of the direction of the movement
            else
            {
                // (Math.PI/4) is 45 degrees in radians
                PositionX += (float)Math.Cos(Math.PI / 4) * dirX * (float)speed;
                PositionY += (float)Math.Sin(Math.PI / 4) * dirY * (float)speed;
            }
        }

        public DrawProjectile FireWeapon()
        {
            return new DrawProjectile(PositionX + (float)Radius, PositionY + (float)Radius, CursorX, CursorY);
        }
    }
}
