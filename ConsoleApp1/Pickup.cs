using System;
using System.Collections.Generic;
using System.Text;
using Raylib;
using rl = Raylib.Raylib;

namespace ConsoleApp1
{
    class Pickup
    {
        public Vector2Int position = new Vector2Int();
        public Color myColor = Color.GOLD;
        public bool enabled = true;
        public Texture2D tex;
        public void Draw()
        {
            if (!enabled)
                return;
            rl.DrawTextureEx(tex, new Vector2(position.x - (tex.width / 2), position.y - (tex.height / 2)), 0f, 1f, Color.WHITE);
        }
    }
}
