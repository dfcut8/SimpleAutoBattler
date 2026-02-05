using System;
using Godot;
using SimpleAutoBattler.Scenes.Core;

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

    public override void _Process(double delta)
    {
        if (isDragging && Target != null)
        {
            // Move the target to follow the mouse, with the initial offset
            // Snap to a cell size
            var desired = Target.GetGlobalMousePosition() + dragOffset;
            Target.GlobalPosition = desired.Snapped(Arena.CellSizePixels);
        }
    }

    public override void _Input(InputEvent @event)
    {
        //GD.Print($"Input Event Received in DragAndDrop. Event: {@event.AsText()}");
        if (Enabled == false || Target == null)
        {
            return;
        }

        var draggingObject = GetTree().GetFirstNodeInGroup("Dragging") as Area2D;
        if (draggingObject != null && !isDragging)
        {
            return;
        }

        if (isDragging && @event.IsActionPressed("DragCancel"))
        {
            GD.Print("Cancelling Drag");
            CancelDrag();
        }
        else if (!isDragging && @event.IsActionPressed("Select"))
        {
            GD.Print("Continuing Drag");
            StartDrag();
        }
        else if (isDragging && @event.IsActionReleased("Select"))
        {
            GD.Print("Dropping Drag");
            DropDrag();
        }
    }

    private void EndDrag()
    {
        isDragging = false;
        Target.RemoveFromGroup("Dragging");
        Target.ZIndex = 0;
    }

    private void CancelDrag()
    {
        EndDrag();
        DragCancelled?.Invoke(startingPosition);
        Target.GlobalPosition = startingPosition;
    }

    private void StartDrag()
    {
        isDragging = true;
        startingPosition = Target.GlobalPosition;
        dragOffset = Target.GlobalPosition - Target.GetGlobalMousePosition();
        Target.AddToGroup("Dragging");
        Target.ZIndex = 100;
        DragStarted?.Invoke();
    }

    private void DropDrag()
    {
        EndDrag();
        DragDropped?.Invoke(Target.GlobalPosition);
    }
}
