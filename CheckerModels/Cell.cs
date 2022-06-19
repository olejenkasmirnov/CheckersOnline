using System.ComponentModel;
using System.Drawing;
using System.Numerics;
using System.Runtime.CompilerServices;
using CheckersLogic.Base;
using CheckersLogic.Interfaces;
using Models.Annotations;
namespace Models.Checkers
{
	public sealed class Cell : BaseCell
	{
		public Cell(BaseBoard board, Vector2 pos, Color color) : base(board, pos, color)
		{
		}
	}
}
