﻿using System;
using System.Reflection;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria.ModLoader;

namespace AvalonTesting;

public class ExxoMenu : ModMenu
{
    public override Asset<Texture2D> Logo
    {
        get
        {
            if (DateTime.Now.Month == 4 && DateTime.Now.Day == 1)
            {
                return AvalonTesting.Mod.Assets.Request<Texture2D>("Sprites/EAOLogoAprilFools");
            }

            return AvalonTesting.Mod.Assets.Request<Texture2D>("Sprites/EAOLogo");
        }
    }

    public override void Load()
    {
        base.Load();
        typeof(MenuLoader)
            .GetField("LastSelectedModMenu", BindingFlags.Static | BindingFlags.NonPublic)
            ?.SetValue(null, FullName);
    }
}