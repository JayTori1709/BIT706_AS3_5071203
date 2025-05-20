using ReactiveUI;

namespace RegistryApp.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private static MainWindowViewModel _instance;
        public static MainWindowViewModel Instance => _instance ??= new MainWindowViewModel();

        private ViewModelBase _currentView;
        public ViewModelBase CurrentView
        {
            get => _currentView;
            set => this.RaiseAndSetIfChanged(ref _currentView, value);
        }

        private MainWindowViewModel()
        {
            var loginVM = new LoginViewModel();
            loginVM.LoginSucceeded += () =>
            {
                CurrentView = new DashboardViewModel();
            };

            CurrentView = loginVM;
        }
    }
}
