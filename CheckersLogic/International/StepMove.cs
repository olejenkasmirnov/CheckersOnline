using System.Numerics;
using CheckersLogic.Base;
using CheckersLogic;
using CheckersLogic.Interfaces;

namespace CheckersLogic.International;

public class StepMove : BaseStepCommand
{
    public override IEnumerable<Vector2> CanMove(IPlayer player, IChecker checker)
    {
        if (checker.Owner != player) yield break;

        

    }

    public override Vector2 Move(IChecker checker, Vector2 step)
    {
        var collectionOfMoves = CanMove(null, checker).ToArray();

        if (collectionOfMoves.Length == 0 && collectionOfMoves.Contains(step))
        {
            checker.Position += step;
            History.Remember(checker, step);
        }

        return checker.Position;
    }


    public StepMove(GameHistory history, BaseBoard board) : base(history, board)
    {
    }
}