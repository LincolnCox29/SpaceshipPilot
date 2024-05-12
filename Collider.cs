using Raylib_CsLo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SpaceshipPilot
{
    class Collider
    {
        private Vector2 position;
        private float width;
        private float height;

        public Collider(float scale, float _width, float _height, Vector2 _position) 
        { 

            width = _width * scale;
            height = _height * scale;
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