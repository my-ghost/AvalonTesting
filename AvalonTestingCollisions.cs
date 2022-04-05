﻿using Microsoft.Xna.Framework;
using Terraria;

namespace AvalonTesting;

public class AvalonTestingCollisions
{
    public static bool TouchingTile(Vector2 Position, int Width, int Height)
    {
        int num = (int)(Position.X / 16f) - 1;
        int num2 = (int)((Position.X + (float)Width) / 16f) + 2;
        int num3 = (int)(Position.Y / 16f) - 1;
        int num4 = (int)((Position.Y + (float)Height) / 16f) + 4;
        if (num < 0)
        {
            num = 0;
        }
        if (num2 > Main.maxTilesX)
        {
            num2 = Main.maxTilesX;
        }
        if (num3 < 0)
        {
            num3 = 0;
        }
        if (num4 > Main.maxTilesY)
        {
            num4 = Main.maxTilesY;
        }
        for (int i = num; i < num2; i++)
        {
            for (int j = num3; j < num4; j++)
            {
                if (Main.tile[i, j] != null && !Main.tile[i, j].IsActuated && Main.tile[i, j].HasTile && Main.tileSolid[(int)Main.tile[i, j].TileType] && !Main.tileSolidTop[(int)Main.tile[i, j].TileType])
                {
                    Vector2 vector;
                    vector.X = (float)(i * 16);
                    vector.Y = (float)(j * 16);
                    int num5 = 16;
                    if (Main.tile[i, j].IsHalfBlock)
                    {
                        vector.Y += 8f;
                        num5 -= 8;
                    }
                    if (Position.Y + (float)Height >= vector.Y)
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }
}
