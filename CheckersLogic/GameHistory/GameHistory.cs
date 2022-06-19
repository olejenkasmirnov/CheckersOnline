using System.ComponentModel;
using System.Numerics;
using System.Runtime.CompilerServices;
using CheckersLogic.Base.GameHistory;
using CheckersLogic.Interfaces;

namespace CheckersLogic;

public partial class GameHistory : INotifyPropertyChanged
{
	private Guid _id;
		 
	public Guid Id
	{
		get => _id;
		init => _id = value;
	}
	public Memento State
	{
		get => _state;
		set
		{
			_state = value;
			OnPropertyChanged();
		}
	}

	private Memento _state;

	public List<Memento> States;

	public void SetMemento(Memento memento) => State = memento;
		
	public Memento Remember(IChecker checker, Vector2 step, int round = -1)
	{
		if (round == -1)
			round = States.Last()?.Round ?? 0;
		var memento = Memento.CreateInstance(checker, step, round);
		States.Add(memento);
		return memento;
	}

	public event PropertyChangedEventHandler? PropertyChanged;
		
	protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null!)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}