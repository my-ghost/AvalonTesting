using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Avalon.Buffs;
// TODO: IMPLEMENT BARFING
public class Virulent : ModBuff
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Infected");
        Description.SetDefault("Losing life and spreading infection");
        Main.debuff[Type] = true;
    }

    public override void Update(Player player, ref int buffIndex)
    {
        if (player.lifeRegen > 0)
        {
            player.lifeRegen = 0;
        }

        player.lifeRegenTime = 0;
        player.lifeRegen -= 16;
    }
    public override void Update(NPC npc, ref int buffIndex)
    {
        for (int i = 0; i < Main.npc.Length; i++)
        {
            NPC n2 = Main.npc[i];
            if (n2.townNPC || n2.friendly)
            {
                continue;
            }

            if (n2.getRect().Intersects(npc.getRect()))
            {
                n2.AddBuff(Type, 540);
            }
        }
        if (Main.rand.NextBool(3))
        {
            int num10 = Dust.NewDust(npc.position, npc.width, npc.height, DustID.PoisonStaff, 0f, 0f, 0, default, 1.8f);
            Main.dust[num10].noGravity = true;
        }
    }
}
