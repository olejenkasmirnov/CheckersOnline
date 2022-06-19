using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using CheckersLogic.Base;
using CheckersLogic.Interfaces;

namespace Models.Checkers
{
	public class Board : BaseBoard
	{
		public Board(int dimension) : base(dimension)
		{
		}

		public Board(int x, int y) : base(x, y)
		{
		}
	}
}
