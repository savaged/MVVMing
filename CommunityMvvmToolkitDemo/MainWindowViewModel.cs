using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using MvvmDialogs;

namespace CommunityMvvmToolkitDemo;

/// <summary>
/// Partial for MainViewModel class to use source generators.
/// </summary>
public partial class MainWindowViewModel : ObservableObject, IRecipient<GreetingResponseMessage>
{
    private readonly IDialogService _dialogService;

    public MainWindowViewModel()
    {
        _dialogService = Ioc.Default.GetRequiredService<IDialogService>() ??
            throw new NullReferenceException(nameof(IDialogService));
        WeakReferenceMessenger.Default.Register(this);
    }

    public void Receive(GreetingResponseMessage m) => GreetingResponse = m.Value;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SayHelloCommand))]
    [NotifyCanExecuteChangedFor(nameof(LoadDataCommand))]
    private bool isLoading;

    [ObservableProperty]
    private string name = "World";

    [ObservableProperty]
    private string data = "No data yet.";

    [ObservableProperty]
    private string greetingResponse = string.Empty;

    [RelayCommand]
    private void SayHello()
    {
        var vm = new GreetingDialogViewModel { Name = Name };
        var _ = _dialogService.ShowDialog(this, vm);
    }

    [RelayCommand]
    private async Task LoadDataAsync()
    {
        IsLoading = true;
        await Task.Delay(2000);
        Data = "Data Loaded!";
        IsLoading = false;
    }

}
