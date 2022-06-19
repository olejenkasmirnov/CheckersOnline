using System.Numerics;
using System.Windows.Input;
using CheckersLogic.Interfaces;

namespace CheckersLogic.Base;

public abstract class BaseStepCommand : IStepCommand
{
    protected readonly BaseBoard Board;
    protected readonly CheckersLogic.GameHistory History;

    protected BaseStepCommand(CheckersLogic.GameHistory history, BaseBoard board)
    {
        History = history;
        Board = board;
    }
    public bool CanExecute(object? parameter)
    {
        if (!(parameter is IChecker checker))
            throw new ArgumentException(nameof(parameter));

        return CanMove(null, checker).Count() != 0;
    }

    public abstract IEnumerable<Vector2> CanMove(IPlayer player, IChecker checker);

    public void Execute(object? parameter)
    {
        if (!(parameter is IChecker checker))
            throw new ArgumentException(nameof(parameter));

        if (!CanExecute(parameter)) return;
        
        Move(checker, CanMove(null, checker).First()); 
    }

    event EventHandler? CanExecuteChanged
    {
        add => throw new NotImplementedException();
        remove => throw new NotImplementedException();
    }

    public abstract Vector2 Move(IChecker checker, Vector2 step);

    event EventHandler? ICommand.CanExecuteChanged
    {
        add => throw new NotImplementedException();
        remove => throw new NotImplementedException();
    }
}