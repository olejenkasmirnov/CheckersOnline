using System.Collections;
using System.Drawing;
using System.Numerics;
using CheckersLogic.Interfaces;

namespace CheckersLogic.Base;

public class BaseBoard : IBoard<BaseCell>
{
    private readonly BaseCell[,] _area;

    public BaseCell this[int row, int column]
    {
        get
        {
            if (row >= _area.GetUpperBound(0))
                throw new ArgumentOutOfRangeException(nameof(row));
            if(column >= _area.GetUpperBound(1))
                throw new ArgumentOutOfRangeException(nameof(column));
            return _area[row, column];   
        }
    }
    
    public BaseCell this[Vector2 pos]
    {
        get => _area[(int)pos.X, (int)pos.Y];
    }

    public BaseBoard(int dimension)
    {
        _area = new BaseCell[dimension, dimension];
        for (var i = 0; i < _area.GetLength(0); i++)
        for (var j = 0; j < _area.GetLength(1); j++)
            _area[i, j] = new BaseCell(this,new Vector2(i,j),
                GetColor(i,j));
    }
		
    public BaseBoard(int x, int y)
    {
        _area = new BaseCell[x, y];
        for (var i = 0; i < _area.GetLength(0); i++)
        for (var j = 0; j < _area.GetLength(1); j++)
            _area[i, j] = new BaseCell(this,new Vector2(i,j), GetColor(i,j));
    }

    public Color GetColor(int i, int j)
    {
        if (i % 2 == 0)
            return j % 2 == 0 ? Color.White : Color.Black;
        return j % 2 == 0 ? Color.Black : Color.White;
    }

    public (int, int) GetDimensions() 
        => (_area.GetUpperBound(0), _area.GetUpperBound(1));

    public IEnumerator<BaseCell> GetEnumerator()
    {
        for (var i = 0; i < _area.GetUpperBound(0); i++)
        for (var j = 0; j < _area.GetUpperBound(1); j++)
            yield return  _area[i, j];
    }

    IEnumerator IEnumerable.GetEnumerator() 
        => _area.GetEnumerator();
}