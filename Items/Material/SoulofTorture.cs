﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace AvalonTesting.Items.Material;

class SoulofTorture : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Soul of Torture");
        Tooltip.SetDefault("'The essence of cruelty'");
        Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(5, 4));
        ItemID.Sets.AnimatesAsSoul[Item.type] = true;
        ItemID.Sets.ItemIconPulse[Item.type] = true;
        ItemID.Sets.ItemNoGravity[Item.type] = true;
        Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 25;
    }
    public override Color? GetAlpha(Color lightColor)
    {
        return new Color(255, 255, 255, 100);
    }
    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.rare = ItemRarityID.Red;
        Item.width = dims.Width;
        Item.maxStack = 999;
        Item.value = 90000;
        Item.height = 28;
    }
    public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
    {
        float num7 = (float)Main.rand.Next(90, 111) * 0.01f;
        num7 *= Main.essScale;
        Lighting.AddLight((int)((Item.position.X + (float)(Item.width / 2)) / 16f), (int)((Item.position.Y + (float)(Item.height / 2)) / 16f), 0.5f * num7, 0.01f * num7, 0.01f * num7);
    }
}
