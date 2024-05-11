﻿using Raylib_CsLo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SpaceshipPilot
{
    class Asteroid
    {
        public Vector2 Position;
        public Vector2 Velocity;
        public Color Color;

        public Texture Texture;

        public Asteroid(Vector2 position, Vector2 velocity, Texture texture)
        {
            Position = position;
            Velocity = velocity;
            Color = new Color(255, 255, 255, 255);
            Texture = texture;
        }

        public void Update()
        {
            Position += Velocity;
        }
    }
}