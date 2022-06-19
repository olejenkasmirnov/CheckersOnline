using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using CheckersDesktop.MVVM.Commands;
using CheckersDesktop.MVVM.Model;
using CheckersDesktop.MVVM.View;
using DryIoc;
using Microsoft.Win32;
using Models.Annotations;

namespace CheckersDesktop.MVVM.ViewModel;

public class ChatViewModel : INotifyPropertyChanged
{
    private ContactModel _selectedContact;
    private ContactModel _user;
    private string _message = string.Empty;
    private bool _isOpen;
    public bool IsOpen
    {
        get { return _isOpen; }
        set
        {
            if (_isOpen == value) return;
            _isOpen = value;
            OnPropertyChanged();
        }
    }
    public ObservableCollection<ContactModel> Contacts { get; set; } = new ObservableCollection<ContactModel>();
    
    public ICommand SendCommand { get; set; }
    public ICommand OpenFileCommand { get; set; }
    public ICommand ChoiceParamsCommand { get; set; }
    public ICommand ShowChatInfoCommand { get; set; }

    public ChatDataView ChatDataView { get; set; } = new ChatDataView();

    public ContactModel SelectedContact
    {
        get => _selectedContact;
        set
        {
            _selectedContact = value;
            OnPropertyChanged();
        }
    }

    public ContactModel User
    {
        get => _user;
        set
        {
            _user = value;
            OnPropertyChanged();
        }
    }

    public string Message
    {
        get => _message;
        set
        {
            _message = value;
            OnPropertyChanged();
        }
    }

    public ChatViewModel()
    {
        //CryptoClient = App.Container.Resolve<CryptoClient>();

        Contacts.Add(new ContactModel
        {
            Username = "Favorite"
        });
        SelectedContact = Contacts.First();
        SendCommand = new RelayCommand(o =>
        {
            if (Message == string.Empty || Message.Split().Length == 0) return;
            SelectedContact.Messages.Add( new MessageModel
            {
                Owner = User,
                Message = new Message
                {
                    MessageData = Encoding.UTF8.GetBytes(Message),
                    Type = Model.Message.MessageType.String
                },
            });
            Message = string.Empty;
        });

        OpenFileCommand = new RelayCommand(o =>
        { 
            var dlg = new OpenFileDialog();
            dlg.Filter = "Documents (*.*)|*.*";

            var msg = new Message();
            if (dlg.ShowDialog() == true)
                msg = new Message
                {
                    FileName = dlg.FileName.Split('\\').Last(),
                    Type = Model.Message.MessageType.File,
                    MessageData = File.ReadAllBytes(dlg.FileName)
                };
            
            SelectedContact.Messages.Add(
                new MessageModel
                {
                    Owner = User,
                    Message = msg,
                }
                );
        });
        ShowChatInfoCommand = new RelayCommand((_) =>
        {
            ChatDataView.ContactId = SelectedContact.Id;
            ChatDataView.ContactName = SelectedContact.Username;
            IsOpen = true;
        });
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}