using Microsoft.Toolkit.HighPerformance;
using Raylib_CsLo;
using System.Numerics;

namespace SpaceshipPilot
{
    class Game
    {
        static BulletMenager bulletMenager = new BulletMenager();
        static AsteroidMenager asteroidMenager = new AsteroidMenager();
        static Background bg = new Background();
        static Ship ship = new Ship();

        private static void Main(string[] args)
        {
            Raylib.InitWindow(400, 800, "Spaceship Pilot");

            Raylib.SetTargetFPS(144);

            GameLoop();
        }

        private static void GameLoop()
        {
            while (!Raylib.WindowShouldClose())
            {
                Update();
                Draw();
            }
            Raylib.CloseWindow();
        }

        private static void Update()
        {
            bulletMenager.Update();
            asteroidMenager.Update();
            ship.CheckingShootingCapability(bulletMenager);
            ship.Animation();
            ship.Move();
            bg.setPosition();
        }

        private static void Draw() 
        {
            Raylib.BeginDrawing();
            Raylib.DrawTextureRec(bg.background, bg.Rectangle, new Vector2(0, 0), new Color(255, 255, 255, 255));
            Raylib.DrawTextureV(ship.currentFrame(), ship.position, new Color(255, 255, 255, 255));
            asteroidMenager.Draw();
            bulletMenager.Draw();
            Raylib.EndDrawing();
        }
    }
}