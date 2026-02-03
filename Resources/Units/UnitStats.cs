using System;
using System.Collections.Generic;
using Godot;

namespace Resources.Units;

[GlobalClass, Tool]
public partial class UnitStats : Resource
{
    public Action SkinCoordinatesChanged;

    public enum Rarity
    {
        Common,
        Uncommon,
        Rare,
        Epic,
        Legendary,
    }

    public Dictionary<Rarity, Color> RarityColors = new()
    {
        { Rarity.Common, Colors.White },
        { Rarity.Uncommon, Colors.Green },
        { Rarity.Rare, Colors.Blue },
        { Rarity.Epic, Colors.Purple },
        { Rarity.Legendary, Colors.Orange },
    };

    [ExportCategory("Data")]
    [Export]
    private string Name { get; set; }

    [Export]
    private Rarity UnitRarity { get; set; } = Rarity.Common;

    [Export]
    private int GoldCost { get; set; } = 1;

    [ExportCategory("Visuals")]
    [Export]
    public Vector2I SkinCoordinates
    {
        get => _skinCoordinates;
        set
        {
            _skinCoordinates = value;
            SkinCoordinatesChanged?.Invoke();
        }
    }
    private Vector2I _skinCoordinates;

    public override string ToString()
    {
        return Name;
    }
}
