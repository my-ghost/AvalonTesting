using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using System;
using Avalon.Players;
using Avalon.Items.Material;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Avalon.NPCs;

public class Rafflesia : ModNPC
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Rafflesia");
        Main.npcFrameCount[NPC.type] = 4;
    }

    public override void SetDefaults()
    {
        NPC.damage = 31;
        NPC.lifeMax = 160;
        NPC.defense = 7;
        NPC.width = 54;
        NPC.aiStyle = -1;
        NPC.npcSlots = 1f;
        NPC.value = 110f;
        NPC.height = 30;
        NPC.HitSound = SoundID.NPCHit1;
        NPC.DeathSound = SoundID.NPCDeath1;
        NPC.knockBackResist = 0f;
        Banner = NPC.type;
        BannerItem = ModContent.ItemType<Items.Banners.RafflesiaBanner>();
        SpawnModBiomes = new int[] { ModContent.GetInstance<Biomes.Tropics>().Type };
        //DrawOffsetY = 10;
    }
    public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry) =>
        bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
        {
            new FlavorTextBestiaryInfoElement(""),
        });
    public override void ModifyNPCLoot(NPCLoot loot)
    {
        loot.Add(ItemDropRule.Common(ModContent.ItemType<Root>(), 2, 1, 2));
    }
    public override float SpawnChance(NPCSpawnInfo spawnInfo)
    {
        if (spawnInfo.Player.GetModPlayer<ExxoBiomePlayer>().ZoneTropics)
        {
            if (Main.tile[spawnInfo.SpawnTileX, spawnInfo.SpawnTileY + 2].TileType == ModContent.TileType<Tiles.TropicalGrass>())
                //&&
                //!Main.tile[spawnInfo.SpawnTileX + 1, spawnInfo.SpawnTileY].HasTile && !Main.tile[spawnInfo.SpawnTileX, spawnInfo.SpawnTileY].HasTile &&
                //!Main.tile[spawnInfo.SpawnTileX - 1, spawnInfo.SpawnTileY].HasTile)
            {
                return 0.7f;
            }
        }
        return 0;
    }
    public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
    {
        NPC.lifeMax = (int)(NPC.lifeMax * 0.55f);
        NPC.damage = (int)(NPC.damage * 0.65f);
    }
    public override void AI()
    {
        NPC.ai[0]++;
        if (NPC.ai[0] >= 240)
        {
            NPC.ai[1] = 1;

        }
        if (NPC.ai[1] == 1)
        {
            NPC.ai[2]++;
            int type = ModContent.NPCType<FlySmall>();
            if (Main.rand.NextBool(3))
                type = ModContent.NPCType<Fly>();
            if (NPC.ai[2] is 60 or 120 or 180) NPC.NewNPC(NPC.GetSource_FromThis(), (int)NPC.Center.X, (int)NPC.position.Y + 8, type, Target: NPC.target);
            if (NPC.ai[2] == 188)
            {
                NPC.ai[2] = 0;
                NPC.ai[0] = 0;
                NPC.ai[1] = 0;
                return;
            }
        }
    }

    public override void FindFrame(int frameHeight)
    {
        int firstStart = 45;

        if (NPC.ai[1] == 0)
        {
            NPC.frameCounter++;
            // start, slower
            if (NPC.ai[0] < 180)
            {
                if (NPC.frameCounter < 16)
                {
                    NPC.frame.Y = 0;
                }
                else if (NPC.frameCounter < 32)
                {
                    NPC.frame.Y = frameHeight;
                }
                else
                {
                    NPC.frameCounter = 0;
                }
            }
            // faster
            else
            {
                if (NPC.frameCounter < 8)
                {
                    NPC.frame.Y = 0;
                }
                else if (NPC.frameCounter < 16)
                {
                    NPC.frame.Y = frameHeight;
                }
                else
                {
                    NPC.frameCounter = 0;
                }
            }
        }
        else if (NPC.ai[1] == 1)
        {
            if (NPC.ai[2] is < 40 or >= 60 and < 100 or >= 120 and < 160 ) // squish frame
            {
                NPC.frame.Y = frameHeight;
            }
            else if (NPC.ai[2] is >= 40 and < 50 or >= 100 and < 110 or >= 160 and < 170)
            {
                NPC.frame.Y = frameHeight * 2;
            }
            else if (NPC.ai[2] is >= 50 and < 60 or >= 110 and < 120 or >= 170 and < 180)
            {
                NPC.frame.Y = frameHeight * 3;
            }
        }
    }

    public override void HitEffect(int hitDirection, double damage)
    {
        //if (npc.life <= 0 && Main.netMode != NetmodeID.Server)
        //{
        //    Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, npc.velocity * 0.8f, Mod.Find<ModGore>("Rafflesia").Type, 1f);
        //}
    }
}
