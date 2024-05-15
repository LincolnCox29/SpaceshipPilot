using Raylib_CsLo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SpaceshipPilot
{
    class Asteroid
    {
        public Vector2 Position;
        public Vector2 Speed;

        public float rotationSpeed;
        public float rotation;

        public Color Color;
        public Texture Texture;

        public int hp;
        private string size;

        public Collider Collider;

        public float renderScale;

        Random random = new Random();

        public Asteroid(Vector2 position)
        {
            renderScale = 2f;
            Position = position;
            RandomSize();
            Texture = RandomTexture(size);
            Collider = new Collider(
                                    renderScale, 
                                    new Vector2(Texture.width, Texture.height),
                                    position);
            Speed = RandomSpeed();
            Color = new Color(255, 255, 255, 255);
            rotationSpeed = RandomRotation();
        }

        public void Update()
        {
            Position += Speed;
            rotation += rotationSpeed;
            Collider.Update(Position);
        }

        public void Damage(int damage, AsteroidManager asteroidMenager)
        {
            hp -= damage;
            if (hp <= 0)
            {
                asteroidMenager.asteroids.Remove(this);
            }
        }

        private Texture RandomTexture(string size)
        {
            return Raylib.LoadTexture(Game.PickRandomFile("assets/asteroids/", size));
        }

        private void RandomSize() 
        {
            switch (random.Next(1, 3))
            {
                case 1:
                    size = "little";
                    hp = 2;
                    break;
                case 2:
                    size = "normal";
                    hp = 3;
                    break;
                case 3:
                    size = "big";
                    hp = 4;
                    break;
            }
        }

        private float RandomRotation() => random.Next(-5, 5) * 0.01f;

        private Vector2 RandomSpeed() => new Vector2(0, random.Next(1, 4));
    }
}