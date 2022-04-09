using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AvalonTesting.Tiles;

public class Lifestone : ModTile
{
    public override void SetStaticDefaults()
    {
        AddMapEntry(new Color(52, 84, 1));
        Main.tileSolid[Type] = true;
        Main.tileMergeDirt[Type] = true;
        Main.tileBlockLight[Type] = true;
        ItemDrop = Mod.Find<ModItem>("Lifestone").Type;
        SoundType = SoundID.Tink;
        SoundStyle = 1;
        DustType = DustID.GreenFairy;
    }
}
