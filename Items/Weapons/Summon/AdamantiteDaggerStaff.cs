using Avalon.Buffs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Avalon.Items.Weapons.Summon;

public class AdamantiteDaggerStaff : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Adamantite Dagger Staff");
        Tooltip.SetDefault("Summons an adamantite dagger to fight for you");
        SacrificeTotal = 1;
        ItemID.Sets.GamepadWholeScreenUseRange[Item.type] = true;
        ItemID.Sets.LockOnIgnoresCollision[Item.type] = false;
    }

    public override void SetDefaults()
    {
        Item.width = 36;
        Item.height = 38;

        Item.damage = 26;
        Item.mana = 8;
        Item.rare = ItemRarityID.LightRed;
        Item.useTime = 30;
        Item.knockBack = 5.5f;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.value = Item.sellPrice(0, 3);
        Item.useAnimation = 30;
        Item.UseSound = SoundID.Item44;

        Item.DamageType = DamageClass.Summon;
        Item.noMelee = true;
        Item.buffType = ModContent.BuffType<AdamantiteDagger>();
        Item.shoot = ModContent.ProjectileType<Projectiles.Summon.AdamantiteDagger>();
    }
    public override bool CanUseItem(Player player)
    {
        return (player.ownedProjectileCounts[Item.shoot] < player.maxMinions);
    }
    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity,
                               int type, int damage, float knockback)
    {
        player.AddBuff(Item.buffType, 2);
        player.SpawnMinionOnCursor(source, player.whoAmI, type, damage, knockback);
        return false;
    }

    public override void AddRecipes()
    {
        CreateRecipe().AddIngredient(ItemID.AdamantiteBar, 22).AddTile(TileID.Anvils).Register();
    }
}
