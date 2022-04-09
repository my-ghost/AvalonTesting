﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AvalonTesting.Items.AdvancedPotions;

class AdvObsidianSkinPotion : ModItem
{
    public override void SetDefaults()
    {
        Rectangle dims = global::AvalonTesting.GetDims("Items/AdvancedPotions/AdvObsidianSkinPotion");
        Item.buffType = ModContent.BuffType<Buffs.AdvancedBuffs.AdvObsidianSkin>();
        Item.UseSound = SoundID.Item3;
        Item.consumable = true;
        Item.rare = ItemRarityID.Lime;
        Item.width = dims.Width;
        Item.useTime = 15;
        Item.useStyle = ItemUseStyleID.EatFood;
        Item.maxStack = 100;
        Item.value = Item.sellPrice(0, 0, 4, 0);
        Item.useAnimation = 15;
        Item.height = dims.Height;
        Item.buffTime = 28800;
    }
}
