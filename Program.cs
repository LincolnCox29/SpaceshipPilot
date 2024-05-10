using Microsoft.Toolkit.HighPerformance;
using Raylib_CsLo;
using System.Numerics;

namespace SpaceshipPilot
{
    class Game
    {
        static List<Bullet> bullets = new List<Bullet>();
        static Background bg = new Background();
        static Ship ship = new Ship();

        static float timeBetweenShots = 0.5f;
        static float elapsedTimeSinceShot = 0f;

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
            UpdateBullets();
            CheckingShootingCapability();
            ship.Animation();
            ship.Move();
            bg.setPosition();
        }

        private static void Draw() 
        {
            Raylib.BeginDrawing();
            Raylib.DrawTextureRec(bg.background, bg.Rectangle, new System.Numerics.Vector2(0, 0), new Color(255, 255, 255, 255));
            Raylib.DrawTextureV(ship.currentFrame(), ship.position, new Color(255, 255, 255, 255));
            DrawBullets();
            Raylib.EndDrawing();
        }

        private static void CheckingShootingCapability()
        {
            elapsedTimeSinceShot += Raylib.GetFrameTime();

            if (elapsedTimeSinceShot >= timeBetweenShots)
            {
                bullets.Add(
                    new Bullet(new Vector2(ship.position.X + 20, ship.position.Y), new Vector2(0, -7)));
                bullets.Add(
                    new Bullet(new Vector2(ship.position.X + 60, ship.position.Y), new Vector2(0, -7)));

                elapsedTimeSinceShot = 0f;
            }
        }

        private static void UpdateBullets() 
        {
            foreach (Bullet bullet in bullets)
            {
                bullet.Update();
            }
        }

        private static void DrawBullets() 
        {
            foreach (Bullet bullet in bullets)
            {
                if (bullet.IsActive)
                {
                    Raylib.DrawCircleV(bullet.Position, 2, new Color(229, 190, 1, 255));
                }
            }
        }
    }
}