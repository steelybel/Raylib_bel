using System;
using System.Collections.Generic;
using System.Text;
using Raylib;
using rl = Raylib.Raylib;

namespace ConsoleApp1
{
    struct Vector2Int
    {
        public int x;
        public int y;
    }
    class Player
    {
        public Texture2D tex;
        public Vector2Int position = new Vector2Int();
        public Color myColor = Color.GOLD;
        public Color eyeColor = Color.BLACK;
        public Color eyeColor2 = Color.RAYWHITE;
        public Color moufColor = Color.BLACK;
        public Color tongColor = Color.RED;
        public Color tearColor = Color.SKYBLUE;
        public float rot = 0f;
        public void RunUpdate()
        {
            if(rl.IsKeyDown(KeyboardKey.KEY_W))
            {
                position.y--;
            }
            if (rl.IsKeyDown(KeyboardKey.KEY_S))
            {
                position.y++;
            }
            if (rl.IsKeyDown(KeyboardKey.KEY_A))
            {
                position.x--;
            }
            if (rl.IsKeyDown(KeyboardKey.KEY_D))
            {
                position.x++;
            }
        }
        public void Draw()
        {
            rl.DrawTextureEx(tex, new Vector2(position.x - (tex.width / 2), position.y - (tex.height / 2)), rot,1f,Color.WHITE);
        }
        public void DrawOld()
        {
            /*rl.DrawCircle(position.x, position.y, 15f, myColor);
            rl.DrawCircle(position.x-4, position.y-3, 3f, eyeColor);
            rl.DrawCircle(position.x+4, position.y-3, 3f, eyeColor);
            rl.DrawCircle(position.x, position.y+6, 5f, moufColor);
            rl.DrawCircle(position.x, position.y+8, 3f, tongColor);*/
            rl.DrawCircle(position.x, position.y, 15f, myColor);//base
            rl.DrawCircle(position.x + 7, position.y + 2, 6f, eyeColor2);//eye base
            rl.DrawLine(position.x + 6, position.y - 4, position.x + 3, position.y - 7, eyeColor);//brow
            rl.DrawCircle(position.x + 5, position.y, 4f, eyeColor);//pupil
            rl.DrawCircle(position.x + 7, position.y - 1, 1f, eyeColor2);//shine
            rl.DrawCircle(position.x + 4, position.y + 1, 1f, eyeColor2);//shine
            rl.DrawCircle(position.x - 5, position.y + 1, 6f, eyeColor2);
            rl.DrawLine(position.x - 5, position.y - 6, position.x - 1, position.y - 9, eyeColor);
            rl.DrawCircle(position.x - 4, position.y - 1, 4f, eyeColor);
            rl.DrawCircle(position.x - 2, position.y - 2, 1f, eyeColor2);
            rl.DrawCircle(position.x - 5, position.y, 1f, eyeColor2);//shine

        }
        public void DrawWin()
        {
            rl.DrawCircle(position.x, position.y, 15f, myColor);
            rl.DrawCircle(position.x - 4, position.y - 3, 3f, eyeColor);
            rl.DrawCircle(position.x + 4, position.y - 3, 3f, eyeColor);
            rl.DrawCircle(position.x, position.y + 8, 2f, moufColor);
            rl.DrawCircle(position.x - 3, position.y + 7, 2f, moufColor);
            rl.DrawCircle(position.x + 3, position.y + 7, 2f, moufColor);
            rl.DrawCircle(position.x - 5, position.y + 5, 2f, moufColor);
            rl.DrawCircle(position.x + 5, position.y + 5, 2f, moufColor);

        }
        public void DrawLose()
        {
            rl.DrawCircle(position.x, position.y, 15f, myColor);//base
            rl.DrawLine(position.x - 8, position.y - 9, position.x - 5, position.y - 11,eyeColor);//LEFT
            rl.DrawLine(position.x - 5, position.y - 11, position.x - 2, position.y - 9, eyeColor);
            rl.DrawCircle(position.x - 10, position.y - 8, 2f, tearColor);
            rl.DrawLine(position.x + 8, position.y - 9, position.x + 5, position.y - 11, eyeColor);//RIGHT
            rl.DrawLine(position.x + 5, position.y - 11, position.x + 2, position.y - 9, eyeColor);
            rl.DrawCircle(position.x + 10, position.y - 8, 2f, tearColor);
            rl.DrawCircle(position.x - 1, position.y + 1, 9f,moufColor);
            rl.DrawCircle(position.x - 1, position.y + 4, 9f,moufColor);
            rl.DrawCircle(position.x + 3, position.y + 5, 8f,moufColor);
            rl.DrawCircle(position.x, position.y + 10, 3f, tongColor);
            rl.DrawCircle(position.x+3, position.y + 6, 3f, tongColor);
            rl.DrawCircle(position.x+2, position.y + 3, 2f, tongColor);
            rl.DrawCircle(position.x, position.y - 1, 2f, tongColor);
        }
    }
}
