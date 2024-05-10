using Raylib_CsLo;
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

        public Asteroid(Vector2 position, Vector2 velocity, Color color)
        {
            Position = position;
            Velocity = velocity;
            Color = color;
        }

        public void Update()
        {
            Position += Velocity;
        }
    }
}