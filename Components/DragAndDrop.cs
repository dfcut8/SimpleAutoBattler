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
}
