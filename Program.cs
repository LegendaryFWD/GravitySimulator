using Raylib_cs;
using planet;
using System.Numerics;

namespace HelloWorld
{
    static class Program
    {
        static Planet plnt1 = new Planet(1, new Vector2(250,100), new Vector2(5.5f,0));
        static Planet plnt2 = new Planet(7500, new Vector2(250,250), new Vector2(0,0));

        const float G = 6.674e-1f;
        
        public static void Main()
        {
            Raylib.InitWindow(500, 500, "S0L4R SYSTEM");
            Raylib.SetTargetFPS(60);

            while (!Raylib.WindowShouldClose())
            {
                Update();
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.BLACK);
                Raylib.DrawCircle((int)plnt1.pos.X, (int)plnt1.pos.Y, 10, Color.BLUE);
                Raylib.DrawCircle((int)plnt2.pos.X, (int)plnt2.pos.Y, 75, Color.RED);
                Raylib.EndDrawing();
            }

            Raylib.CloseWindow();
        }
        
        public static void Update(){
            Vector2 dir = Vector2.Subtract(plnt2.pos, plnt1.pos);
            float dist = dir.Length();
            Vector2 forceDir = Vector2.Normalize(dir);
            float ForceMag = G * ((plnt1.mass * plnt2.mass) / (dist * dist));
            Vector2 Force = Vector2.Multiply(forceDir, ForceMag);

            Vector2 acc1 = Vector2.Divide(Force, plnt1.mass);
            Vector2 acc2 = Vector2.Divide(Force, plnt2.mass);

            plnt1.velocity = Vector2.Add(plnt1.velocity, acc1);
            plnt2.velocity = Vector2.Add(plnt2.velocity, acc2);

            plnt1.pos = Vector2.Add(plnt1.pos, plnt1.velocity);
            plnt2.pos = Vector2.Add(plnt2.pos, plnt2.velocity);

            Console.WriteLine(dist);
        }
    }
}