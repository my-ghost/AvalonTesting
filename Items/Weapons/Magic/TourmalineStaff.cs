using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Avalon.Items.Weapons.Magic;

class TourmalineStaff : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Tourmaline Staff");
        SacrificeTotal = 1;
        Item.staff[Item.type] = true;
    }

    public override void SetDefaults()
    {
        Item.CloneDefaults(ItemID.SapphireStaff);
        Item.staff[Item.type] = true;
        Rectangle dims = this.GetDims();
        Item.width = dims.Width;
        Item.height = dims.Height;
        Item.damage = 18;
        Item.shootSpeed = 6.5f;
        Item.mana = 5;
        Item.rare = ItemRarityID.Blue;
        Item.useTime = 38;
        Item.useAnimation = 38;
        Item.knockBack = 3.5f;
        Item.shoot = ModContent.ProjectileType<Projectiles.TourmalineBolt>();
        Item.value = Item.buyPrice(0, 3, 50, 0);
        Item.UseSound = SoundID.Item43;
    }
    public override void AddRecipes()
    {
        CreateRecipe(1)
            .AddIngredient(ModContent.ItemType<Placeable.Tile.Tourmaline>(), 15)
            .AddIngredient(ModContent.ItemType<Placeable.Bar.BronzeBar>(), 8)
            .AddTile(TileID.Anvils)
            .Register();
    }
}
