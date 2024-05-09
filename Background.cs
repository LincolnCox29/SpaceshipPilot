using Raylib_CsLo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceshipPilot
{
    internal class Background
    {
        public Rectangle Rectangle;
        public float Position = 0f;
        public Texture background;

        public Background()
        {
            background = Raylib.LoadTexture("assets/space1.png");
        }

        public void setPosition()
        {
            Position -= 0.3f;
            Rectangle = new Rectangle(0, Position, 400, 800);
        }
    }
}
