using System;
using System.Drawing;
using System.Numerics;
using System.Runtime.Serialization;
using CheckersLogic.Enums;
using CheckersLogic.Interfaces;

namespace Models.Checkers
{
	public sealed partial class Checker :  ICloneable, IChecker
	{
		public CheckerType Type { get; set; }

		public IPlayer Owner { get; set; }

		public Vector2 Position { get; set; }

		public Color Color
		{
			get => Owner.Color;
		}

		public static Checker CreateInstance(Player player, Vector2 pos, CheckerType checkerType = CheckerType.Common)
		{
			return new Checker()
			{
				Owner = player,
				Position = pos,
				Type = checkerType
			};
		}

		internal Checker(){}

		public object Clone()
		{
			return new Checker()
			{
				Owner = this.Owner,
				Type = this.Type,
				Position = this.Position
			};
		}
	}
}
