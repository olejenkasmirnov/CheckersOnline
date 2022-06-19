using System.Drawing;

namespace CheckersLogic.Interfaces;

public interface IPlayer
{
    Guid Guid { get;  set; }
    Color Color { get; set; }
}