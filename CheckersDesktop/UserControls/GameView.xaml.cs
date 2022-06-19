using System.Windows.Controls;

namespace CheckersDesktop.UserControls;

public partial class GameView : UserControl
{
    public object Content { get; set; }
    public GameView()
    {
        InitializeComponent();
    }
}