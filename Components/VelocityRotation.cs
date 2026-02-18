using Godot;

namespace SimpleAutoBattler.Components;

public partial class VelocityRotation : Node
{
    [Export]
    private bool Enabled { get; set; } = true;

    [Export]
    private Node2D Target { get; set; }

    [Export(PropertyHint.Range, "0.25, 1.5")]
    private float LerpSpeed { get; set; } = 0.4f;

    [Export]
    private float RotationMultiplier { get; set; } = 120f;

    [Export]
    private float VelocityThreshold { get; set; } = 3.0f;

    private Vector2 previousPosition;
    private Vector2 velocity;
    private float angle;
    private float progress;
    private float timeElapsed;
}
