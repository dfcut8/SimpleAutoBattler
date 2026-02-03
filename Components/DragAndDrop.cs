using System;
using Godot;

namespace SimpleAutoBattler.Components;

[GlobalClass]
public partial class DragAndDrop : Node
{
    public Action DragStarted;
    public Action<Vector2> DragDropped;
    public Action<Vector2> DragCancelled;

    [Export]
    private bool Enabled { get; set; } = true;

    [Export]
    private Area2D Target { get; set; }

    private Vector2 startingPosition;
    private bool isDragging = false;
    private Vector2 dragOffset;

    public override void _Ready()
    {
        if (Target != null)
        {
            Target.InputEvent += OnInputEvent;
        }
    }

    public override void _Process(double delta)
    {
        if (isDragging && Target != null)
        {
            Target.GlobalPosition = Target.GetGlobalMousePosition() + dragOffset;
        }
    }

    private void OnInputEvent(Node viewport, InputEvent @event, long shapeIdx)
    {
        throw new NotImplementedException();
    }
}
