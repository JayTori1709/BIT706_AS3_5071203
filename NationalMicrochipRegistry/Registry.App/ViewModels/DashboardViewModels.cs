using ReactiveUI;
using System.Reactive;
using RegistryApp.ViewModels;

namespace RegistryApp.ViewModels
{
    public class DashboardViewModel : ViewModelBase
    {
        public ReactiveCommand<Unit, Unit> RegisterAnimalCommand { get; }
        public ReactiveCommand<Unit, Unit> AssignMicrochipCommand { get; }
        public ReactiveCommand<Unit, Unit> ManageUsersCommand { get; }

        public DashboardViewModel()
        {
            RegisterAnimalCommand = ReactiveCommand.Create(() =>
            {
                MainWindowViewModel.Instance.CurrentView = new RegisterAnimalViewModel();
            });

            AssignMicrochipCommand = ReactiveCommand.Create(() =>
            {
                MainWindowViewModel.Instance.CurrentView = new AssignMicrochipViewModel();
            });

            ManageUsersCommand = ReactiveCommand.Create(() =>
            {
                MainWindowViewModel.Instance.CurrentView = new ManageUsersViewModel();
            });
        }
    }
}
