﻿using Raylib_CsLo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SpaceshipPilot
{
    public class Bullet
    {
        public Vector2 Position;
        public Vector2 Velocity;

        public Bullet(Vector2 position, Vector2 velocity)
        {
            Position = position;
            Velocity = velocity;
        }

        public void Update()
        {
            Position += Velocity;
        }
    }
}
