using Godot;
using Resources.Units;
using Scenes.Core;

namespace Scenes.Units;

[Tool]
public partial class Unit : Area2D
{
    [Export]
    private UnitStats UnitStats { get; set; }

    private Sprite2D skin;
    private ProgressBar healthBar;
    private ProgressBar manaBar;

    public override void _Ready()
    {
        skin = GetNode<Sprite2D>("%Skin");
        healthBar = GetNode<ProgressBar>("%HealthBar");
        manaBar = GetNode<ProgressBar>("%ManaBar");

        UnitStats.SkinCoordinatesChanged += UpdateSkin;
        UpdateSkin();
    }

    private void UpdateSkin()
    {
        var regionRect = skin.RegionRect;
        regionRect.Position =
            new Vector2(UnitStats.SkinCoordinates.X, UnitStats.SkinCoordinates.Y)
            * Arena.CellSizePixels;
        skin.RegionRect = regionRect;
    }
}
