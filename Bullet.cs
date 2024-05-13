using Raylib_CsLo;
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
        public Vector2 Size;
        public Color Color;
        public float Scale;

        public Collider Collider;

        public Bullet(Vector2 position, Vector2 velocity)
        {
            Position = position;
            Velocity = velocity;
            Scale = 1f;
            Color = new Color(229, 190, 1, 255);
            Size = new Vector2(3, 10);
            Collider = new Collider(Scale, Size, position);
        }

        public void Update()
        {
            Position += Velocity;
            Collider.Update(Position);
        }
    }
}
