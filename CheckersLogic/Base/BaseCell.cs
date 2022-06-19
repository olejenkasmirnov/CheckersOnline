using System.ComponentModel;
using System.Drawing;
using System.Numerics;
using System.Runtime.CompilerServices;
using CheckersLogic.Interfaces;

namespace CheckersLogic.Base;

public class BaseCell : ICell
{
    private Color color;
    private IChecker checker = null!;
    private Vector2 position;
    private BaseBoard Board { get; init; } 

    public BaseCell(BaseBoard board,Vector2 pos, Color color)
    {
        Board = board;
        Color = color;
        Position = pos;
        GetCellsArround = new Lazy<IEnumerable<BaseCell>>(GetAllCellsAround(1));
    }

    public Lazy<IEnumerable<BaseCell>> GetCellsArround { get; init; }
    public Vector2 Position
    {
        get => position;
        set
        {
            position = value;
            OnPropertyChanged();
        }
    }
    public IChecker Checker
    {
        get => checker;
        set
        {
            checker = value;
            OnPropertyChanged();
        }
    }
    public Color Color
    {
        get => color;
        set => color = value;
    }


    public IEnumerable<BaseCell> GetAllCellsAround(int radius = 1)
    {
        for (int i = -radius; i < radius; i++)
        {
            for (int j = -radius; i < radius; j++)
            {
                yield return Board[position + new Vector2(i,j)];
            }   
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    
    private void OnPropertyChanged([CallerMemberName] string propertyName = null!)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}