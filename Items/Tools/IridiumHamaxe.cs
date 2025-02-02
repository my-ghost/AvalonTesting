using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Avalon.Items.Tools;

class IridiumHamaxe : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Iridium Hamaxe");
        SacrificeTotal = 1;
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.damage = 20;
        Item.autoReuse = true;
        Item.hammer = 75;
        Item.useTurn = true;
        Item.scale = 1.2f;
        Item.axe = 22;
        Item.crit += 4;
        Item.rare = ItemRarityID.LightRed;
        Item.width = dims.Width;
        Item.useTime = 13;
        Item.knockBack = 2.5f;
        Item.DamageType = DamageClass.Melee;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.value = 50000;
        Item.useAnimation = 13;
        Item.height = dims.Height;
        Item.UseSound = SoundID.Item1;
    }
    public override void AddRecipes()
    {
        Recipe.Create(Type)
            .AddIngredient(ModContent.ItemType<Placeable.Bar.IridiumBar>(), 12)
            .AddIngredient(ModContent.ItemType<Material.DesertFeather>())
            .AddTile(TileID.Anvils)
            .Register();
    }
}
