using ReactiveUI;
using System.Collections.ObjectModel;
using System.Reactive;

namespace RegistryApp.ViewModels
{
    public class ManageUsersViewModel : ViewModelBase
    {
        public ObservableCollection<User> Users { get; } = new();

        public ReactiveCommand<User, Unit> DeleteCommand { get; }
        public ReactiveCommand<Unit, Unit> AddUserCommand { get; }

        public ManageUsersViewModel()
        {
            DeleteCommand = ReactiveCommand.Create<User>(user =>
            {
                Users.Remove(user);
            });

            AddUserCommand = ReactiveCommand.Create(() =>
            {
                Users.Add(new User { Username = "newuser", Role = "Clinic" });
            });
        }
    }

    public class User
    {
        public string Username { get; set; }
        public string Role { get; set; }
    }
}
