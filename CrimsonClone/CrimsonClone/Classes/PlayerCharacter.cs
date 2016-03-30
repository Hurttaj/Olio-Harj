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
        private readonly double maxSpeed = 15.0;
        private readonly double accelerate = 0.7;
        private double speed = 0;

        // Constructor. Vector2 is a property that marks the centerpoint as a coordinate. 
        public PlayerCharacter(Vector2 center, double radius)
        {
            Center = center;
            Radius = radius;
        }

        public void Move (int dirX, int dirY)
        {
            // speed settings; speed and acceleration are defined in class's private fields
            speed += accelerate;
            if (speed > maxSpeed) speed = maxSpeed;
            
            // if X or Y change is 0, there's no need for further calculation
            if (dirX == 0 || dirY == 0)
            {
                LocationX += speed * dirX;
                LocationY += speed * dirY;
            }
            
            // if both X and Y change, the actual amount of movement has to be re-evaluated so that the movement area is not a square but rather a stop-sign
            // this way speed stays the same regardless of the direction of the movement
            else
            {
                // (Math.PI/4) is 45 degrees in radians
                LocationX += Math.Cos(Math.PI/4) * dirX * speed;
                LocationY += Math.Sin(Math.PI/4) * dirY * speed;
            } 
        }
        
    }
}
