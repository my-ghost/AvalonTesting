using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Avalon.Items.Accessories;

[AutoloadEquip(EquipType.Shoes, EquipType.Wings)]
class InertiaBoots : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Inertia Boots");
        Tooltip.SetDefault("Allows infinite flight and slow fall and the wearer can run incredibly fast\nThe wearer has a chance to dodge attacks and negates fall damage");
        SacrificeTotal = 1;
        ArmorIDs.Wing.Sets.Stats[Item.wingSlot] = new WingStats(1000, 9f, 1.2f, true);
    }

    public override void SetDefaults()
    {
        Item.defense = 4;
        Item.rare = ItemRarityID.Lime;
        Item.width = 30;
        Item.value = Item.sellPrice(0, 16, 45, 0);
        Item.accessory = true;
        Item.height = 30;
    }

    public override void AddRecipes()
    {
        CreateRecipe(1).AddRecipeGroup("Avalon:Wings").AddIngredient(ItemID.FrostsparkBoots).AddIngredient(ItemID.BlackBelt).AddIngredient(ItemID.LunarBar, 2).AddTile(TileID.TinkerersWorkbench).Register();
    }

    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        //player.Avalon().noSticky = true;
        player.accRunSpeed = 10.29f;
        player.rocketBoots = 3;
        player.noFallDmg = true;
        player.blackBelt = true;
        player.iceSkate = true;
        player.wingTime = 1000;
        player.empressBrooch = true;
        //player.Avalon().inertiaBoots = true;
        //if (player.controlUp && player.controlJump)
        //{
        //    player.velocity.Y = player.velocity.Y - 0.3f * player.gravDir;
        //    if (player.gravDir == 1f)
        //    {
        //        if (player.velocity.Y > 0f)
        //        {
        //            player.velocity.Y = player.velocity.Y - 1f;
        //        }
        //        else if (player.velocity.Y > -Player.jumpSpeed)
        //        {
        //            player.velocity.Y = player.velocity.Y - 0.2f;
        //        }
        //        if (player.velocity.Y < -Player.jumpSpeed * 3f)
        //        {
        //            player.velocity.Y = -Player.jumpSpeed * 3f;
        //        }
        //    }
        //    else
        //    {
        //        if (player.velocity.Y < 0f)
        //        {
        //            player.velocity.Y = player.velocity.Y + 1f;
        //        }
        //        else if (player.velocity.Y < Player.jumpSpeed)
        //        {
        //            player.velocity.Y = player.velocity.Y + 0.2f;
        //        }
        //        if (player.velocity.Y > Player.jumpSpeed * 3f)
        //        {
        //            player.velocity.Y = Player.jumpSpeed * 3f;
        //        }
        //    }
        //}
        //if (!player.setVortex && !player.vortexStealthActive)
        //{
        if (player.controlLeft)
        {
            if (player.velocity.X > (player.vortexStealthActive ? -1f : -5f))
            {
                player.velocity.X -= player.vortexStealthActive ? 0.06f : 0.31f;
            }
            if (player.velocity.X < (player.vortexStealthActive ? -1f : -5f) && player.velocity.X > (player.vortexStealthActive ? -2f : -10f))
            {
                player.velocity.X -= player.vortexStealthActive ? 0.04f : 0.29f;
            }
        }
        if (player.controlRight)
        {
            if (player.velocity.X < (player.vortexStealthActive ? 1f : 5f))
            {
                player.velocity.X += player.vortexStealthActive ? 0.06f : 0.31f;
            }
            if (player.velocity.X > (player.vortexStealthActive ? 1f : 5f) && player.velocity.X < (player.vortexStealthActive ? 2f : 10f))
            {
                player.velocity.X += player.vortexStealthActive ? 0.04f : 0.29f;
            }
        }
        //}
        if (player.velocity.X is > 6f or < -6f)
        {
            var newColor = default(Color);
            var num = Dust.NewDust(new Vector2(player.position.X, player.position.Y), player.width, player.height, DustID.Cloud, Main.rand.Next(-5, 5), Main.rand.Next(-5, 5), 100, newColor, 2f);
            Main.dust[num].noGravity = true;
        }
    }
}
