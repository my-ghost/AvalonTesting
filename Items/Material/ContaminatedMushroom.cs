﻿using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace AvalonTesting.Items.Material;

class ContaminatedMushroom : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Virulent Mushroom");
        Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 25;
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.width = dims.Width;
        Item.maxStack = 999;
        Item.value = 50;
        Item.height = dims.Height;
    }
}
