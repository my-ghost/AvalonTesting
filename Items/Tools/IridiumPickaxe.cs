using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Avalon.Items.Tools;

class IridiumPickaxe : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Iridium Pickaxe");
        Tooltip.SetDefault("Can mine Hellstone");
        SacrificeTotal = 1;
    }
    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.UseSound = SoundID.Item1;
        Item.damage = 15;
        Item.autoReuse = true;
        Item.useTurn = true;
        Item.scale = 1f;
        Item.rare = ItemRarityID.LightRed;
        Item.pick = 85;
        Item.width = dims.Width;
        Item.useTime = 15;
        Item.knockBack = 2.6f;
        Item.DamageType = DamageClass.Melee;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.value = Item.sellPrice(0, 1, 0, 0);
        Item.useAnimation = 15;
        Item.height = dims.Height;
    }
    public override void HoldItem(Player player)
    {
        if (player.inventory[player.selectedItem].type == Mod.Find<ModItem>("IridiumPickaxe").Type)
        {
            player.pickSpeed -= 0.5f;
        }
    }
    public override void AddRecipes()
    {
        Recipe.Create(Type)
            .AddIngredient(ModContent.ItemType<Placeable.Bar.IridiumBar>(), 13)
            .AddIngredient(ModContent.ItemType<Material.DesertFeather>(), 2)
            .AddTile(TileID.Anvils)
            .Register();
    }
}
