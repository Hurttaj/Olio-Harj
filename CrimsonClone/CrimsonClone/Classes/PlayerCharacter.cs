using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CrimsonClone.Classes
{
    class PlayerCharacter : CollisionObject
    {
        // Constructor. Vector2 is a property that marks the centerpoint as a coordinate. 
        public PlayerCharacter(Vector2 center, double radius)
        {
            Center = center;
            Radius = radius;
        }

        public override void move()
        {
            throw new NotImplementedException();
        }
    }
}
