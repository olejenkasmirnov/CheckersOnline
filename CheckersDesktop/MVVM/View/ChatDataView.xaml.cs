using System.Text;
using System.Windows.Controls;

namespace CheckersDesktop.MVVM.View;

public partial class ChatDataView : UserControl
{

    public int ContactId { get; set; } = 0;
    public string ContactName { get; set; } = "Secret";
    public byte[] SymmetricKey { get; set; } = Encoding.UTF8.GetBytes("Empty");
    public byte[] PublicKey { get; set; } = Encoding.UTF8.GetBytes("Empty");
    public byte[] PrivateKey { get; set; } = Encoding.UTF8.GetBytes("Empty");

    public ChatDataView()
    {
        InitializeComponent();
    }
}