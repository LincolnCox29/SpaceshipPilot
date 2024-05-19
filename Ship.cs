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

        private int hp;

        public Collider Collider;

        public Vector2 position;

        private float timeBetweenShots = 0.5f;
        private float elapsedTimeSinceShot = 0f;

        public Ship()
        {
            hp = 10;
            animation = new List<Texture>()
            {
                Raylib.LoadTexture("assets/space_ship1.png"),
                Raylib.LoadTexture("assets/space_ship2.png")
            };
            position = new Vector2(170, 700);
            Collider = new Collider(
                                    1f,
                                    new Vector2(animation[_currentFrame].width, animation[_currentFrame].height),
                                    position);
        }

        public void Update(BulletManager bulletMenager, AsteroidManager asteroidMenager)
        {
            CheckingShootingCapability(bulletMenager);
            Animation();
            Move();
            Collider.Update(position);
            Collision(asteroidMenager);
        }

        public Texture currentFrame() => animation[_currentFrame];

        private void Collision(AsteroidManager asteroidMenager)
        {
            for (int a = 0; a < asteroidMenager.asteroids.Count; a++)
            {
                if (Collider.CheckCollision(asteroidMenager.asteroids[a].Collider))
                {
                    Console.WriteLine($"Collision detected with asteroid {a}");
                    int AsteroidHP = asteroidMenager.asteroids[a].hp;
                    Damage(AsteroidHP);
                    asteroidMenager.asteroids[a].Damage(AsteroidHP, asteroidMenager);
                    a--;
                }
            }
        }

        private void Animation()
        {
            animFrameCounter++;
            if (animFrameCounter >= animFrameTime)
            {
                animFrameCounter = 0;
                _currentFrame = (_currentFrame + 1) % animation.Count;
            }
        }

        private void CheckingShootingCapability(BulletManager bulletMenager)
        {
            elapsedTimeSinceShot += Raylib.GetFrameTime();

            if (elapsedTimeSinceShot >= timeBetweenShots)
            {
                bulletMenager.AddNewBullet(new Vector2(position.X, position.Y), new Vector2(0, -7));
                bulletMenager.AddNewBullet(new Vector2(position.X + 40, position.Y), new Vector2(0, -7));

                elapsedTimeSinceShot = 0f;
            }
        }

        private void Move()
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
                position.Y -= speed;
            
            else if (Raylib.IsKeyDown(KeyboardKey.KEY_A))           
                position.X -= speed;
            
            else if (Raylib.IsKeyDown(KeyboardKey.KEY_S))          
                position.Y += speed;
            
            else if (Raylib.IsKeyDown(KeyboardKey.KEY_D))        
                position.X += speed;
            
            CheckingBounds();
        }

        private void Damage(int damage)
        {
            hp -= damage;
            if (hp <= 0)
            {
                Raylib.CloseWindow();
            }
        }

        private void CheckingBounds()
        {
            if (position.X < -10)
                position.X = -10;

            if (position.X > 330)
                position.X = 330;

            if (position.Y < -10)
                position.Y = -10;

            if (position.Y > 730)
                position.Y = 730;
        }
    }
}