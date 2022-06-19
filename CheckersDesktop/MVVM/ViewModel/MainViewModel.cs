using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using CheckersDesktop.UserControls;
using Models.Annotations;

namespace CheckersDesktop.MVVM.ViewModel;

public class MainViewModel : INotifyPropertyChanged
{
    /*
    public UserService.Messages.User User { get; set; } = new UserService.Messages.User()
    {
        Username = "User",
        Status = UserStatus.Player
    };*/
    
    public ICommand MainViewCommand { get; set; }
    public ICommand DiscoveryCommand { get; set; }
    public ICommand CreatePortfolioCommand { get; set; }
    public ICommand AddPortfolioCommand { get; set; }

    public object Content
    {
        get => _content;
        set
        {
            _content = value;
            OnPropertyChanged();
        }
    }

    private readonly DiscoveryView _discoveryViewControl = new DiscoveryView();
    private object _content;
    //private ExpertClient Client { get; set; }

    public MainViewModel()
    {
        /*
        Client = client;
        Content = _portfolioControl;
        MainViewCommand = new RelayCommand((_) => Content = _portfolioControl);
        DiscoveryCommand = new RelayCommand((_) => Content = _discoveryViewControl);
        CreatePortfolioCommand = new RelayCommand((_) => Content = _createPortfolioControl);
        AddPortfolioCommand = new RelayCommand((_) => Content = _addPortfolioControl);
        Portfolios = client.Portfolios;
        
        _createPortfolioControl = new CreatePortfolio(client);
        _portfolioControl.Portfolios = Portfolios;
        */
    }
    
    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}