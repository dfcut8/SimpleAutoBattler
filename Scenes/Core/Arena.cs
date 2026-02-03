using Godot;

namespace Scenes.Core;

public partial class Arena : Node2D
{
    public readonly static Vector2I CellSizePixels = new(32, 32);
    public readonly static Vector2I HalfCellSizePixels = CellSizePixels / 2;
    public readonly static Vector2I QuaterCellSizePixels = HalfCellSizePixels / 2;
}
