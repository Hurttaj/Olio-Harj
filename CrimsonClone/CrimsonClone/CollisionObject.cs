using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrimsonClone
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Numerics;
    using System.Text;
    using System.Threading.Tasks;


    class CollisionObject
    {
        // speed and radius properties. Marked private so I can exclude negative values.
        // Theoretically using unsigned doubles would also work, but it would probably crash the game if these properties got a negative value.
        private double speed;
        private double radius;
        // From the System.Numerics library. Seems like this is easier than having separate coordinate properties. The library contains
        // some functionality we would otherwise have to code ourselves.
        // Could add encapsulation to make sure Vector2 values cannot be out of bounds of the XAML canvas.
        public Vector2 Center { get; set; }

        // Constructor. Vector2 is a property that marks the centerpoint as a coordinate. 
        public CollisionObject(Vector2 center, double radius)
        {
            Center = center;
            Radius = radius;
        }

        // This just throws an exception if you try to give the speed property a negative value.
        public double Speed
        {
            get
            { return speed; }
            set
            {
                if (value >= 0) speed = value;
                else throw new System.ArgumentException("Cannot be negative.");
            }
        }

        // Same as previous except for the radius property. The code is copypasted.
        public double Radius
        {
            get
            { return radius; }
            set
            {
                if (value >= 0) radius = value;
                else throw new System.ArgumentException("Cannot be negative.");
            }
        }

        // Collision math. Basically, if the distance between the centers of the circles is smaller
        // than the difference between radii, the circles necessarily intersect.
        // It's a bool, so it returns a true/false value. So if this method returns true,
        // we can have that trigger collision mechanics.
        public bool Collision(CollisionObject collisionObject)
        {
            return ((collisionObject.Center - Center).Length() < (collisionObject.radius - radius));
        }

        // Placeholder.
        public void move()
        {
            Debug.WriteLine("Do something!");
        }

    }
}
