using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Avalon.Items.Weapons.Throw;

class PearlsandBomb : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Pearlsand Bomb");
        Tooltip.SetDefault("An explosion of pearlsand that will not destroy tiles");
        SacrificeTotal = 99;
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.noUseGraphic = true;
        Item.damage = 0;
        Item.maxStack = 999;
        Item.shootSpeed = 5f;
        Item.consumable = true;
        Item.noMelee = true;
        Item.width = dims.Width;
        Item.useTime = 25;
        Item.shoot = ModContent.ProjectileType<Projectiles.PearlsandBomb>();
        Item.useStyle = ItemUseStyleID.Swing;
        Item.value = Item.buyPrice(0, 0, 4, 0);
        Item.useAnimation = 25;
        Item.height = dims.Height;
    }
    public override void AddRecipes()
    {
        Recipe.Create(Type, 2)
            .AddIngredient(ItemID.Bomb, 2)
            .AddIngredient(ItemID.PearlsandBlock, 30)
            .AddTile(TileID.Anvils).Register();
    }
}
