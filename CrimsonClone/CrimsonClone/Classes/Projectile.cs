using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrimsonClone.Classes
{
    public class Projectile : CollisionObject
    {
        public readonly float Speed = 30;

        public Projectile(double radius, float positionX, float positionY)
        {
            Radius = radius;
            PositionX = positionX;
            PositionY = positionY;
        }

        public override void Move(float dirX, float dirY)
        {
            throw new NotImplementedException();
        }

        /*public override void Move(int dirX, int dirY)
        {
            throw new NotImplementedException();
        }*/
    }
}