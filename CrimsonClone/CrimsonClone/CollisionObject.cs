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


    abstract class CollisionObject
    {
        // speed and radius properties. Marked private so I can exclude negative values.
        // Theoretically using unsigned doubles would also work, but it would probably crash the game if these properties got a negative value.
        private double speed;
        private double radius;
        // From the System.Numerics library. Seems like this is easier than having separate coordinate properties. The library contains
        // some functionality we would otherwise have to code ourselves.
        // Could add encapsulation to make sure Vector2 values cannot be out of bounds of the XAML canvas.
        // 23.3 Encapsulation added.

        private Vector2 center;

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

        // Encapsulating the Vector2 attribute. Seems like "UnitX.ToPoint().X" is the numeric value of the X-coordinate in the Vector2 struct. This public attribute
        // prevents the Vector2 coordinates of the center attribute from being less than 0 or more than 600 (Y) or 800 (X).
        // This is what I'm currently assuming the size of the canvas is, but that can be changed.
        public Vector2 Center
        {
            get { return center; }
            set
            {
                if (Vector2.UnitX.ToPoint().X >= 0 & Vector2.UnitX.ToPoint().X <= 800 & Vector2.UnitY.ToPoint().Y >= 0 & Vector2.UnitY.ToPoint().Y <= 600)
                {
                    center = value;
                }
            }
        }

        // Collision math. Basically, if the distance between the centers of the circles is smaller
        // than the difference between radii, the circles necessarily intersect.
        // It's a bool, so it returns a true/false value. So if this method returns true,
        // we can have that trigger collision mechanics.
        // http://rbwhitaker.wikidot.com/circle-collision-detection
        // Object1.Collision(Object2)
        // Revised collision math.
        public bool Collision(CollisionObject collisionObject)
        {
            return (Math.Abs((collisionObject.Center - Center).Length()) <= (collisionObject.radius + radius));
        }

        // Placeholder.
        public abstract void move();

    }
}
