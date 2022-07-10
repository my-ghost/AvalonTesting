﻿using Terraria;
using Terraria.ModLoader;
using AvalonTesting.Players;

namespace AvalonTesting.Buffs;

public class BrokenWeaponry : ModBuff
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Broken Weaponry");
        Description.SetDefault("You can't use melee weapons");
        Main.debuff[Type] = true;
    }
    public override void Update(Player player, ref int buffIndex)
    {
        player.GetModPlayer<ExxoBuffPlayer>().BrokenWeaponry = true;
    }
}
