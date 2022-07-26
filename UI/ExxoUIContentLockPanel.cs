﻿using System;
using Avalon.Logic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.UI;

namespace Avalon.UI;

internal class ExxoUIContentLockPanel : ExxoUIPanel
{
    public LockStatusChangedEventHandler OnLockStatusChanged;
    private readonly UIElement contentHolder;
    private readonly UIElement elementToLock;
    private readonly ExxoUIList list;
    private readonly CalculatedStyle listOuterDimensions;
    private readonly Observer<bool> lockedStatusChanged;
    private readonly string message;
    private readonly Observer<bool> oversizeChanged;
    private readonly Func<bool> unlockCondition;

    public ExxoUIContentLockPanel(UIElement elementToLock, Func<bool> unlockCondition,
                                  string message = "Content locked")
    {
        this.message = message;
        this.elementToLock = elementToLock;
        this.unlockCondition = unlockCondition;

        BackgroundColor = Color.Black * 0.9f;
        SetPadding(0);

        list = new ExxoUIList { VAlign = UIAlign.Center, HAlign = UIAlign.Center };
        list.SetPadding(0);
        list.ListPadding = 5;
        list.Direction = Direction.Horizontal;
        list.FitHeightToContent = true;
        list.FitWidthToContent = true;
        list.ContentVAlign = UIAlign.Center;

        var iconBackground = new ExxoUIImage(Terraria.Main.Assets.Request<Texture2D>("Images/UI/Wires_1"));
        list.Append(iconBackground);
        var innerImage = new ExxoUIImage(Terraria.Main.Assets.Request<Texture2D>("Images/UI/UI_quickicon1"))
        {
            VAlign = UIAlign.Center, HAlign = UIAlign.Center,
        };
        iconBackground.Append(innerImage);

        var text = new ExxoUIText(message);
        list.Append(text);
        list.Recalculate();

        contentHolder = new UIElement();
        contentHolder.SetPadding(0);
        contentHolder.Width.Set(0, 1);
        contentHolder.Height.Set(0, 1);
        Append(contentHolder);

        listOuterDimensions = list.GetOuterDimensions();
        oversizeChanged = new Observer<bool>(() => ListIsOversize);
        lockedStatusChanged = new Observer<bool>(() => Locked);
        Hidden = !Locked;
    }

    public delegate void LockStatusChangedEventHandler(ExxoUIContentLockPanel sender, EventArgs e);

    public bool Locked => !unlockCondition();

    private bool ListIsOversize => listOuterDimensions.Width > elementToLock.GetInnerDimensions().Width ||
                                   listOuterDimensions.Height > elementToLock.GetInnerDimensions().Height;

    protected override void UpdateSelf(GameTime gameTime)
    {
        base.UpdateSelf(gameTime);
        if (lockedStatusChanged.Check())
        {
            LockStatusChanged();
        }
    }

    protected override void PreRecalculate()
    {
        base.PreRecalculate();
        Width.Set(elementToLock.GetOuterDimensions().Width, 0);
        Height.Set(elementToLock.GetOuterDimensions().Height, 0);
        Vector2 position = elementToLock.GetDimensions().Position() - Parent.GetDimensions().Position();
        Left.Set(position.X - Parent.PaddingLeft, 0);
        Top.Set(position.Y - Parent.PaddingTop, 0);
    }

    protected override void PostRecalculate()
    {
        base.PostRecalculate();
        if (oversizeChanged.Check())
        {
            contentHolder.RemoveAllChildren();
            if (ListIsOversize)
            {
                var image = new ExxoUIImage(Terraria.Main.Assets.Request<Texture2D>("Images/UI/UI_quickicon1"))
                {
                    VAlign = UIAlign.Center, HAlign = UIAlign.Center,
                };
                contentHolder.Append(image);
                Tooltip = message;
            }
            else
            {
                contentHolder.Append(list);
                Tooltip = "";
            }
        }
    }

    protected virtual void LockStatusChanged()
    {
        Hidden = !Locked;
        OnLockStatusChanged?.Invoke(this, EventArgs.Empty);
    }
}
