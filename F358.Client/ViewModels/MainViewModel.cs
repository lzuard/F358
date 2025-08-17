using CommunityToolkit.Mvvm.ComponentModel;

namespace F358.Client.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    //[ObservableProperty]
    private string Greeting => "Welcome to Avalonia!";
}
