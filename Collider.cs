using Raylib_CsLo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SpaceshipPilot
{
    public class Collider
    {
        public Vector2 position;
        private float width;
        private float height;

        public Collider(float scale, Vector2 textureSize, Vector2 _position)
        { 

            width = textureSize.X * scale;
            height = textureSize.Y * scale;
            position = _position;
        }

        public bool CheckCollision(Collider other)
            => position.X < other.position.X + other.width &&
               position.X + width > other.position.X &&
               position.Y < other.position.Y + other.height &&
               position.Y + height > other.position.Y;

        public void Update(Vector2 parentPosition)
        {
            position = parentPosition;
        }
    }
}