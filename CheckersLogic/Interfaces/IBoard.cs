using System.Drawing;

namespace CheckersLogic.Interfaces;

public interface IBoard<T> : IEnumerable<T>
    where T : ICell
{
    Color GetColor(int i, int j);

    (int, int) GetDimensions();
}