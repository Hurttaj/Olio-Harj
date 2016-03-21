using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class CollisionObject
    {
        double speed;
        double radius;
        int xPosition;
        int yPosition;

        public double Speed
        {   get
            { return speed; }
            set
            {
                if (value >= 0) speed = value;
                else throw new System.ArgumentException("Cannot be negatve."); }
        }

        public double Radius
        {
            get
            { return speed; }
            set
            {
                if (value >= 0) radius = value;
                else throw new System.ArgumentException("Cannot be negatve.");
            }
        }

        public void Collision(CollisionObject, CollisionObject)
        {
            Console.WriteLine("Do something!");
        }

        public void move()
        {
            Console.WriteLine("Do something!");
        }

    }
}
