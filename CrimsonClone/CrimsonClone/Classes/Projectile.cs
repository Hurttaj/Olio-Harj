﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrimsonClone.Classes
{
    public class Projectile : CollisionObject
    {
        public readonly float MaxSpeed = 30;

        public Projectile(double radius, float positionX, float positionY, float CursorX, float CursorY)
        {
            Radius = radius;
            PositionX = positionX;
            PositionY = positionY;
        }

        public void Move(float dirX, float dirY)
        {
          
        }

        /*public override void Move(int dirX, int dirY)
        {
            throw new NotImplementedException();
        }*/
    }
}