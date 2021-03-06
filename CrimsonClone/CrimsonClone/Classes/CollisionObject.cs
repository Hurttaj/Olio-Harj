﻿/*
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
    /// <summary>
    /// This is the master class for all colision objects (player, enemies, projectiles)
    /// The class used to be abstract to prevent objects of it to be created, but it caused issues and thus was abandoned
    /// </summary>
    public /*abstract*/ class CollisionObject
    {
        /// <summary>
        /// speed and radius properties. Marked private so I can exclude negative values.
        /// Theoretically using unsigned doubles would also work, but it would probably crash the game if these properties got a negative value.
        /// </summary>
        private double speed = 0;
        private double radius;

        // From the System.Numerics library. Seems like this is easier than having separate coordinate properties. The library contains
        // some functionality we would otherwise have to code ourselves.
        // Could add encapsulation to make sure Vector2 values cannot be out of bounds of the XAML canvas.
        // 23.3 Encapsulation added.
        
        // 29.3 Disregard previous. Vector2 and the numerics library abandoned for being annoying.

        /// position
        private float positionY;
        private float positionX;

        /// This just throws an exception if you try to give the speed property a negative value.
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

        /// Same as previous except for the radius property. The code is copypasted.
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
     
        /// Property for Y-coordinate
        // Their possible positions are vo
        public float PositionY
        {
            get { return positionY; }
            set
            {
                /// Limits for coordinate attributes. This ensures no object can leave the canvas.
                if (value <= 600 - 2 * radius && value >= 0) positionY = value;
                else if (value >= 600 - 2 * radius) positionY = 600 - 2 * (float)radius;
                else if (value <= 0) positionY = 0;
                /*else throw new System.ArgumentException("Object outside canvas.");*/
            }
        }

        /// Property for X-coordinate
        public float PositionX
        {
            get { return positionX; }
            set
            {
                /// Limits for coordinate attributes. This ensures no object can leave the canvas.
                if (value <= 800 - 2 * radius && value >= 0) positionX = value;
                else if (value >= 800 - 2 * radius) positionX = 800 - 2 * (float)radius;
                else if (value <= 0) positionX = 0;
                /*else throw new System.ArgumentException("Object outside canvas.");*/
            }
        }

        /// Collision math. Basically, if the distance between the centers of the circles is smaller
        /// than the difference between radius, the circles necessarily intersect.
        /// It's a bool, so it returns a true/false value. So if this method returns true,
        /// we can have that trigger collision mechanics.
        /// http://rbwhitaker.wikidot.com/circle-collision-detection
        /// Object1.Collision(Object2)
        // Revised collision math.
        // Revised again for x and y coordinates based code.
        // Math.Pow is a method that raises a given value to a power.
        // Moved to game page
        // Moved again to enemy page
        public bool Collision(CollisionObject collisionObject)
        {
            return (Math.Pow(((positionX + radius) - (collisionObject.positionX + collisionObject.radius)), 2) + Math.Pow(((positionY + radius) - (collisionObject.positionY + collisionObject.radius)), 2) <= Math.Pow((radius + collisionObject.radius), 2));

        }

        // Placeholder.
        /*
        public void Move()
        { }
        */
        
        // public abstract void Move();

    }
}
