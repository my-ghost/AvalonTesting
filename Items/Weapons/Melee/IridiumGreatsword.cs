using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace Avalon.Items.Weapons.Melee;

class IridiumGreatsword : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Iridium Greatsword");
        SacrificeTotal = 1;
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.damage = 30;
        Item.crit = 6;
        Item.rare = ItemRarityID.LightRed;
        Item.autoReuse = true;
        Item.useTurn = true;
        Item.scale = 1.4f;
        Item.width = dims.Width;
        Item.useTime = 18;
        Item.knockBack = 5.4f;
        Item.DamageType = DamageClass.Melee;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.value = 50000;
        Item.useAnimation = 18;
        Item.height = dims.Height;
        Item.UseSound = SoundID.Item1;
    }
    public override void AddRecipes()
    {
        Recipe.Create(Type)
            .AddIngredient(ModContent.ItemType<Placeable.Bar.IridiumBar>(), 14)
            .AddIngredient(ModContent.ItemType<Material.DesertFeather>(), 3)
            .AddTile(TileID.Anvils)
            .Register();
    }
}
