using ReactiveUI;
using System.Reactive;

namespace RegistryApp.ViewModels
{
    public class DashboardViewModel : ViewModelBase
    {
        public bool IsAdmin { get; set; } = true;

        public ReactiveCommand<Unit, Unit> NavigateRegisterAnimal { get; }
        public ReactiveCommand<Unit, Unit> NavigateAssignMicrochip { get; }
        public ReactiveCommand<Unit, Unit> NavigateManageUsers { get; }

        public DashboardViewModel()
        {
            NavigateRegisterAnimal = ReactiveCommand.Create(() => { /* Navigate logic */ });
            NavigateAssignMicrochip = ReactiveCommand.Create(() => { /* Navigate logic */ });
            NavigateManageUsers = ReactiveCommand.Create(() => { /* Navigate logic */ });
        }
    }
}
