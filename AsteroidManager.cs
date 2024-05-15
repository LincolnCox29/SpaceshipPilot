using Raylib_CsLo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SpaceshipPilot
{
    class AsteroidManager
    {
        public List<Asteroid> asteroids;

        private float timeBetweenSpawn = 5f;
        private float elapsedTimeSpawn = 0f;

        Random random = new Random();

        public AsteroidManager()
        {
            asteroids = new List<Asteroid>();
        }

        public void Update()
        {
            SpawnAsteroids();

            for (int i = 0; i < asteroids.Count; i++)
            {
                if (asteroids[i].Position.Y > 800)
                {
                    asteroids.RemoveAt(i);
                    i--;
                    continue;
                }
                asteroids[i].Update();
            }
        }

        public void AddNewAsteroid(Vector2 position)
            => asteroids.Add(new Asteroid(position));

        public void Draw()
        {
            foreach (Asteroid asteroid in asteroids)
            {
                Raylib.DrawTextureEx(asteroid.Texture, asteroid.Position, asteroid.rotation, 2f, asteroid.Color);
            }
        }

        private void SpawnAsteroids()
        {
            elapsedTimeSpawn += Raylib.GetFrameTime();

            if (elapsedTimeSpawn >= timeBetweenSpawn)
            {

                AddNewAsteroid(new Vector2(random.Next(20,360) + 20, - 100));

                elapsedTimeSpawn = 0f;

                timeBetweenSpawn = random.Next(1,7);
            }
        }
    }
}