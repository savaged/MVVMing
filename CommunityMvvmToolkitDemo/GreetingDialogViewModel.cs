using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using MvvmDialogs;

namespace CommunityMvvmToolkitDemo;

public partial class GreetingDialogViewModel() : ObservableObject, IModalDialogViewModel
{
    private bool? _dialogResult;
    private string _name = string.Empty;

    public string Name
    {
        get => _name;
        set => _name = value ?? string.Empty;
    }

    public bool? DialogResult
    {
        get => _dialogResult;
        set => SetProperty(ref _dialogResult, value);
    }

    [RelayCommand]
    public void Respond()
    {
        WeakReferenceMessenger.Default.Send(new GreetingResponseMessage($"Hello from {Name}"));
        DialogResult = true;
    }

}
