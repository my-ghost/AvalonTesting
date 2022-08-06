using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Avalon.Items.Armor;

[AutoloadEquip(EquipType.Legs)]
class AwakenedRoseSubligar : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Awakened Rose Subligar");
        Tooltip.SetDefault("10% increased movement speed"
                           + "\n10% decreased mana cost");
        SacrificeTotal = 1;
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.defense = 20;
        Item.rare = ModContent.RarityType<Rarities.TealRarity>();
        Item.width = dims.Width;
        Item.value = Item.sellPrice(0, 40, 0, 0);
        Item.height = dims.Height;
    }

    public override void UpdateEquip(Player player)
    {
        player.moveSpeed += 0.1f; // rework into boosting movement speed even after hermes boots is equipped
        player.manaCost -= 0.1f;
    }
}
