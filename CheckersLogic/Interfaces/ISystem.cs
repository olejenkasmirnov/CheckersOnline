using CheckersLogic.Base;
using CheckersLogic.Base.GameHistory;

namespace CheckersLogic.Interfaces;

public interface ISystem
{ 
    IGameStartCommand GameStartCommand { get; set; }
    
    IPlayer CurrentStepper { get; set; }
    
    List<IPlayer> Players { get; set; }

    IStepCommand StepCommonCheckersLogic { get; set; }
    
    IStepCommand StepQueenCheckersLogic { get; set; }
    
    GameHistory History { get; set; }

    bool IsGameOver();

    /// <summary>
    /// Method that starts a match
    /// </summary>
    void StartGame();


    /// <summary>
    /// For visitors or rewatching match
    /// </summary>
    void NextStep();

}