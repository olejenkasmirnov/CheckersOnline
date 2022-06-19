using System.Numerics;
using System.Windows.Input;

namespace CheckersLogic.Interfaces;

/// <summary>
/// 
/// </summary>
public interface IStepCommand : ICommand
{
    /// <summary>
    /// Gets a list of possible moves 
    /// </summary>
    /// <param name="player">Player who wants to move</param>
    /// <param name="checker">Checker for check</param>
    /// <returns>list of possible moves</returns>
    IEnumerable<Vector2> CanMove(IPlayer player, IChecker checker);

    /// <summary>
    /// Moving a checker with a step
    /// </summary>
    /// <param name="checker">checker for move</param>
    /// <param name="step">Diff from current pos</param>
    /// <returns>Current pos of <see cref="checker"/> after move</returns>
    public Vector2 Move(IChecker checker, Vector2 step);
}