using Godot;

namespace SimpleAutoBattler.Scenes.Core;

public partial class Arena : Node2D
{
    public static readonly Vector2I CellSizePixels = new(32, 32);
    public static readonly Vector2I HalfCellSizePixels = CellSizePixels / 2;
    public static readonly Vector2I QuaterCellSizePixels = HalfCellSizePixels / 2;
}
