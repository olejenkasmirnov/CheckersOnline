using System.ComponentModel;

namespace CheckersLogic.Interfaces;

public interface ICell : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
}