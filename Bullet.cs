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
        public bool IsActive;

        public Bullet(Vector2 position, Vector2 velocity)
        {
            Position = position;
            Velocity = velocity;
            IsActive = true;
        }

        public void Update()
        {
            if (IsActive)
            {
                Position += Velocity;
            }
        }
    }
}
