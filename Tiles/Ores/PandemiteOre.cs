using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Avalon.Tiles.Ores;

public class PandemiteOre : ModTile
{
    public override void SetStaticDefaults()
    {
        AddMapEntry(Color.Olive, LanguageManager.Instance.GetText("Pandemite"));
        Main.tileSolid[Type] = true;
        Main.tileMergeDirt[Type] = true;
        Main.tileShine2[Type] = true;
        Main.tileShine[Type] = 1150;
        Main.tileSpelunker[Type] = true;
        Main.tileBlockLight[Type] = true;
        Main.tileOreFinderPriority[Type] = 320;
        Main.tileLighted[Type] = true;
        ItemDrop = ModContent.ItemType<Items.Placeable.Tile.PandemiteOre>();
        HitSound = SoundID.Tink;
        DustType = DustID.JungleSpore;
        MinPick = 55;
        TileID.Sets.Ore[Type] = true;
    }

    public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
    {
        r = 0.18f;
        g = 0.25f;
    }
}
