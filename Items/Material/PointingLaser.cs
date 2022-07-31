using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Avalon.Items.Material;

class PointingLaser : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Pointing Laser");
        Tooltip.SetDefault("Used for crafting the Eye of Oblivion\nCan be pointed");
        SacrificeTotal = 25;
        Item.staff[Item.type] = true;
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.rare = ItemRarityID.Pink;
        Item.useAnimation = 5;
        Item.useTime = 5;
        Item.autoReuse = true;
        Item.shoot = ModContent.ProjectileType<Projectiles.Ranged.ArrowBeam>();
        Item.shootSpeed = 6f;
        Item.width = dims.Width;
        Item.channel = true;
        Item.useStyle = ItemUseStyleID.Shoot;
        Item.maxStack = 999;
        Item.value = 0;
        Item.height = dims.Height;
    }
}
