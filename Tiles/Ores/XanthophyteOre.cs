﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace AvalonTesting.Tiles.Ores;

public class XanthophyteOre : ModTile
{
    private Color xanthophyteColor = new Color(210, 217, 0);
    public override void SetStaticDefaults()
    {
        AddMapEntry(xanthophyteColor, LanguageManager.Instance.GetText("Xanthophyte"));
        Main.tileSolid[Type] = true;
        global::AvalonTesting.MergeWith(Type, ModContent.TileType<TropicalMud>());
        global::AvalonTesting.MergeWith(Type, ModContent.TileType<TropicalGrass>());
        Main.tileShine2[Type] = true;
        Main.tileShine[Type] = 775;
        Main.tileSpelunker[Type] = true;
        Main.tileBlockLight[Type] = true;
        Main.tileValue[Type] = 705;
        ItemDrop = ModContent.ItemType<Items.Placeable.Tile.XanthophyteOre>();
        SoundType = SoundID.Tink;
        SoundStyle = 1;
        DustType = DustID.Moss_Yellow;
        minPick = 200;
    }
    public override bool CanExplode(int i, int j)
    {
        return false;
    }
    public override bool TileFrame(int i, int j, ref bool resetFrame, ref bool noBreak)
    {
        global::AvalonTesting.MergeWithFrame(i, j, Type, ModContent.TileType<TropicalMud>(), false, false, false, false, resetFrame);
        return false;
    }
}
