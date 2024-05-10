using Raylib_CsLo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SpaceshipPilot
{
    class BulletMenager
    {
        private List<Bullet> bullets;

        public BulletMenager()
        {
            bullets = new List<Bullet>();
        }

        public void Update()
        {
            for(int i = 0; i < bullets.Count; i++)
            {
                if (bullets[i].Position.Y < 0)
                {
                    bullets.RemoveAt(i);
                    i--;
                    continue;
                }
                bullets[i].Update();
            }
        }

        public void AddNewBullet(Vector2 position, Vector2 velocity) => bullets.Add(new Bullet(position, velocity));

        public void Draw()
        {
            foreach (Bullet bullet in bullets)
            {
                Raylib.DrawCircleV(bullet.Position, 2, new Color(229, 190, 1, 255));
            }
        }
    }
}
