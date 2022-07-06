using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AvalonTesting.Items.Placeable.Crafting;

class SolariumAnvil : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Solarium Anvil");
        Tooltip.SetDefault("Used to craft high-end items");
    }
    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.autoReuse = true;
        Item.consumable = true;
        Item.createTile = ModContent.TileType<Tiles.SolariumAnvil>();
        Item.rare = ItemRarityID.Lime;
        Item.width = dims.Width;
        Item.useTurn = true;
        Item.useTime = 10;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.maxStack = 99;
        Item.value = 75000;
        Item.useAnimation = 15;
        Item.height = dims.Height;
    }
    public override void AddRecipes()
    {
        Recipe.Create(1)
            .AddIngredient(ModContent.ItemType<Material.SolariumStar>(), 16)
            .AddIngredient(ModContent.ItemType<Material.HellsteelPlate>(), 5)
            .AddTile(TileID.MythrilAnvil).Register();
    }
}
