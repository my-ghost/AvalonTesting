using Avalon.Rarities;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Avalon.Items.Placeable.Bar;

class OblivionBar : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Oblivion Bar");
        SacrificeTotal = 25;
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.autoReuse = true;
        Item.useTurn = true;
        Item.maxStack = 999;
        Item.consumable = true;
        Item.createTile = ModContent.TileType<Tiles.PlacedBars>();
        Item.placeStyle = 1;
        Item.rare = ModContent.RarityType<YellowGreenRarity>();
        Item.width = dims.Width;
        Item.useTime = 10;
        Item.value = Item.sellPrice(0, 1, 25, 0);
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useAnimation = 15;
        Item.height = dims.Height;
    }
    public override void AddRecipes()
    {
        Recipe.Create(Type)
            .AddIngredient(ModContent.ItemType<Tile.OblivionOre>(), 7)
            .AddTile(ModContent.TileType<Tiles.CaesiumForge>())
            .Register();
    }
}
