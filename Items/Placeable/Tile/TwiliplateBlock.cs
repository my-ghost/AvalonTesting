using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace Avalon.Items.Placeable.Tile;

class TwiliplateBlock : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Twiliplate Block");
        SacrificeTotal = 100;
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.autoReuse = true;
        Item.consumable = true;
        Item.createTile = ModContent.TileType<Tiles.TwiliplateBlock>();
        Item.width = dims.Width;
        Item.useTurn = true;
        Item.useTime = 10;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.maxStack = 999;
        Item.useAnimation = 15;
        Item.height = dims.Height;
    }
    public override void AddRecipes()
    {
        Terraria.Recipe.Create(Type, 2)
            .AddIngredient(ModContent.ItemType<BismuthOre>())
            .AddIngredient(ItemID.Cloud)
            .AddTile(TileID.Furnaces).Register();
    }
}
