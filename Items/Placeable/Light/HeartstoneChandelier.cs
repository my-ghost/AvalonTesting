using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace AvalonTesting.Items.Placeable.Light;

class HeartstoneChandelier : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Heartstone Chandelier");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.autoReuse = true;
        Item.consumable = true;
        Item.createTile = ModContent.TileType<Tiles.HeartstoneChandelier>();
        Item.width = dims.Width;
        Item.useTurn = true;
        Item.useTime = 10;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.maxStack = 99;
        Item.value = 3000;
        Item.useAnimation = 15;
        Item.height = dims.Height;
    }
}