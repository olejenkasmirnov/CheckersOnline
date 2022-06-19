using System.ComponentModel;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using CheckersLogic.Interfaces;
using Models.Annotations;
using Models.Checkers;
using Color = System.Drawing.Color;

namespace CheckersControls
{
	public partial class Cell : UserControl, INotifyPropertyChanged
	{
		private Models.Checkers.Cell _model;
		public Models.Checkers.Cell Model
		{
			get => _model;
			set => _model = value;
		}
		
		public Cell(Board board, int x, int y, Color color)
		{
			Model = new Models.Checkers.Cell(board,new Vector2(x, y), color);
			Model.PropertyChanged += (obj,e) => OnPropertyChanged(nameof(Model));
			InitializeComponent();
		}

		protected override void OnDrop(DragEventArgs e)
		{
			if (Model.Checker != null)
			{
				e.Handled = true;
				return;
			}
			Model.Checker = (IChecker) e.Data.GetData("object") ?? null;
		}

		protected override void OnDragOver(DragEventArgs e)
		{
			base.OnDragOver(e);
			e.Effects = DragDropEffects.None;

			e.Handled = true;
		}

		public event PropertyChangedEventHandler? PropertyChanged;

		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}

