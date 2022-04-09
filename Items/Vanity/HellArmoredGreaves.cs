﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AvalonTesting.Items.Vanity;

[AutoloadEquip(EquipType.Legs)]
class HellArmoredGreaves : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Hell Armored Greaves");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.rare = ItemRarityID.Yellow;
        Item.width = dims.Width;
        Item.vanity = true;
        Item.value = Item.sellPrice(0, 0, 90, 0);
        Item.height = dims.Height;
    }
}
