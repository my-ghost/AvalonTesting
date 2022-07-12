using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace AvalonTesting.Items.Fish;

class SicklyTrout : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Sickly Trout");
        Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 3;
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.rare = ItemRarityID.White;
        Item.width = dims.Width;
        Item.value = 10;
        Item.maxStack = 999;
        Item.height = dims.Height;
    }
}
