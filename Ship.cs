using Raylib_CsLo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SpaceshipPilot
{
    internal class Ship
    {
        private int animFrameCounter = 0;
        private int animFrameTime = 10;

        private List<Texture> animation;
        private int _currentFrame = 0;

        public Vector2 position;

        private float timeBetweenShots = 0.5f;
        private float elapsedTimeSinceShot = 0f;

        public Ship()
        {
            animation = new List<Texture>()
            {
                Raylib.LoadTexture("assets/space_ship1.png"),
                Raylib.LoadTexture("assets/space_ship2.png")
            };
            position = new Vector2(170, 700);
        }

        public void Animation()
        {
            animFrameCounter++;
            if (animFrameCounter >= animFrameTime)
            {
                animFrameCounter = 0;
                _currentFrame = (_currentFrame + 1) % animation.Count;
            }
        }

        public void CheckingShootingCapability(BulletMenager bulletMenager)
        {
            elapsedTimeSinceShot += Raylib.GetFrameTime();

            if (elapsedTimeSinceShot >= timeBetweenShots)
            {
                bulletMenager.AddNewBullet(new Vector2(position.X + 20, position.Y), new Vector2(0, -7));
                bulletMenager.AddNewBullet(new Vector2(position.X + 60, position.Y), new Vector2(0, -7));

                elapsedTimeSinceShot = 0f;
            }
        }

        public Texture currentFrame() => animation[_currentFrame];

        public void Move()
        {
            float speed = 2f;
            float diagonalSpeed = (float)Math.Sqrt(speed * speed / 2);

            if (Raylib.IsKeyDown(KeyboardKey.KEY_W) && Raylib.IsKeyDown(KeyboardKey.KEY_D))
            {
                position.X += diagonalSpeed;
                position.Y -= diagonalSpeed;
            }
            else if (Raylib.IsKeyDown(KeyboardKey.KEY_W) && Raylib.IsKeyDown(KeyboardKey.KEY_A))
            {
                position.X -= diagonalSpeed;
                position.Y -= diagonalSpeed;
            }
            else if (Raylib.IsKeyDown(KeyboardKey.KEY_S) && Raylib.IsKeyDown(KeyboardKey.KEY_A))
            {
                position.X -= diagonalSpeed;
                position.Y += diagonalSpeed;
            }
            else if (Raylib.IsKeyDown(KeyboardKey.KEY_S) && Raylib.IsKeyDown(KeyboardKey.KEY_D))
            {
                position.X += diagonalSpeed;
                position.Y += diagonalSpeed;
            }
            else if (Raylib.IsKeyDown(KeyboardKey.KEY_W))
            {
                position.Y -= speed;
            }
            else if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
            {
                position.X -= speed;
            }
            else if (Raylib.IsKeyDown(KeyboardKey.KEY_S))
            {
                position.Y += speed;
            }
            else if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
            {
                position.X += speed;
            }
        }
    }
}
