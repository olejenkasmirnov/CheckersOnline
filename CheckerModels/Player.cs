using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Drawing;
using System.Runtime.Serialization;
using CheckersLogic.Interfaces;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable ConvertToAutoProperty
namespace Models.Checkers
{
	public partial class Player : ISerializable, IDeserializationCallback, IPlayer
	{
		public Guid Guid { get;  set; }
		public Color Color { get; set; }
		
		
		private string _name;

		public ObservableCollection<Checker> Checkers { get; set; } = new ObservableCollection<Checker>();

		public Player()
		{
			Checkers.CollectionChanged += CheckersOnCollectionChanged;
		}
		public string Name
		{
			get => _name;
			set => _name = value;
		}
		
		private void CheckersOnCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
		{
			switch (e.Action)
			{

				case NotifyCollectionChangedAction.Add:
					break;
				case NotifyCollectionChangedAction.Remove:
					break;
				case NotifyCollectionChangedAction.Replace:
					break;
				case NotifyCollectionChangedAction.Move:
					break;
				case NotifyCollectionChangedAction.Reset:
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}

	}
}
