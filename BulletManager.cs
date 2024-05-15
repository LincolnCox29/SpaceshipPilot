using Raylib_CsLo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SpaceshipPilot
{
    class BulletManager
    {
        private List<Bullet> bullets;

        public BulletManager()
        {
            bullets = new List<Bullet>();
        }

        public void Update(AsteroidManager asteroidMenager)
        {
            for (int i = 0; i < bullets.Count; i++)
            {
                if (bullets[i].Position.Y < 0)
                {
                    bullets.RemoveAt(i);
                    i--;
                    continue;
                }

                bullets[i].Update();

                for (int a = 0; a < asteroidMenager.asteroids.Count; a++)
                {
                    if (bullets[i].Collider.CheckCollision(asteroidMenager.asteroids[a].Collider))
                    {
                        asteroidMenager.asteroids[a].Damage(1, asteroidMenager);
                        bullets.RemoveAt(i);
                        i--;
                        break;
                    }
                }
            }
        }

        public void AddNewBullet(Vector2 position, Vector2 velocity) => bullets.Add(new Bullet(position, velocity));

        public void Draw()
        {
            foreach (Bullet bullet in bullets)
            {
                Raylib.DrawRectangleV(bullet.Position, bullet.Size, bullet.Color);
            }
        }
    }
}
