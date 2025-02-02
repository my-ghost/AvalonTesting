﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Avalon.Items.MusicBoxes;

class MusicBoxPhantasm : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Music Box (Phantasm)");
        SacrificeTotal = 1;
        MusicLoader.AddMusicBox(Mod, MusicLoader.GetMusicSlot(Mod, "Sounds/Music/Phantasm"), ModContent.ItemType<MusicBoxPhantasm>(), ModContent.TileType<Tiles.MusicBoxes>(), 216);
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.autoReuse = true;
        Item.useTurn = true;
        Item.accessory = true;
        Item.consumable = true;
        Item.createTile = ModContent.TileType<Tiles.MusicBoxes>();
        Item.placeStyle = 6;
        Item.rare = ItemRarityID.LightRed;
        Item.width = dims.Width;
        Item.useTime = 10;
        Item.value = Item.sellPrice(0, 2, 0, 0);
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useAnimation = 15;
        Item.height = dims.Height;
    }
}
