using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrimsonClone.Classes
{
    class Projectile
    {
        public readonly float Speed = 30;

        public Projectile(double radius, float positionX, float positionY)
        {
            Radius = radius;
            PositionX = positionX;
            PositionY = positionY;
        }
    }
}