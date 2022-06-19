using System.Drawing;
using System.Numerics;
using CheckersLogic.Enums;

namespace CheckersLogic.Interfaces;

public interface IChecker
{
    
    public CheckerType Type { get; set; }

    public IPlayer Owner { get; set; }

    public Vector2 Position { get; set; }

    public Color Color
    {
        get => Owner.Color;
    }
}