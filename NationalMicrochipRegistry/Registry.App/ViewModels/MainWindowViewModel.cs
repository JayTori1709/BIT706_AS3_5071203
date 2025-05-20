using ReactiveUI;


namespace RegistryApp.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
{
    public static MainWindowViewModel Instance { get; private set; }

    private ViewModelBase _currentView;
    public ViewModelBase CurrentView
    {
        get => _currentView;
        set => this.RaiseAndSetIfChanged(ref _currentView, value);
    }

    public MainWindowViewModel()
    {
        Instance = this;

        var loginVM = new LoginViewModel();
        loginVM.LoginSucceeded += () => CurrentView = new DashboardViewModel();
        CurrentView = loginVM;
    }
}
}
