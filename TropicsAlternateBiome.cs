using AltLibrary;
using AltLibrary.Common.AltBiomes;
using AltLibrary.Common.Systems;
using AltLibrary.Common.Hooks;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.ID;
using Terraria.ModLoader;
using AvalonTesting.Items.Placeable.Seed;
using AvalonTesting.Items.Weapons.Melee;
using AvalonTesting.NPCs;
using AvalonTesting.Tiles;
using AvalonTesting.Tiles.Ores;
using AvalonTesting.Walls;

namespace AvalonTesting
{
    internal class TropicsAlternateBiome : AltBiome
    {
        public override Color NameColor => new(0, 255, 128);

        public override void SetStaticDefaults()
        {
            BiomeType = BiomeType.Jungle;

            BiomeGrass = ModContent.TileType<TropicalGrass>();
            BiomeStone = ModContent.TileType<TropicalStone>();
            BiomeOre = ModContent.TileType<XanthophyteOre>();
            BiomeOreBrick = ModContent.TileType<XanthophyteOre>(); //Change to Xanthophyte Brick when its finished
            //BossBulb = ModContent.TileType<CentipedeNest>();

            BiomeChestItem = ModContent.ItemType<VirulentKnives>(); //Change to biome item later
            BiomeChestTile = ModContent.TileType<LockedContagionChest>(); //change to biome chest locked later
            BiomeChestTileStyle = 0;

            DisplayName.SetDefault("Tropics");
            Description.SetDefault("A Tropical forest which houses lots of wasps. A hidden outpost lives beneath the surface. [c/E11919:(Not Complete)]");

            BakeTileChild(ModContent.TileType<TropicalMud>(), TileID.Mud, new(true, true, true));

            /*WallContext = new WallContext()
                .AddReplacement<ContagionNaturalWall1>(28, 1, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 188, 189, 190, 191, 192, 193, 194, 195, 61, 185, 212, 213, 214, 215, 3, 200, 201, 202, 203, 83)
                .AddReplacement<ContagionGrassWall>(63, 65, 66, 68, 69, 70, 81)
                .AddReplacement<ContagionNaturalWall2>(216, 217, 218, 219) //Sandstone walls
                .AddReplacement<ContagionNaturalWall2>(197, 220, 221, 222); //Hardened sand walls*/
        }

        public override string WorldIcon => "AvalonTesting/Assets/WorldIcons/Tropics";

        public override string IconSmall => "AvalonTesting/Sprites/Bestiary/TropicsIcon";
    }
}
