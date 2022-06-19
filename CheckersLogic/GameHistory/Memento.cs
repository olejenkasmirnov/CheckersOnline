using System.Numerics;
using CheckersLogic.Interfaces;

// ReSharper disable MemberCanBePrivate.Global
namespace CheckersLogic.Base.GameHistory
{
	public class Memento
	{
		public Guid Guid;
		private CheckersLogic.GameHistory _gameHistory = null!;
		public IChecker Checker;

		public Vector2 Step;

		public int Round;
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="checker">Checker before step</param>
		/// <param name="step">Change of step</param>
		/// <param name="round">Current Round</param>
		private Memento(IChecker checker, Vector2 step, int round)
		{
			Guid = Guid.NewGuid();
			Checker = checker;
			Step = step;
			Round = round;
		}
		public static Memento CreateInstance(IChecker checker, Vector2 step, int round)
		{
			return new Memento(checker, step, round);
		}

		public override string ToString()
			=> $"{Checker.Color} : {Checker.Position} -> {Step}";
	}
}
