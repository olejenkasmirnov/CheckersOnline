using CheckersLogic.Interfaces;

namespace CheckersLogic.Base;

public class BaseSystem : ISystem
{
    #region Properties and Fields

    public IGameStartCommand GameStartCommand { get; set; }
    public IPlayer CurrentStepper { get; set; }
    
    public List<IPlayer> Players { get; set; }
    
    public IStepCommand StepCommonCheckersLogic { get; set; }
    
    public IStepCommand StepQueenCheckersLogic { get; set; }
    
    public CheckersLogic.GameHistory History { get; set; }

    #endregion

    #region Constructors

    public BaseSystem(
        IGameStartCommand gameStartCommand, 
        IPlayer currentStepper,
        List<IPlayer> players,
        IStepCommand stepCommonCheckersLogic, 
        IStepCommand stepQueenCheckersLogic, 
        CheckersLogic.GameHistory history = null!)
    {
        GameStartCommand = gameStartCommand;
        CurrentStepper = currentStepper;
        Players = players;
        StepCommonCheckersLogic = stepCommonCheckersLogic;
        StepQueenCheckersLogic = stepQueenCheckersLogic;
        History = history ?? new CheckersLogic.GameHistory();
    }

    #endregion

    #region Methods

    public bool IsGameOver()
    {
        throw new NotImplementedException();
    }

    public virtual void StartGame() => GameStartCommand.Execute(null);

    public void NextStep()
    {
        throw new NotImplementedException();
    }

    #endregion
}