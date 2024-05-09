using Raylib_CsLo;

namespace SpaceshipPilot
{
    class Game
    {
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
            ship.frameChanging();
            ship.Move();
            bg.setPosition();
        }

        private static void Draw() 
        {
            Raylib.BeginDrawing();
            Raylib.DrawTextureRec(bg.background, bg.Rectangle, new System.Numerics.Vector2(0, 0), new Color(255, 255, 255, 255));
            Raylib.DrawTextureV(ship.currentFrame(), ship.position, new Color(255, 255, 255, 255));
            Raylib.EndDrawing();
        }
    }
}