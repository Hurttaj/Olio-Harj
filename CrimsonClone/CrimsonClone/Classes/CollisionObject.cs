using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace CrimsonClone
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    // Abstract class abandoned for being annoying.
    public /*abstract*/ class CollisionObject
    {
        // speed and radius properties. Marked private so I can exclude negative values.
        // Theoretically using unsigned doubles would also work, but it would probably crash the game if these properties got a negative value.
        private double speed = 0;
        private double radius;
        // From the System.Numerics library. Seems like this is easier than having separate coordinate properties. The library contains
        // some functionality we would otherwise have to code ourselves.
        // Could add encapsulation to make sure Vector2 values cannot be out of bounds of the XAML canvas.
        // 23.3 Encapsulation added.
        
        // 29.3 Disregard previous. Vector2 and the numerics library abandoned for being annoying.

        private float positionY;
        private float positionX;

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

        // Encapsulation for coordinate attributes. This ensures no object can leave the canvas.
        // Their possible positions are vo
        public float PositionY
        {
            get { return positionY; }
            set
            {
                if (value <= 600 - 2 * radius && value >= 0) positionY = value;
                else if (value >= 600 - 2 * radius) positionY = 600 - 2 * (float)radius;
                else if (value <= 0) positionY = 0;
                /*else throw new System.ArgumentException("Object outside canvas.");*/
            }
        }

        public float PositionX
        {
            get { return positionX; }
            set
            {
                if (value <= 800 - 2 * radius && value >= 0) positionX = value;
                else if (value >= 800 - 2 * radius) positionX = 800 - 2 * (float)radius;
                else if (value <= 0) positionX = 0;
                /*else throw new System.ArgumentException("Object outside canvas.");*/
            }
        }

        // Collision math. Basically, if the distance between the centers of the circles is smaller
        // than the difference between radii, the circles necessarily intersect.
        // It's a bool, so it returns a true/false value. So if this method returns true,
        // we can have that trigger collision mechanics.
        // http://rbwhitaker.wikidot.com/circle-collision-detection
        // Object1.Collision(Object2)
        // Revised collision math.
        // Revised again for x and y coordinates based code.
        // Math.Pow is a method that raises a given value to a power.
        public bool Collision(CollisionObject collisionObject)
        {
            return (Math.Pow((positionX - collisionObject.positionX), 2) + Math.Pow((positionY - collisionObject.positionY), 2) <= Math.Pow((radius + collisionObject.radius), 2));

        }

        // Placeholder.
        public void Move()
        { }
        
        // public abstract void Move();

    }
}
