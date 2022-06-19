using System.Windows.Controls;
using CheckersDesktop.Core.Interfaces;

namespace CheckersDesktop;

public partial class BindablePasswordBox : UserControl, IPasswordSupplier
{
    public BindablePasswordBox()
    {
        InitializeComponent();
    }
    public string GetPassword()
    {
        return pwdBox.Password;
    }
}