using System;
using System.Collections.Generic;
using System.Text;
using Raylib;
using rl = Raylib.Raylib;


namespace ConsoleApp1
{
    static class Program
    {
        public static Random rnd = new Random();
        public static bool CheckCollisionV1(Player _p1, Pickup _pu)
        {
            bool rtn = false;
            Rectangle PickupTest = new Rectangle(_pu.position.x - 10, _pu.position.y - 10, 20, 20);
            Rectangle PlayerTest = new Rectangle(_p1.position.x - 10, _p1.position.y - 10, 20, 20);
            rtn = rl.CheckCollisionRecs(PlayerTest, PickupTest);
            if (rtn)
                _pu.enabled = false;
            return rtn;
        }
        public static int Main()
        {
            // Initialization
            //--------------------------------------------------------------------------------------
            int screenWidth = 800;//1280;
            int screenHeight = 450;//720;
            Player myPlayer = new Player();
            Pickup[] myPickup = new Pickup[10];
            int idx = 0;
            int score = 0;
            int timer = 600;
            for (int x = 100; x < 700&& idx < 10; x += 40)
            {
                myPickup[idx] = new Pickup();
                myPickup[idx].position.x = x + (rnd.Next(0,50) - 25);
                myPickup[idx].position.y = 150 +  (rnd.Next(0, 100) - 50);
                idx++;
            }
            myPlayer.position.x = 75;
            myPlayer.position.y = 75;
            rl.InitWindow(screenWidth, screenHeight, "raylib [core] example - basic window");

            rl.SetTargetFPS(60);
            //--------------------------------------------------------------------------------------
            Texture2D frog1 = rl.LoadTexture("frog.png");
            Texture2D frog2 = rl.LoadTexture("frog_leap.png");
            Texture2D frog3 = rl.LoadTexture("frog_dead.png");
            string[] gemTex = new string[4]
            {
                "Resources/items/platformPack_item001.png",
                "Resources/items/platformPack_item002.png",
                "Resources/items/platformPack_item003.png",
                "Resources/items/platformPack_item004.png"
            };
            Texture2D[] test = new Texture2D[8]
                {
                    rl.LoadTexture("Resources/items/platformPack_item001.png"),
                    rl.LoadTexture("Resources/items/platformPack_item001.png"),
                    rl.LoadTexture("Resources/items/platformPack_item002.png"),
                    rl.LoadTexture("Resources/items/platformPack_item002.png"),
                    rl.LoadTexture("Resources/items/platformPack_item003.png"),
                    rl.LoadTexture("Resources/items/platformPack_item003.png"),
                    rl.LoadTexture("Resources/items/platformPack_item004.png"),
                    rl.LoadTexture("Resources/items/platformPack_item004.png")
                };
            int g = 0;
            // Main game loop
            while (!rl.WindowShouldClose())    // Detect window close button or ESC key
            {
                // Update
                //----------------------------------------------------------------------------------
                // TODO: Update your variables here
                //----------------------------------------------------------------------------------
                if (score < 10 && timer > 0)
                {
                    myPlayer.RunUpdate();
                    timer--;
                }
                g++;
                if (g >= 8) g = 0;
                //myPlayer.rot += 12;
                // Draw
                //----------------------------------------------------------------------------------
                rl.BeginDrawing();
                rl.DrawText(g.ToString(), 50, 100, 1, Color.RAYWHITE);
                rl.ClearBackground(Color.SKYBLUE);
                //myPlayer.Draw();
                if (score < 10 && timer > 0)
                {
                    myPlayer.tex = frog1;
                    myPlayer.Draw();
                }
                else
                {
                    if (score == 10) myPlayer.tex = frog2; myPlayer.Draw();
                    if (timer <=10) myPlayer.tex = frog3; myPlayer.Draw();
                }
                
                foreach (Pickup pickup in myPickup)
                {
                    if (pickup.enabled)
                    {
                        pickup.tex = test[g];
                        pickup.Draw();
                        score += CheckCollisionV1(myPlayer, pickup) ? 1 : 0;
                    }
                    if (score == 10)
                    {
                        rl.DrawText("Bro nice job... ;)", 50, 100, 1,Color.RAYWHITE);
                        rl.ClearBackground(Color.PINK);
                    }
                }
                    rl.DrawText("Time : " + (timer / 60), 320, 0, 20, Color.RAYWHITE);
                    rl.DrawText("Score : " + score, 320, 400, 20, Color.RAYWHITE);
                //Console.WriteLine("buh:" + rl.CheckCollisionRecs(PlayerTest, PickupTest).ToString());
                if (timer <= 0)
                {
                    rl.ClearBackground(Color.RED);
                    rl.DrawText("Certified Bruh Moment", 40, 100, 64, Color.RAYWHITE);
                    //rl.CloseWindow();
                }
                rl.EndDrawing();
                //----------------------------------------------------------------------------------
            }

            // De-Initialization
            //--------------------------------------------------------------------------------------
            rl.CloseWindow();        // Close window and OpenGL context
                                     //--------------------------------------------------------------------------------------

            return 0;
        }
    }
}