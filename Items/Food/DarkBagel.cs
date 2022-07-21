using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace AvalonTesting.Items.Food
{
	public class DarkBagel : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Dark Bagel");
			Tooltip.SetDefault("{$CommonItemTooltip.MediumStats}");
			SacrificeTotal = 5;
			Main.RegisterItemAnimation(Type, new DrawAnimationVertical(int.MaxValue, 3));
			ItemID.Sets.FoodParticleColors[Item.type] = new Color[3] {
				new Color(165, 125, 212),
				new Color(145, 74, 227),
				new Color(81, 42, 126)
			};
			ItemID.Sets.IsFood[Type] = true;
		}

		public override void SetDefaults()
		{
			// DefaultToFood sets all of the food related item defaults such as the buff type, buff duration, use sound, and animation time.
			Item.DefaultToFood(22, 18, BuffID.WellFed3, 57600); // 57600 is 16 minutes: 16 * 60 * 60
			Item.value = Item.buyPrice(0, 2);
			Item.rare = ItemRarityID.Blue;
		}
	}
}