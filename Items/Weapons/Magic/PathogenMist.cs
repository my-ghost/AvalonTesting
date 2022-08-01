using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace Avalon.Items.Weapons.Magic;

class PathogenMist : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Pathogen Mist");
        Tooltip.SetDefault("Fires a blast of infected mist");
        SacrificeTotal = 1;
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.DamageType = DamageClass.Magic;
        Item.damage = 24;
        Item.autoReuse = true;
        Item.scale = 0.9f;
        Item.shootSpeed = 14f;
        Item.mana = 5;
        Item.rare = ItemRarityID.LightRed;
        Item.width = dims.Width;
        Item.useTime = 11;
        Item.knockBack = 1.5f;
        Item.shoot = ModContent.ProjectileType<Projectiles.Melee.VirulentCloud>();
        Item.useStyle = ItemUseStyleID.Shoot;
        Item.value = 500000;
        Item.useAnimation = 11;
        Item.height = dims.Height;
    }
}
