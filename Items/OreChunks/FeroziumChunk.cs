using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;

namespace Avalon.Items.OreChunks;

class FeroziumChunk : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Ferozium Chunk");
        SacrificeTotal = 200;
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.width = dims.Width;
        Item.maxStack = 999;
        Item.value = 100;
        Item.height = dims.Height;
        Item.rare = ItemRarityID.Lime;
    }
    public override void AddRecipes()
    {
        Recipe.Create(ModContent.ItemType<Placeable.Bar.FeroziumBar>())
            .AddIngredient(Type, 6)
            .AddTile(TileID.WorkBenches)
            .Register();

        Recipe.Create(ModContent.ItemType<Placeable.Bar.HydrolythBar>())
            .AddIngredient(ModContent.ItemType<HydrolythChunk>(), 5)
            .AddIngredient(Type)
            .AddIngredient(ModContent.ItemType<Placeable.Tile.SolariumOre>())
            .AddTile(TileID.WorkBenches)
            .Register();
    }
}
