using Raylib_CsLo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SpaceshipPilot
{
    class AsteroidMenager
    {
        private List<Asteroid> asteroids;

        private float timeBetweenSpawn = 5f;
        private float elapsedTimeSpawn = 0f;

        Random random = new Random();

        public AsteroidMenager()
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

        public void AddNewAsteroid(Vector2 position, Vector2 velocity, Texture texture)
            => asteroids.Add(new Asteroid(position, velocity, texture));

        public void Draw()
        {
            foreach (Asteroid asteroid in asteroids)
            {
                Raylib.DrawTextureV(asteroid.Texture, asteroid.Position, asteroid.Color);
            }
        }

        private void SpawnAsteroids()
        {
            elapsedTimeSpawn += Raylib.GetFrameTime();

            if (elapsedTimeSpawn >= timeBetweenSpawn)
            {
                int ySpeed = random.Next(1, 4);

                Texture rndTexture = Raylib.LoadTexture(Game.PickRandomFile("assets/asteroids"));

                AddNewAsteroid(new Vector2(random.Next(40,360) + 20, - 100), new Vector2(0, ySpeed), rndTexture);

                elapsedTimeSpawn = 0f;

                timeBetweenSpawn = random.Next(1,7);
            }
        }
    }
}