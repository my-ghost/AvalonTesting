using System.Collections.Generic;
using Avalon.Tiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Avalon.World;

class Utils
{
    /// <summary>
    /// Helper method to shift the Sky Fortress to the left/right if there are tiles/liquid/walls in the way.
    /// </summary>
    /// <param name="x">The X coordinate of the Sky Fortress origin point.</param>
    /// <param name="y">The Y coordinate of the Sky Fortress origin point.</param>
    /// <param name="xLength">The width of the Sky Fortress.</param>
    /// <param name="ylength">The height of the Sky Fortress.</param>
    /// <param name="xCoord">The X coordinate of the Sky Fortress origin point, passed in again to be modified (the original X coordinate needs to remain the same I think).</param>
    public static void GetSkyFortressXCoord(int x, int y, int xLength, int ylength, ref int xCoord)
    {
        bool leftSideActive = false;
        bool rightSideActive = false;
        for (int i = y; i < y + ylength; i++)
        {
            if (Main.tile[x, i].HasTile || Main.tile[x, i].LiquidAmount > 0 || Main.tile[x, i].WallType > 0)
            {
                leftSideActive = true;
                break;
            }
        }
        for (int i = y; i < y + ylength; i++)
        {
            if (Main.tile[x + xLength, i].HasTile || Main.tile[x + xLength, i].LiquidAmount > 0 || Main.tile[x + xLength, i].WallType > 0)
            {
                rightSideActive = true;
                break;
            }
        }
        if (leftSideActive || rightSideActive)
        {
            if (xCoord > Main.maxTilesX / 2)
                xCoord--;
            else xCoord++;
            if (xCoord < 100)
            {
                xCoord = 100;
                return;
            }
            if (xCoord > Main.maxTilesX - 100)
            {
                xCoord = Main.maxTilesX - 100;
                return;
            }
            GetSkyFortressXCoord(xCoord, y, xLength, ylength, ref xCoord);
        }
    }

    /// <summary>
    /// Generic version of the Sky Fortress shift method. Does not currently work - will crash the game when used.
    /// </summary>
    /// <param name="x">The X coordinate of the structure's origin point.</param>
    /// <param name="y">The Y coordinate of the structure's origin point.</param>
    /// <param name="xLength">The width of the structure.</param>
    /// <param name="ylength">The height of the structure.</param>
    /// <param name="xCoord">The X coordinate of the structure's origin point, passed in again as ref to be modified.</param>
    /// <param name="typesToCheck">A List of the tile types to shift the structure if found.</param>
    /// <param name="liquid">Whether or not to check for liquids.</param>
    /// <param name="walls">Whether or not to check for walls.</param>
    public static void GetXCoordGeneric(int x, int y, int xLength, int ylength, ref int xCoord, List<int> typesToCheck, bool liquid = true, bool walls = true)
    {
        bool leftSideActive = false;
        bool rightSideActive = false;

        for (int i = y; i < y + ylength; i++)
        {
            if ((Main.tile[x, i].HasTile && typesToCheck.Contains(Main.tile[x, i].TileType)) || (Main.tile[x, i].LiquidAmount > 0 && liquid) || (Main.tile[x, i].WallType > 0 && walls))
            {
                leftSideActive = true;
                break;
            }
        }
        for (int i = y; i < y + ylength; i++)
        {
            if ((Main.tile[x + xLength, i].HasTile && typesToCheck.Contains(Main.tile[x + xLength, i].TileType)) || (Main.tile[x + xLength, i].LiquidAmount > 0 && liquid) || (Main.tile[x + xLength, i].WallType > 0 && walls))
            {
                rightSideActive = true;
                break;
            }
        }
        if (leftSideActive || rightSideActive)
        {
            if (xCoord > Main.maxTilesX / 2)
                xCoord--;
            else
                xCoord++;
            if (xCoord < 100)
            {
                xCoord = 100;
                return;
            }
            if (xCoord > Main.maxTilesX - 100)
            {
                xCoord = Main.maxTilesX - 100;
                return;
            }
            GetXCoordGeneric(xCoord, y, xLength, ylength, ref xCoord, typesToCheck, liquid, walls);
        }
    }

    public static void PlaceHallowedAltar(int x, int y, int style = 0)
    {
        if (x < 5 || x > Main.maxTilesX - 5 || y < 5 || y > Main.maxTilesY - 5)
        {
            return;
        }
        bool placeOrNot = true;
        int num = y - 1;
        for (int i = x - 1; i < x + 2; i++)
        {
            for (int j = num; j < y + 1; j++)
            {
                if (Main.tileCut[Main.tile[i, j].TileType] || Main.tile[i, j].TileType is TileID.SmallPiles or TileID.LargePiles or TileID.LargePiles2 or TileID.Stalactite)
                {
                    WorldGen.KillTile(i, j, noItem: true);
                }
            }
            for (int j2 = num; j2 < y + 1; j2++)
            {
                if (Main.tile[i, j2].HasTile) placeOrNot = false;
            }
        }
        if (placeOrNot)
        {
            short num2 = (short)(54 * style);
            Tile t0 = Main.tile[x - 1, y - 1];
            t0.HasTile = true;
            Main.tile[x - 1, y - 1].TileFrameY = 0;
            Main.tile[x - 1, y - 1].TileFrameX = num2;
            Main.tile[x - 1, y - 1].TileType = (ushort)ModContent.TileType<HallowedAltar>();
            Tile t = Main.tile[x, y - 1];
            t.HasTile = true;
            Main.tile[x, y - 1].TileFrameY = 0;
            Main.tile[x, y - 1].TileFrameX = (short)(num2 + 18);
            Main.tile[x, y - 1].TileType = (ushort)ModContent.TileType<HallowedAltar>();
            Tile t2 = Main.tile[x + 1, y - 1];
            t2.HasTile = true;
            Main.tile[x + 1, y - 1].TileFrameY = 0;
            Main.tile[x + 1, y - 1].TileFrameX = (short)(num2 + 36);
            Main.tile[x + 1, y - 1].TileType = (ushort)ModContent.TileType<HallowedAltar>();
            Tile t3 = Main.tile[x - 1, y];
            t3.HasTile = true;
            Main.tile[x - 1, y].TileFrameY = 18;
            Main.tile[x - 1, y].TileFrameX = num2;
            Main.tile[x - 1, y].TileType = (ushort)ModContent.TileType<HallowedAltar>();
            Tile t4 = Main.tile[x, y];
            t4.HasTile = true;
            Main.tile[x, y].TileFrameY = 18;
            Main.tile[x, y].TileFrameX = (short)(num2 + 18);
            Main.tile[x, y].TileType = (ushort)ModContent.TileType<HallowedAltar>();
            Tile t5 = Main.tile[x + 1, y];
            t5.HasTile = true;
            Main.tile[x + 1, y].TileFrameY = 18;
            Main.tile[x + 1, y].TileFrameX = (short)(num2 + 36);
            Main.tile[x + 1, y].TileType = (ushort)ModContent.TileType<HallowedAltar>();
        }
    }
    public static void ResetSlope(int i, int j)
    {
        Tile t = Main.tile[i, j];
        t.Slope = SlopeType.Solid;
        t.IsHalfBlock = false;
    }
    public static void SquareTileFrame(int i, int j, bool resetFrame = true, bool resetSlope = false, bool largeHerb = false)
    {
        if (resetSlope)
        {
            Tile t = Main.tile[i, j];
            t.Slope = SlopeType.Solid;
            t.IsHalfBlock = false;
        }
        WorldGen.TileFrame(i - 1, j - 1, false, largeHerb);
        WorldGen.TileFrame(i - 1, j, false, largeHerb);
        WorldGen.TileFrame(i - 1, j + 1, false, largeHerb);
        WorldGen.TileFrame(i, j - 1, false, largeHerb);
        WorldGen.TileFrame(i, j, resetFrame, largeHerb);
        WorldGen.TileFrame(i, j + 1, false, largeHerb);
        WorldGen.TileFrame(i + 1, j - 1, false, largeHerb);
        WorldGen.TileFrame(i + 1, j, false, largeHerb);
        WorldGen.TileFrame(i + 1, j + 1, false, largeHerb);
    }
    /// <summary>
    /// A helper method to run WorldGen.SquareTileFrame() over an area.
    /// </summary>
    /// <param name="x">The x coordinate.</param>
    /// <param name="y">The y coordinate.</param>
    /// <param name="r">The radius.</param>
    /// <param name="lh">Whether or not to use Large Herb logic.</param>
    public static void SquareTileFrameArea(int x, int y, int r, bool lh = false)
    {
        for (int i = x - r; i < x + r; i++)
        {
            for (int j = y - r; j < y + r; j++)
            {
                SquareTileFrame(i, j, true, lh);
            }
        }
    }
    /// <summary>
    /// A helper method to run WorldGen.SquareTileFrame() over an area.
    /// </summary>
    /// <param name="x">The x coordinate.</param>
    /// <param name="y">The y coordinate.</param>
    /// <param name="xr">The number of blocks in the X direction.</param>
    /// <param name="yr">The number of blocks in the Y direction.</param>
    /// <param name="lh">Whether or not to use Large Herb logic.</param>
    public static void SquareTileFrameArea(int x, int y, int xr, int yr, bool lh = false)
    {
        for (int i = x; i < x + xr; i++)
        {
            for (int j = y; j < y + yr; j++)
            {
                SquareTileFrame(i, j, true, lh);
            }
        }
    }
    /// <summary>
    /// Swaps two values.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="lhs">Left hand side.</param>
    /// <param name="rhs">Right hand side.</param>
    public static void Swap<T>(ref T lhs, ref T rhs)
    {
        T t = lhs;
        lhs = rhs;
        rhs = t;
    }
    /// <summary>
    /// A helper method to find the actual surface of the world.
    /// </summary>
    /// <param name="positionX">The x position.</param>
    /// <returns></returns>
    public static int TileCheck(int positionX)
    {
        for (int i = (int)(WorldGen.worldSurfaceLow - 30); i < Main.maxTilesY; i++)
        {
            Tile tile = Framing.GetTileSafely(positionX, i);
            if ((tile.TileType == TileID.Dirt || tile.TileType == TileID.ClayBlock || tile.TileType == TileID.Stone || tile.TileType == TileID.Sand || tile.TileType == ModContent.TileType<Snotsand>() || tile.TileType == ModContent.TileType<Loam>() || tile.TileType == TileID.Mud || tile.TileType == TileID.SnowBlock || tile.TileType == TileID.IceBlock) && tile.HasTile)
            {
                return i;
            }
        }
        return 0;
    }
    public static void MakeSquareTemp(int x, int y)
    {
        for (int i = x; i < x + 5; i++)
        {
            for (int j = y; j < y + 5; j++)
            {
                
                WorldGen.KillTile(i, j, noItem: true);
                Main.tile[i, j].TileType = TileID.Stone;
                Tile t = Main.tile[i, j];
                t.HasTile = true;
                WorldGen.SquareTileFrame(i, j);
            }
        }
    }
    public static void MakeCircle(int x, int y, int radius, int tileType, bool walls = false, int wallType = WallID.Dirt)
    {
        for (int k = x - radius; k <= x + radius; k++)
        {
            for (int l = y - radius; l <= y + radius; l++)
            {
                float dist = Vector2.Distance(new Vector2(k, l), new Vector2(x, y));
                if (dist <= radius && dist >= (radius - 29))
                {
                    Tile t = Main.tile[k, l];
                    t.HasTile = false;
                }
                if ((dist <= radius && dist >= radius - 7) || (dist <= radius - 22 && dist >= radius - 29))
                {
                    Tile t = Main.tile[k, l];
                    t.HasTile = false;
                    t.IsHalfBlock = false;
                    t.Slope = SlopeType.Solid;
                    Main.tile[k, l].TileType = (ushort)tileType;
                    WorldGen.SquareTileFrame(k, l);
                }
                if (walls)
                {
                    if (dist <= radius - 6 && dist >= radius - 23)
                    {
                        Main.tile[k, l].WallType = (ushort)wallType;
                    }
                }
            }
        }
    }
}
