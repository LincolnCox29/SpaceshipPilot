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

        private Texture texture;

        Random random = new Random();

        private Color[] ColorsList = new Color[8]
        {
            new Color(229, 190, 1, 255),
            new Color(79, 79, 79, 255),
            new Color(83, 75, 79, 255),
            new Color(65, 74, 76, 255),
            new Color(282, 100, 24, 255), 
            new Color(11, 88, 31, 255),
            new Color(19, 72, 63, 255),
            new Color(116, 55, 12, 255)
        };

        public AsteroidMenager()
        {
            asteroids = new List<Asteroid>();
            texture = Raylib.LoadTexture("assets/asteroid.png");
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

        public void AddNewAsteroid(Vector2 position, Vector2 velocity, Color color) => asteroids.Add(new Asteroid(position, velocity, color));

        public void Draw()
        {
            foreach (Asteroid asteroid in asteroids)
            {
                Raylib.DrawTextureV(texture, asteroid.Position, asteroid.Color);
            }
        }

        private void SpawnAsteroids()
        {
            elapsedTimeSpawn += Raylib.GetFrameTime();

            if (elapsedTimeSpawn >= timeBetweenSpawn)
            {
                int ySpeed = random.Next(1, 4);

                Color rndCollor = ColorsList[random.Next(0, ColorsList.Length)];

                AddNewAsteroid(new Vector2(random.Next(40,360) + 20, - 100), new Vector2(0, ySpeed), rndCollor);

                elapsedTimeSpawn = 0f;

                timeBetweenSpawn = random.Next(1,7);
            }
        }
    }
}