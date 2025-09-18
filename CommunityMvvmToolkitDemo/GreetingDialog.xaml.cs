using System.Windows;

namespace CommunityMvvmToolkitDemo;

public partial class GreetingDialog : Window
{
    public GreetingDialog() => InitializeComponent();

    private void OnClose(object sender, RoutedEventArgs e)
    {
        if (DataContext is GreetingDialogViewModel vm)
            vm.DialogResult = false;
        Close();
    }

}
