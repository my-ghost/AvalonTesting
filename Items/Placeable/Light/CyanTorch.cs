﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AvalonTesting.Items.Placeable.Light;

class CyanTorch : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Cyan Torch");
        Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 25;
    }

    public override void SetDefaults()
    {
        Item.CloneDefaults(ItemID.Torch);
        Rectangle dims = this.GetDims();
        Item.createTile = ModContent.TileType<Tiles.Torches>();
        Item.width = dims.Width;
        Item.height = dims.Height;
        Item.placeStyle = 3;
        Item.value = Item.sellPrice(0, 0, 0, 15);
        Item.notAmmo = true;
        Item.flame = true;
        Item.ammo = 8;
    }
    public override void AddRecipes()
    {
        CreateRecipe(3).AddIngredient(ItemID.Torch, 3).AddIngredient(ModContent.ItemType<Tile.Tourmaline>()).Register();
    }
    public override void HoldItem(Player player)
    {
        if (Main.rand.Next(player.itemAnimation > 0 ? 40 : 80) == 0)
        {
            Dust.NewDust(new Vector2(player.itemLocation.X + 16f * player.direction, player.itemLocation.Y - 14f * player.gravDir), 4, 4, DustID.BlueTorch);
        }
        Vector2 position = player.RotatedRelativePoint(new Vector2(player.itemLocation.X + 12f * player.direction + player.velocity.X, player.itemLocation.Y - 14f + player.velocity.Y), true);
        Lighting.AddLight(position, 0f, 2f, 2f);
    }

    public override void PostUpdate()
    {
        if (!Item.wet)
        {
            Lighting.AddLight((int)((Item.position.X + Item.width / 2) / 16f), (int)((Item.position.Y + Item.height / 2) / 16f), 0f, 2f, 2f);
        }
    }

    public override void AutoLightSelect(ref bool dryTorch, ref bool wetTorch, ref bool glowstick)
    {
        dryTorch = true;
    }
}
